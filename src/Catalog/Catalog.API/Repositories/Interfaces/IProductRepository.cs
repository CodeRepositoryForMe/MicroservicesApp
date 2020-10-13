using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getProducts();

        Task<Product> getProduct(string Id);

        Task<IEnumerable<Product>> getProductByName(string Name);

        Task<IEnumerable<Product>> getProductByCategory(string Category);

        Task<Product> createProdct(Product product);

        Task<bool> updateProduct(Product product);

        Task<bool> deleteProduct(string Id);


    }
}
