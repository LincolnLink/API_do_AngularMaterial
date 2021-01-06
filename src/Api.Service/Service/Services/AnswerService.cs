using Domain.Entities;
using Domain.Interface.RepositoryBase;
using Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AnswerService : IAnswerService
    {

        private IRepository<Answer> _repository;


        public AnswerService(IRepository<Answer> repository)
        {
            this._repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
          return await this._repository.DeleteAsync(id);
        }

        public async Task<Answer> Get(Guid id)
        {
           return await this._repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await this._repository.SelectAcync();
        }

        public async Task<Answer> Post(Answer a)
        {
            return await this._repository.InsertAsync(a);
        }

        public async Task<Answer> Put(Answer a)
        {
            return await this._repository.UpdateAsync(a);
        }
    }
}
