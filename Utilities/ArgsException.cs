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
            var errorMessage = string.Empty;

            switch (ErrorCode)
            {
                case ErrorCode.Ok:
                    errorMessage = "TILT: Should not get here.";
                    break;
                case ErrorCode.Unexpected_Argument:
                    errorMessage = string.Format("Argument -{0} unexpected.", ErrorArgumentId);
                    break;
                case ErrorCode.Missing_String:
                    errorMessage = string.Format("Could not find string parameter for -{0}.", ErrorArgumentId);
                    break;
                case ErrorCode.Invalid_Integer:
                    errorMessage = string.Format("Argument -{0} expects an integer but was '{1}'.", ErrorArgumentId, ErrorParameter);
                    break;
                case ErrorCode.Missing_Integer:
                    errorMessage = string.Format("Could not find integer parameter for -{0}.", ErrorArgumentId);
                    break;
                case ErrorCode.Invalid_Double:
                    errorMessage = string.Format("Argument -{0} expects a double but was '{1}'.", ErrorArgumentId, ErrorParameter);
                    break;
                case ErrorCode.Missing_Double:
                    errorMessage = string.Format("Could not find double parameter for -{0}.", ErrorArgumentId);
                    break;
                case ErrorCode.Invalid_Argument_Name:
                    errorMessage = string.Format("'{0}' is not a valid argument name.", ErrorArgumentId);
                    break;
                case ErrorCode.Invalid_Argument_Format:
                    errorMessage = string.Format("'{0}' is not a valid argument format.", ErrorParameter);
                    break;
            }

            return errorMessage;
        }
    }
}
