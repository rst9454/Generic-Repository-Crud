
using Using_GenericRepository_CrudOperation.Repository;

namespace Using_GenericRepository_CrudOperation.GenericSerivce
{
    public class GenericService : IGenericService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public GenericService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            using(var scope = serviceScopeFactory.CreateScope())
            {
                var genericRepository = scope.ServiceProvider.GetService<IGenericRepository<T>>();
                if(genericRepository == null)
                {
                    throw new InvalidOperationException($"Repository of entity type {typeof(T).Name} not found");
                }
                await genericRepository.AddAsync(entity);
            }
        }

        public async Task DeleteAsync<T>(int id) where T : class
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var genericRepository = scope.ServiceProvider.GetService<IGenericRepository<T>>();
                if (genericRepository == null)
                {
                    throw new InvalidOperationException($"Repository of entity type {typeof(T).Name} not found");
                }
                await genericRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var genericRepository = scope.ServiceProvider.GetService<IGenericRepository<T>>();
                if (genericRepository == null)
                {
                    throw new InvalidOperationException($"Repository of entity type {typeof(T).Name} not found");
                }
              return await genericRepository.GetAllAsync();
            }
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var genericRepository = scope.ServiceProvider.GetService<IGenericRepository<T>>();
                if (genericRepository == null)
                {
                    throw new InvalidOperationException($"Repository of entity type {typeof(T).Name} not found");
                }
                return await genericRepository.GetByIdAsync(id);
            }
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var genericRepository = scope.ServiceProvider.GetService<IGenericRepository<T>>();
                if (genericRepository == null)
                {
                    throw new InvalidOperationException($"Repository of entity type {typeof(T).Name} not found");
                }
                 await genericRepository.UpdateAsync(entity);
            }
        }
    }
}
