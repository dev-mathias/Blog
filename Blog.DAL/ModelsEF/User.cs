using System.ComponentModel.DataAnnotations;

namespace Blog.Dal.ModelsEF
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? Nickname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        
        public ICollection<Comment>? Comments { get; set; }
    }
}
