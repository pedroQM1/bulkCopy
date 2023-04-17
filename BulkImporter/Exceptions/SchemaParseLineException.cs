using System;

namespace BulkImporter.Exceptions
{
    public class SchemaParseLineException : Exception
    {
        public SchemaParseLineException(string? message) : base(message)
        {
        }

        public SchemaParseLineException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
