﻿namespace Utilities
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        private bool _value;

        #region IArgumentMarshaler Member

        public void Set(System.Collections.Generic.List<string>.Enumerator currentArgument)
        {
            _value = true;
        }

        public object GetValue()
        {
            return _value;
        }

        #endregion
    }
}
