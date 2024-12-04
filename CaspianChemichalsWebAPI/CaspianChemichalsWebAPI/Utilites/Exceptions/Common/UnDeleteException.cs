using CaspianChemichalsWebAPI.Utilites.Exceptions.Generic;

namespace CaspianChemichalsWebAPI.Utilites.Exceptions.Common
{
    public class UnDeleteException:Exception,IBaseException
    {
        public UnDeleteException(string message = "This item can't delete") : base(message)
        {
        }
    }
}
