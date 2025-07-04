using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC_2_0.Models;

namespace MVC_2_0.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            SeedData(modelBuilder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Software", Manager = "Mr. Farag" },
                new Department { Id = 2, Name = "Networks", Manager = "Ms. Salma" },
                new Department { Id = 3, Name = "AI", Manager = "Dr. Hanaa" },
                new Department { Id = 4, Name = "Security", Manager = "Eng. Karim" },
                new Department { Id = 5, Name = "Bioinformatics", Manager = "Dr. Mona" },
                new Department { Id = 6, Name = "Embedded", Manager = "Eng. Omar" },
                new Department { Id = 7, Name = "Data Science", Manager = "Dr. Amina" },
                new Department { Id = 8, Name = "Cloud", Manager = "Ms. Layla" },
                new Department { Id = 9, Name = "Robotics", Manager = "Mr. Hatem" },
                new Department { Id = 10, Name = "Design", Manager = "Ms. Nour" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C#", Hours = 30, Degree = 100, MinDegree = 50, DeptId = 1 },
                new Course { Id = 2, Name = "SQL", Hours = 25, Degree = 100, MinDegree = 60, DeptId = 2 },
                new Course { Id = 3, Name = "AI Basics", Hours = 40, Degree = 100, MinDegree = 55, DeptId = 3 },
                new Course { Id = 4, Name = "Ethical Hacking", Hours = 35, Degree = 100, MinDegree = 65, DeptId = 4 },
                new Course { Id = 5, Name = "Genomics", Hours = 45, Degree = 100, MinDegree = 60, DeptId = 5 },
                new Course { Id = 6, Name = "Microcontrollers", Hours = 20, Degree = 100, MinDegree = 50, DeptId = 6 },
                new Course { Id = 7, Name = "ML with Python", Hours = 50, Degree = 100, MinDegree = 70, DeptId = 7 },
                new Course { Id = 8, Name = "AWS", Hours = 30, Degree = 100, MinDegree = 60, DeptId = 8 },
                new Course { Id = 9, Name = "Arduino", Hours = 28, Degree = 100, MinDegree = 60, DeptId = 9 },
                new Course { Id = 10, Name = "UX Design", Hours = 32, Degree = 100, MinDegree = 50, DeptId = 10 }
            );

            modelBuilder.Entity<Trainee>().HasData(
                Enumerable.Range(1, 10).Select(i => new Trainee
                {
                    Id = i,
                    Name = $"Trainee {i}",
                    Address = $"City {i}",
                    Grade = i % 2 == 0 ? "A" : "B",
                    DeptId = i,
                    ImageUrl = $"trainee{i}.png"
                }).ToArray()
            );

            modelBuilder.Entity<Instructor>().HasData(
                Enumerable.Range(1, 10).Select(i => new Instructor
                {
                    Id = i,
                    Name = $"Instructor {i}",
                    Address = $"Town {i}",
                    Salary = 5000 + i * 100,
                    DeptId = i,
                    CrsId = i,
                    ImageUrl = $"instructor{i}.png"
                }).ToArray()
            );

            modelBuilder.Entity<CrsResult>().HasData(
                Enumerable.Range(1, 10).Select(i => new CrsResult
                {
                    CrsId = i,
                    TraineeId = i,
                    Degree = 60 + i
                }).ToArray()
            );
        }

    }
}
