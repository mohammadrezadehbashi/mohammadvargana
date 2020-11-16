using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Varagana1.Areas.Admin.Controllers
{
    public class SliderrsController : Controller
    {
        private Varagana_DBEntities db = new Varagana_DBEntities();

        // GET: Admin/Sliderrs
        public ActionResult Index()
        {
            return View(db.Sliderrs.ToList());
        }

        // GET: Admin/Sliderrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliderr sliderr = db.Sliderrs.Find(id);
            if (sliderr == null)
            {
                return HttpNotFound();
            }
            return View(sliderr);
        }

        // GET: Admin/Sliderrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliderrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderID,Title,Url,ImageName,StartDate,EndDate,IsActive")] Sliderr sliderr,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp == null)
                {
                    ModelState.AddModelError("ImageName", "لطفا تصویر را انتخاب کنید");
                    return View(sliderr);
                }
                sliderr.ImageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imgUp.FileName);
                imgUp.SaveAs(Server.MapPath("/Images/Slider/"+sliderr.ImageName));
                db.Sliderrs.Add(sliderr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sliderr);
        }

        // GET: Admin/Sliderrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliderr sliderr = db.Sliderrs.Find(id);
            if (sliderr == null)
            {
                return HttpNotFound();
            }
            return View(sliderr);
        }

        // POST: Admin/Sliderrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderID,Title,Url,ImageName,StartDate,EndDate,IsActive")] Sliderr sliderr,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    System.IO.File.Delete(Server.MapPath("/Images/Sliderr/" + sliderr.ImageName));
                    sliderr.ImageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/Slider/" + sliderr.ImageName));
                }
                db.Entry(sliderr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sliderr);
        }

        // GET: Admin/Sliderrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliderr sliderr = db.Sliderrs.Find(id);
            if (sliderr == null)
            {
                return HttpNotFound();
            }
            return View(sliderr);
        }

        // POST: Admin/Sliderrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sliderr sliderr = db.Sliderrs.Find(id);
            System.IO.File.Delete(Server.MapPath("/Images/Slider/" + sliderr.ImageName));
            db.Sliderrs.Remove(sliderr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
