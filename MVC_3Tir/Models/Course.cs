namespace MVC_3Tir.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<CourseResult> CourseResults { get; set; }
}