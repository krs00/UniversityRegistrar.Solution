using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public DepartmentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Department> model = _db.Departments.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Department Department)
    {
      if (!ModelState.IsValid)
      {
        return View(Department);
      }
      else
      {
        _db.Departments.Add(Department);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Department thisDepartment = _db.Departments
                          .Include(Department => Department.Courses)
                          // .ThenInclude(course => course.Student)
                          .FirstOrDefault(Department => Department.DepartmentId == id);
      return View(thisDepartment);
    }

    public ActionResult Edit(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department)
    {
      _db.Departments.Update(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      _db.Departments.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

//     public ActionResult AddCourse(int id)
//     {
//       Department thisDepartment = _db.Departments.FirstOrDefault(Department => Department.DepartmentId == id);
//       ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
//       return View(thisDepartment);
//     }

//     [HttpPost]
//     public ActionResult AddCourse(Department department, int courseId)
//     {
// #nullable enable
//       Departmentstudent? joinEntity = _db.Departmentstudents.FirstOrDefault(join => join.StudentId == studentId && join.DepartmentId == Department.DepartmentId);
// #nullable disable
//       if (joinEntity == null && studentId != 0)
//       {
//         _db.Departmentstudents.Add(new Departmentstudent() { DepartmentId = Department.DepartmentId, StudentId = studentId });
//         _db.SaveChanges();
//       }
//       return RedirectToAction("Details", new { id = Department.DepartmentId });
//     }
  }
}