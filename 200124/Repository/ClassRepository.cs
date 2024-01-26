using _200124.Data;
using _200124.Models;

namespace _200124.Repository
{
    public interface IClassRepository : IBaseRepository<Class>
    {

    }
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
