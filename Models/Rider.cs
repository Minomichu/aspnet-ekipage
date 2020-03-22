using System;
using System.ComponentModel.DataAnnotations;

namespace ekipage.Models
{
    public class Rider
    {

        //PK
        public int RiderId { get; set; }

        [Required]
        [Display(Name = "Ryttare")]
        public string RiderName { get; set; }

        [Display(Name = "Ej hästhumör:")]
        public string Preference { get; set; }

        //FK - kopplar ihop med modellen
        public int HorseId { get; set; }

        //Navigering - visas på sidan
        [Display(Name = "Häst")]
        public Horse Horse { get; set; }


        public Rider()
        {
        }
    }
}
