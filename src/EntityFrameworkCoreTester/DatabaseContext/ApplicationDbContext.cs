using System.IO;
using EntityFrameworkCoreTester.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using programModel =  EntityFrameworkCoreTester.Model.Program;

namespace EntityFrameworkCoreTester.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        private static IConfigurationRoot _config;

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            { 
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: true);

                _config = builder.Build();
                optionsBuilder.UseSqlServer(_config.GetConnectionString("Default"));
            }
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
        public DbSet<programModel> Programs { get; set; }
    }
}
