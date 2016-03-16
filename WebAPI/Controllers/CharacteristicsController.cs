﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CharacteristicsController : BaseController<Characteristic>
    {
        public CharacteristicsController(Repository<Characteristic> depo) : base(depo)
        { }

        public IList<CharacteristicModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (Repository.Get(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(Repository.Get(id)));
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        public IHttpActionResult Post(CharacteristicModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(CharacteristicModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
            public IHttpActionResult Delete(int id)
        {
            try
            {
                if (Repository.Get(id) != null)
                {
                    Repository.Delete(id);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
           
        }
    
    }

