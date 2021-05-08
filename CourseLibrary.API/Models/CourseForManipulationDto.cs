﻿using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public abstract  class CourseForManipulationDto
    {
        [CourseTitleMustBeDifferentFromDescription(ErrorMessage = "Title must be different from description")]
       

            [Required(ErrorMessage = "You should fill out a title.")]
            [MaxLength(100, ErrorMessage = "the title shouldn't have more than 100 characters.")]
            public string Title { get; set; }

            [MaxLength(1500, ErrorMessage = "The description should't have more than 1500 characters.")]
            public virtual string Description { get; set; }

        
    }
}
