using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.DATA.EF;
using Microsoft.AspNet.Identity;

namespace FinalProject.UI.Controllers
{
    public class ApplicationsController : Controller
    {
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: Applications
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Index()
        {
            string userID = User.Identity.GetUserId();
            if (User.IsInRole("Employee"))
            {
                var applications = db.Applications.Where(a => a.UserID == userID).Include(a => a.ApplicationStatus).Include(a => a.OpenPosition).Include(a => a.UserDetail);
                return View(applications.ToList());
            }
            if (User.IsInRole("Manager"))
            {
                var applications = db.Applications.Where(a => a.OpenPosition.Location.ManagerID == userID).Include(a => a.ApplicationStatus).Include(a => a.OpenPosition).Include(a => a.UserDetail);
                return View(applications.ToList());
            }
            else
            {
                var applications = db.Applications.Include(a => a.ApplicationStatus).Include(a => a.OpenPosition).Include(a => a.UserDetail);
                return View(applications.ToList());
            }
        }

        // GET: Applications/Details/5
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Create()
        {
            ViewBag.ApplicationStatusID = new SelectList(db.ApplicationStatus1, "ApplicationStatusID", "StatusName");
            ViewBag.OpenPositionID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID");
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationID,OpenPositionID,UserID,ApplicationDate,ManagerNotes,ApplicationStatusID,ResumeFileName")] Application application, HttpPostedFileBase resume)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string resumeName = "noPDF.pdf";

                if (resume != null)
                {
                    resumeName = resume.FileName;
                    string ext = resumeName.Substring(resumeName.LastIndexOf('.'));
                    string[] goodExts = { ".pdf" };

                    if (goodExts.Contains(ext.ToLower()))
                    {
                        resume.SaveAs(Server.MapPath("~/Content/resumes/" + resumeName));
                    }
                    else
                    {
                        resumeName = "noPDF.pdf";
                    }
                }
                application.ResumeFileName = resumeName;
                #endregion

                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationStatusID = new SelectList(db.ApplicationStatus1, "ApplicationStatusID", "StatusName", application.ApplicationStatusID);
            ViewBag.OpenPositionID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID", application.OpenPositionID);
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName", application.UserID);
            return View(application);
        }

        // GET: Applications/Edit/5
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationStatusID = new SelectList(db.ApplicationStatus1, "ApplicationStatusID", "StatusName", application.ApplicationStatusID);
            ViewBag.OpenPositionID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID", application.OpenPositionID);
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName", application.UserID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationID,OpenPositionID,UserID,ApplicationDate,ManagerNotes,ApplicationStatusID,ResumeFileName")] Application application, HttpPostedFileBase resume)
        {
            if (ModelState.IsValid)
            {
                if (resume != null)
                {
                    string resumeName = resume.FileName;

                    string ext = resumeName.Substring(resumeName.LastIndexOf('.'));

                    string[] goodExts = { ".pdf" };

                    if (goodExts.Contains(ext.ToLower()))
                    {
                        resume.SaveAs(Server.MapPath("~/Content/resumes/" + resumeName));

                        application.ResumeFileName = resumeName;
                    }
                }
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationStatusID = new SelectList(db.ApplicationStatus1, "ApplicationStatusID", "StatusName", application.ApplicationStatusID);
            ViewBag.OpenPositionID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID", application.OpenPositionID);
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName", application.UserID);
            return View(application);
        }

        // GET: Applications/Delete/5
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
