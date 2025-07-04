using MVC_2_0.Models;

namespace MVC_2_0.ViewModel
{
    public class InstructorWithCrsDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
        public int CrsId { get; set; }
        public List<Course> crsList { get; set; }
        public List<Department> deptList { get; set; }

    }
}
