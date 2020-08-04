using System;
using EntityFrameworkCoreTester.ModelInterface;

namespace EntityFrameworkCoreTester.Model
{
    public class Program : IBaseEntity<long>, IFullAudit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatorUserKey { get; set; }
        public Guid ModifierUserKey { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}