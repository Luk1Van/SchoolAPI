using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DepartmentName { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
