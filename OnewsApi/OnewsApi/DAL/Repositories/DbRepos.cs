using OnewsApi;
using OnewsApi.DAL.Interfaces;

namespace OnewsApi.DAL.Repositories
{
    //Scaffold-DbContext "Server=DESKTOP-A57HCR0\SQLEXPRESS;Database=Onews;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
    public class DbRepos : IDbRepos
    {
        private OnewsContext db;
        private UserRepos user;
        private EventRepos even;
        private EventStringRepos eventString;
        private ParticipationRepos participation;

        public DbRepos()
        {
            db = new OnewsContext();
        }

        public IRepository<User> User
        {
            get
            {
                if (user == null)
                    user = new UserRepos(db);
                return user;
            }
        }

        public IRepository<Event> Even
        {
            get
            {
                if (even == null)
                    even = new EventRepos(db);
                return even;
            }
        }

        public IRepository<EventString> EventString
        {
            get
            {
                if (eventString == null)
                    eventString = new EventStringRepos(db);
                return eventString;
            }
        }

        public IRepository<Participation> Participation
        {
            get
            {
                if (participation == null)
                    participation = new ParticipationRepos(db);
                return participation;
            }
        }
    }
}
