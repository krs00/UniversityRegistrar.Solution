using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    [Required(ErrorMessage = "You must input a name for the student")]
    public string Name { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Student must have enrollment date")]
    public DateTime DOE { get; set; }
    public List<CourseStudent> JoinEntities { get; }
    public int DepartmentId { get; set; }
  }
}