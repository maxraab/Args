namespace Utilities
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        private bool _value;

        #region IArgumentMarshaler Member

        public void SetArgument(System.Collections.Generic.List<string>.Enumerator argument)
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
