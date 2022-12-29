namespace CORSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseService _cs;
        public CourseController(CourseService cs)
        {
            this._cs = cs;
        }
        [HttpGet("AllCourse")]
        public IActionResult GetAllCourse()
        {
           var result =  _cs.GetCourses();
            return Ok(result);
        }
    }
}
