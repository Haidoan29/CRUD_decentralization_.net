using _200124.Models;
using _200124.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _200124.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : BaseController<Class>
    {
        public ClassController(IBaseRepository<Class> repository) : base(repository)
        {
        }
    }
}
