using System.Collections.Generic;
using System.Linq;
using CleanArch.Domains;
using CleanArch.Domains.Interfaces;
using CleanArch.Domains.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _ctx;

        public CourseRepository(UniversityDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _ctx.Courses;
        }

        public Course GetCourseById(int courseId)
        {
            return _ctx.Courses.Find(courseId);
        }
    }
}