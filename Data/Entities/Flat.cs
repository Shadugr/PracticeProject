using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }
        public int AdvertId { get; set; }

        public int Floor { get; set; }
        public int Storey { get; set; }

        public int Square { get; set; }
        public int BuildingAge { get; set; }


        public Advert? Advert { get; set; }
    }
}
