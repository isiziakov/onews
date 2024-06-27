using Microsoft.EntityFrameworkCore;
using OnewsApi.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnewsApi.DAL.Repositories
{
    public class EventStringRepos : IRepository<EventString>
    {
        private OnewsContext db;

        public EventStringRepos(OnewsContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<EventString> GetList()
        {
            return db.EventStrings.ToList();
        }

        public EventString? GetItem(int id)
        {
            return db.EventStrings.Where(i => i.Id == id).SingleOrDefault();
        }

        public void Create(EventString item)
        {
            db.EventStrings.Add(item);
            Save();
        }

        public void Update(EventString item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            EventString item = db.EventStrings.Find(id);
            if (item != null)
                db.EventStrings.Remove(item);
            Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
