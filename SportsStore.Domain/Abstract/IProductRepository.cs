using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{   
    /// <summary>
    /// Provide an interface to comunicate with db. In this proj we use Entity Framework implementaion.
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
    }
}
