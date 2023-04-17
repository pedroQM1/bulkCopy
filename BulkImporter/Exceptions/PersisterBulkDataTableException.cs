using System;

namespace BulkImporter.Exceptions
{
    public class PersisterBulkDataTableException : Exception
    {
        public PersisterBulkDataTableException(string? message) : base(message)
        {
        }
        public PersisterBulkDataTableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
