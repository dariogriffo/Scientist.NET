using ScientistApp.Models;

namespace ScientistApp.Services;

public interface IUsersRepository
{
    Task<User> GetById(Guid id);
}