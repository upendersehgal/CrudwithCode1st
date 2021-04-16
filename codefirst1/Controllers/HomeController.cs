using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codefirst1.Models;
using System.Data.Entity;

namespace codefirst1.Controllers
{
    public class HomeController : Controller
    {
		studentcontext db = new studentcontext();
		// GET: Home
		public ActionResult Index()
		{
			var data = db.students.ToList();
			return View(data);
		}
		
		public ActionResult create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create( student s)
		{
			if(ModelState.IsValid==true)
			{
				db.students.Add(s);
				int a = db.SaveChanges();
				if (a > 0)
				{
					//ViewBag.InsertMessage = "<script>alert('Data Inserted!')</script>";
					//TempData["InsertMessage"] = "<script>alert('Data Inserted!')</script>";
					TempData["InsertMessage"] = "Data Inserted!";
					//ModelState.Clear();
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.InsertMessage = "<script>alert('Data Not Inserted!')</script>";
					
				}
			}
			
			return View();
		}
		public ActionResult edit(int id)
		{
			var b = db.students.Where(model => model.id == id).FirstOrDefault();
			return View(b);
		}
		[HttpPost]
		public ActionResult edit(student s)
		{
			db.Entry(s).State = EntityState.Modified;
			int a =db.SaveChanges();
			if(a>0)
			{
				ViewBag.InsertMessage = "<script>alert('Data Updated!')</script>";
				
				return RedirectToAction("Index");

			}
			else
					{
				//ViewBag.InsertMessage = "<script>alert('Data Not Updated!')</script>";
				//ModelState.Clear();
				TempData["UpdateMessage"] = "<script>alert('Data Not Updated!')</script>";
				//ModelState.Clear();
			}

			return View();
		}

		public ActionResult delete( int id)
		{
			var a = db.students.Where(model => model.id == id).FirstOrDefault();

			return View(a);
		}
		[HttpPost]
		public ActionResult delete(student s)
		{
			db.Entry(s).State = EntityState.Deleted;
			int a=db.SaveChanges();
			if(a>0)
			{
				TempData["Deletemessage"] = "<script>alert('Data Deleted!')</script>";

			}
			else
			{
				TempData["Deletemessage"] = "<script>alert('Data Notated!')</script>";
			
			}
			return RedirectToAction("Index");
		}
	}
}