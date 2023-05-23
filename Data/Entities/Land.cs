using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Land
    {
        [Key]
        public int land_id { get; set; }
        public int advert_id { get; set; }

        public string type_of_land { get; set; }
        public int area { get; set; }
        public short area_dimension { get; set; }


        public Advert? Advert { get; set; }
    }
}
