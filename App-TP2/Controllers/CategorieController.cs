using App_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_TP2.Controllers
{
	public class CategorieController : Controller
	{
		public IActionResult Index()
		{
			var categories = _context.categorie.ToList();
			return View(categories);
		}


		private readonly ApplicationDbContext _context;
		public CategorieController(ApplicationDbContext _context)
		{
			this._context = _context;
		}



		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Categorie categorie)
		{
			_context.categorie.Add(categorie);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}



		public IActionResult Edit(int? id)
		{
			if (id == null) NotFound();
			var cat = _context.categorie.Find(id);
			return View(cat);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Categorie cat)
		{
			_context.categorie.Update(cat);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}





		public IActionResult Delete(int? id)
		{
			if (id == null) NotFound();
			var cat = _context.categorie.Find(id);
			return View(cat);
		}
		[HttpPost]
		public IActionResult Delete2(int? id)
		{
			if (id == null) NotFound();
			var cat = _context.categorie.Find(id);
			_context.categorie.Remove(cat);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}



	}
}
