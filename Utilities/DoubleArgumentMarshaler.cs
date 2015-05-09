using System;
using System.Collections.Generic;

namespace Utilities
{
    public class DoubleArgumentMarshaler : IArgumentMarshaler
    {
        public double _doubleValue;

        #region IArgumentMarshaler Member

        public void Set(List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                _doubleValue = double.Parse(currentArgument.Current);
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
            return _doubleValue;
        }

        #endregion
    }
}
