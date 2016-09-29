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
            get { return context.Products; }            
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)     // add if new. 0 is default id for new items.
                context.Products.Add(product);
            else                            // change existing product
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry == null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
    }
}