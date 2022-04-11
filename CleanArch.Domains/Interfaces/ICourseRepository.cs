using System.Collections.Generic;
using CleanArch.Domains.Models;

namespace CleanArch.Domains.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseById(int courseId);
    }
}