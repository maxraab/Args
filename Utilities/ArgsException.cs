using System;

namespace Utilities
{
    public class ArgsException : Exception
    {
        public ArgsException()
        {
        }

        public ArgsException(ErrorCode errorCode)
        {
            ErrorCode = errorCode;
        }

        public ArgsException(ErrorCode errorCode, string errorParameters)
        {
            ErrorCode = errorCode;
            ErrorParameter = errorParameters;
        }


        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameters)
        {
            ErrorCode = errorCode;
            ErrorArgumentId = errorArgumentId;
            ErrorParameter = errorParameters;
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
            switch (ErrorCode)
            {
                case ErrorCode.Ok:
                    return "TILT: Should not get here.";
                case ErrorCode.Unexpected_Argument:
                    return string.Format("Argument -{0} unexpected.", ErrorArgumentId);
                case ErrorCode.Missing_String:
                    return string.Format("Could not find string parameter for -{0}.", ErrorArgumentId);
                case ErrorCode.Invalid_Integer:
                    return string.Format("Argument -{0} expects an integer but was '{1}'.", ErrorArgumentId, ErrorParameter);
                case ErrorCode.Missing_Integer:
                    return string.Format("Could not find integer parameter for -{0}.", ErrorArgumentId);
                case ErrorCode.Invalid_Double:
                    return string.Format("Argument -{0} expects a double but was '{1}'.", ErrorArgumentId, ErrorParameter);
                case ErrorCode.Missing_Double:
                    return string.Format("Could not find double parameter for -{0}.", ErrorArgumentId);
                case ErrorCode.Invalid_Argument_Name:
                    return string.Format("'{0}' is not a valid argument name.", ErrorArgumentId);
                case ErrorCode.Invalid_Argument_Format:
                    return string.Format("'{0}' is not a valid argument format.", ErrorParameter);
            }

            return string.Empty;
        }
    }
}
