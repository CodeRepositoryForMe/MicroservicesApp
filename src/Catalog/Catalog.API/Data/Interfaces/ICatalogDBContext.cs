using MongoDB.Driver;
using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data.Interfaces
{
    public interface ICatalogDBContext
    {
        IMongoCollection<Product> Products { get;}

    }
}
