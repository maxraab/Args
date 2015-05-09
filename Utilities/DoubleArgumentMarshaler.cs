using System;
using System.Collections.Generic;

namespace Utilities
{
    public class DoubleArgumentMarshaler : IArgumentMarshaler
    {
        public double _value;

        #region IArgumentMarshaler Member

        public void Set(List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                _value = double.Parse(currentArgument.Current);
            }
            catch (ArgumentNullException)
            {
                throw new ArgsException(ErrorCode.Missing_Double, currentArgument.Current);
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.Invalid_Double, currentArgument.Current);
            }
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
