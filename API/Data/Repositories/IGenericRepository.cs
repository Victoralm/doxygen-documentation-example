namespace doxygen_documentation_example.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task PopulateDb();
        Task<T> GetByIdAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> AddAsync(List<T> entity);
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateAsync(List<T> entity);
        Task<int> DeleteAsync(string id);
    }
}
