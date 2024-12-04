using CaspianChemichalsWebAPI.Utilites.Exceptions.Generic;

namespace CaspianChemichalsWebAPI.Utilites.Exceptions.Common
{
    public class ImageNotValidateException:Exception,IBaseException
    {
        public ImageNotValidateException(string message = "Image is not validate") : base(message)
        {

        }
    }
}
