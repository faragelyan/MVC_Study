using System.ComponentModel.DataAnnotations;
namespace MVC_2_0.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int Hours { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [Unique]
        public string Name { get; set; }
        [Required]
        [Range(50,100)]
        public int Degree { get; set; }
        [Required]
        [LessThanDegree]
        public int MinDegree { get; set; }
        public int DeptId { get; set; }
        public Department Department { get; set; } 
        public List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();

    }
}
