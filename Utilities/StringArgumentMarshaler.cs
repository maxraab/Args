
using System;
namespace Utilities
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        public string _stringValue;

        #region IArgumentMarshaler Member

        public void Set(System.Collections.Generic.List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                _stringValue = currentArgument.Current;
            }
            catch (InvalidOperationException)
            {
                throw new ArgsException(ErrorCode.Missing_String);
            }
        }

        public object GetValue()
        {
            return _stringValue;
        }

        #endregion
    }
}
