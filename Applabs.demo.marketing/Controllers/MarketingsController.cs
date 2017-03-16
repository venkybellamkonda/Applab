using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applabs.demo.marketing.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Applabs.demo.marketing.Controllers
{
    [Authorize]
    public class MarketingsController : Controller
    {
        private ApplabsDemoEntities3 db = new ApplabsDemoEntities3();

        // GET: Marketings
        public ActionResult Index()
        {
            return View(db.Marketings.ToList());
        }

        // GET: Marketings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing marketing = db.Marketings.Find(id);
            if (marketing == null)
            {
                return HttpNotFound();
            }
            return View(marketing);
        }

        // GET: Marketings/Create
        public ActionResult Create()
        {
            ViewBag.marketid = new SelectList(db.Employees, "EmployeeId", "FirstName");
            Marketing marketer = new Marketing();
            marketer.emplo = db.Employees.Where(v => v.IsInternalEmployee == false).ToList();
            marketer.market = db.Employees.Where(v => v.IsInternalEmployee == true).ToList();
            return View(marketer);
        }

        // POST: Marketings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeName,MarketerName,StartDate,CaseStatus,CloseDate")] Marketing marketing,FormCollection frm)
        {
            //try
            //{
                marketing.EmployeeName = frm["emplo"].ToString();
                marketing.MarketerName = frm["market"].ToString();

                
                

                if (ModelState.IsValid)
                {
                    db.Marketings.Add(marketing);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(marketing);

            }

            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        //System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",eve.Entry.Entity.GetType().Name,eve.Entry.State );
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Trace.TraceInformation("- Property: \"{0}\", Error:\"{1}\"", ve.PropertyName, ve.ErrorMessage);
            //        }

            //    }

            //    throw;
            //}
            
        //}

        // GET: Marketings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing marketing = db.Marketings.Find(id);
            if (marketing == null)
            {
                return HttpNotFound();
            }
            return View(marketing);
        }

        // POST: Marketings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeName,MarketerName,StartDate,CaseStatus,CloseDate")] Marketing marketing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marketing);
        }

        // GET: Marketings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing marketing = db.Marketings.Find(id);
            if (marketing == null)
            {
                return HttpNotFound();
            }
            return View(marketing);
        }

        // POST: Marketings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marketing marketing = db.Marketings.Find(id);
            db.Marketings.Remove(marketing);
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
