using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Web.Http;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AutoMapper;
using Employee = AdventureWorks.EmployeeManager.Services.Models.Employee;

namespace AdventureWorks.EmployeeManager.Services.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeeDao _employeeDao = new EmployeeDao();
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            var settings = ConfigurationManager.ConnectionStrings["AdventureWorks2017"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = settings.ConnectionString;
                connection.Open();
                foreach (var employee in _employeeDao.GetEmployees(connection))
                {
                    yield return Mapper.Map<Employee>(employee);
                }
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}