using System;
using System.ComponentModel.DataAnnotations;

namespace ekipage.Models
{
    public class DateForLesson
    {

        //PK
        public int DateForLessonId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum för ridlektionen")]
        public DateTime Date { get; set; }

        //FK
        public int LessonContentId { get; set; }

        //Navigering
        [Display(Name = "Typ av lektion")]
        public LessonContent LessonContent { get; set; }


        public DateForLesson()
        {
        }
    }
}
