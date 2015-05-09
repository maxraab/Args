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
        }

        public ArgsException(ErrorCode errorCode, string errorParameters)
        {
        }


        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameters)
        {
        }

        public char ErrorArgumentId
        {
            get;
            set;
        }
    }
}
