using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogDBContext _context;

        public ProductRepository(ICatalogDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> getProducts()
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Where(p => true);

            //List<Product> products  = _context.Products.FindAsync(filter).Result.ToList<Product>();

            return await _context.Products.FindAsync(filter).Result.ToListAsync<Product>(); 

        }

        public async Task<Product> getProduct(string Id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Where(p => p.Id == Id);

            return await _context.Products.Find(filter).FirstOrDefaultAsync<Product>();
        }

        public async Task<IEnumerable<Product>> getProductByName(string Name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, Name);

            return await _context.Products.Find(filter).ToListAsync<Product>();
        }

        public async Task<IEnumerable<Product>> getProductByCategory(string Category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category , Category);

            return await _context.Products.Find(filter).ToListAsync<Product>();
        }


        public async Task createProdct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> updateProduct(Product product)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Where(p => p.Id == product.Id);

            var updateResult = await _context
                                .Products
                                .ReplaceOneAsync(filter, product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> deleteProduct(string Id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Where(p => p.Id == Id);

            var deleteResult = await _context
                                    .Products
                                    .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        
    }
}
