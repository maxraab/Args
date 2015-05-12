using System;
using System.Collections.Generic;
using System.Globalization;

namespace Utilities
{
    public class IntegerArgumentMarshaler : IArgumentMarshaler
    {
        private int _value;

        #region IArgumentMarshaler Member

        public void SetArgument(IEnumerator<string> argument)
        {
            try
            {
                argument.MoveNext();
                _value = int.Parse(argument.Current, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException)
            {
                throw new ArgsException(ErrorCode.MissingInteger, argument.Current);
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.InvalidInteger, argument.Current);
            }
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
