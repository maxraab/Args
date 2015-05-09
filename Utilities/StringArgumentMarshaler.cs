
using System;
namespace Utilities
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        public string StringValue
        {
            get;
            set;
        }

        public static string GetValue(IArgumentMarshaler am)
        {
            if (am != null && am is StringArgumentMarshaler)
            {
                return ((StringArgumentMarshaler)am).StringValue;
            }

            return string.Empty;
        }

        #region IArgumentMarshaler Member

        public void Set(System.Collections.Generic.List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                StringValue = currentArgument.Current;
            }
            catch (InvalidOperationException)
            {
                throw new ArgsException(ErrorCode.Missing_String);
            }
        }

        #endregion
    }
}
