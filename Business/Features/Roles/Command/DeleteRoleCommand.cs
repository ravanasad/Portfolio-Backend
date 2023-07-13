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
    public class DeleteRoleCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
        {
            private RoleManager<AppRole> _roleManager;

            public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                IdentityResult result = await _roleManager.DeleteAsync(new() { Id = request.Id });
                return result.Succeeded;
            }
        }
    }
}
