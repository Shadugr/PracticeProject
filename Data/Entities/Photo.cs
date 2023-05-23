using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Photo
    {
        [Key]
        public int photo_id { get; set; }
        public int advert_id { get; set; }

        public string path_to_file { get; set; }


        public Advert? Advert { get; set; }
    }
}
