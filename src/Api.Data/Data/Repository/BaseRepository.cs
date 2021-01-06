using Data.Context;
using Domain.Entities;
using Domain.Interface.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T>: IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;

        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                //Procura o objeto no banco!
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id == id);
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                //Caso o ID esteja vasio, é criado um id
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                //Salva a data da criação
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                //o termo await faz parte do método async, salva o objeto usando o contexto
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //retorna o que foi inserido
            return item;
        }

        public async Task<IEnumerable<T>> SelectAcync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                //Procura o objeto no banco!
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }

                //Caso ele exista informa a data de modificação e reforça a de criação!
                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                //Atualiza as informações novas e salva no banco!
                _context.Entry(result).CurrentValues.SetValues(item);

                //ele faz o commit ou o roolback
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //retorna o que foi atualizado
            return item;
        }
    }
}
