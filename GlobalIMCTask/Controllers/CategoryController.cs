using GlobalIMCTask.Models;
using GlobalIMCTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalIMCTask.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Categories"] = await _categoryService.GetAllCategories();
            Category Category = await _categoryService.GetFirstCategory();
            return View(Category);
        }

        public async Task<IActionResult> GetCategoryProduct(Guid id)
        {
            ViewData["Categories"] = await _categoryService.GetAllCategories();
            Category Category = await _categoryService.GetCategoryWithProduct(id);
            return View(nameof(Index), Category);
        }


        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
