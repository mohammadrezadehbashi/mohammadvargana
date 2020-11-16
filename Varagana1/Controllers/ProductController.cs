using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ViewModel;
using MoreLinq;


namespace Varagana1.Controllers
{
    public class ProductController : Controller
    {
        Varagana_DBEntities db = new Varagana_DBEntities();
        public ActionResult ShowGroups()
        {
            return PartialView(db.Product_Groups.ToList());
        }
        public ActionResult LastProduct()
        {
            return PartialView(db.Products.OrderByDescending(p => p.CreateDate).Take(12));
        }
        [Route("ShowProduct/{id}")]
        public ActionResult ShowProduct(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.ProductFeatures = product.Product_Features.DistinctBy(f => f.FeatureID).Select(f => new ShowProductFeatureViewModel()
            {
                FeatureTitle = f.Features.FeatureTitle,
                Values = db.Product_Features.Where(fe => fe.FeatureID == f.FeatureID).Select(fe => fe.Value).ToList()
            }).ToList();


            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult ShowComment(int id)
        {

            return PartialView(db.Products_Comments.Where(c=>c.ProductID==id));
        }
         
        public ActionResult CreateComment(int id)
        {
            return PartialView(new Product_Comments()
            {
                ProductID = id
            });
        }
        [HttpPost]
        public ActionResult CreateComment(Product_Comments productcomments)
        {
            if (ModelState.IsValid)
            {
                productcomments.CreateDate = DateTime.Now;
                db.Products_Comments.Add(productcomments);
                db.SaveChanges();

                return PartialView("ShowComment", db.Products_Comments.Where(c => c.ProductID == productcomments.ProductID));
            }
            return PartialView(productcomments);
        }
        [Route("Archive")]
        public ActionResult ArchiveProduct(int pageId=1,string title="",int minPrice=0, int maxPrice=0,List<int> selectedGroups = null)
        {    
            ViewBag.Groups = db.Product_Groups.ToList();
            ViewBag.ProductTitle = title;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.Pageid = pageId;
            ViewBag.SelectGroup = selectedGroups;
                       
            List<Products> list =new List<Products>();
            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (var group in selectedGroups)
                {
                    list.AddRange(db.Product_Selected_Groups.Where(g => g.GroupID == group).Select(g => g.Products).ToList());
                }
                list = list.Distinct().ToList();
            }
            else
            {
                list.AddRange(db.Products.ToList());
            }
            
            if (title!="")
            {
                list = list.Where(p => p.Title.Contains(title)).ToList();
            }
            if (minPrice > 0)
            {
                list = list.Where(p => p.Price >= minPrice).ToList();
            }
            if (maxPrice > 0)
            {
                list = list.Where(p => p.Price <= maxPrice).ToList();
            }
            //paging      
            int take =6;
            int skip = (pageId - 1) * take;
            ViewBag.PageCount = list.Count() / take;
            return View(list.OrderByDescending(p=>p.CreateDate).Skip(skip).Take(take).ToList());

        }
    }
}