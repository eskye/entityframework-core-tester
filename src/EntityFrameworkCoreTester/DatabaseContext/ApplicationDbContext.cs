using System.IO;
using EntityFrameworkCoreTester.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCoreTester.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        private static IConfigurationRoot Config { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: true);
            
            Config = builder.Build();
            optionsBuilder.UseSqlServer(Config.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FluentBuilder.OnCreateModel(modelBuilder);
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<StudentComplaint> StudentComplaints { get; set; }
        public DbSet<ProgramApplication> ProgramApplications { get; set; }
        public DbSet<RefApplicationStatus> RefApplicationStatuses { get; set; }
        public DbSet<RefComplaintOutcome> RefComplaintOutcomes { get; set; }
        public DbSet<RefApplicationOutcome> RefApplicationOutcomes { get; set; }
        public DbSet<RefComplaintStatus> RefComplaintStatuses { get; set; }
        public DbSet<Model.Program> Programs { get; set; }
    }
}
