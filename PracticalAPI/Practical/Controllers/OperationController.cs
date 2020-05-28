using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Practical.Model;

namespace Practical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly IHubContext<MessageHub> _messageHub;

        public OperationController(IDataAccessProvider dataAccessProvider, IHubContext<MessageHub> messageHub)
        {
            _dataAccessProvider = dataAccessProvider;
            _messageHub = messageHub;
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
                _messageHub.Clients.All.SendAsync("BroadcastMessage", "employee added.");
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