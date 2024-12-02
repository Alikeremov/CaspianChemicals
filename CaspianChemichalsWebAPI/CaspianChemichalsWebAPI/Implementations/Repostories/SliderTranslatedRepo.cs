using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Implementations.Repostories.Generic;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class SliderTranslatedRepo : TranslatedRepo<SliderTranslate>, ISliderTranslateRepo
    {
        public SliderTranslatedRepo(AppDbContext context) : base(context)
        {
        }
    }
}
