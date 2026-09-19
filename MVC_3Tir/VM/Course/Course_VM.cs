using System.ComponentModel.DataAnnotations;

namespace MVC_3Tir.ViewModels;

public class Course_VM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Course name is required")]
    [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Course name must be between 3 and 50 characters")]
    public string Name { get; set; }

    [Range(1, int.MaxValue,
        ErrorMessage = "Please select a department")]
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }
    
    
}