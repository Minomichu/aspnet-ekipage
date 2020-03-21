using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ekipage.Models
{
    public class LessonContent
    {

        //PK
        public int LessonContentId { get; set; }

        [Required]
        [Display(Name = "Typ av lektion:")]
        public string Lesson { get; set; }

        //Länkar till datum
        public ICollection<DateForLesson> DateForLessons { get; set; }


        public LessonContent()
        {
        }
    }
}
