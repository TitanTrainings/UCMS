using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCMS.Website.Models;
using UCMS.Website.Services;

namespace UCMS.Website.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly IFacultyService _facultyService;
        private readonly ApplicationDbContext _context;

        public FacultiesController(IFacultyService facultyService, ApplicationDbContext context)
        {
            _facultyService = facultyService;
            _context = context; 
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
            ViewBag.Roles = new SelectList(_context.Roles, "RoleName", "RoleName");
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
                TempData["FacultyCreationResponse"] = "User Created Successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // make changes as per requirement.


            if (id == null)
            {
                return NotFound();
            }

            //var faculty = await _context.Faculty.FindAsync(id);
            //if (faculty == null)
            //{
            //    return NotFound();
            //}
            return View();
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacultyId,FirstName,LastName,Email,RoleId")] Faculty faculty)
        {
            // make changes as per requirement.

            if (id != faculty.FacultyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.FacultyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // make changes as per requirement.

            if (id == null)
            {
                return NotFound();
            }

            //var faculty = await _context.Faculty
            //    .FirstOrDefaultAsync(m => m.FacultyId == id);
            //if (faculty == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // make changes as per requirement


            //var faculty = await _context.Faculty.FindAsync(id);
            //if (faculty != null)
            //{
            //    _context.Faculty.Remove(faculty);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(int id)
        {
            //make changes as per requirement.
            return true;
        }
    }
}
