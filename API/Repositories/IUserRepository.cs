using doxygen_documentation_example.Models;

namespace doxygen_documentation_example.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }
}
