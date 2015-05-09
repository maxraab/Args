
using System.Collections.Generic;
namespace Utilities
{
    public class Args
    {
        private Dictionary<char, IArgumentMarshaler> _marshalers;
        private List<char> _argsFound;
        private List<string>.Enumerator _currentArgument;

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

            if (elementTail.Length == 0)
            {
                _marshalers.Add(elementId, new BooleanArgumentMarshaler());
            }
            else if (elementTail.Equals("*"))
            {
                _marshalers.Add(elementId, new StringArgumentMarshaler());
            }
            else if (elementTail.Equals("#"))
            {
                _marshalers.Add(elementId, new IntegerArgumentMarshaler());
            }
            else
            {
                throw new ArgsException(ErrorCode.Invalid_Argument_Format, elementId, elementTail);
            }
        }

        private void ValidateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
            {
                throw new ArgsException(ErrorCode.Invalid_Argument_Name, elementId, null);
            }
        }

        private void ParseArgumentStrings(List<string> argsList)
        {
            for (_currentArgument = argsList.GetEnumerator(); _currentArgument.MoveNext(); )
            {
                var previousArgument = _currentArgument;
                var argsString = _currentArgument.Current;

                if (argsString.StartsWith("-"))
                {
                    ParseArgumentCharacters(argsString.Substring(1));
                }
                //else
                //{
                //    _currentArgument = previousArgument;
                //    break;
                //}
            }
        }

        private void ParseArgumentCharacters(string argChars)
        {
            for (var i = 0; i < argChars.Length; i++)
            {
                ParseArgumentCharacter(argChars[i]);
            }
        }

        private void ParseArgumentCharacter(char argChar)
        {
            var m = _marshalers[argChar];

            if (m == null)
            {
                throw new ArgsException(ErrorCode.Unexpected_Argument, argChar, null);
            }

            _argsFound.Add(argChar);

            try
            {
                m.Set(_currentArgument);
            }
            catch (ArgsException e)
            {
                e.ErrorArgumentId = argChar;
                throw;
            }
        }

        public bool Has(char arg)
        {
            return _argsFound.Contains(arg);
        }

        public int NextArgument()
        {
            return 0;
        }

        public bool GetBoolean(char arg)
        {
            return BooleanArgumentMarshaler.GetValue(_marshalers[arg]);
        }

        public string GetString(char arg)
        {
            return StringArgumentMarshaler.GetValue(_marshalers[arg]);
        }

        public int GetInteger(char arg)
        {
            return IntegerArgumentMarshaler.GetValue(_marshalers[arg]);
        }
    }
}
