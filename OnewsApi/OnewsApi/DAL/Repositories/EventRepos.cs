using Microsoft.EntityFrameworkCore;
using OnewsApi.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnewsApi.DAL.Repositories
{
    public class EventRepos : IRepository<Event>
    {
        private OnewsContext db;

        public EventRepos(OnewsContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Event> GetList()
        {
            return db.Events.ToList();
        }

        public Event? GetItem(int id)
        {
            return db.Events.Where(i => i.Id == id).SingleOrDefault();
        }

        public void Create(Event item)
        {
            db.Events.Add(item);
            Save();
        }

        public void Update(Event item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Event item = db.Events.Find(id);
            if (item != null)
                db.Events.Remove(item);
            Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
