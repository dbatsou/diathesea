using Application.Core;
using AutoMapper;
using Common.Services;
using MediatR;
using Storage;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<Domain.Entities.User>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, Domain.Entities.User>
        {
            private readonly IPasswordService _passwordService;
            public Handler(DataContext context, IMapper mapper, IPasswordService passwordService)
            : base(context, mapper)
            {
                _passwordService = passwordService;
            }

            public async Task<Domain.Entities.User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (_context.User.Any())
                    return null;

                byte[] passwordHash, passwordSalt;
                _passwordService.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                var user = new Domain.Entities.User()
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Username = request.Username,
                };

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();

                return new Domain.Entities.User() { Username = user.Username };
            }
        }
    }
}