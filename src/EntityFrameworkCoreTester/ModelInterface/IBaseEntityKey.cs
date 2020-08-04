using System;

namespace EntityFrameworkCoreTester.ModelInterface
{
    public interface IBaseEntityKey
    {
        Guid Key { get; set; }
    }
}