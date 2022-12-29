namespace CORSDemo.Services
{
    public class CourseService
    {
        public List<Course> courses;
        public CourseService()
        {
            courses = new List<Course>()
            {
                new Course() {Id = 101,Name="Maths"},
                new Course() {Id = 102,Name="Science"},
                new Course() {Id = 103,Name="English"},
                new Course() {Id = 104,Name="Social Science"},
                new Course() {Id = 105,Name="Sanskrit"},
            };
        }

        public List<Course> GetCourses()
        {
            return courses;
        }
    }
}
