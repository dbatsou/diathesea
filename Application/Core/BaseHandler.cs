using Storage;
namespace Application.Core
{
    public class BaseHandler
    {
        protected DataContext _context;

        public BaseHandler(DataContext context)
        {
            _context = context;
        }
    }
}