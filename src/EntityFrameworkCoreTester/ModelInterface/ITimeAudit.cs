using System;

namespace EntityFrameworkCoreTester.ModelInterface
{
    public interface ITimeAudit
    {
        DateTime CreationTime { get; set; }
        DateTime ModificationTime { get; set; }
    }
}