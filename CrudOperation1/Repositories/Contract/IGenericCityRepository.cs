namespace CrudOperation1.Repositories.Contract
{
    public interface IGenericCityRepository<T> where T : class
    {
        Task<List<T>> GetCityList(int StateId);
    }
}
