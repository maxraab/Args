using System;
using System.Collections.Generic;
using System.Globalization;

namespace Utilities
{
    public class DoubleArgumentMarshaler : IArgumentMarshaler
    {
        private double _value;

        #region IArgumentMarshaler Member

        public void SetArgument(List<string>.Enumerator argument)
        {
            try
            {
                argument.MoveNext();
                _value = double.Parse(argument.Current, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException)
            {
                throw new ArgsException(ErrorCode.MissingDouble, argument.Current);
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.InvalidDouble, argument.Current);
            }
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
