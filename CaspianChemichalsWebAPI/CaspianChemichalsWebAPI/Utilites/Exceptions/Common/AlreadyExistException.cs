using CaspianChemichalsWebAPI.Utilites.Exceptions.Generic;

namespace CaspianChemichalsWebAPI.Utilites.Exceptions.Common
{
    public class AlreadyExistException:Exception,IBaseException
    {
        public AlreadyExistException(string message = "This item already exist") : base(message)
        {
        }
    }
}
