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
using Microsoft.Ajax.Utilities;

namespace TimeTracking.Controllers
{
    public class DaysController : BaseController
    {
        public ActionResult Index()
        {
            return View(new DayUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }


        public ActionResult Details(int id)
        {
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }


        public ActionResult Create()
        {
            FillBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayModel model)
        {
            if (ModelState.IsValid)
            {
                new DayUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Days/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DayModel model)
        {

            if (ModelState.IsValid)
            {
                new DayUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Days/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }

        // POST: Days/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new DayUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }


        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
        }
    }
}





