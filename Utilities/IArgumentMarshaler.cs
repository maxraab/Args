
using System.Collections.Generic;

namespace Utilities
{
    public interface IArgumentMarshaler
    {
        void SetArgument(List<string>.Enumerator argument);

        object GetValue();
    }
}
