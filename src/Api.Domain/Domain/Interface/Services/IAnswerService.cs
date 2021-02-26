using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IAnswerService
    {
        Task<Answer> Get(Guid id);

        Task<List<Answer>> GetAll();

        Task<Answer> Post(Answer user);

        Task<Answer> Put(Answer user);

        Task<List<Answer>> PutAll(Answer[] c);

        Task<bool> Delete(Guid id);
    }
}
