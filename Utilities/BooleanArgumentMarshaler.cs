
namespace Utilities
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        private bool _booleanValue;

        #region IArgumentMarshaler Member

        public void Set(System.Collections.Generic.List<string>.Enumerator currentArgument)
        {
            _booleanValue = true;
        }

        public object GetValue()
        {
            return _booleanValue;
        }

        #endregion
    }
}
