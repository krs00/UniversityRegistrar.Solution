using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public int CourseId { get; set; }
    [Required(ErrorMessage = "Course must have a name!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must enter course name!")]
    public string CourseNumber { get; set; }
    public List<CourseStudent> JoinEntities { get; }

  }
}