﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;


namespace WebAPI.Helpers
{
    public class ListTeams
    {
        public static ListTeamsModel Create(Team team)
        {
            Person person = new Person();
           


            ListTeamsModel listteam = new ListTeamsModel()
            {
                Id = team.Id,
                Name = team.Name,

            };

            int dd = DateTime.Now.Month; //(year: 2016, month: 3, day: 1);
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, dd);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, dd, d).DayOfWeek));

 
            var members = team.Details.GroupBy(x => x.Day.Person.FullName).Select(x => new { person = x.Key, time = x.Sum(y => y.WorkTime), empty = x.GroupBy(z => z.Day.Date).Count() }).ToList();

            foreach (var det in members)
            {
                listteam.Members.Add(new CountModel { Category = det.person, Count = (int)det.time, EmptyDays = businessDaysInMonth.Count() - det.empty });
            }

            var time = team.Details.GroupBy(x => x.Team).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var tm in time)
            {
                listteam.Details.Add(new ListModel { Category = "Overall time worked", Count = (int)tm.time });
            }

            var days = team.Details.GroupBy(x => x.Team).Select(x => new { type = x.Key, days = x.Count() }).ToList();

            foreach (var day in days)
            {
                listteam.Days.Add(new ListModel { Category = "Overall days worked", Count = (int)day.days });
            }

            foreach (var d in members)
            {

                listteam.MissedDays = businessDaysInMonth.Count() - d.empty;
            }   
            
            return listteam;         
        }
     }
}