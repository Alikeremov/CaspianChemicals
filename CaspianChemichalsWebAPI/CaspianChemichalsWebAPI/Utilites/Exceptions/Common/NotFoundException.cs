using CaspianChemichalsWebAPI.Utilites.Exceptions.Generic;

namespace CaspianChemichalsWebAPI.Utilites.Exceptions.Common
{
    public class NotFoundException:Exception,IBaseException
    {
        public NotFoundException(string message = "Not Found.. ") : base(message)
        {
        }
    }
}
