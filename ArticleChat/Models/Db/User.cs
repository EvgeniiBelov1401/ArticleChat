using System.ComponentModel.DataAnnotations;

namespace ArticleChat.Models.Db
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Nickname { get; set; }

        [Required]
        [StringLength(4)]
        public string? Password { get; set; }
        public string Role { get; set; } = "Пользователь";
    }
}
