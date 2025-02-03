using NuGet.Protocol.Plugins;
using UCMS.Website.Models;

namespace UCMS.Website.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _dbContext;
        public CourseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Course CreateCourse(Course course)
        {
            try
            {
                _dbContext.Courses.Add(course);
                _dbContext.SaveChanges();

                return course;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public string DeleteCourse(int id)
        {
            try
            {
                var course = _dbContext.Courses.Find(id);
                if (course != null)
                {
                    _dbContext.Remove(course);
                    _dbContext.SaveChanges();
                    return "success";
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        public Course GetCourseById(int id)
        {
            Course course = _dbContext.Courses.Find(id);
            return course;
        }

        public List<Course> GetCourses()
        {
            List<Course> course = _dbContext.Courses.ToList();
            return course;
        }

        public Course UpdateCourse(Course course)
        {
            try
            {
                var updatecourse = _dbContext.Courses.Find(course.CourseId);
                if (updatecourse != null)
                {
                    updatecourse.Title = course.Title;
                    updatecourse.Detail = course.Detail;
                    updatecourse.FacultyId = course.FacultyId;
                    updatecourse.Duration = course.Duration;
                    updatecourse.Status = course.Status;
                    _dbContext.Update(updatecourse);
                    _dbContext.SaveChanges();
                    return updatecourse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
