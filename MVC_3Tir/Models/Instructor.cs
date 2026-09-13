namespace MVC_3Tir.Models;

public class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Image { get; set; }

    public decimal Salary { get; set; }

    public string? Address { get; set; }

    public int DepartmentId { get; set; }

    public Department Department { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}