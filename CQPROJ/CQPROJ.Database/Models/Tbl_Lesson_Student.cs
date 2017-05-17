﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to the relationship between a Lesson and a Schedule
    public class Tbl_Lesson_Student
    {
        [Required]
        [ForeignKey("Lesson")]
        public Tbl_Lesson Lesson { get; set; }
        public int LessonFK { get; set; }

        [Required]
        [ForeignKey("Student")]
        public Tbl_Student Student { get; set; }
        public int StudentFK { get; set; }

        [Required]
        [DefaultValue(false)]
        public Boolean Presence { get; set; }

        [Required]
        [DefaultValue(false)]
        public Boolean Material { get; set; }

        [Required]
        public int Behavior { get; set; }
    }
}