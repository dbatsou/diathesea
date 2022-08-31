using Storage;
using AutoMapper;
namespace Application.Core
{
    public class BaseHandler
    {
        protected DataContext _context;
        protected IMapper _mapper;

        public BaseHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}