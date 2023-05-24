using Microsoft.AspNetCore.Identity;
using PracticeProject.Data;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Data.Entities
{
    public class User:IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }


        public ICollection<Advert>? Adverts { get; set; }
    }
}
