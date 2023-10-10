namespace Blog.Dal.ModelsEF
{
    public class Admin: User
    {   

        public virtual ICollection<Post> Posts { get; set; }
    }
}
