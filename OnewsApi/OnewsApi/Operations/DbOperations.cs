using OnewsApi.DAL.Repositories;
using OnewsApi.Models;
using System.Collections.Generic;
using System.Linq;

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

        public List<Event> GetEvents()
        {
            return db.Even.GetList();
        }

        public void CreateEvents(Event even)
        {
            db.Even.Create(even);
        }

        public Event GetEvent(int id)
        {
            return db.Even.GetItem(id);
        }

        public List<EventString> GetEventStrings(int id)
        {
            return db.EventString.GetList().Where(i => i.Event == id).OrderBy(i => i.Id).ToList();
        }

        public bool CheckEventReg(EventReg reg)
        {
            return db.Participation.GetList().Where(i => i.EventId == reg.EventId && i.UserId == reg.UserId).Count() == 1;
        }

        public void MakeReg(EventReg reg)
        {
            db.Participation.Create(new Participation()
            {
                EventId = reg.EventId,
                UserId = reg.UserId
            });
        }

        public void RemoveReg(EventReg reg)
        {
            var eventInfo = db.Participation.GetList().Where(i => i.EventId == reg.EventId && i.UserId == reg.UserId).Single();
            db.Participation.Delete(eventInfo.Id);
        }

        public List<User> GetAllReg(int id)
        {
            return db.Participation.GetList().Where(i => i.EventId == id).Select(i => db.User.GetItem(i.UserId)).ToList();
        }
    }
}
