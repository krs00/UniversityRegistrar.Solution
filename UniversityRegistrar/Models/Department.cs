using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models
{
  public class Department
  {
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "Department must have a name!")]
    public string Name { get; set; }
    public List<Student> Students { get; }
    public List<Course> Courses { get; }
  }
}