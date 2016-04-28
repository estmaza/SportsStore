using System;
using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concerte
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext(); 

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }

            set
            {
                throw new NotImplementedException("There is no setter in the book. It may be a mistake, or I miss that interface IProductRepository must have only getter.");
            }
        }
    }
}
