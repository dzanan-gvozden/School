﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ResourceUnit : Repository<Resource>
    {
        public SchoolContext context = new SchoolContext();

        public override void Insert(Resource resource)
        {

            context.Resources.Add(resource);
            context.Entry(resource.ResourceCategory).State = EntityState.Unchanged;
            context.SaveChanges();
        }
    }
}
