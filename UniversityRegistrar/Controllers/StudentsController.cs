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
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Details(int id)
    // {
    //   // Item thisItem = _db.Items
    //   //                     .Include(item => item.Category)
    //   //                     .FirstOrDefault(item => item.ItemId == id);
    //   return View(thisItem);
    // }

    // public ActionResult Edit(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //   // ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult Edit(Item item)
    // {
    //   // _db.Items.Update(item);
    //   // _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //   return View(thisItem);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //   // _db.Items.Remove(thisItem);
    //   // _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}