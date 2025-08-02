using AutoMapper;
using MediatR;
using TicketManagement.Application.Common;
using TicketManagement.Application.Domains.Users.DTOs;
using TicketManagement.Domain.Domains.Users;
using UserManagement.Application.Domains.Users.Commands;

namespace UserManagement.Application.Domains.Users.Handlers;

public class CreateUserCommandHandler(IUserWriteRepository usertWriteRepository, IMapper mapper, IPasswordHasher passwordHasher) : IRequestHandler<CreateUserCommand, UserResponseDto>
{
    private readonly IUserWriteRepository _usertWriteRepository = usertWriteRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<User>(request.User);
        newUser.SetPasswordHash(_passwordHasher.Hash(request.User.Password));

        var result = await _usertWriteRepository.AddAsync(newUser);
        await _usertWriteRepository.SaveChangesAsync();
        return _mapper.Map<UserResponseDto>(result);
    }
}
