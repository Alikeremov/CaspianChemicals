using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class OurPartnerTranslate: BaseEntityTranslateNameable
    {
        //Relational properties 
        public int OurPartnerId { get; set; }
        public OurPartner OurPartner { get; set; }
    }
}
