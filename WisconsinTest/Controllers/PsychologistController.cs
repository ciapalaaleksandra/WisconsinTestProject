using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WisconsinTest.Models;
using Newtonsoft.Json;

namespace WisconsinTest.Controllers
{
    public class PsychologistController : Controller
    {
        private WiscounsinTestDatabaseEntities db = new WiscounsinTestDatabaseEntities();
        
        // GET: Psychologist
        public ActionResult Index()
        {
            string psychologistId = Session["LogedUserID"].ToString();
            int psychologistIdInt = Int32.Parse(psychologistId);
            var patients = db.Patients.Where(x => x.PsychologistId == psychologistIdInt);
            return View(patients.ToList());
        }

        // GET: Psychologist/Details/5
        public ActionResult Details(int? id)
        {
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();
            List<DataPoint> dataPoints4 = new List<DataPoint>();

                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["PatientId"] = id.ToString();
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            foreach (var item in db.Surveys.Where(x => x.PatientId == id))
            {
                foreach(var results in db.Results.Where(x => x.SurveyId == item.SurveyId))
                {
                    dataPoints1.Add(new DataPoint(item.Date.ToString(), double.Parse(results.NumberOfTries)));
                    dataPoints2.Add(new DataPoint(item.Date.ToString(), double.Parse(results.CorrectAnswers)));
                    dataPoints3.Add(new DataPoint(item.Date.ToString(), double.Parse(results.PerseverationErrors)));
                    dataPoints4.Add(new DataPoint(item.Date.ToString(), double.Parse(results.NonPerseveranceErrors)));
                }
            }
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);
            ViewBag.DataPoints4 = JsonConvert.SerializeObject(dataPoints4);
            return View(patients);
        }


        // GET: Psychologist/Create
        public ActionResult Create()
        {
            ViewBag.PsychologistId = new SelectList(db.Psychologists, "PsychologistId", "Name");
            return View();
        }

        // POST: Psychologist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PsychologistId,Name,Surname,PESEL,Address,PhoneNumber,BirthDate")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                string psychologistId = Session["LogedUserID"].ToString();
                int psychologistIdInt = Int32.Parse(psychologistId);
                patients.PsychologistId = psychologistIdInt;
                db.Patients.Add(patients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PsychologistId = new SelectList(db.Psychologists, "PsychologistId", "Name", patients.PsychologistId);
            return View(patients);
        }

        // GET: Psychologist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            ViewBag.PsychologistId = new SelectList(db.Psychologists, "PsychologistId", "Name", patients.PsychologistId);
            return View(patients);
        }

        // POST: Psychologist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,PsychologistId,Name,Surname,PESEL,Address,PhoneNumber,BirthDate")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PsychologistId = new SelectList(db.Psychologists, "PsychologistId", "Name", patients.PsychologistId);
            return View(patients);
        }

        // GET: Psychologist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Psychologist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patients patients = db.Patients.Find(id);
            db.Patients.Remove(patients);
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
