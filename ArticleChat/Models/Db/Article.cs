using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleChat.Models.Db
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10000)]
        public string? Content { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag? Tag { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}
