using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TMS.Domain.Entities;

namespace TMS.Infrastructure.Data
{
    public partial class TMSDbContext : DbContext
    {
        public TMSDbContext() { }
        public TMSDbContext(DbContextOptions<TMSDbContext> options) 
            : base(options) 
        { 
        }

        public virtual DbSet<City> City { get; set; } = null!;
        public virtual DbSet<Company> Company { get; set; } = null!;
        public virtual DbSet<CompanyProject> CompanyProject { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; } = null!;
        public virtual DbSet<Language> Language { get; set; } = null!;
        public virtual DbSet<Project> Project { get; set; } = null!;
        public virtual DbSet<Reference> Reference { get; set; } = null!;
        public virtual DbSet<ReferenceLanguage> ReferenceLanguage { get; set; } = null!;
        public virtual DbSet<ReferenceType> ReferenceType { get; set; } = null!;
        public virtual DbSet<ReferenceTypeLanguage> ReferenceTypeLanguage { get; set; } = null!;
        public virtual DbSet<Team> Team { get; set; } = null!;
        public virtual DbSet<TeamProject> TeamProject { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<UserProject> UserProject { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Get connection string from appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
