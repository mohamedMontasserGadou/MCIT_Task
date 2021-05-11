using MCIT_Task.Domain.Entities;
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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<object>> Get()
        {
            var repo = _unitOfWork.GetRepo<Product>();

            return await repo.Get();
        }

        [HttpGet("Get/{id}")]
        public async Task<object> Get(int id)
        {
            var repo = _unitOfWork.GetRepo<Product>();

            return await repo.GetByID(id);
        }

        [HttpPost("Add")]
        public async Task Add([FromBody] object value)
        {
            var repo = _unitOfWork.GetRepo<Product>();
            //repo.Insert(value);
            await _unitOfWork.CompleteAsync();
        }

        [HttpPut("Edit/{id}")]
        public async Task Edit(int id, [FromBody] string value)
        {
            var repo = _unitOfWork.GetRepo<Product>();
            var product = await repo.GetByID(id);

            await _unitOfWork.CompleteAsync();
        }

        [HttpDelete("Remove/{id}")]
        public void Delete(int id)
        {
        }
    }
}
