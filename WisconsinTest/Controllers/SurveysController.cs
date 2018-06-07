using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WisconsinTest.Models;
using PagedList;

namespace WisconsinTest.Controllers
{
    public class SurveysController : Controller
    {
        private WiscounsinTestDatabaseEntities db = new WiscounsinTestDatabaseEntities();

        // GET: Surveys
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            ViewBag.SurnameSortParm = String.IsNullOrEmpty(sortOrder) ? "surname_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            //ViewBag.CorrectAnsParm = sortOrder == "CorrectAnswers" ? "corr_desc" : "CorrectAnswers";
            //ViewBag.NumbOfTriesParm = sortOrder == "NumberOfTries" ? "tries_desc" : "NumberOfTries";
            //if(searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}
            //ViewBag.CurrentFilter = searchString;
            var surveys = from s in db.Surveys
                           select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                surveys = surveys.Where(s => s.Patients.Name.Contains(searchString) || s.Patients.Surname.Contains(searchString));
            }
            var res = from r in db.Results select r;
            switch (sortOrder)
            {
                case "Name":
                    surveys = surveys.OrderBy(s => s.Patients.Name);
                    break;
                case "name_desc":
                    surveys = surveys.OrderByDescending(s => s.Patients.Name);
                    break;
                //case "CorrectAnswers":
                //    res = res.OrderBy(r => r.CorrectAnswers);
                //    break;
                //case "corr_desc":
                //    res = res.OrderByDescending(r => r.CorrectAnswers);
                //    break;
                //case "NumberOfTries":
                //    res = res.OrderBy(r => r.NumberOfTries);
                //    break;
                //case "tries_desc":
                //    res = res.OrderByDescending(r => r.NumberOfTries);
                //    break;
                case "surname_desc":
                    surveys = surveys.OrderByDescending(s => s.Patients.Surname);
                    break;
                case "Date":
                    surveys = surveys.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    surveys = surveys.OrderByDescending(s => s.Date);
                    break;
                default:
                    surveys = surveys.OrderBy(s => s.Patients.Surname);
                    break;
            }
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //var surveys = db.Surveys.Include(s => s.Patients);
            return View(surveys.ToList());
        }

        //// GET: Surveys/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Surveys surveys = db.Surveys.Find(id);
        //    if (surveys == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surveys);
        //}

        //// GET: Surveys/Create
        //public ActionResult Create()
        //{
        //    ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
        //    return View();
        //}

        //// POST: Surveys/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "SurveyId,PatientId,Date")] Surveys surveys)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Surveys.Add(surveys);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", surveys.PatientId);
        //    return View(surveys);
        //}

        //// GET: Surveys/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Surveys surveys = db.Surveys.Find(id);
        //    if (surveys == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", surveys.PatientId);
        //    return View(surveys);
        //}

        //// POST: Surveys/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "SurveyId,PatientId,Date")] Surveys surveys)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(surveys).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", surveys.PatientId);
        //    return View(surveys);
        //}

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surveys surveys = db.Surveys.Find(id);
            if (surveys == null)
            {
                return HttpNotFound();
            }
            return View(surveys);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Surveys surveys = db.Surveys.Find(id);
            db.Surveys.Remove(surveys);
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
