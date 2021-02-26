using Domain.Entities;
using Domain.Interface.RepositoryBase;
using Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ChapterService : IChapterService
    {

        private IRepository<Chapter> _repository;

        public ChapterService(IRepository<Chapter> repository)
        {
            this._repository = repository;
        }


        public async Task<bool> Delete(Guid id)
        {
            return await this._repository.DeleteAsync(id);
        }

        public async Task<Chapter> Get(Guid id)
        {
            return await this._repository.SelectAsync(id);
        }

        public async Task<List<Chapter>> GetAll()
        {
            return (List<Chapter>)await this._repository.SelectAcync();
        }

        public async Task<Chapter> Post(Chapter c)
        {
            List<Chapter> indexValue = await GetAll();

            int? indexValueInt = indexValue.Count();

            if (indexValueInt == null)
            {
                c.Index = 0;
            }
            else { c.Index = (int)indexValueInt; }

            return await this._repository.InsertAsync(c);
        }

        public async Task<Chapter> Put(Chapter c)
        {
            return await this._repository.UpdateAsync(c);
        }

        public async Task<List<Chapter>> PutAll(Chapter[] c)
        {
            return await this._repository.UpdateAllAsync(c.ToList());
        }
    }
}
