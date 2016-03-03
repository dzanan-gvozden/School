﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;

namespace ReservationSystem.Controllers
{
    public class PeopleController : BaseController
    {

        public ActionResult Index()
        {
            return View(new Repository<Person>(Context).Get().ToList().Select(x => Factory.Create(x)));
        }

        public ActionResult Details(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeopleModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {

            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PeopleModel model)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new Repository<Person>(Context).Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Engagements(int id)
        {
            PersonEngagement model = new PersonEngagement();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Engagements = new EngagementUnit(Context)
                               .Get().Where(x => x.Person.Id == id).ToList()
                               .Select(x => Factory.Create(x)).ToList();
            return View(model);

        }

        public ActionResult EngCreate(int id)   // id = Person.Id
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new EngagementModel()
            { Id = 0, Person = person.Id, PersonName = person.FirstName + " " + person.LastName });
        }

        //POST people/engcreate/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EngCreate(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                Engagement engagement = Parser.Create(model);
                new EngagementUnit(Context).Insert(engagement);
                return RedirectToAction("Engagements/" + model.Person);
            }
            return View(model);
        }

        public ActionResult EngEdit(int id)       // id = Egagement.Id
        {
            FillBag();
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        //POST people/engedit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EngEdit(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                Engagement engagement = Parser.Create(model);
                new EngagementUnit(Context).Update(engagement, engagement.Id);
                return RedirectToAction("Engagements/" + model.Person);
            }
            return View(model);
        }

        public ActionResult EngDelete(int id)
        {
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));

        }

        //POST people/engdelete/1
        [HttpPost, ActionName("EngDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EngDeleteConfirmed(int id)
        {
            EngagementUnit engagements = new EngagementUnit(Context);
            int employee = engagements.Get(id).Person.Id;
            engagements.Delete(id);
            return RedirectToAction("engagements/" + employee);
        }

        void FillBag()
        {
            
            ViewBag.RolesList = new SelectList(new Repository<Role>(Context).Get().ToList(), "Id", "Name");
            ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");
        }
    }
}