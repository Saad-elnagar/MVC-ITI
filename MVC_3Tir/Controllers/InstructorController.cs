using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_3Tir.DataBase;
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
}