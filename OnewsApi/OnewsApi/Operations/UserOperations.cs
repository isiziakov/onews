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

        public string Login(LoginInfo user)
        {
            var users = db.GetUsers();
            if (users.Where(i => i.Email == user.Email && i.Password == user.Password).Count() == 1)
            { 
                return users.Where(i => i.Email == user.Email && i.Password == user.Password).Single().Name;
            }
            return "";
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

        public User GetInfo(string email)
        {
            return db.GetUsers().Where(i => i.Email == email).Single();
        }

        public void Update(User newUser)
        {
            var user = GetInfo(newUser.Email);
            newUser.Id = user.Id;
            newUser.Sex = user.Sex;
            db = new DbOperations();
            db.UpdateUser(newUser);
        }
    }
}
