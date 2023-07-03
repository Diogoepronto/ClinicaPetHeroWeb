using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaPetHeroWeb.Data.Entities.Abstract
{
    public abstract class Person : IEntity
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public string Gender { get; set; }


        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }


        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


        public string Phone { get; set; }


        public User User { get; set; }


        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
