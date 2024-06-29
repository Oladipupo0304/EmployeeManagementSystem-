using Microsoft.EntityFrameworkCore;
using EMSAPP.Data;
using EMSAPP.Models;

namespace EMSAPP.Repository.MsSQL
{
    public class EMSDBRepository : IEMSRepository
    {
        EMSDbContext _dbContext;
        //public EmployeesController(IEMSRepository repo, EMSDbContext context)
        //{
        //    this._repo = repo;
        //    _context = context;
        //}
        public EMSDBRepository(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.Include(d => d.Departments).AsNoTracking().ToList();
        }
        public Employee GetEmployeeById(int Id)
        {
            return _dbContext.Employees.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges(); //CUD Operations you need to save the details -> commit
            return newEmployee;
        }
        public Employee UpdateEmployee(int employeeId, Employee newEmployee)
        {
            _dbContext.Employees.Update(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public Employee DeleteEmployee(int EmployeeId)
        {
            var emp = GetEmployeeById(EmployeeId);
            if (emp != null)
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
            }
            return emp;

        }



        //Departments
        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.AsNoTracking().ToList();
        }
 

        public Department GetDepByID(int Id)
        {
            return _dbContext.Departments.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
        }
      
        public Department AddDepartment(Department newDep)
        {
            _dbContext.Add(newDep);
            _dbContext.SaveChanges(); //CUD Operations you need to save the details -> commit
            return newDep;
        }
        public Department DeleteDepartment(int Id)
        {
            var emp = GetDepByID(Id);
            if (emp != null)
            {
                _dbContext.Departments.Remove(emp);
                _dbContext.SaveChanges();
            }
            return emp;
        }
       
        public Department UpdateDepartment(int Id, Department newDep)
        {
            _dbContext.Departments.Update(newDep);
            _dbContext.SaveChanges();
            return newDep;
        }

     
    }
}
