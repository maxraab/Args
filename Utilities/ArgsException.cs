﻿using System;

namespace Utilities
{
    class ArgsException : Exception
    {
        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameters)
        {
        }
    }
}