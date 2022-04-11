using CleanArch.Application.ViewModels;
using CleanArch.Domains.Models;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseService
    {
        CourseViewModel GetCourses();
        Course GetCourseById(int courseId);
    }
}