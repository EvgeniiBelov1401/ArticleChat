using System.ComponentModel.DataAnnotations;

namespace ArticleChat.Models.Db
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Moderator,
        User
    }
}
