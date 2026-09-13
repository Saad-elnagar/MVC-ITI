namespace MVC_3Tir.Models;

public class CourseResult
{
    public int Id { get; set; }
    public int Degree { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int TraineeId { get; set; }
    public Trainee Trainee { get; set; }
}