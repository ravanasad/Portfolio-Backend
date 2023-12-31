﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class AboutDal : EfEntityRepositoryBase<About>, IAboutDal
    {
        public AboutDal(BaseContext context) : base(context)
        {
        }
    }
}
