using CleanArch.Domains;
using System.Collections;
using System.Collections.Generic;

namespace CleanArch.Application.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}