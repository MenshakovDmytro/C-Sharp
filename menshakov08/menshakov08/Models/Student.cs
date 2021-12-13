using System;
using System.ComponentModel.DataAnnotations;

namespace menshakov08.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 3 , ErrorMessage = "You've entered wrong first name")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "You've entered wrong last name")]
        public string LastName { get; set; }

        [StringLength(4, ErrorMessage = "You've entered wrong group")]
        public string Group { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "You've entered wrong faculty")]
        public string Faculty { get; set; }

        [StringLength(40, MinimumLength = 10, ErrorMessage = "You've entered wrong group")]
        public string Specialty { get; set; }

        [Range(10, 100)]
        public int AcademicPerformance { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfAdmission { get; set; }
    }
}