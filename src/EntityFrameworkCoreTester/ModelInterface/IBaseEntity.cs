using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreTester.ModelInterface
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
