using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDev.Data;
using AppDev.Models;

namespace AppDev.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
            
        public IActionResult Index()
        {
            var obj = _context.Categories.ToList();
            return View(obj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (Category model)
        {
            if(ModelState.IsValid)
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
            var obj = _context.Categories.Find(id);
            if(id == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Categories.Update(model);
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
            var obj = _context.Categories.FirstOrDefault(m => m.Id == id);
            return View(obj);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var obj = _context.Categories.Find(id);
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
    
}
