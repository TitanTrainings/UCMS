using UCMS.Website.Models;

namespace UCMS.Website.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User CreateUser(User user);
        public User UpdateUser(User user);
        public string DeleteUser(int id);
        public User GetUserByUsernameAndPassword(User user);
    }
}
