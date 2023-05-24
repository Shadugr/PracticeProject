using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public int AdvertId { get; set; }

        public string? PathToFile { get; set; }


        public Advert? Advert { get; set; }
    }
}
