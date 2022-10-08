using Dapper;
using doxygen_documentation_example.Data.Models;
using Microsoft.Data.Sqlite;

namespace doxygen_documentation_example.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly Context _context;
        public UserRepository(IConfiguration configuration, Context context)
        {
            this.configuration = configuration;
            _context = context;
        }

        public async Task PopulateDb()
        {
            for (int i = 0; i < 10; i++)
            {
                var user = new User();

                user.Id = Guid.NewGuid().ToString();
                user.Name = Faker.Name.FullName();
                user.Email = Faker.Internet.Email(user.Name);
                user.WebSite = Faker.Internet.DomainName();
                user.Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
                user.Followers = Faker.RandomNumber.Next(0, 10000);
                user.Bio = String.Join(" ", Faker.Lorem.Sentences(3));

                await AddAsync(user);
            }
        }

        public async Task<int> AddAsync(User entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            var sql = "Insert into Users (Id, Name, Email, WebSite, Followers, Area, Bio) VALUES (@Id, @Name, @Email, @WebSite, @Followers, @Area, @Bio)";
            using (var connection = _context.GetDbConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = _context.GetDbConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM Users";
            using (var connection = _context.GetDbConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = _context.GetDbConnection())
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var sql = "UPDATE Users SET Name = @Name, Email = @Email, WebSite = @WebSite, Followers = @Followers, Area = @Area, Bio = @Bio  WHERE Id = @Id";
            using (var connection = _context.GetDbConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
