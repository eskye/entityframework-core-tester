using System;
using EntityFrameworkCoreTester.ModelInterface;

namespace EntityFrameworkCoreTester.Model
{
    public class RefApplicationOutcome : IBaseEntity<long>, IBaseEntityKey
    {
        public long Id { get; set; }
        public string OutComeCode { get; set; } // We can use the first 3 alphabet, converted to Uppercase as the OutcomeCode
        public string Description { get; set; }
        public Guid Key { get; set; }
    }
}