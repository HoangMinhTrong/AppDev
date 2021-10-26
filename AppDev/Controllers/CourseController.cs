using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDev.Data;
using AppDev.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppDev.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
            
        public IActionResult Index()
        {
            var obj = _context.Courses.Include(x => x.Category);
            return View(obj.ToList());
        }
        public IActionResult Create()
        {
            List<Category> cate = _context.Categories.ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "Id", "Name");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Course model)
        {
            
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        public IActionResult Update(int? id)
        {
            Course course = new Course
            {
                CategoryList = _context.Categories.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            var obj = _context.Courses.Find(id);
            if(id == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Course model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Courses.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _context.Courses.FirstOrDefault(m => m.Id == id);
            return View(obj);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var obj = _context.Courses.Find(id);
            _context.Courses.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
    
}
