using System;
using System.Collections.Generic;

namespace Utilities
{
    public class IntegerArgumentMarshaler : IArgumentMarshaler
    {
        public int _intValue;

        #region IArgumentMarshaler Member

        public void Set(List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                _intValue = int.Parse(currentArgument.Current);
            }
            catch (ArgumentNullException)
            {
                throw new ArgsException(ErrorCode.Missing_Integer, currentArgument.Current);
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.Invalid_Integer, currentArgument.Current);
            }
        }

        public object GetValue()
        {
            return _intValue;
        }

        #endregion
    }
}
