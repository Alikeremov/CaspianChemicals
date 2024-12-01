using CaspianChemichalsWebAPI.Abstraction.Repostories.Generic;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities.BaseEntities;
using CaspianChemichalsWebAPI.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class TranslatedRepo<Ttranslate> : Repository<Ttranslate>, ITranslatedRepo<Ttranslate> where Ttranslate : BaseEntityTranslate, new()
    {

        public TranslatedRepo(AppDbContext context) : base(context)
        { 
        }
        public IQueryable<Ttranslate> GetAllTranslated(Language language = Language.AZ,
    bool isTracking = false, bool QueryFilter = false, params string[] includes)
        {
            var query = _dbSet.AsQueryable().Where(x => x.Language == language);

            foreach (var include in includes)
                query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<Ttranslate> GetAllWhereTranslated(
            Expression<Func<Ttranslate, bool>>? expression = null,
            Expression<Func<Ttranslate, object>>? orderexpression = null,
            Language language = Language.AZ,
            bool isDescending = false, bool isTracking = false, bool queryFilter = false,
            int skip = 0, int take = 0, params string[] includes)
        {
            var query = _dbSet.AsQueryable().Where(x => x.Language == language);

            if (expression != null)
                query = query.Where(expression);

            if (orderexpression != null)
                query = isDescending ? query.OrderByDescending(orderexpression) : query.OrderBy(orderexpression);

            foreach (var include in includes)
                query = query.Include(include);
            
            query = query.Skip(skip).Take(take);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<Ttranslate> GetByIdTranslatedAsync(int id, Language language = Language.AZ,
    bool isTracking = false, bool QueryFilter = false, params string[] includes)
        {
            var query = _dbSet.AsQueryable().Where(x => x.Id == id && x.Language == language);

            foreach (var include in includes)
                query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Ttranslate> GetByExpressionTranslatedAsync(
    Expression<Func<Ttranslate, bool>> expression,
    Language language = Language.AZ,
    bool isTracking = false, bool QueryFilter = false, params string[] includes)
        {
            var query = _dbSet.AsQueryable().Where(x => x.Language == language).Where(expression);
            foreach (var include in includes)
                query = query.Include(include);
            if (!isTracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}
