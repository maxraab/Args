using System;
using System.Collections.Generic;

namespace Utilities
{
    public class IntegerArgumentMarshaler : IArgumentMarshaler
    {
        public int IntValue
        {
            get;
            set;
        }

        public static int GetValue(IArgumentMarshaler am)
        {
            if (am != null && am is IntegerArgumentMarshaler)
            {
                return ((IntegerArgumentMarshaler)am).IntValue;
            }

            return 0;
        }

        #region IArgumentMarshaler Member

        public void Set(List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                IntValue = int.Parse(currentArgument.Current);
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

        #endregion
    }
}
