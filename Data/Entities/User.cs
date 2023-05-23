using Microsoft.AspNetCore.Identity;
using PracticeProject.Data;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class User:IdentityUser
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }

        public bool is_active { get; set; }

        public DateTime created_at { get; set; }


        public ICollection<Advert> Adverts { get; set; }
    }
}
