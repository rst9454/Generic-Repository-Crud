namespace Using_GenericRepository_CrudOperation.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        //Create
        Task<T> AddAsync(T entity);
        //Get the Record By ID
        Task<T> GetByIdAsync(int id);
        //Get list of data
        Task<IEnumerable<T>> GetAllAsync();
        //Update
        Task<T> UpdateAsync(T entity);
        //Delete
        Task<bool> DeleteAsync(int id);
    }
}
