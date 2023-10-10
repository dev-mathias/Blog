using Blog.Dal.ModelsEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Context
{
    public class BlogContext :DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogBD;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            
            modelBuilder.Entity<User>().ToTable("Users");// Besoin de faire ça sinon EF va créer qu'une seule table pour user et admin car admin hérite de user..
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Lastname = "Dupont", FirstName = "Jean", Nickname = "JD", Email = "jd@example.com", Password = "123" }  // mot de passe exemple, devrait être crypté dans un scénario réel
                 
                );
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 2, Lastname = "Martin", FirstName = "Alice", Nickname = "AM", Email = "am@example.com", Password = "456" }
                );

            // Données pour Post
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Titre = "Les bienfaits de l'écologie", Contenu = "L'écologie est essentielle pour...", DateDePublication = DateTime.Now, ImageUrl = "image1.jpg", AdminId = 2 },
                new Post { Id = 2, Titre = "Réduire, Réutiliser, Recycler", Contenu = "La règle des trois R est...", DateDePublication = DateTime.Now, ImageUrl = "image2.jpg", AdminId = 2 }
            );

            // Données pour Comment
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Content = "Très bon article!", Date = DateTime.Now, PostId = 1, UserId = 1 },
                new Comment { Id = 2, Content = "Merci pour ces informations.", Date = DateTime.Now, PostId = 2, UserId = 1 }
            );
        }
    }
}
