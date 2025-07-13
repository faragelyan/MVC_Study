using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_2_0.Data;
using MVC_2_0.Models;
using MVC_2_0.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MVC_2_0.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext context = new AppDbContext(); // Manual context

        // GET: Course/Index
        public IActionResult Index(string search)
        {
            var query = context.Courses
                .Include(c => c.Department)
                .Include(c => c.CrsResult)
                .Include(c => c.Instructors)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            var courses = query
                .Select(c => new Course
                {
                    Id = c.Id,
                    Name = c.Name,
                    Hours = c.Hours,
                    Degree = c.Degree,
                    MinDegree = c.MinDegree,
                    DeptId = c.DeptId,
                    Department = c.Department,
                    CrsResult = c.CrsResult.ToList(),
                    Instructors = c.Instructors.ToList()
                })
                .ToList();

            ViewBag.Search = search;
            return View("Index", courses);
        }

        // GET: Course/SearchPartial?search=...
        [HttpGet]
        public IActionResult SearchPartial(string search)
        {
            var query = context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .Include(c => c.CrsResult)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(c => c.Name.Contains(search));

            var results = query.ToList();
            return PartialView("_CourseTablePartial", results);
        }

        // GET: Course/Add
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new CourseInstructoridsViewModel
            {
                AllInstructors = context.Instructors.ToList(),
                AllDepartments = context.Departments.ToList()
            };

            return View("Add", vm);
        }

        // POST: Course/SaveAdd
        [HttpPost]
        public IActionResult SaveAdd(CourseInstructoridsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var selectedIds = vm.SelectedInstructorIds ?? new List<int>();

                vm.Course.Instructors = context.Instructors
                    .Where(i => selectedIds.Contains(i.Id))
                    .ToList();

                context.Courses.Add(vm.Course);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            vm.AllInstructors = context.Instructors.ToList();
            vm.AllDepartments = context.Departments.ToList();
            return View("Add", vm);
        }
    }
}
