using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ArticleChat.Models.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();
        private int _currentId = 1;

        public void Register(User user)
        {
            user.Id = _currentId++;
            _users.Add(user);
        }

        public void Edit(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Nickname = user.Nickname;
                existingUser.Password = user.Password;
                // Не меняем роль напрямую
            }
        }

        public void Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }   
}
