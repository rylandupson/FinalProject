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
    public class UserDetailsController : Controller
    {
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: UserDetails
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Index()
        {
            string userID = User.Identity.GetUserId();
            if (User.IsInRole("Employee"))
            {
                var userDetails = db.UserDetails.Where(x => x.UserID == userID);
                return View(userDetails.ToList());
            }
            else
            {
                return View(db.UserDetails.ToList());
            }
        }

        // GET: UserDetails/Details/5
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // GET: UserDetails/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,ResumeFileName")] UserDetail userDetail, HttpPostedFileBase resume)
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
                userDetail.ResumeFileName = resumeName;
                #endregion

                db.UserDetails.Add(userDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetail);
        }

        // GET: UserDetails/Edit/5
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,ResumeFileName")] UserDetail userDetail, HttpPostedFileBase resume)
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

                        userDetail.ResumeFileName = resumeName;
                    }
                }
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetail);
        }

        // GET: UserDetails/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
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
