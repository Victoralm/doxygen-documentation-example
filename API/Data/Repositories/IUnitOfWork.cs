namespace doxygen_documentation_example.Data.Repositories
{
    public interface IUnitOfWork
    {
        Context Session { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
