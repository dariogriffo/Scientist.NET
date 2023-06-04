using ScientistApp.Models;

namespace ScientistApp.Services.SqlRepository;

public class SqlUsersRepository : IUsersRepository
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
                FirstName = "SQL",
                LastName = "SQL",
                DateOfBirth = DateTime.Today
            }
        }
    };

    public Task<User> GetById(Guid id)
    {
        return Task.FromResult(_users[id]);
    }
}