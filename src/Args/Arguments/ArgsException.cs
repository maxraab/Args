using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Arguments
{
    [Serializable]
    public class ArgsException : Exception
    {
        public ArgsException(ErrorCode errorCode, string errorParameters)
        {
            ErrorCode = errorCode;
            ErrorParameter = errorParameters;
        }

        public ArgsException(ErrorCode errorCode, string errorParameters, char errorArgumentId)
        {
            ErrorCode = errorCode;
            ErrorParameter = errorParameters;
            ErrorArgumentId = errorArgumentId;
        }

        protected ArgsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ArgsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ArgsException(string message)
            : base(message)
        {
        }

        public ArgsException()
            : base()
        {
        }

        public string ErrorParameter
        {
            get;
            set;
        }
        public ErrorCode ErrorCode
        {
            get;
            set;
        }

        public char ErrorArgumentId
        {
            get;
            set;
        }

        public string ErrorMessage()
        {
            var errorMessage = string.Empty;

            switch (ErrorCode)
            {
                case ErrorCode.UnexpectedArgument:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "Argument -{0} unexpected.", ErrorArgumentId);
                    break;
                case ErrorCode.MissingString:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "Could not find string parameter for -{0}.", ErrorArgumentId);
                    break;
                case ErrorCode.InvalidInteger:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "Argument -{0} expects an integer but was '{1}'.",
                        ErrorArgumentId, ErrorParameter);
                    break;
                case ErrorCode.MissingInteger:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "Could not find integer parameter for -{0}.", ErrorArgumentId);
                    break;
                case ErrorCode.InvalidDouble:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "Argument -{0} expects a double but was '{1}'.",
                        ErrorArgumentId, ErrorParameter);
                    break;
                case ErrorCode.MissingDouble:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "Could not find double parameter for -{0}.", ErrorArgumentId);
                    break;
                case ErrorCode.InvalidArgumentName:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "'{0}' is not a valid argument name.", ErrorArgumentId);
                    break;
                case ErrorCode.InvalidArgumentFormat:
                    errorMessage = string.Format(CultureInfo.CurrentCulture, "'{0}' is not a valid argument format.", ErrorParameter);
                    break;
            }

            return errorMessage;
        }
    }
}
