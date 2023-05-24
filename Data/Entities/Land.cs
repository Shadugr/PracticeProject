using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Land
    {
        [Key]
        public int Id { get; set; }
        public int AdvertId { get; set; }

        public string? TypeOfLand { get; set; }
        public int Area { get; set; }
        public short AreaDimension { get; set; }


        public Advert? Advert { get; set; }
    }
}
