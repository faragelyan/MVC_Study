using System.Security.Cryptography.X509Certificates;

namespace MVC_2_0.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        public int CrsId { get; set; }
        public int TraineeId { get; set; }
        public Course Course { get; set; } 
        public Trainee Trainee { get; set; } 

    }
}
