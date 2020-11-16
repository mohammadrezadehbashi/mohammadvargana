using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Varagana1.Controllers
{
    public class SearchController : Controller
    {
        Varagana_DBEntities db = new Varagana_DBEntities();
        public ActionResult Index(string q)
        {
            List<Products> list = new List<Products>();

            list.AddRange(db.Product_Tags.Where(t => t.Tag == q).Select(t =>t.Products ).ToList());
            list.AddRange(db.Products.Where(p => p.Title.Contains(q) || p.ShortDescription.Contains(q) || p.Text.Contains(q)).ToList());

            ViewBag.Search = q;
            return View(list.Distinct());
        }
    }
}