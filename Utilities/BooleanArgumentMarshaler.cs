
namespace Utilities
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        public bool BooleanValue
        {
            get;
            set;
        }

        public static bool GetValue(IArgumentMarshaler am)
        {
            if (am != null && am is BooleanArgumentMarshaler)
            {
                return ((BooleanArgumentMarshaler)am).BooleanValue;
            }

            return false;
        }
    }
}
