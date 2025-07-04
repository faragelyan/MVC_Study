namespace MVC_2_0.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Grade { get; set; }
        public int DeptId { get; set; }
        public Department Department { get; set; } 
        public List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();

    }
}
