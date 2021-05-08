using MCIT_Task.Domain.ParameterObjects;
using MCIT_Task.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Product> Products { get; private set; }

        private Category()
        {

        }

        private Category(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }

        public static Category Create(CategoryInputParameter input)
        {
            Guard.AssertStringIsValid(input.Name);
            Guard.AssertCollectionIsNotNullOrEmpty(input.Products);

            return new Category(input.Name, input.Products);
        }
    }
}
