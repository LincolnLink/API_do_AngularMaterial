using Domain.Entities;
using Domain.Interface.RepositoryBase;
using Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Answer>> GetAll()
        {
            return (List<Answer>)await this._repository.SelectAcync();
        }

        public async Task<Answer> Post(Answer a)
        {
            List<Answer> indexValue = await GetAll();

            int? indexValueInt = indexValue.Where(i => i.QuestionsId == a.QuestionsId).Count();

            if (indexValueInt == null)
            {
                a.Index = 0;
            }
            else { a.Index = (int)indexValueInt; }

            return await this._repository.InsertAsync(a);
        }

        public async Task<Answer> Put(Answer a)
        {
            return await this._repository.UpdateAsync(a);
        }

        public async Task<List<Answer>> PutAll(Answer[] c)
        {
            return await this._repository.UpdateAllAsync(c.ToList());
        }
    }
}
