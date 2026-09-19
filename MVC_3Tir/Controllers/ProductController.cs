using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_3Tir.DataBase;
using MVC_3Tir.Models;
using MVC_3Tir.Pagination;
using MVC_3Tir.VM.Product;

namespace MVC_3Tir.Controllers;

public class ProductController : Controller
{
    private readonly ECDbContext _context;

    public ProductController(ECDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
    {
        var items = await _context.products.CountAsync();

        var products = await _context.products
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var model = new PaginationVM<Product>
        {
            CurrentPage = page,
            PageSize = pageSize,
            TotalItems = items,
            Data = products
        };

        return View(model);
    }

    public async Task<IActionResult> Details(int? id)
    {
        var product = _context.products.Find(id);
        if (product == null) return NotFound();
        var model = new ProductVM()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Image = product.Image,
        };

        return View(model);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductVM model)
    {
        if (!ModelState.IsValid)
        {
           
            return View(model);
        }

        var iteam = new Product()
        {
            Name = model.Name,
            Price = model.Price,
            Description = model.Description,
            Image = model.Image,
        };

        _context.products.Add(iteam);

        await _context.SaveChangesAsync();

        return RedirectToAction("Details", new { id = iteam.Id });
    }


    public async Task<IActionResult> Delete(int? id)
    {
        
        var iteam = _context.products.Find(id);
        _context.products.Remove(iteam);
        _context.SaveChanges();

      return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {

        var iteam = _context.products.Find(id);
        var model = new ProductVM()
        {
            Name = iteam.Name,
            Description = iteam.Description,
            Price = iteam.Price,
            Image = iteam.Image,
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductVM model)
    {
        var iteam = _context.products.Find(model.Id);
        iteam.Name = model.Name;
        iteam.Description = model.Description;
        iteam.Price = model.Price;
        iteam.Image = model.Image;
        _context.SaveChanges();

        return RedirectToAction("Details", new { id = iteam.Id });
    }
}