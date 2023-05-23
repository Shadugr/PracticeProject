using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Flat
    {
        [Key]
        public int flat_id { get; set; }
        public int AdvertId { get; set; }

        public int floor { get; set; }
        public int storey { get; set; }

        public int square { get; set; }
        public int building_age { get; set; }


        public Advert? Advert { get; set; }
    }
}
