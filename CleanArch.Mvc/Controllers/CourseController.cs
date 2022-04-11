using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;

namespace CleanArch.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var model = _courseService.GetCourses();
            return View(model);
        }

        public IActionResult ShowCourse(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course==null)
            {
                return NotFound();      
            }

            return View(course);
        }
    }
}
