﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using TimeTracking.Models;

namespace TimeTracking.Controllers
{
    public class PeopleController : BaseController
    {
        public ActionResult Index()
        {
            return View(new Repository<Person>(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }
<<<<<<< HEAD

=======
        
>>>>>>> delta
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD

=======
 
>>>>>>> delta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
<<<<<<< HEAD

            return View(model);
        }


=======
            
            return View(model);
        }

        
>>>>>>> delta
        public ActionResult Edit(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonModel model)
        {

            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new Repository<Person>(Context).Delete(id);
            return RedirectToAction("Index");
        }

<<<<<<< HEAD
        public ActionResult Days(int id)
=======
        public ActionResult Days (int id)
>>>>>>> delta
        {
            PersonDays model = new PersonDays();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Days = new DayUnit(Context)
                               .Get().Where(x => x.Person.Id == id).ToList()
                               .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            PersonDetails model = new PersonDetails();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Details = new DayUnit(Context)
                               .Get().Where(x => x.Person.Id == id).ToList()
                               .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult DayCreate(int id)   // id = Person.Id
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new DayModel()
            { Id = 0, Person = person.Id, PersonName = person.FirstName + " " + person.LastName });
        }

        public ActionResult DayEdit(int id)     // id = Egagement.Id
        {
            FillBag();
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
        }
    }
}