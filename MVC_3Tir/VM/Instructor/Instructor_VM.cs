namespace MVC_3Tir.ViewModels
{
    public class InstructorVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public decimal Salary { get; set; }

        public string? Address { get; set; }

        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}