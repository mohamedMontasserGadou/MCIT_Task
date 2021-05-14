using MCIT_Task.Domain.ParameterObjects;
using MCIT_Task.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }
        private Product()
        {

        }

        private Product(string name, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public static Product Create(ProductInputParameter input)
        {
            Guard.AssertStringIsValid(input.Name);
            Guard.AssertValueGreaterThanZero(input.Price);
            Guard.AssertValueGreaterThanZero(input.CategoryId);


            return new Product(input.Name, input.Price, input.CategoryId);
        }

        public void Edit(string name, decimal price)
        {
            Guard.AssertStringIsValid(name);
            Guard.AssertValueGreaterThanZero(price);

            Name = name;
            Price = price;
        }
    }
}
