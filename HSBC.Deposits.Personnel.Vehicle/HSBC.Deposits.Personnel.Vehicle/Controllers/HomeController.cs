using HSBC.Deposits.Personnel.Vehicle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HSBC.Deposits.Personnel.Vehicle.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> arrNames = new List<string>() { "asfsf", "asdfdsf" };
            return arrNames;
        }

        [HttpPost, Route("save-employee")]
        public string SaveEmployee(int empno, string empname)
        {
            return "Welcome " + empname + ", Your employee number is " + empno.ToString();
        }

        [HttpPost, Route("post-consultant-data")]
        [SwaggerOperation(Summary = "Get AeTm Credentials based on corporatename", Description = "Get AeTm Credentials  based on Profile Type")]
        [SwaggerResponse(200, "Successful", typeof(EmployeeDTO))]
        public async Task<IActionResult> PostConsultantData(EmployeeDTO objEmployee)
        {
            return StatusCode(StatusCodes.Status200OK,
                "Welcome " + objEmployee.EmpName + ", Your employee number is " + objEmployee.EmpNo.ToString());

        }

        [HttpGet, Route("get-employee")]
        [SwaggerResponse(200, "Successful", typeof(EmployeeDTO))]
        public async Task<IActionResult> GetEmployee(int empno)
        {
            var objEmployee = new EmployeeDTO()
            {
                EmpNo = 10,
                EmpName = "Murali",
                Department = "Software Engineering"
            };
            return StatusCode(StatusCodes.Status200OK, objEmployee);
        }
    }
}
