using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_2_0.Data;
using MVC_2_0.Models;
using MVC_2_0.ViewModel;
using System.Linq;

namespace MVC_2_0.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();

        // GET: /Instructor
        public IActionResult Index(string search)
        {
            var query = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(i => i.Name.Contains(search));
            }

            var instructors = query.ToList();
            ViewBag.Search = search;

            return View("Index", instructors);
        }

        // 🔁 Used for AJAX search (returns just <tbody>)
        public IActionResult SearchPartial(string search)
        {
            var query = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(i => i.Name.Contains(search));
            }
            var instructors = query.ToList();
            return PartialView("_InstructorTablePartial", instructors);
        }


        // GET: /Instructor/Details/5
        public IActionResult Details(int id)
        {
            var instructor = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
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
            if (!string.IsNullOrWhiteSpace(instructor.Name))
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Re-fetch dropdowns if validation fails
            var vm = new InstructorWithCrsDeptListViewModel
            {
                Name = instructor.Name,
                Address = instructor.Address,
                Salary = instructor.Salary,
                DeptId = instructor.DeptId,
                CrsId = instructor.CrsId,
                ImageUrl = instructor.ImageUrl,
                deptList = context.Departments.ToList(),
                crsList = context.Courses.ToList()
            };

            return View("Add", vm);
        }
    }
}
