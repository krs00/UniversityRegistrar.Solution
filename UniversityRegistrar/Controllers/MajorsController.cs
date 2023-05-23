using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class MajorsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public MajorsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Majors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Major major)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
        return View(major);
      }
      else
      {
        _db.Majors.Add(major);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Major thisMajor = _db.Majors
                          .Include(major => major.Department)
                          // .Include(major => major.JoinEntities)
                          // .ThenInclude(join => join.Student)
                          .FirstOrDefault(major => major.MajorId == id);
      return View(thisMajor);
    }

    public ActionResult Edit(int id)
    {
      Major thisMajor = _db.Majors.FirstOrDefault(major => major.MajorId == id);
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View(thisMajor);
    }

    [HttpPost]
    public ActionResult Edit(Major major)
    {
      _db.Majors.Update(major);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Major thisMajor = _db.Majors.FirstOrDefault(major => major.MajorId == id);
      return View(thisMajor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Major thisMajor = _db.Majors.FirstOrDefault(major => major.MajorId == id);
      _db.Majors.Remove(thisMajor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //     public ActionResult AddStudent(int id)
    //     {
    //       Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
    //       ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
    //       return View(thisCourse);
    //     }

    //     [HttpPost]
    //     public ActionResult AddStudent(Course course, int studentId)
    //     {
    // #nullable enable
    //       CourseStudent? joinEntity = _db.CourseStudents.FirstOrDefault(join => join.StudentId == studentId && join.CourseId == course.CourseId);
    // #nullable disable
    //       if (joinEntity == null && studentId != 0)
    //       {
    //         _db.CourseStudents.Add(new CourseStudent() { CourseId = course.CourseId, StudentId = studentId });
    //         _db.SaveChanges();
    //       }
    //       return RedirectToAction("Details", new { id = course.CourseId });
    //     }
  }
}