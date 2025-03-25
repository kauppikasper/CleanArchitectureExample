using CleanArchitectureExample.Application.Dtos;
using CleanArchitectureExample.Application.Mappers;
using CleanArchitectureExample.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureExample.Application.Features.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDto?>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            return user?.ToDto();
        }
    }
}
