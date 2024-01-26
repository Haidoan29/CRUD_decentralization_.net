using _200124.Data;
using _200124.Models;

namespace _200124.Repository
{
    public interface IStudentRepository : IBaseRepository<Student>
    {

    }
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
