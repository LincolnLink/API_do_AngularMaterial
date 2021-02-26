using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IQuestionsService
    {
        Task<Questions> Get(Guid id);

        Task<List<Questions>> GetAll();

        Task<Questions> Post(Questions user);

        Task<Questions> Put(Questions user);

        Task<List<Questions>> PutAll(Questions[] c);

        Task<bool> Delete(Guid id);
    }
}
