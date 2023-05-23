using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Student> model = _db.Students.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      // ViewBag.AllCourses = new SelectList(_db.Courses, "")
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      if (!ModelState.IsValid)
      {
        return View(student);
      }
      else
      {
        _db.Students.Add(student);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Student thisStudent = _db.Students
                          .Include(student => student.JoinEntities)
                          .ThenInclude(join => join.Course)
                          .Include(student => student.JoinMajors)
                          .ThenInclude(major => major.Major)
                          .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Students.Update(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int courseId)
    {
#nullable enable
      CourseStudent? joinEntity = _db.CourseStudents.FirstOrDefault(join => join.CourseId == courseId && join.StudentId == student.StudentId);
#nullable disable
      if (joinEntity == null && courseId != 0)
      {
        _db.CourseStudents.Add(new CourseStudent() { CourseId = courseId, StudentId = student.StudentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = student.StudentId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId, int id)
    {
      CourseStudent joinEntry = _db.CourseStudents.FirstOrDefault(entry => entry.CourseStudentId == joinId);
      _db.CourseStudents.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMajor(int id)
    {
      Student thisStudent = _db.Students
                                        .Include(student => student.JoinMajors)
                                        .ThenInclude(major => major.Major)
                                        .FirstOrDefault(students => students.StudentId == id);
      ViewBag.MajorId = new SelectList(_db.Majors, "MajorId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddMajor(Student student, int majorId)
    {
#nullable enable
      StudentMajor? joinEntity = _db.StudentMajors.FirstOrDefault(join => join.MajorId == majorId && join.StudentId == student.StudentId);
#nullable disable
      if (joinEntity == null && majorId != 0)
      {
        _db.StudentMajors.Add(new StudentMajor() { MajorId = majorId, StudentId = student.StudentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = student.StudentId });
    }

    [HttpPost]
    public ActionResult DeleteJoinMajor(int joinId, int id)
    {
      StudentMajor joinEntry = _db.StudentMajors.FirstOrDefault(entry => entry.StudentMajorId == joinId);
      _db.StudentMajors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}