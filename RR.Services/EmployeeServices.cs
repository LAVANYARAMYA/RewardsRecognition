using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.DataBaseConnect;
using RR.Models.EmployeeInfo;
using RR.Services.RequestClasses;

namespace RR.Services
{
    public class EmployeeServices
    {
        private readonly DataBaseAccess dataBaseAccess;

        public EmployeeServices()
        {

        }

        public EmployeeServices(DataBaseAccess dataBaseAccess)
        {
            this.dataBaseAccess = dataBaseAccess;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeAsync()
        {
            return await dataBaseAccess.Employee.ToListAsync();
        }

        public async Task<ActionResult<Employee>> AddEmployee(RequestEmployee requestEmployee)
        {
            Employee employee = new Employee();
            employee.EmployeeId = requestEmployee.EmployeeId;

            employee.Name = requestEmployee.Name;
            employee.EmailId = requestEmployee.EmailId;
            employee.Password = requestEmployee.Password;
            employee.Designation = requestEmployee.Designation;


            UserNamePassword UserNamePassword = new UserNamePassword();
          
            UserNamePassword.EmailID = requestEmployee.EmailId;
            UserNamePassword.Password = requestEmployee.Password;

            employee.UserNamePassword = UserNamePassword;



            foreach (var roleID in requestEmployee.Roles)
            {
                EmployeeRoles employeeRole = new EmployeeRoles();


                employeeRole.IdOfRole = roleID;

                employeeRole.role = await dataBaseAccess.Roles.FindAsync(roleID);

                employeeRole.RoleName = employeeRole.role.RoleName;

                employeeRole.EmpId = requestEmployee.EmployeeId;
                await dataBaseAccess.EmployeeRoles.AddAsync(employeeRole);


            }
            await dataBaseAccess.Employee.AddAsync(employee);

            await dataBaseAccess.SaveChangesAsync();

            return employee;
        }
    }
}