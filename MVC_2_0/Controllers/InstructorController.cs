using Microsoft.AspNetCore.Mvc;
using MVC_2_0.Data;
using MVC_2_0.Models;
using MVC_2_0.ViewModel;
using System.Linq;

namespace MVC_2_0.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext context = new AppDbContext(); // Manual context

        // GET: /Instructor
        public IActionResult Index()
        {
            var instructors = context.Instructors
                .Select(i => new Instructor
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary,
                    ImageUrl = i.ImageUrl,
                    Department = i.Department,
                    Course = i.Course
                }).ToList();

            return View("Index", instructors);
        }

        // GET: /Instructor/Details/5
        public IActionResult Details(int id)
        {
            var instructor = context.Instructors
                .FirstOrDefault(i => i.Id == id);

            return instructor == null
                ? NotFound()
                : View("Details", instructor);
        }

        // GET: /Instructor/Add
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new InstructorWithCrsDeptListViewModel
            {
                deptList = context.Departments.ToList(),
                crsList = context.Courses.ToList()
            };

            return View("Add", vm);
        }

        // POST: /Instructor/SaveAdd
        [HttpPost]
        public IActionResult SaveAdd(Instructor instructor)
        {
            if (instructor.Name != null)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Add", instructor);
        }
    }
}
