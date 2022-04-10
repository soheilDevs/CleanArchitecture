using System.Collections.Generic;

namespace CleanArch.Domains.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
    }
}