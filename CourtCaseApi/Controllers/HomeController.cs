using CourtCaseApi.Models;
using CourtCaseApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CourtCaseApi.Controllers
{
    public class HomeController : Controller
    {
        public CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult PIndex()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult PlaintiffCreate()
        {
            ViewBag.Title = "Plaintiff page";

            return View();
        }

        public ActionResult CaseIndex()
        {
            ViewBag.Title = "Home Page";
            ViewBag.PlaintiffID = new SelectList(db.Plaintiffs, "PlaintiffID", "PlaintiffID");


            return View();


        }
        public ActionResult PaymentProcess()
        {
            ViewBag.Title = "Finance Page";
            ViewBag.CaseID = new SelectList(db.Cases, "CaseID", "CaseID");

            return View();


        }
        public ActionResult CaseFile()
        {
            ViewBag.Title = " Case file page";
            ViewBag.CaseID = new SelectList(db.Cases, "CaseID", "CaseID");

            return View();
        }
        public ActionResult CaseSchedule()
        {
            ViewBag.Title = " Schedule";
            ViewBag.CaseID = new SelectList(db.Cases, "CaseID", "CaseID");
            return View();
        }
        public ActionResult CaseJudge()
        {
            ViewBag.Title = " Judge";
            ViewBag.CaseID = new SelectList(db.Cases, "CaseID", "CaseID");
            return View();
        }

        public ActionResult UserIndex()
        {
            ViewBag.Title = " User";
            return View();
        }
        public ActionResult ReportManager()
        {

            List<ReportVM> Report = new List<ReportVM>();

            var customerlist = (from plaintiff in db.Plaintiffs

                                join caselist in db.Cases on plaintiff.PlaintiffID equals caselist.PlaintiffID
                                join judg in db.CaseJudges on caselist.CaseID equals judg.CaseID
                                select new
                                {
                                    plaintiff.PlaintiffID,
                                    caselist.CaseID,
                                    caselist.Date,
                                    caselist.CaseType,
                                    judg.CaseStatus,
                                    judg.JudgmentDate
                                }).ToList();


            foreach (var item in customerlist)

            {

                ReportVM report = new ReportVM(); // ViewModel

                report.PlaintiffID = item.PlaintiffID;
                report.CaseID = item.CaseID;
                report.CaseRegDate = item.Date;
                report.CaseType = item.CaseType;
                report.CaseStatus = item.CaseStatus;
                report.JudgmentDate = item.JudgmentDate;
                Report.Add(report);
            }

            return View(Report);
        }

        public ActionResult Anouncement()
        {
            ViewBag.Title = " Announcement";

            return View();
        }
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}
