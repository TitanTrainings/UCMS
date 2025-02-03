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
    public class CoursesController : Controller
    {
        private readonly ICourseService _CourseService;

        public CoursesController(ICourseService courseService)
        {
            _CourseService = courseService;
        }

        // GET: Courses
        public IActionResult Index()
        {
            if (TempData["CourseCreationResponse"] != null)
            {
                ViewBag.Message = TempData["CourseCreationResponse"];
            }
            var courses = _CourseService.GetCourses().ToList();
            return View(courses);
        }

        // GET: Courses/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var course = _CourseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {           
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CourseId,Title,Detail,FacultyId,Duration,Status")] Course course)
        {
            var result = _CourseService.CreateCourse(course);
            if (result != null)
            {
                TempData["CourseCreationResponse"] = "Course Created Successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["CourseCreationResponse"] = "Unable to create the Course..";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int id)
        {
            var course = _CourseService.GetCourseById(id);

            if (id <= 0)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId,Title,Detail,FacultyId,Duration,Status")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            try
            {
                var result = _CourseService.UpdateCourse(course);
                if (result != null)
                {
                    TempData["FacultyUpdatedResponse"] = "Course updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["FacultyUpdatedResponse"] = "Unable to update the Course.";
                    return RedirectToAction(nameof(Edit), course);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int id)
        {
            var course = _CourseService.GetCourseById(id);

            if (id <= 0)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
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
                var result = _CourseService.DeleteCourse(id);
                if (result == "success")
                {
                    TempData["CourseDeletedResponse"] = "Course deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var deletecourse = _CourseService.GetCourseById(id);
                    TempData["CourseDeletedResponse"] = "Unable to delete the Course.";
                    return RedirectToAction(nameof(Delete), deletecourse);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
