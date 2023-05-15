using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    public interface ICourceRepository
    {
         IEnumerable<Course> AllCourses { get; }
    }
}
