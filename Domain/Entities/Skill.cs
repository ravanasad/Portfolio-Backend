﻿using Domain.Entities.Identity;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public byte Value { get; set; } = 10;

        public AppUser User { get; set; }
    }
}
