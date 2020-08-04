using System;
using System.Collections.Generic;
using EntityFrameworkCoreTester.ModelInterface;

namespace EntityFrameworkCoreTester.Model
{
    public class Applicant : IBaseEntity<long>, IFullAudit
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public Guid CreatorUserKey { get; set; }
        public Guid ModifierUserKey { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public ICollection<ProgramApplication> ProgramApplications { get; set; }
    }
}