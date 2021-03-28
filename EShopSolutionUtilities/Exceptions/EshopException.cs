using System;
using System.Collections.Generic;
using System.Text;

namespace EShopSolutionUtilities.Exceptions
{
    public class EshopException : Exception
    {
        public EshopException()
        {

        }
        public EshopException(string mess)
                :base(mess)
        {

        }
        public EshopException(string message, Exception inner)
            :base(message,inner)
        {

        }
    }
}
