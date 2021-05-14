using AutoMapper;
using MCIT_Task.Domain.Entities;
using MCIT_Task.Domain.ParameterObjects;
using MCIT_Task.DTO;
using MCIT_Task.Infrastructure.UOW;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var allCategories = await _unitOfWork.GetRepo<Category>().GetAll();
            
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(allCategories));
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            var product = await _unitOfWork.GetRepo<Category>().GetByID(id);

            if (product == null) return NotFound("Could not find the category");

            return Ok(_mapper.Map<CategoryDto>(product));
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CreateCategoryDto input)
        {

            var newCategory = Category.Create(_mapper.Map<CategoryInputParameter>(input));
            _unitOfWork.GetRepo<Category>().Insert(newCategory);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("failed to add new category");
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditCategoryDto input)
        {
            if (id <= 0) return BadRequest("Invalid Category Id");

            var category = await _unitOfWork.GetRepo<Category>().GetByID(id);

            if (category == null) return NotFound("There is no Category with the specified Id");

            category.Edit(input.Name);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest($"Failed to edit category with Id : {id}");
        }

        [HttpDelete("Remove/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Category Id");

            _unitOfWork.GetRepo<Category>().Delete(id);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest($"Failed to remove category with id : {id}");
        }
    }
}
