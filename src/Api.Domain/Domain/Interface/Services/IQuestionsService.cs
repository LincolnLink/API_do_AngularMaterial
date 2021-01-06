using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IQuestionsService
    {
        Task<Questions> Get(Guid id);

        Task<IEnumerable<Questions>> GetAll();

        Task<Questions> Post(Questions user);

        Task<Questions> Put(Questions user);

        Task<bool> Delete(Guid id);
    }
}
