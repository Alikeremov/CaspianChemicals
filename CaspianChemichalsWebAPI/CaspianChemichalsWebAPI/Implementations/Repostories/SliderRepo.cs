using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Implementations.Repostories.Generic;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class SliderRepo : Repository<Slider>,ISliderRepo
    {
        public SliderRepo(AppDbContext context) : base(context)
        {
        }
    }
}
