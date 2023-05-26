using PracticeProject.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeProject.Data.Entities
{
    public class Advert
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [StringLength(20)]
        public string? PathToProperty { get; set; }

        public string Title { get; set; }
        [StringLength(40)]
        public string Location { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Price { get; set; }

        public int ViewNumber { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }


        public User User { get; set; }
        public Flat? Flat { get; set; }
        public Land? Land { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
