using System;
using System.Collections.Generic;

namespace Utilities
{
    public class DoubleArgumentMarshaler : IArgumentMarshaler
    {
        public double DoubleValue
        {
            get;
            set;
        }

        public static double GetValue(IArgumentMarshaler am)
        {
            if (am != null && am is DoubleArgumentMarshaler)
            {
                return ((DoubleArgumentMarshaler)am).DoubleValue;
            }

            return 0.0;
        }

        #region IArgumentMarshaler Member

        public void Set(List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                DoubleValue = double.Parse(currentArgument.Current);
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

        #endregion
    }
}
