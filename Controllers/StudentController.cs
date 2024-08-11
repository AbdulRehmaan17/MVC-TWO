using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectX.Data;
using ProjectX.Models;
using ProjectX.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace ProjectX.Controllers
{
    public class StudentController : Controller
    {
        
        private readonly StudentServices iRepo;
        public StudentController(StudentServices sServices)
        {
            iRepo = sServices;
        }
        public IActionResult Index()
        {
            var students = iRepo.readAll();
            return View(students);
        }
        //public string Read()
        //{
        //    var students = iRepo.readAll();
        //    return (JsonSerializer.Serialize(students));
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                iRepo.create(student);
                 return RedirectToAction("Index");
            }
             return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = iRepo.read(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(int id,Student student)
        {
            if(id!=student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iRepo.update(student);
                TempData["SuccessPrint"] = "Student Updated Successfully";

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = iRepo.read(id);
            if(student ==null)
            {
                return NotFound();
            }
            iRepo.delete(id);
            TempData["Successfully"] = "Student deleted Successfully";
            return Ok();
        }
        //[HttpPost,ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id,Student student)
        //{
        //    if(id != student.Id)
        //    {
        //        return NotFound();
        //    }
        //    iRepo.delete(id);
        //    TempData["Successfully"] = "Student deleted Successfully";
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
