using Business.Dtos;
using Business.Exceptions;
using Business.Features.Auth.Dtos;
using Business.Features.Auths.Rules;
using Business.Security.JWT;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
        {
            private UserManager<AppUser> _userManager;
            private SignInManager<AppUser> _signInManager;
            private IJwtService _jwtService;
            private AuthBusinessRules _rules;
            public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> myProperty, IJwtService jwtService, AuthBusinessRules rules)
            {
                _userManager = userManager;
                _signInManager = myProperty;
                _jwtService = jwtService;
                _rules = rules;
            }

            public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                AppUser? user = await _rules.UserShouldBeExists(request.Email);
                var result = await _rules.CheckPassword(user, request.Password);
                if (result.Succeeded)
                {
                    Token token = _jwtService.CreateAccessToken(user);
                    return new() { Token = token };
                }
                throw new Exception("Something went wrong");
            }
        }
    }
}
