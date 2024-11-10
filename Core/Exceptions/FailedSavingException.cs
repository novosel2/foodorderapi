using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class FailedSavingException : Exception
    {
        public FailedSavingException()
        {
        }

        public FailedSavingException(string? message) : base(message)
        {
        }

        public FailedSavingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedSavingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
