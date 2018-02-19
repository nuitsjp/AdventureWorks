using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdventureWorks.EmployeeManager.Services.Server.Models;
using AutoMapper;
using Da = AdventureWorks.EmployeeManager.DatabaseAccesses;

namespace AdventureWorks.EmployeeManager.Services.Server.Controllers
{
    public class SalesOrderDetailsController : ApiController
    {
        private readonly Da.SalesOrderDetailDao _salesOrderDetailDao = new Da.SalesOrderDetailDao();
        // GET api/<controller>
        public IEnumerable<SalesOrderDetail> Get()
        {
            var settings = ConfigurationManager.ConnectionStrings["AdventureWorks2017"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = settings.ConnectionString;
                connection.Open();
                foreach (var salesOrderDetail in _salesOrderDetailDao.GetAll(connection))
                {
                    yield return Mapper.Map<SalesOrderDetail>(salesOrderDetail);
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