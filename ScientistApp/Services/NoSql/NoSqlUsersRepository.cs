using ScientistApp.Models;

namespace ScientistApp.Services.NoSql;

public class NoSqlUsersRepository : IUsersRepository
{
    private Dictionary<Guid, User> _users = new()
    {
        {
            Guid.Empty,
            new User()
            {
                Id = Guid.Empty,
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = DateTime.Today
            }
        },
        {
            Guid.Parse("00000000-0000-0000-0000-000000000001"),
            new User()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "NOSQL",
                LastName = "NOSQL",
                DateOfBirth = DateTime.Today
            }
        }
    };

    public Task<User> GetById(Guid id)
    {
        return Task.FromResult(_users[id]);
    }
}
