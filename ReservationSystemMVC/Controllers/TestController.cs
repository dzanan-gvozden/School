﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;

namespace ReservationSystemMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "This is just for the test.";
        }

        public string Show()
        {
            return "This is another string from the same controller.";
        }

        public string Look(string id)
        {
            return "You just sent a " + id + " to me";
        }

        public ActionResult Get(string id = "X")
        {
            if (id == "X")
            {
                ViewBag.Title = "WorkforceRoster";
                return View();
            }
            else
            {
                return Content("Proslijedise mi " + id);
            }
        }

        public ActionResult Person(int id)
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            Person person = people.Get(id);
            //ViewData ["Person"] = person;
            return View(person);
        }

        public ActionResult People()
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());

            return View(people.Get().ToList());
        }

    }
}
