namespace MVC_2_0.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
        public int CrsId { get; set; }
        public Department Department { get; set; }
        public Course Course { get; set; }
    }
}
