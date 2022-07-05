using System;

namespace SalesApp.Production.Api.Infrastructure.Data.Exceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(string Message) : base(Message)
        {

        }
    }
}
