using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Dal.ModelsEF
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Posts")]
        public int PostId { get; set; }
        public Post? Post { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
