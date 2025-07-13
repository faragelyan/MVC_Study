using MVC_2_0.Models;

namespace MVC_2_0.ViewModel
{
    public class CourseInstructoridsViewModel
    {
        public Course Course { get; set; } = new Course();

        public List<int> SelectedInstructorIds { get; set; } = new List<int>();

        public List<Instructor> AllInstructors { get; set; } = new List<Instructor>();

        public List<Department> AllDepartments { get; set; } = new List<Department>();
    }


}
