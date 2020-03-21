using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ekipage.Models
{
    public class Horse
    {

        //PK
        public int HorseId { get; set; }

        [Required]
        [Display(Name = "Häst")]
        public string HorseName { get; set; }

        [Display(Name = "Humör")]
        public string HorseTemper { get; set; }

        [Display(Name = "Om hästen")]
        public string HorseDescription { get; set; }


        //Länkar till ryttaren
        public ICollection<Rider> Riders { get; set; }


        public Horse()
        {
        }
    }
}
