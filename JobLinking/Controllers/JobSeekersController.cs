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
    public class JobSeekersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobSeekers
        public ActionResult Index()
        {
            return View(db.JobSeekers.ToList());
        }


        [Authorize(Roles = "Admin,JobSeeker")]
        public ActionResult DeleteApplication(int JobSeekerId, int JobAdvertisementId)
        {
            var jobSeeker = db.JobSeekers.Where(m => m.Id == JobSeekerId).FirstOrDefault();
            var jobAdvertisement = db.JobAdvertisements.Where(m => m.Id == JobAdvertisementId).FirstOrDefault();
            jobSeeker.JobAdvertisements.Remove(jobAdvertisement);
            db.SaveChanges();
            return RedirectToAction("Details",new {id = JobSeekerId});
        }

        public ActionResult ProfileShow()
        {
            var userId = User.Identity.GetUserId();
            var jobSeekerId = db.JobSeekers.Where(m => m.UserIdRelation == userId).FirstOrDefault().Id;
            return RedirectToAction("Details",new {id = jobSeekerId});
        }

        // GET: JobSeekers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSeekers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Age,City,EducationLevel,Education,About")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.JobSeekers.Add(jobSeeker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobSeeker);
        }

        // GET: JobSeekers/Edit/5
        [Authorize(Roles = "Admin,JobSeeker")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,JobSeeker")]
        public ActionResult Edit([Bind(Include = "Id,Image,Name,Surname,Age,City,EducationLevel,Education,About,UserIdRelation")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeeker);
        }

        [Authorize(Roles = "Admin,JobSeeker")]
        public ActionResult Delete(int id)
        {
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            db.JobSeekers.Remove(jobSeeker);
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
