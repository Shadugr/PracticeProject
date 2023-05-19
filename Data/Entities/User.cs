using PracticeProject.Data;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }

        [Required, StringLength(12)]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }

        public bool is_active { get; set; }

        public DateTime created_at { get; set; }


        public ICollection<Advert> Adverts { get; set; }
    }
}
