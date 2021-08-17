#nullable enable
using System;

namespace RelationshipApi.Helpers.CustomiseExceptions
{
    public class ProductApiValidationException : Exception
    {
        public ProductApiValidationException(string message)
            : base(message)
        {
            Message = message;
        }

        public ProductApiValidationException(string message, Exception inner)
            : base(message, inner)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}