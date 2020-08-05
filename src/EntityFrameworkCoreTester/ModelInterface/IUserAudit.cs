using System;

namespace EntityFrameworkCoreTester.ModelInterface
{
    public interface IUserAudit
    {
        Guid CreatorUserKey { get; set; }
        Guid? ModifierUserKey { get; set; }
    }
}