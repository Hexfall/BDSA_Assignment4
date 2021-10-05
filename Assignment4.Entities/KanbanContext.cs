using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Assignment4.Entities
{
    public class KanbanContext : DbContext
    {
        public DBSet<User> Users { get; set; }
        public DBSet<Tag> Tags { get; set; }
        public DBSet<Task> Tasks { get; set; }

        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Task>()
                .Property(e => e.State)
                .HasConversion(new EnumToStringConverter<Core.State>());
        }
    }

    public class KanbanContextFactory : IDesignTimeDbContextFactory<KanbanContext>
    {
        public KanbanContext CreateDbContext(string[] args)
        {
            /*var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Program>()
                .AddJsonFile("appsettings.json")
                .Build();
            */
            string server = "hattie.db.elephantsql.com",
                   db = "wsqawkcj",
                   user = "wsqawkcj",
                   pass = "lql13AjDvehThpybQXCNw5LnxpC7Oq-T";
            int port = 5432;
            var connectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                server, db, user, pass, port);

            var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>()
                .UseNpgsql(connectionString);

            return new KanbanContext(optionsBuilder.Options);
        }
    }
}
