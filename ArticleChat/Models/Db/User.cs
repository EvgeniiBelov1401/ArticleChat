using System.ComponentModel.DataAnnotations;

namespace ArticleChat.Models.Db
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Nickname { get; set; }

        [Required]
        [StringLength(4)]
        public string? Password { get; set; }
    }
}
