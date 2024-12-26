using System.ComponentModel.DataAnnotations;

namespace ArticleChat.Models.Db
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? TagText { get; set; }
    }
}
