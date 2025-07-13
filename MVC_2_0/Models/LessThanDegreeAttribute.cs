using System.ComponentModel.DataAnnotations;

namespace MVC_2_0.Models
{
    public class LessThanDegreeAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            int minDegree = Convert.ToInt32(value.ToString());
            var course = validationContext.ObjectInstance as Course;

            if (value == null || course == null)
                return null;
            if (minDegree >= course.Degree)
                return new ValidationResult("Minimum degree must be less than full degree.");
            return ValidationResult.Success;
        }
    }
}
