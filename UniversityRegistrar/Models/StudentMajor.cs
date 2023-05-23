namespace UniversityRegistrar.Models
{
  public class StudentMajor
  {
    public int StudentMajorId { get; set; }
    public Student Student { get; set; } // REFERENCE NAVIGATION PROPERTY
    public int StudentId { get; set; } // NAVIGATION PROPERTY

    public Major Major { get; set; }// REFERENCE NAVIGATION PROPERTY
    public int MajorId { get; set; } // NAVIGATION PROPERTY
  }
}