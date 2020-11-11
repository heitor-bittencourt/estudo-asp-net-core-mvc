using System;

namespace WebVendasMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
