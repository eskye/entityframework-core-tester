using System;
using EntityFrameworkCoreTester.ModelInterface;

namespace EntityFrameworkCoreTester.Model
{
    public class RefComplaintStatus : IBaseEntity<long>, IBaseEntityKey
    {
        public long Id { get; set; }
        public string StatusCode { get; set; } // We can use the first 3 alphabet, converted to Uppercase as the StatusCode
        public string Description { get; set; }
        public Guid Key { get; set; }
    }
}