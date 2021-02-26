using Data.Context;
using Domain.Entities;
using Domain.Interface.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<T>> SelectAcync()
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
                return await _dataset
                    .SingleOrDefaultAsync(p => p.Id.Equals(id));
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

        public async Task<List<T>> UpdateAllAsync(List<T> item)
        {
            try
            {
                //Procura o objeto no banco!
                //var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                //var result2 = (List<T>)await SelectAcync();
                
                /*
                if (result2 == null)
                {
                    return null;
                }
                */

                
                //Caso ele exista informa a data de modificação e reforça a de criação!
                //item.ForEach(i => i.UpdateAt = DateTime.UtcNow);
                /*
                for(var i = 0; i > item.Count; i++)
                {
                    item[i].CreateAt = result2
                        .Where(j => j.Id == item[i].Id)
                        .Select(p => p.CreateAt)
                        .FirstOrDefault();
                }
                */

                // Teste 1
                //_context.Entry(result2).CurrentValues.SetValues(item);

                // Teste 2
                //_context.UpdateRange(item);

                // Teste 3
                //_context.Entry(item).State = EntityState.Modified;

                // Teste 4
                item.ForEach(i => 
                {
                    _context.Entry(i).State = EntityState.Modified;
                });

               
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
