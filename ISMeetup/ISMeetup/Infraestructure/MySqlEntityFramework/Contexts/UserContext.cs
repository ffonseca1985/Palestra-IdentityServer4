using ISMeetup.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace ISMeetup.Infraestructure.MySqlEntityFramework.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext() { }
        
        public DbSet<User> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //vamos colocar a connectionstring ou o name da connection que esta no webConfig
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MeetupIdentityServer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
