using OnewsApi.Models;
using System.Linq;

namespace OnewsApi.Operations
{
    public class UserOperations
    {
        DbOperations db;
        public UserOperations()
        {
            db = new DbOperations();
        }

        public bool Login(LoginInfo user)
        {
            var users = db.GetUsers();
            if (users.Where(i => i.Email == user.Email && i.Password == user.Password).Count() == 1)
            {
                return true;
            }
            return false;
        }

        public bool Register(User user)
        {
            var users = db.GetUsers();
            if (users.Where(i => i.Email == user.Email).Count() > 0)
            {
                return false;
            }
            db.CreateUser(user);
            return true;
        }
    }
}
