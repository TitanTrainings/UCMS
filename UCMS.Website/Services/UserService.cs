using UCMS.Website.Models;

namespace UCMS.Website.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User CreateUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public string DeleteUser(int id)
        {
            try
            {
                User user = _dbContext.Users.Find(id);
                _dbContext.Remove(user);
                _dbContext.SaveChanges();

                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.Find(id);
            if (user != null)
            {
                return user;
            }

            return null;
        }

        public User GetUserByUsernameAndPassword(User user)
        {
            User loginuser = _dbContext.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            if (user != null)
            {
                return loginuser;
            }

            return null;
        }

        public List<User> GetUsers()
        {
            List<User> user = _dbContext.Users.ToList();
            if (user != null)
            {
                return user;
            }

            return null;
        }

        public User UpdateUser(User user)
        {
            try
            {
                User _user = _dbContext.Users.Find(user.UserId);
                if (_user != null)
                {
                    _dbContext.Update(_user);
                    _dbContext.SaveChanges();
                    return _user;
                }

            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
