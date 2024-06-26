using Microsoft.EntityFrameworkCore;
using OnewsApi.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnewsApi.DAL.Repositories
{
    public class UserRepos : IRepository<User>
    {
        private OnewsContext db;

        public UserRepos(OnewsContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<User> GetList()
        {
            return db.Users.ToList();
        }

        public User? GetItem(int id)
        {
            return db.Users.Where(i => i.Id == id).SingleOrDefault();
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            Save();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            User item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
            Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
