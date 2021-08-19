using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProductsService
    {
        Task<Product> Get(Guid id);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Post(Product user);

        Task<Product> Put(Product user);

        Task<List<Product>> PutAll(Product[] c);

        Task<bool> Delete(Guid id);
    }
}
