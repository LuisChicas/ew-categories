using System;

namespace EasyWallet.Categories.Business.Exceptions
{
    public class DuplicatedKeywordNameException : ArgumentException
    {
        public DuplicatedKeywordNameException()
        {
        }

        public DuplicatedKeywordNameException(string message) : base(message)
        {
        }

        public DuplicatedKeywordNameException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
