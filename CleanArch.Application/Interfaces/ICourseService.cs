using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Services
{
    public interface ICourseService
    {
        CourseViewModel GetCourses();
    }
}