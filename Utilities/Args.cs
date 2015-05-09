using System;
using System.Collections.Generic;
using System.Globalization;

namespace Utilities
{
    public class Args
    {
        private string _schema;
        private Dictionary<char, IArgumentMarshaler> _marshalers;
        private List<char> _argsFound;
        private List<string>.Enumerator _currentArgument;

        public Args(string schema, string[] args)
        {
            _schema = schema;
            _marshalers = new Dictionary<char, IArgumentMarshaler>();
            _argsFound = new List<char>();

            ParseSchema(_schema);
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
            else if (elementTail.Equals("##"))
            {
                _marshalers.Add(elementId, new DoubleArgumentMarshaler());
            }
            else
            {
                throw new ArgsException(ErrorCode.InvalidArgumentFormat, elementTail, elementId);
            }
        }

        private static void ValidateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
            {
                throw new ArgsException(ErrorCode.InvalidArgumentName, null, elementId);
            }
        }

        private void ParseArgumentStrings(List<string> argsList)
        {
            for (_currentArgument = argsList.GetEnumerator(); _currentArgument.MoveNext(); )
            {
                var argsString = _currentArgument.Current;

                if (argsString.StartsWith("-", StringComparison.Ordinal))
                {
                    ParseArgumentCharacters(argsString.Substring(1));
                }
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
            IArgumentMarshaler marshaler;
            if (!_marshalers.TryGetValue(argChar, out marshaler))
            {
                throw new ArgsException(ErrorCode.UnexpectedArgument, null, argChar);
            }

            _argsFound.Add(argChar);

            try
            {
                marshaler.SetArgument(_currentArgument);
            }
            catch (ArgsException e)
            {
                e.ErrorArgumentId = argChar;
                throw;
            }
        }

        public bool GetBoolean(char arg)
        {
            return GetValue<bool>(arg);
        }

        public string GetString(char arg)
        {
            return GetValue<string>(arg);
        }

        public int GetInteger(char arg)
        {
            return GetValue<int>(arg);
        }

        public double GetDouble(char arg)
        {
            return GetValue<double>(arg);
        }

        private T GetValue<T>(char arg)
        {
            IArgumentMarshaler marshaler;
            T result = default(T);
            if (_marshalers.TryGetValue(arg, out marshaler))
            {
                try
                {
                    result = (T)marshaler.GetValue();
                }
                catch (InvalidCastException)
                {
                    result = default(T);
                }
            }
            return result;
        }

        public int Cardinality()
        {
            return _argsFound.Count;
        }

        public string Usage()
        {
            var usage = string.Empty;

            if (_schema.Length > 0)
            {
                usage = string.Format(CultureInfo.CurrentCulture, "Usage: -[{0}]", _schema);
            }

            return usage;
        }

        public bool Has(char arg)
        {
            return _argsFound.Contains(arg);
        }
    }
}
