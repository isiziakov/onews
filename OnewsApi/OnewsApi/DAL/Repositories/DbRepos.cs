using OnewsApi;
using OnewsApi.DAL.Interfaces;

namespace OnewsApi.DAL.Repositories
{
    //Scaffold-DbContext "Server=DESKTOP-A57HCR0\SQLEXPRESS;Database=Onews;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
    public class DbRepos : IDbRepos
    {
        private OnewsContext db;
        private UserRepos user;

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
    }
}
