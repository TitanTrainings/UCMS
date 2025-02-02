using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using UCMS.Website.Models;
using UCMS.Website.Services;

namespace UCMS.Website.Controllers
{

    public class FacultiesController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // GET: Faculties
        public IActionResult Index()
        {
            if (TempData["FacultyCreationResponse"] != null)
            {
                ViewBag.Message = TempData["FacultyCreationResponse"];
            }
            var faculties = _facultyService.GetFaculties().ToList();
            return View(faculties);
        }

        // GET: Faculties/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var faculty = _facultyService.GetFacultyById(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FacultyId,FirstName,LastName,Email,RoleId")] Faculty faculty)
        {
            var result = _facultyService.CreateFaculty(faculty);
            if (result != null)
            {
                TempData["FacultyCreationResponse"] = "Faculty Created Successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Faculties/Edit/5
        public IActionResult Edit(int id)
        {
            var faculty = _facultyService.GetFacultyById(id);

            if (id <= 0)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FacultyId,FirstName,LastName,Email,RoleId")] Faculty faculty)
        {            
            if (id != faculty.FacultyId)
            {
                return NotFound();
            }

            try
            {
                _facultyService.UpdateFaculty(faculty);
                TempData["FacultyUpdatedResponse"] = "Faculty updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }                      
        }

        // GET: Faculties/Delete/5
        public IActionResult Delete(int id)
        {
            var faculty = _facultyService.GetFacultyById(id);

            if (id <= 0)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            try
            {
                _facultyService.DeleteFaculty(id);
                TempData["FacultyDeletedResponse"] = "Faculty deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
    }
}
