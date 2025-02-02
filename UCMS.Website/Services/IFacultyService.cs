using UCMS.Website.Models;

namespace UCMS.Website.Services
{
    public interface IFacultyService
    {
        public List<Faculty> GetFaculties();
        public Faculty GetFacultyById(int id);
        public Faculty CreateFaculty(Faculty faculty);
        public Faculty UpdateFaculty(Faculty faculty);
        public string DeleteFaculty(int id);
        public List<Role> GetRoles();
    }
}
