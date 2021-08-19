using Domain.Entities;
using Domain.Interface.RepositoryBase;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductsService : IProductsService
    {

        private IRepository<Product> _repository;

        public ProductsService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Product> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.SelectAcync();
        }

        public async Task<Product> Post(Product user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<Product> Put(Product user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<List<Product>> PutAll(Product[] c)
        {
            return await this._repository.UpdateAllAsync(c.ToList());
        }
    }
}
