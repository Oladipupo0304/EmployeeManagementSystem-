using EMSAPP.Data;
using EMSAPP.Models;

namespace EMSAPP.Repository.InMemoryRepository
{
    public class EMSInMemoryRepository : IEMSRepository
    {
        static List<Employee> employeeList = new List<Employee>();
        static List<Department> deplist = new List<Department>();

        EMSInMemoryContext _Inmemorycontext;

        public EMSInMemoryRepository(EMSInMemoryContext Inmemorycontext)
        {
            this._Inmemorycontext = Inmemorycontext;
        }
        static EMSInMemoryRepository()
        {
            Department department = null;
            employeeList.Add(new Employee(1, "Ivhan", DateTime.Now.AddDays(1), "ivhan@gmail.com", "09079260368", department));

        }
        public List<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        // get any specific todo
        public Employee GetEmployeeById(int eId)
        {
            return employeeList.FirstOrDefault(x => x.Id == eId);
        }

        // add todo into the list
        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = employeeList.Max(x => x.Id) + 1; // max id of your list
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        // update todo in the list
        public Employee UpdateEmployee(int empid, Employee newEmployee)
        {
            var oldEmployee = employeeList.Find(x => x.Id == empid);
            if (oldEmployee == null)
                return null;
            employeeList.Remove(oldEmployee);
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        // delete 
        public Employee DeleteEmployee(int empid)
        {
            var oldEmployee = employeeList.Find(x => x.Id == empid);
            if (oldEmployee == null)
                return null;
            employeeList.Remove(oldEmployee);
            return oldEmployee;
        }



        //Departments
        public List<Department> GetAllDepartments()
        {
            return deplist;
        }

        public Department GetDepByID(int eId)
        {
            return deplist.FirstOrDefault(x => x.Id == eId);
        }

        public Department AddDepartment(Department newDep)
        {
            newDep.Id = deplist.Max(x => x.Id) + 1; // max id of your list
            deplist.Add(newDep);
            return newDep;
        }

        public Department UpdateDepartment(int eId, Department newDep)
        {
             var olddept = deplist.Find(x => x.Id == eId);
            if (olddept == null)
                return null;
            deplist.Remove(olddept);
            deplist.Add(newDep);
            return newDep;
        }

        public Department DeleteDepartment(int Id)
        {
            var olddept = deplist.Find(x => x.Id == Id);
            if (olddept == null)
                return null;
            deplist.Remove(olddept);
            return olddept;
        }
    }
}
