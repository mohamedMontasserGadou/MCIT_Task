using MCIT_Task.Infrastructure.UOW;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MCIT_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("Get/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Add")]
        public void Add([FromBody] string value)
        {
        }

        [HttpPut("Edit/{id}")]
        public void Edit(int id, [FromBody] string value)
        {
        }

        [HttpDelete("Remove/{id}")]
        public void Delete(int id)
        {
        }
    }
}
