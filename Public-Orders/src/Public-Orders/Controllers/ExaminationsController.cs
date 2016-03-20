

namespace PublicOrders.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Data.AppData.UnitOfWork;
    using Microsoft.AspNet.Authorization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.Data.Entity;
    using PublicOrders.Data.BisData.Models;

    [Authorize]
    [RequireHttps]
    public class ExaminationsController : BaseController
    {
        public ExaminationsController(IPublicOrdersData data) 
            : base(data)
        {
        }

        // GET: Examinations
        public IActionResult Index()
        {
            var userExaminations = this.UserProfileAsync.ContinueWith(loadTask =>
            {
                return this.BisDbContext.Examinations
                .Where(e => e.Patient.Egn == loadTask.Result.Egn)
                .Include(e => e.Doctor)
                .Include(e => e.Patient).ToList();
            }).Result;
            //var userExaminations = this.BisDbContext.Examinations
            //    .Where(e => e.Patient.Egn == this.UserProfile.Egn)
            //    .Include(e => e.Doctor)
            //    .Include(e => e.Patient).ToList();

            return View(userExaminations);
        }

        // GET: Examinations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var examination = this.BisDbContext.Examinations.SingleAsync(m => m.Id == id);

            if (examination.IsFaulted)
            {
                return HttpNotFound();
            }

            return View(examination.Result);
        }

        // GET: Examinations/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(this.BisDbContext.Doctors, "Id", "FirstName");
            ViewData["PatientId"] = new SelectList(this.BisDbContext.Patients.Where(p => p.Egn == this.UserProfileAsync.Result.Egn), "Id", "FirstName");
            return View();
        }

        // POST: Examinations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Examination examination)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.BisDbContext.Examinations.Add(examination);
                    this.BisDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewData["DoctorId"] = new SelectList(this.BisDbContext.Doctors, "Id", "FirstName", examination.DoctorId);
                ViewData["PatientId"] = new SelectList(this.BisDbContext.Patients, "Id", "FirstName", examination.PatientId);
                return View(examination);
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }

        // GET: Examinations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Task<Examination> examination = this.BisDbContext.Examinations.SingleAsync(m => m.Id == id);

            if (examination.IsFaulted)
            {
                return HttpNotFound();
            }

            ViewData["DoctorId"] = new SelectList(this.BisDbContext.Doctors, "Id", "Doctors", examination.Result.DoctorId);
            ViewData["PatientId"] = new SelectList(this.BisDbContext.Patients.Where(p => p.Egn == this.UserProfileAsync.Result.Egn), "Id", "Patients", examination.Result.PatientId);
            return View(examination.Result);
        }

        // POST: Examinations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Examination examination)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.BisDbContext.Update(examination);
                    this.BisDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewData["DoctorId"] = new SelectList(this.BisDbContext.Doctors, "Id", "Doctors", examination.DoctorId);
                ViewData["PatientId"] = new SelectList(this.BisDbContext.Patients.Where(p => p.Egn == this.UserProfileAsync.Result.Egn), "Id", "Patients", examination.PatientId);
                return View(examination);
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }

        // GET: Examinations/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return HttpNotFound();
                }

                Task<Examination> examination = this.BisDbContext.Examinations.SingleAsync(m => m.Id == id);

                if (examination.IsFaulted)
                {
                    return HttpNotFound();
                }

                return View(examination.Result);
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }

        // POST: Examinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Examination examination = this.BisDbContext.Examinations.SingleAsync(m => m.Id == id).Result;
            this.BisDbContext.Examinations.Remove(examination);
            this.BisDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
