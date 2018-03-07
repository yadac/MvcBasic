using System.Data.Entity;

namespace MvcBasic.Models
{
    public class MvcBasicContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        public System.Data.Entity.DbSet<MvcBasic.Models.Person> People { get; set; }
    }
}