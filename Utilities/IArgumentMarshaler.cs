
using System.Collections.Generic;

namespace Utilities
{
    public interface IArgumentMarshaler
    {
        void Set(List<string>.Enumerator currentArgument);

        object GetValue();
    }
}
