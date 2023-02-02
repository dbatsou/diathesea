using Application.Core;
using AutoMapper;
using Common.Services;
using MediatR;
using Storage;
namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<Domain.Entities.User>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, Domain.Entities.User>
        {
            private readonly IPasswordService _passwordService;

            public Handler(DataContext context, IMapper mapper, IPasswordService passwordService)
            : base(context, mapper)
            {
                _passwordService = passwordService;
            }

            public async Task<Domain.Entities.User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = _context.User.SingleOrDefault(x => x.Username == request.Username);
                if (user == null)
                    return null;

                if (!_passwordService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    return null;

                return user;
            }
        }
    }
}