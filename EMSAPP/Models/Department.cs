using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSAPP.Models
{
    public class Department
    {
        [DisplayName("Department ID")]
        public int Id { get; set; }

        [DisplayName("Department Name")]
        [Required (ErrorMessage = "Department Name is Required")]
        public string Dep_Name { get; set; }

        [ValidateNever]
        //[Keyless]
        [NotMapped]
        public ICollection<Employee>? Employees { get; set; }

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Dep_Name = name;

        }
    }
}
