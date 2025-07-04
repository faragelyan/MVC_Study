using Microsoft.EntityFrameworkCore;
using MVC_2_0.Data;

namespace MVC_2_0.Models
{
    public class InstructorBL
    {
        private readonly AppDbContext _context = new AppDbContext();

        
        public List<Instructor> GetAll()
        {
            return _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToList();
        }
        public Instructor GetById(int id) 
        {
            return _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(i => i.Id == id);
        }
    }
}
