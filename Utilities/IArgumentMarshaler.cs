using System.Collections.Generic;

namespace Utilities
{
    public interface IArgumentMarshaler
    {
        void SetArgument(IEnumerator<string> argument);

        object GetValue();
    }
}
