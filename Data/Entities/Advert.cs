using PracticeProject.Data;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class Advert
    {
        public string UserId { get; set; }
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string path_to_property { get; set; }

        public string title { get; set; }
        [StringLength(40)]
        public string location { get; set; }
        [StringLength(500)]
        public string description { get; set; }
        public int price { get; set; }

        public int view_number { get; set; }
        public bool is_active { get; set; } = true;

        public DateTime created_at { get; set; }


        public User? User { get; set; }
        public Flat? Flat { get; set; }
        public Land? Land { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
