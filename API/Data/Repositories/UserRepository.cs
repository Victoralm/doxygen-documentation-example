using Dapper;
using doxygen_documentation_example.Data.Models;
using Microsoft.Data.Sqlite;

namespace doxygen_documentation_example.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task PopulateDb()
        {
            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                var user = new User();

                user.Id = "";
                user.Name = Faker.Name.FullName();
                user.Email = Faker.Internet.Email(user.Name);
                user.WebSite = Faker.Internet.DomainName();
                user.Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
                user.Followers = Faker.RandomNumber.Next(0, 10000);
                user.Bio = String.Join(" ", Faker.Lorem.Sentences(3));

                users.Add(user);
            }

            await AddAsync(users);
        }

        public async Task<int> AddAsync(User entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            var sql = "Insert into Users (Id, Name, Email, WebSite, Followers, Area, Bio) VALUES (@Id, @Name, @Email, @WebSite, @Followers, @Area, @Bio)";
            using (var connection = _unitOfWork.Session.Connection)
            {
                int result = 0;
                //if (entity.IsValid().IsValid)
                //{
                    _unitOfWork.BeginTransaction();
                    result = await connection.ExecuteAsync(sql, entity);
                    _unitOfWork.Commit();
                //}

                return result;
            }
        }

        public async Task<int> AddAsync(List<User> entity)
        {
            var sql = "Insert into Users (Id, Name, Email, WebSite, Followers, Area, Bio) VALUES (@Id, @Name, @Email, @WebSite, @Followers, @Area, @Bio)";
            int result = 0;
            using (var connection = _unitOfWork.Session.Connection)
            {
                _unitOfWork.BeginTransaction();
                foreach (var user in entity)
                {
                    user.Id = Guid.NewGuid().ToString();
                    result = await connection.ExecuteAsync(sql, user);
                }
                _unitOfWork.Commit();
                return result;
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = _unitOfWork.Session.Connection)
            {
                _unitOfWork.BeginTransaction();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                _unitOfWork.Commit();
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM Users";
            using (var connection = _unitOfWork.Session.Connection)
            {
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = _unitOfWork.Session.Connection)
            {
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var sql = "UPDATE Users SET Name = @Name, Email = @Email, WebSite = @WebSite, Followers = @Followers, Area = @Area, Bio = @Bio  WHERE Id = @Id";
            using (var connection = _unitOfWork.Session.Connection)
            {
                _unitOfWork.BeginTransaction();
                var result = await connection.ExecuteAsync(sql, entity);
                _unitOfWork.Commit();
                return result;
            }
        }

        public async Task<int> UpdateAsync(List<User> entity)
        {
            var sql = "UPDATE Users SET Name = @Name, Email = @Email, WebSite = @WebSite, Followers = @Followers, Area = @Area, Bio = @Bio  WHERE Id = @Id";
            int result = 0;
            using (var connection = _unitOfWork.Session.Connection)
            {
                _unitOfWork.BeginTransaction();
                foreach (var user in entity)
                    result = await connection.ExecuteAsync(sql, user);
                _unitOfWork.Commit();
                return result;
            }
        }
    }
}
