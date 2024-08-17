
using Microsoft.EntityFrameworkCore;
using Using_GenericRepository_CrudOperation.Data;

namespace Using_GenericRepository_CrudOperation.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {

                throw new ApplicationException("An error occourred while adding the entity.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _dbSet.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {

                throw new ApplicationException("An error occurred while deleting the entity.", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("An error occured while retriving entities.", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("A database error occured while retrieving the entity.", ex);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw new ApplicationException("A concurrency eror occure while updating the entity.", ex);
            }
        }
    }
}
