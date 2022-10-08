namespace doxygen_documentation_example.Data.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
