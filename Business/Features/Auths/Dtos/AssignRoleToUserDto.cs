using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auths.Dtos
{
    public class AssignRoleToUserDto
    {
        public List<string> Role { get; set; }
        public string Email { get; set; }
    }
}
