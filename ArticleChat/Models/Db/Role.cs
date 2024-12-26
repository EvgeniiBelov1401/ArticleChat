namespace ArticleChat.Models.Db
{
    public class Role
    {
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
