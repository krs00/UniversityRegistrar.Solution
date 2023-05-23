using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models
{
  public class Major
  {
    public int MajorId { get; set; }
    [Required(ErrorMessage = "Major must have a name!")]
    public string Name { get; set; }
    public int DepartmentId { get; set; } // FOREIGN KEY 
    public Department Department { get; set; } // REFERENCE NAVIGATION PROPERTY
  }
}