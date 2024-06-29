using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSAPP.Models
{
    public class Employee
    {
        [DisplayName("Employee ID")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Employee Name is Required")]
        public string EmployeeName { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email  { get; set; }

       // [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        
        public int DepartmentId { get; set; }

        //[DisplayName("Department Name")]
        //public int DepartmentName { get; set; }

        [ValidateNever]
        [NotMapped]
        public Department Departments { get; set; }
        

        public Employee()
        {   
        }
        public Employee(int id,string name, DateTime dob, string email, string phone, Department department )
        {
            Id = id;   
            EmployeeName = name;
            DOB = dob;
            Email = email;
            Phone = phone;
            Departments = department;
        }
    }
}
