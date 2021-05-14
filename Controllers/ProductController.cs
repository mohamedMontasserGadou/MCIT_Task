using AutoMapper;
using MCIT_Task.Domain.Entities;
using MCIT_Task.Domain.ParameterObjects;
using MCIT_Task.DTO;
using MCIT_Task.Infrastructure.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCIT_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(int categoryId)
        {
            if (categoryId <= 0) return BadRequest("This Category is invalid");

            var products = await _unitOfWork.GetRepo<Product>().GetAll(p => p.CategoryId == categoryId);
            
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var product = await _unitOfWork.GetRepo<Product>().GetByID(id);

            if (product == null) return NotFound("Could not find the product");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CreateProductDto input)
        {
            if (input.CategoryId <= 0) return BadRequest("This Category is invalid");

            var productCategory = await _unitOfWork.GetRepo<Category>().GetByID(input.CategoryId);

            if (productCategory == null) return NotFound("There is no category with the specified Id");

            var newProduct = Product.Create(_mapper.Map<ProductInputParameter>(input));
            productCategory.Products.Add(newProduct);
            
            if(await _unitOfWork.Complete()) return Ok();

            return BadRequest("failed to add new product");
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditProductDto input)
        {
            if (id <= 0) return BadRequest("Invalid Product Id");

            var product = await _unitOfWork.GetRepo<Product>().GetByID(id);

            if (product == null) return NotFound("There is no product with the specified Id");

            product.Edit(input.Name, input.Price);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest($"Failed to edit product with Id : {id}");
        }

        [HttpDelete("Remove/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Product Id");

            _unitOfWork.GetRepo<Product>().Delete(id);

            if(await _unitOfWork.Complete()) return Ok();

            return BadRequest($"Failed to remove product with id : {id}");
        }

    }
}
