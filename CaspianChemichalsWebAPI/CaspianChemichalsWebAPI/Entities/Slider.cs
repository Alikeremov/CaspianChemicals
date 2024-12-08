using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class Slider:BaseEntity
    {
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Order { get; set; }
        //Relational properties 
        public ICollection<SliderTranslate> Translates { get; set; }
    }
}
