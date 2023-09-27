using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SingUP(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> DeleteUser(int id);

        Task<bool> SingIN(string username, string password);
    }
}