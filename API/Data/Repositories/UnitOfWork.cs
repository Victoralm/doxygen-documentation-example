namespace doxygen_documentation_example.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }
        public IUserRepository Users { get; }
    }
}
