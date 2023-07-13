using Business.Exceptions;
using Business.Features.Auth.Dtos;
using Business.Features.Auths.Rules;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Features.Auths.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
        {
            private UserManager<AppUser> _userManager;
            private SignInManager<AppUser> _signInManager;
            private AuthBusinessRules _rules;

            public RegisterCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AuthBusinessRules rules = null)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _rules = rules;
            }

            public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                _ = await _rules.UserShouldBeNotExists(request.Email);
                IdentityResult result = await _userManager.CreateAsync(new() { Email = request.Email, UserName = request.Email }, request.Password);
                if (result.Succeeded)
                {
                    return new() { Email = request.Email };
                }

                throw new UserCreateFailedException();
            }
        }
    }
}
