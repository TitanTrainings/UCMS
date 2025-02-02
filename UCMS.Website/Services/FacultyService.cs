using NuGet.Protocol.Plugins;
using UCMS.Website.Models;

namespace UCMS.Website.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly ApplicationDbContext _dbContext;
        public FacultyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Faculty CreateFaculty(Faculty faculty)
        {
            try
            {
                _dbContext.Faculty.Add(faculty);
                _dbContext.SaveChanges();

                return faculty;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public string DeleteFaculty(int id)
        {
            try
            {
                var faculty = _dbContext.Faculty.Find(id);
                if (faculty != null)
                {
                    _dbContext.Remove(faculty);
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

        public List<Faculty> GetFaculties()
        {
            List<Faculty> faculties = _dbContext.Faculty.ToList();
            return faculties;
        }

        public Faculty GetFacultyById(int id)
        {
            Faculty faculty = _dbContext.Faculty.Find(id);
            return faculty;
        }

        public Faculty UpdateFaculty(Faculty faculty)
        {
            try
            {
                var updatefaculty = _dbContext.Faculty.Find(faculty.FacultyId);
                if (updatefaculty != null)
                {
                    updatefaculty.FirstName = faculty.FirstName;
                    updatefaculty.LastName = faculty.LastName;
                    updatefaculty.Email = faculty.Email;
                    updatefaculty.RoleId = faculty.RoleId;
                    _dbContext.Update(updatefaculty);
                    _dbContext.SaveChanges();
                    return faculty;
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

        public List<Role> GetRoles()
        {
            List<Role> roles = _dbContext.Roles.ToList();
            return roles;
        }
    }
}

