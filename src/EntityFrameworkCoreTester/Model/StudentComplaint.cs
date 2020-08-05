using System;
using EntityFrameworkCoreTester.ModelInterface;

namespace EntityFrameworkCoreTester.Model
{
    public class StudentComplaint : IBaseEntity<long>, IBaseEntityKey,IFullAudit
    {
        public long Id { get; set; }
        public Guid Key { get; set; }
      
        public bool IsResponded { get; set; }
        public DateTime DateOfComplaint { get; set; }
        public string ComplaintText { get; set; }
        public string ResponseText { get; set; }
        public long ProgramApplicationId { get; set; }
        public virtual ProgramApplication ProgramApplication { get; set; }
        public long RefComplaintOutComeId { get; set; } 
        public virtual RefComplaintOutcome RefComplaintOutcome { get; set; }
        public long RefComplaintStatusId { get; set; }
       
        public virtual RefComplaintStatus RefComplaintStatus { get; set; }
        public Guid CreatorUserKey { get; set; }
        public Guid? ModifierUserKey { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; }
    }
}