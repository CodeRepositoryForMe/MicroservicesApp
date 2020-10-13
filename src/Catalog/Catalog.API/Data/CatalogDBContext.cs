using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogDBContext : ICatalogDBContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogDBContext(ICatalogDatabaseSetting setting)
        {
            var Client = new MongoClient(setting.ConnectionString);
            var Database = Client.GetDatabase(setting.DatabaseName);

            Products = Database.GetCollection<Product>(setting.CollectionName);

            CatalogContextSeed.seedData(Products);
        }
    }
}
