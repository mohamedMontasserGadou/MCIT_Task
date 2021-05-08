using MCIT_Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Domain.ParameterObjects
{
    public class CategoryInputParameter
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
