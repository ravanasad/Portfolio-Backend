using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Roles.Command
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
        {
            private RoleManager<AppRole> _roleManager;

            public CreateRoleCommandHandler(RoleManager<AppRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                IdentityResult identiyResult = await _roleManager.CreateAsync(new() { Name=request.Name});

                return identiyResult.Succeeded;
            }
        }
    }
}
