namespace CrudOperation1.Repositories.Contract
{
    public interface IGenericStateRepository<T> where T : class
    {
        Task<List<T>> GetStateList();
    }
}
