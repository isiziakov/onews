using OnewsApi.DAL.Repositories;
using System.Collections.Generic;

namespace OnewsApi.Operations
{
    public class DbOperations
    {
        DbRepos db;
        public DbOperations()
        {
            db = new DbRepos();
        }

        public List<User> GetUsers()
        {
            return db.User.GetList();
        }

        public void CreateUser(User user)
        {
            db.User.Create(user);
        }

        public void UpdateUser(User user)
        {
            db.User.Update(user);
        }
    }
}
