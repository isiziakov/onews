using Microsoft.EntityFrameworkCore;
using OnewsApi.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnewsApi.DAL.Repositories
{
    public class ParticipationRepos : IRepository<Participation>
    {
        private OnewsContext db;

        public ParticipationRepos(OnewsContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Participation> GetList()
        {
            return db.Participations.ToList();
        }

        public Participation? GetItem(int id)
        {
            return db.Participations.Where(i => i.Id == id).SingleOrDefault();
        }

        public void Create(Participation item)
        {
            db.Participations.Add(item);
            Save();
        }

        public void Update(Participation item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Participation item = db.Participations.Find(id);
            if (item != null)
                db.Participations.Remove(item);
            Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
