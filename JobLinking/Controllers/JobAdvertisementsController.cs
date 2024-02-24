using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobLinking.Models;
using Microsoft.AspNet.Identity;

namespace JobLinking.Controllers
{
    public class JobAdvertisementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobAdvertisements
        public ActionResult Index()
        {
            var jobAdvertisements = db.JobAdvertisements.Include(j => j.Company).Include(j => j.Job);
            return View(jobAdvertisements.ToList());
        }


        [Authorize(Roles = "Admin,JobSeeker")]
        public ActionResult Apply(int id)
        {
            var CurrentJobAdvertisement = db.JobAdvertisements.Where(m => m.Id == id).FirstOrDefault();
            string CurrentUserId = User.Identity.GetUserId();
            int CurrentJobSeekerId = db.UserJobSeekerRelationModels.Where(m => m.UserId == CurrentUserId).First().JobSeekerId;
            db.JobSeekers.Where(m => m.Id == CurrentJobSeekerId).First().JobAdvertisements.Add(CurrentJobAdvertisement);
            db.SaveChanges();
            return RedirectToAction("Details","JobSeekers",new {id = CurrentJobSeekerId});
        }

        // GET: JobAdvertisements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            int companyId = jobAdvertisement.CompanyId;
            ViewBag.CompanyId = db.Companies.Where(m => m.Id == companyId).FirstOrDefault().UserIdRelation;
            return View(jobAdvertisement);
        }

        // GET: JobAdvertisements/Create
        [Authorize(Roles = "Admin,Company")]
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            int companyId = db.UserCompanyRelationModels.Where(m => m.UserId == userId).First().CompanyId;
            ViewBag.CurrentCompanyId = companyId;
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title");
            return View();
        }

        // POST: JobAdvertisements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Company")]
        public ActionResult Create([Bind(Include = "Id,Description,City,JobId,CompanyId")] JobAdvertisement jobAdvertisement)
        {
            jobAdvertisement.JobTitle = db.Jobs.Where(m => m.Id == jobAdvertisement.JobId).FirstOrDefault().Title;
            if (ModelState.IsValid)
            {
                db.JobAdvertisements.Add(jobAdvertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", jobAdvertisement.CompanyId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title", jobAdvertisement.JobId);
            return View(jobAdvertisement);
        }

        // GET: JobAdvertisements/Edit/5
        [Authorize(Roles = "Admin,Company")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", jobAdvertisement.CompanyId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title", jobAdvertisement.JobId);
            return View(jobAdvertisement);
        }

        // POST: JobAdvertisements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Company")]
        public ActionResult Edit([Bind(Include = "Id,Description,City,JobId,CompanyId,JobTitle")] JobAdvertisement jobAdvertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobAdvertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", jobAdvertisement.CompanyId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title", jobAdvertisement.JobId);
            return View(jobAdvertisement);
        }
        
        [Authorize(Roles = "Admin,Company")]
        public ActionResult Delete(int id)
        {
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            db.JobAdvertisements.Remove(jobAdvertisement);
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
