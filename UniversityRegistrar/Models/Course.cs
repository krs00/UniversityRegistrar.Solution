using System.Collections.Generic;
using System;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string CourseNumber { get; set; }
    public List<CourseStudent> JoinEntities { get; }

  }
}