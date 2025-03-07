using AttributeLibrary.Attributes;
using AttributeLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AttributeTestWeb.Controllers
{
	public class ProductController : Controller
	{
		private readonly CustomDbOperations _dbOperations;

		public ProductController(IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DefaultConnection");
			_dbOperations = new CustomDbOperations(connectionString);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(UrunEntity urun)
		{
			if (ModelState.IsValid)
			{
				int result = _dbOperations.Add(urun);
				if (result > 0)
				{
					TempData["Success"] = true;
					return RedirectToAction("Create");
				}
				ModelState.AddModelError("", "Failed to insert the product.");
			}
			return RedirectToAction("Create");
		}
	}

}
