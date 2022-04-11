using System.Collections.Generic;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domains;
using CleanArch.Domains.Interfaces;
using CleanArch.Domains.Models;

namespace CleanArch.Application.Services
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
     

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                Courses = _courseRepository.GetCourses()
            };
        }

        public Course GetCourseById(int courseId)
        {
            Course course = _courseRepository.GetCourseById(courseId);
            return course;
        }
    }
}