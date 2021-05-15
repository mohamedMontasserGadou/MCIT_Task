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
        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products => _products;

        private Category()
        {
            _products = new List<Product>();
        }

        private Category(string name)
        {
            Name = name;
        }

        public static Category Create(CategoryInputParameter input)
        {
            Guard.AssertStringIsValid(input.Name);

            return new Category(input.Name);
        }

        public void AddNewProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
