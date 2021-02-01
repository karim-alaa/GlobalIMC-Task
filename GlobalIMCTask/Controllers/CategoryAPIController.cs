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
    [ApiController]
    [Route("api/Category")]
    public class CategoryAPIController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryAPIController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("ViewCategories")]
        public IActionResult ViewCategories()
        {
            return View();
        }

        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            List<Category> Categories = await _categoryService.GetAllCategories();
            return Ok(Categories);
        }

        [Route("GetCategoryProduct/{id}")]
        public async Task<IActionResult> GetCategoryProduct(Guid id)
        {
            Category Category = await _categoryService.GetCategoryWithProduct(id);
            return Ok(Category);
        }
    }
}
