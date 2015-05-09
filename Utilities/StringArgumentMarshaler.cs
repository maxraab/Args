using System;

namespace Utilities
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        public string _value;

        #region IArgumentMarshaler Member

        public void Set(System.Collections.Generic.List<string>.Enumerator currentArgument)
        {
            try
            {
                currentArgument.MoveNext();
                _value = currentArgument.Current;
            }
            catch (InvalidOperationException)
            {
                throw new ArgsException(ErrorCode.Missing_String);
            }
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
