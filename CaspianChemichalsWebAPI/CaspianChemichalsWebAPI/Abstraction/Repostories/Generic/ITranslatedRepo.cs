using CaspianChemichalsWebAPI.Entities.BaseEntities;
using CaspianChemichalsWebAPI.Enums;
using System.Linq.Expressions;

namespace CaspianChemichalsWebAPI.Abstraction.Repostories.Generic
{
    public interface ITranslatedRepo<Ttranslate>:IRepository<Ttranslate> where Ttranslate : BaseEntityTranslate , new() 
    {
        IQueryable<Ttranslate> GetAllTranslated( Language language = Language.AZ, 
            bool isTracking = false, bool QueryFilter = false, params string[] includes);
        IQueryable<Ttranslate> GetAllWhereTranslated
            (
                Expression<Func<Ttranslate, bool>>? expression = null,
                Expression<Func<Ttranslate, object>>? orderexpression = null,
                 Language language = Language.AZ,
                 bool isDescending = false, bool isTracking = false, bool queryFilter = false,
                int skip = 0, int take = 0, params string[] includes
            );
        Task<Ttranslate> GetByIdTranslatedAsync(int id,Language language=Language.AZ, bool isTracking = false, bool QueryFilter = false, params string[] includes);
        Task<Ttranslate> GetByExpressionTranslatedAsync
            (
                Expression<Func<Ttranslate, bool>> expression, Language language = Language.AZ, bool isTracking = false,
                bool QueryFilter = false, params string[] includes
            );
    }
}
