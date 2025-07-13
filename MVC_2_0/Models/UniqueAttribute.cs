using MVC_2_0.Data;
using System.ComponentModel.DataAnnotations;

namespace MVC_2_0.Models
{
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            String newName=value.ToString();
            AppDbContext context = new AppDbContext();
            Course crs = context.Courses.FirstOrDefault(c => c.Name == newName);
            if (crs != null)
                return new ValidationResult("Name Must Be Unique.");
            return ValidationResult.Success;
        }
    }
}
