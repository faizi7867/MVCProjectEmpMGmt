using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Model.Properties;

namespace MyApp.DB.DbOperations
{
    public class EmpRepos
    {
        public int M1()
        {
            return 1;
        }
        public int AddEmployee(EmpModel model)
        {
            using (var context  = new EmployeeDbEntities())
            {
                employee emp = new employee()
                {
                     firstname = model.firstname,
                     lastname = model.lastname,
                     email = model.email,
                     code = model.code,

                };
                if (emp.Address != null)
                {
                    emp.Address = new Address()
                    {
                        details = model.address.details,
                        state = model.address.state,
                        country = model.address.country
                    };
                }
                context.employee.Add(emp);
                context.SaveChanges();
                return emp.id;
            }
          

        }

        public List<EmpModel> GetAllEmployees()
        {
            using (var context = new EmployeeDbEntities())
            {
                var result = context.employee.
                    Select(x => new EmpModel()
                    {
                        id = x.id,
                        firstname = x.firstname,
                        lastname = x.lastname,
                        email = x.email,
                        addressid = x.addressid,

                        code = x.code,
                        address = new AddressModel()
                        {
                            id = x.Address.id,
                            details = x.Address.details,
                            state = x.Address.state,
                            country = x.Address.country
                        }
                    }).ToList();
                return result;
            }
        }
        public EmpModel GetEmployee(int id)
        {
            using (var context = new EmployeeDbEntities())
            {
                var result = context.employee
                    .Where(x => x.id == id)
                    .Select(x => new EmpModel()
                    {
                        id = x.id,
                        firstname = x.firstname,
                        lastname = x.lastname,
                        email = x.email,
                        addressid = x.addressid,

                        code = x.code,
                        address = new AddressModel()
                        {
                            id = x.Address.id,
                            details = x.Address.details,
                            state = x.Address.state,
                            country = x.Address.country
                        }
                    }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateEmployee(int id,EmpModel model)
        {
            using (var context = new EmployeeDbEntities())
            {
                var employee = context.employee.FirstOrDefault(x => x.id == id);
                if (employee != null)
                {
                    employee.firstname = model.firstname;
                    employee.lastname = model.lastname;
                    employee.email = model.email;
                    employee.code = model.code;
                }
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteEmployee(int id)
        {
            using (var context = new EmployeeDbEntities())
            {
                var employee = context.employee.FirstOrDefault(x => x.id == id);
                if (employee != null)
                {
                    context.employee.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
