using CaspianChemichalsWebAPI.Utilites.Exceptions.Generic;

namespace CaspianChemichalsWebAPI.Utilites.Exceptions.Common
{
    public class BadRequestException:Exception,IBaseException
    {
        public BadRequestException(string message = "Bad Request.. ") : base(message)
        {
        }
    }
}
