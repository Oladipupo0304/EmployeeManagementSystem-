using EMSAPP.Models;

namespace EMSAPP.Repository
{
    public interface IEMSRepository
    {
        List<Employee> GetAllEmployees();

        // get any specific employee
        Employee GetEmployeeById(int Id);

        // add todo into the employee
        Employee AddEmployee(Employee newEmployee);

        // update todo in the employee
        Employee UpdateEmployee(int EmployeeId, Employee newEmployee);

        // delete 
        Employee DeleteEmployee(int EmployeeId);


        //Department
        List<Department> GetAllDepartments();

        // get any specific Department
        Department GetDepByID(int Id);

        // add todo into the Department
        Department AddDepartment(Department newDep);

        // update todo in the Department
        Department UpdateDepartment(int Id, Department newDep);

        // delete 
        Department DeleteDepartment(int Id);
    }
}
