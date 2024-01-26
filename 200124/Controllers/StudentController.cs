using _200124.Models;
using _200124.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _200124.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController<Student>
    {
        public StudentController(IBaseRepository<Student> repository) : base(repository)
        {
        }
    }
}
