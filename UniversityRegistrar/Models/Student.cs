using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models
{
  public class Student
  {
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime DOE { get; set; }
    public List<CourseStudent> JoinEntities { get; }
  }
}