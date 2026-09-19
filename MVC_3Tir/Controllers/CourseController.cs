using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_3Tir.DataBase;
using MVC_3Tir.Models;
using MVC_3Tir.ViewModels;

namespace MVC_3Tir.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context )
    {
        _context = context;

    }

    public async Task<IActionResult> Index()
    {
        var courses = _context.Courses.Select(c => new Course_VM
        {
            Id =  c.Id,
            DepartmentId =  c.DepartmentId,
            DepartmentName = c.Department.Name,
            Name = c.Name,

        });
        return View(courses);


    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Departments = _context.Departments.ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Course_VM course)
    {
        foreach (var item in ModelState)
        {
            foreach (var error in item.Value.Errors)
            {
                Console.WriteLine($"{item.Key}: {error.ErrorMessage}");
            }
        }


        var newCourse = new Course
        {
            Name = course.Name,
            DepartmentId = course.DepartmentId
        };

        _context.Courses.Add(newCourse);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
 
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = _context.Courses
            .Where(c => c.Id == id)
            .Select(c => new Course_VM
            {
                Id = c.Id,
                Name = c.Name,
                DepartmentId = c.DepartmentId,
                DepartmentName = c.Department.Name
            })
            .FirstOrDefault();

        if (course == null)
            return NotFound();

        ViewBag.Departments = _context.Departments.ToList();

        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Course_VM vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View(vm);
        }

        var course = _context.Courses.Find(vm.Id);

        if (course == null)
            return NotFound();

        course.Name = vm.Name;
        course.DepartmentId = vm.DepartmentId;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


}