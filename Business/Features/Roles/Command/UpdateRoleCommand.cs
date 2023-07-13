using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Roles.Command
{
    public class UpdateRoleCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
        {
            private RoleManager<AppRole> _roleManager;

            public UpdateRoleCommandHandler(RoleManager<AppRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                IdentityResult result = await _roleManager.UpdateAsync(new() { Id = request.Id, Name = request.Name });
                return result.Succeeded;
            }
        }
    }
}
