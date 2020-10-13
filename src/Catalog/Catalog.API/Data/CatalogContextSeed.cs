using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void seedData(IMongoCollection<Product> productCollection)
        {
            bool ExistProduct = productCollection.Find(p => true).Any();

            if (!ExistProduct)
            {
                productCollection.InsertManyAsync(getConfigurableProducts());
            }

        }

        private static IEnumerable<Product> getConfigurableProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "ABC1",
                    Category = "Cat1",
                    Description = "Good one",
                    Summary ="Take it 1",
                    Price = 12.00M
                },
                new Product()
                {
                    Name = "ABC2",
                    Category = "Cat2",
                    Description = "Good Two",
                    Summary ="Take it 2",
                    Price = 24.00M
                },
                new Product()
                {
                    Name = "ABC3",
                    Category = "Cat3",
                    Description = "Good Three",
                    Summary ="Take it 3",
                    Price = 36.00M
                },
                new Product()
                {
                    Name = "ABC4",
                    Category = "Cat4",
                    Description = "Good four",
                    Summary ="Take it 4",
                    Price = 48.00M
                }
            };
        }
    }
}
