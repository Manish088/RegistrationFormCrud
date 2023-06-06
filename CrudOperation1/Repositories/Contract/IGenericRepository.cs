namespace CrudOperation1.Repositories.Contract
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<List<T>> GetList();
        Task<bool> Save(T entity);
        Task<bool> Delete(int Id);
        Task<bool> Edit(T entity);
        Task<T> GetById(int id);
    }
}
