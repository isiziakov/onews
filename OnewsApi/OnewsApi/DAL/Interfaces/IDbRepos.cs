using OnewsApi;

namespace OnewsApi.DAL.Interfaces
{
    public interface IDbRepos // интерфейс для взаимодействия с репозиториями
    {
        IRepository<User> User { get; }
    }
}
