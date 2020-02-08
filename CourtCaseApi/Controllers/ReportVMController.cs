using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourtCaseApi.Models;
using CourtCaseApi.ViewModels;

namespace CourtCaseApi.Controllers
{
    public class ReportVMController : Controller
    {
        public CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: ReportVM
        public ActionResult Report()
        {

            List<ReportVM> CustomerVMlist = new List<ReportVM>();

            var customerlist = (from Cust in db.Plaintiffs

                                join Ord in db.Cases on Cust.PlaintiffID equals Ord.PlaintiffID
                                join judg in db.CaseJudges on Ord.CaseID equals judg.CaseID
                                select new
                                {
                                    Cust.PlaintiffID,
                                    Ord.CaseID,
                                    judg.CaseStatus
                                }).ToList();
            foreach (var item in customerlist)

            {

                ReportVM objcvm = new ReportVM(); // ViewModel

                objcvm.PlaintiffID = item.PlaintiffID;

                objcvm.CaseID = item.CaseID;

                objcvm.CaseStatus = item.CaseStatus;

                CustomerVMlist.Add(objcvm);

            }

            return View(CustomerVMlist);
        }
    }
}