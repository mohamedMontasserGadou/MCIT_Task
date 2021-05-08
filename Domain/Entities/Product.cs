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

        private Product()
        {

        }

        private Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static Product Create(ProductInputParameter input)
        {
            Guard.AssertStringIsValid(input.Name);
            Guard.AssertDecimalGreaterThanZero(input.Price);

            return new Product(input.Name, input.Price);
        }
    }
}
