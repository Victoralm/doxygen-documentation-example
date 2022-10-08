using doxygen_documentation_example.Models;

namespace doxygen_documentation_example.Repositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Search and returns all users of type User
        /// </summary>
        /// <returns>A list of all users of type User</returns>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                var user = new User();

                user.Id = Guid.NewGuid();
                user.Name = Faker.Name.FullName();
                user.Email = Faker.Internet.Email(user.Name);
                user.WebSite = Faker.Internet.DomainName();
                user.Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
                user.Followers = Faker.RandomNumber.Next(0, 10000);
                user.Bio = String.Join(" ", Faker.Lorem.Sentences(3));

                users.Add(user);
            }

            return users;
        }
    }
}
