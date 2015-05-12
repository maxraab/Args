using System;
using System.Collections.Generic;

namespace Utilities
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        private string _value;

        #region IArgumentMarshaler Member

        public void SetArgument(IEnumerator<string> argument)
        {
            try
            {
                argument.MoveNext();
                _value = argument.Current;
            }
            catch (InvalidOperationException)
            {
                throw new ArgsException(ErrorCode.MissingString, argument.Current);
            }
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
