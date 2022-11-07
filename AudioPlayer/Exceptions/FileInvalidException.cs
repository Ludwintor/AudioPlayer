using System;

namespace AudioPlayer.Exceptions
{
    public class FileInvalidException : IOException
    {
        public FileInvalidException() : this(null, null, null) { }

        public FileInvalidException(string? message) : this(message, null, null) { }

        public FileInvalidException(string? message, string? fileName) : this(message, fileName, null) { }

        public FileInvalidException(string? message, Exception? innerException) : this(message, null, innerException) { }

        public FileInvalidException(string? message, string? fileName, Exception? innerException) : base(message, innerException)
        {
            FileName = fileName;
        }

        public string? FileName { get; }
    }
}
