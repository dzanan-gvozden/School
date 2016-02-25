﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class EntityParser
    {
        public Engagement Create(EngagementModel model, SchoolContext context)
        {
            return new Engagement()
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Time = model.Time,
                Person = context.People.Find(model.Person),
                Team = context.Teams.Find(model.Team),
                Role = context.Roles.Find(model.Role)
            };
        }

        public EmployeeSkill Create (EmployeeSkillModel model, SchoolContext context)
        {
            return new EmployeeSkill()
            {
                Id = model.Id,
                Employee = context.People.Find(model.Employee),
                Tool = context.Tools.Find(model.Tool),
                Level = model.Level,
                Experience = model.Experience
            };
        }
    }
}