using System;


namespace SalesApp.Production.Api.Infrastructure.Data.Exceptions
{
    public class CountryException : Exception
    {
        public CountryException(string Message) : base(Message)
        {

        }
    }
}
