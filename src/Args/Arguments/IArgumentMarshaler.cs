using System.Collections.Generic;

namespace Arguments
{
    public interface IArgumentMarshaler
    {
        void SetArgument(IEnumerator<string> argument);

        object GetValue();
    }
}
