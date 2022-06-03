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
                if (model.address != null)
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

        public bool UpdateEmployee(EmpModel model)
        {
            using (var context = new EmployeeDbEntities())
            {
                var employee = new employee();
                employee.id = model.id;
                employee.firstname = model.firstname;
                employee.lastname = model.lastname;
                employee.email = model.email;
                employee.code = model.code;
                employee.addressid = model.addressid;

                context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteEmployee(int Id)
        {
            using (var context = new EmployeeDbEntities())
            {

                var emp = new employee()
                {
                    id = Id
                };
                context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return false;
            }
        }
    }
}
