using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal
{
    [Serializable]
    public class NoGameFoundOwlException : Exception
    {
        public const short ExceptionId = 0;

        public NoGameFoundOwlException() { }
        public NoGameFoundOwlException(string message)
            : base(message) { }
        public NoGameFoundOwlException(string message, Exception inner)
            : base(message, inner) { }
    }
    [Serializable]
    public class NoGameModulesFoundOwlException : Exception
    {
        public const short ExceptionId = 1;

        public NoGameModulesFoundOwlException() { }
        public NoGameModulesFoundOwlException(string message)
            : base(message) { }
        public NoGameModulesFoundOwlException(string message, Exception inner)
            : base(message, inner) { }
    }
    [Serializable]
    public class ZeroPointerReadOwlException : Exception
    {
        public const short ExceptionId = 2;

        public ZeroPointerReadOwlException() { }
        public ZeroPointerReadOwlException(string message)
            : base(message) { }
        public ZeroPointerReadOwlException(string message, Exception inner)
            : base(message, inner) { }
    }
    [Serializable]
    public class OutOfMemoryReaderCacheOwlException : Exception
    {
        public const short ExceptionId = 3;

        public OutOfMemoryReaderCacheOwlException() { }
        public OutOfMemoryReaderCacheOwlException(string message)
            : base(message) { }
        public OutOfMemoryReaderCacheOwlException(string message, Exception inner)
            : base(message, inner) { }
    }
    [Serializable]
    public class OpenProcessOwlException : Exception
    {
        public const short ExceptionId = 4;

        public OpenProcessOwlException() { }
        public OpenProcessOwlException(string message)
            : base(message) { }
        public OpenProcessOwlException(string message, Exception inner)
            : base(message, inner) { }
    }
}
