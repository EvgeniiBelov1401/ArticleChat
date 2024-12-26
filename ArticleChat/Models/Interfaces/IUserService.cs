using ArticleChat.Models.Db;

namespace ArticleChat.Models.Interfaces
{
    public interface IUserService
    {
        void Register(User user);
        void Edit(User user);
        void Delete(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
