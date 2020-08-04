using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreTester.Helpers;

namespace EntityFrameworkCoreTester.Model
{
    public static class FluentBuilder
    {
        public static ModelBuilder OnCreateModel(this ModelBuilder builder)
        {
            builder.Entity<Applicant>(e =>
            {
                e.HasKey(p => p.Id);


                e.Property(p => p.FirstName).Varchar(50).IsRequired();
                e.Property(p => p.LastName).Varchar(50).IsRequired();
                e.Property(p => p.Address).Varchar(150);
                e.Property(p => p.EmailAddress).Varchar(50).IsRequired();
                e.Property(p => p.PhoneNumber).Varchar(20).IsRequired();
                e.Property(p => p.Gender).IsRequired();
            });


            builder.Entity<ProgramApplication>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasIndex(f => f.ApplicantId);
                e.HasIndex(f => f.ProgramId);
                e.HasIndex(f => f.RefApplicationOutComeId);
                e.HasIndex(f => f.RefApplicationStatusId);


                e.HasOne(p => p.Applicant)
                    .WithMany(p => p.ProgramApplications)
                    .HasForeignKey(f => f.ApplicantId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.RefApplicationOutcome)
                    .WithMany()
                    .HasForeignKey(f => f.RefApplicationOutComeId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.RefApplicationStatus)
                    .WithMany()
                    .HasForeignKey(f => f.RefApplicationStatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.Program)
                    .WithMany()
                    .HasForeignKey(f => f.ProgramId)
                    .OnDelete(DeleteBehavior.Restrict);


            });

            builder.Entity<StudentComplaint>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasIndex(f => f.ProgramApplicationId);
                e.HasIndex(f => f.RefComplaintOutComeId);
                e.HasIndex(f => f.RefComplaintStatusId);

                e.Property(p => p.ComplaintText).Varchar(256);
                e.Property(p => p.ResponseText).Varchar(256);

                e.HasOne(p => p.ProgramApplication)
                    .WithMany()
                    .HasForeignKey(f => f.ProgramApplicationId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.RefComplaintStatus)
                    .WithMany()
                    .HasForeignKey(f => f.RefComplaintStatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.RefComplaintOutcome)
                    .WithMany()
                    .HasForeignKey(f => f.RefComplaintOutComeId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<RefApplicationStatus>(e =>
            {
                e.HasKey(p => p.Id);
                

                e.Property(p => p.StatusCode).Varchar(10);
                e.Property(p => p.Description).Varchar(150);

            });

            builder.Entity<RefApplicationOutcome>(e =>
            {
                e.HasKey(p => p.Id);


                e.Property(p => p.OutComeCode).Varchar(10);
                e.Property(p => p.Description).Varchar(150);

            });
            
            builder.Entity<RefComplaintOutcome>(e =>
            {
                e.HasKey(p => p.Id);


                e.Property(p => p.OutComeCode).Varchar(10);
                e.Property(p => p.Description).Varchar(150);

            }); 
            
            builder.Entity<RefComplaintStatus>(e =>
            {
                e.HasKey(p => p.Id);


                e.Property(p => p.StatusCode).Varchar(10);
                e.Property(p => p.Description).Varchar(150);

            });



            return builder;
        }
    }
}
