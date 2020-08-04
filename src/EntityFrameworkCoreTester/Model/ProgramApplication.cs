using System;
using EntityFrameworkCoreTester.ModelInterface;

namespace EntityFrameworkCoreTester.Model
{
    public class ProgramApplication: IBaseEntity<long>, IBaseEntityKey, ITimeAudit
    {
        public long Id { get; set; }
        public long ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public long ProgramId { get; set; }
        public virtual Program Program { get; set; }
        public long RefApplicationOutComeId { get; set; }
        public virtual RefApplicationOutcome RefApplicationOutcome { get; set; }
        public long RefApplicationStatusId { get; set; }
        public virtual RefApplicationStatus RefApplicationStatus { get; set; }
        public int Score { get; set; }
        public Guid Key { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}