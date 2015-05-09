
using System.Collections.Generic;
namespace Utilities
{
    public class Args
    {
        private Dictionary<char, IArgumentMarshaler> _marshalers;
        private List<char> _argsFound;
        private IEnumerable<string> currentArgument;

        public Args(string shema, string[] args)
        {
            _marshalers = new Dictionary<char, IArgumentMarshaler>();
            _argsFound = new List<char>();

            ParseSchema(shema);
            ParseArgumentStrings(new List<string>(args));
        }

        private void ParseSchema(string schema)
        {
            foreach (var element in schema.Split(','))
            {
                if (element.Length > 0)
                {
                    ParseSchemaElement(element.Trim());
                }
            }
        }

        private void ParseSchemaElement(string element)
        {
            var elementId = element[0];
            var elementTail = element.Substring(1);

            ValidateSchemaElementId(elementId);
        }

        private void ValidateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
            {
                throw new ArgsException(ErrorCode.Invalid_Argument_Name, elementId, null);
            }
        }

        private void ParseArgumentStrings(List<string> list)
        {
            throw new System.NotImplementedException();
        }
    }
}
