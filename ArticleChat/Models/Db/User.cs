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

        [Required]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
