using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_3Tir.DataBase;
using MVC_3Tir.Models;
using MVC_3Tir.ViewModels;


namespace MVC_3Tir.Controllers;

public class InstructorController : Controller
{
    private readonly AppDbContext _context;

    public InstructorController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var instructors = await _context.Instructors
            .Select(i => new InstructorVM
            {
                Id = i.Id,
                Name = i.Name,
                Image = i.Image,
                Salary = i.Salary,
                Address = i.Address,
                DepartmentId = i.DepartmentId,
                DepartmentName = i.Department.Name
            })
            .ToListAsync();

        return View(instructors);
    }

    public async Task<IActionResult> Details(int id)
    {
        var instructor = await _context.Instructors
            .Include(i => i.Department)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (instructor == null)
            return NotFound();

        var model = new InstructorVM
        {
            Id = instructor.Id,
            Name = instructor.Name,
            Image = instructor.Image,
            Salary = instructor.Salary,
            Address = instructor.Address,
            DepartmentId = instructor.DepartmentId,
            DepartmentName = instructor.Department?.Name
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Departments = _context.Departments.ToList();
        return View("Create");
    }

    [HttpPost]
    public IActionResult Create(InstructorVM vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View(vm);
        }

        var instructorVm = new Instructor
        {
            Name = vm.Name??"test", 
            Image = vm.Image,
            Salary = vm.Salary,
            Address = vm.Address,
            DepartmentId = vm.DepartmentId,
           
        };
        _context.Instructors.Add(instructorVm);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var instructor = _context.Instructors
            .Where(i => i.Id == id)
            .Select(i => new InstructorVM
            {
                Id = i.Id,
                Name = i.Name,
                Image = i.Image,
                Salary = i.Salary,
                Address = i.Address,
                DepartmentId = i.DepartmentId,
                DepartmentName = i.Department.Name
            })
            .FirstOrDefault();

        if (instructor == null)
            return NotFound();

        ViewBag.Departments = _context.Departments.ToList();

        return View(instructor);
    }
    [HttpPost]
    public IActionResult Edit(InstructorVM vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View(vm);
        }

        var instructor = _context.Instructors
            .FirstOrDefault(i => i.Id == vm.Id);

        if (instructor == null)
            return NotFound();

        instructor.Name = vm.Name;
        instructor.Image = vm.Image;
        instructor.Salary = vm.Salary;
        instructor.Address = vm.Address;
        instructor.DepartmentId = vm.DepartmentId;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}