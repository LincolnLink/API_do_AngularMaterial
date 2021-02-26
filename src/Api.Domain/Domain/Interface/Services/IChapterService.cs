using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IChapterService
    {
        Task<Chapter> Get(Guid id);

        Task<List<Chapter>> GetAll();

        Task<Chapter> Post(Chapter c);

        Task<Chapter> Put(Chapter c);

        Task<List<Chapter>> PutAll(Chapter[] c);

        Task<bool> Delete(Guid id);
    }
}
