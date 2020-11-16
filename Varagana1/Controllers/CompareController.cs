using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ViewModel;

namespace Varagana1.Controllers
{
    public class CompareController : Controller
    {
        Varagana_DBEntities db = new Varagana_DBEntities();
        // GET: Compare
        public ActionResult Index()
        {
            List<CompareItem> list = new List<CompareItem>();
            if (Session["Compare"] != null)
            {
                list=Session["Compare"] as List<CompareItem>;
            }
            List<Features> features = new List<Features>();
            List<Product_Features> productFeatures = new List<Product_Features>();
            foreach(var item in list)
            {
                features.AddRange(db.Product_Features.Where(p => p.ProductID == item.ProductID).Select(f => f.Features).ToList());
                productFeatures.AddRange(db.Product_Features.Where(p => p.ProductID == item.ProductID).ToList());
                ViewBag.features = features.Distinct().ToList();
                ViewBag.productFeatures = productFeatures;
            }
            return View(list);
        }

        public ActionResult AddToCompare(int id)
        {
            List<CompareItem> list = new List<CompareItem>();
            if (Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
            }
            if (!list.Any(p => p.ProductID == id))
            {
                var product = db.Products.Where(p => p.ProductID == id).Select(p => new
                {
                    p.Title,
                    p.ImageName
                }).Single();
                list.Add(new CompareItem()
                {
                    ProductID = id,
                    Title = product.Title,
                    ImageName = product.ImageName
                });
            }
            Session["Compare"] = list;
            return PartialView("ListCompare",list);
        }

        public ActionResult ListCompare()
        {
            List<CompareItem> list = new List<CompareItem>();
            if (Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
            }
            return PartialView(list);
        }

        public ActionResult DeleteFromCompare(int id)
        {
            List<CompareItem> list = new List<CompareItem>();
            if(Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
            }
            int index = list.FindIndex(p => p.ProductID == id);
            list.RemoveAt(index);
            Session["Compare"] = list;
            return PartialView("ListCompare",list);
        }
    }
}