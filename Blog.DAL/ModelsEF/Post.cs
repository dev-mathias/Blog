using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Dal.ModelsEF
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Titre { get; set; }
        [Required]
        public string? Contenu { get; set; }
        [Required]
        public DateTime DateDePublication { get; set; }
        public string? ImageUrl { get; set; }

        
        [Required]
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public Admin? Admin { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
