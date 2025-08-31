using System;
using System.ComponentModel.DataAnnotations;

namespace UoStudents.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public double AverageGrade { get; set; }

        public bool IsActive { get; set; }
    }
}
