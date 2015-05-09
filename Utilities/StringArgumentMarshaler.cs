using System;

namespace Utilities
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        private string _value;

        #region IArgumentMarshaler Member

        public void SetArgument(System.Collections.Generic.List<string>.Enumerator argument)
        {
            try
            {
                argument.MoveNext();
                _value = argument.Current;
            }
            catch (InvalidOperationException)
            {
                throw new ArgsException(ErrorCode.MissingString, argument.Current);
            }
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
