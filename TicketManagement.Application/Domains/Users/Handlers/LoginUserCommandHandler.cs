using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Common;
using TicketManagement.Domain.Domains.Users;
using UserManagement.Application.Domains.Users.Commands;

namespace UserManagement.Application.Domains.Users.Handlers;

public class LoginUserCommandHandler(IUserReadRepository usertReadRepository,
                                     IPasswordHasher passwordHasher,
                                     IJwtTokenGenerator jwtTokenGenerator)
             : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserReadRepository _usertReadRepository = usertReadRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _usertReadRepository.GetAll().SingleOrDefaultAsync(x => x.Email == request.User.Email, cancellationToken: cancellationToken);
        if (user is null || !_passwordHasher.Verify(user.PasswordHash, request.User.Password))
            throw new UnauthorizedAccessException("Invalid credentials.");

        return _jwtTokenGenerator.GenerateToken(user);
    }
}
