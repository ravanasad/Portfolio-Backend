using Business.Features.Auths.Dtos;
using Business.Features.Auths.Rules;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auths.Commands.AssignRoleToUser
{
    public class AssignRoleToUserCommand : IRequest<AssignRoleToUserDto>
    {
        public string Id { get; set; }
        public List<string> Roles { get; set; }

        public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, AssignRoleToUserDto>
        {
            private RoleManager<AppRole> _roleManager;
            private UserManager<AppUser> _userManager;
            private AuthBusinessRules _rules;
            public AssignRoleToUserCommandHandler(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, AuthBusinessRules rules)
            {
                _roleManager = roleManager;
                _userManager = userManager;
                _rules = rules;
            }

            public async Task<AssignRoleToUserDto> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
            {
                AppUser? user = await _rules.UserShouldBeExists(request.Id);
                request.Roles = await _rules.CheckAndAddRole(user,request.Roles);
                return new() { Email = user.Email, Role = request.Roles };
            }
        }
    }
}
