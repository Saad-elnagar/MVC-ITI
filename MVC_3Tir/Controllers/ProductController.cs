using Microsoft.AspNetCore.Mvc;
using MVC_3Tir.Models;

namespace MVC_3Tir.Controllers;

  
public class ProductController : Controller
{
    ProductBL productBL = new ProductBL();
    public IActionResult Index()
    {
        return  View( "All Products",productBL.GetAll());
    }
    
    
    public IActionResult Details (int id)
    {
        var product = productBL.GetById(id);
        if (product == null)
        {
            return Content($"Product with ID {id} not found.");
        }
        return View(product);
    }
    
}