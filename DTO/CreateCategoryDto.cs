using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.DTO
{
    public class CreateCategoryDto
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public List<CreateProductDto> Products { get; set; }
    }
}
