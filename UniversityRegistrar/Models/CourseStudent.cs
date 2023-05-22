using System.Collections.Generic;
using System;

namespace UniversityRegistrar.Models
{
  public class CourseStudent
  {
    public int CourseStudentId { get; set; }
    public Student Student { get; set; } // REFERENCE NAVIGATION PROPERTY
    public int StudentId { get; set; } // NAVIGATION PROPERTY

    public Course Course { get; set; }// REFERENCE NAVIGATION PROPERTY
    public int CourseId { get; set; } // NAVIGATION PROPERTY
  }
}