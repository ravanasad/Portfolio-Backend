﻿using Business.Dtos;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.JWT
{
    public interface IJwtService
    {
        Token CreateAccessToken(AppUser user);
    }
}
