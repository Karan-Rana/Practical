using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practical.Model;

namespace Practical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public OperationController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("InsertEmployee")]
        public IActionResult InsertEmployee([FromBody]Employee employee)
        {
            if(ModelState.IsValid)
            {
                _dataAccessProvider.InsertEmployee(employee);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public IActionResult DeleteDepartment(char Id)
        {
            var department = _dataAccessProvider.GetDepartment(Id);
            if(department == null)
            {
                return BadRequest();
            }
            _dataAccessProvider.DeleteDepartment(Id);
            return Ok();
        }

        [HttpGet]
        [Route("GetAverage")]
        public decimal GetAverage(char clubId, int typeId)
        {
            return _dataAccessProvider.GetAverageAnnual(clubId, typeId);
        }
    }
}