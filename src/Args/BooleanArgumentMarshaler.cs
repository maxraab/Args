using System.Collections.Generic;

namespace Arguments
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        private bool _value;

        #region IArgumentMarshaler Member

        public void SetArgument(IEnumerator<string> argument)
        {
            _value = true;
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
