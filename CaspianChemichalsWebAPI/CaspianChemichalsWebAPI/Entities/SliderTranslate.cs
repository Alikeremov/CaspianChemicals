using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class SliderTranslate:BaseEntityTranslate
    {
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        //Relational properties
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
