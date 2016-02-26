﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.Models
{
    public class EntityParser
    {

        public Engagement Create(EngagementModel model, SchoolContext context)
        {
            return new Engagement()
            {
                Id = 0,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Time = model.Time,
                Person = context.People.Find(model.Person),
                Team = context.Teams.Find(model.Team),
                Role = context.Roles.Find(model.Role)
            };
        }

        public Day Create(DayModel model, SchoolContext context)
        {
            return new Day()
            {
                Id = 0,
                Person = context.People.Find(model.Person),
                Date = model.Date,
                WorkTime = model.WorkTime,
                PtoTime = model.PtoTime,
                EntryStatus = model.EntryStatus
            };
        }
    }
}