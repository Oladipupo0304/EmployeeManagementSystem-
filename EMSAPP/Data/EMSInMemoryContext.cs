using EMSAPP.Models;

namespace EMSAPP.Data
{
    public class EMSInMemoryContext
    {
        public List<Employee> employees = new List<Employee>();
        public List<Department> departments = new List<Department>();

        public EMSInMemoryContext()
        {
            // Departments
            departments.Add(new Department { Id = 3, Dep_Name = "Sales" });
            departments.Add(new Department { Id = 4, Dep_Name = "IT" });

            // Employees
            employees.Add(new Employee { Id = 1, EmployeeName = "Admin One", Email = "adminone@email.com", DOB = DateTime.Now, Phone = "09123456789", DepartmentId = 2, Departments = departments[1] });

        }
    }
}
