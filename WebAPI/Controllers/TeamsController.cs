﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
<<<<<<< HEAD
using WebApi.Controllers.WebAPI.Controllers;
=======
>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TeamsController : BaseController<Team>
    {
<<<<<<< HEAD

        public TeamsController(Repository<Team> depo) : base(depo)
        { }


=======
        public TeamsController(Repository<Team> depo) : base(depo)
        { }

>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
        public IList<TeamModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id) {
            try
            {
                Team team = Repository.Get(id);
                if (team == null) return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex) {
                return BadRequest();
            }
<<<<<<< HEAD

=======
>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
        }

        public IHttpActionResult Post(Team team)
        {
            try
            {
<<<<<<< HEAD

=======
>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
                if (team == null) return NotFound();
                else {
                    Repository.Insert(team);
                    return Ok(Factory.Create(team));
                }
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(int id, Team team)
        {
            try {
                Team team1 = Repository.Get(id);
                if (team1==null || team == null) return NotFound();
                else {
                    Repository.Update(team, id);
                    return Ok(Factory.Create(team));
                }
            }
            catch(Exception ex)
<<<<<<< HEAD

=======
>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
            {
                return BadRequest();
            }
        }
<<<<<<< HEAD

=======
>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
        public IHttpActionResult Delete(int id) {
            try
            {
                Team team = Repository.Get(id);
                if (team == null) return NotFound();
                else {
                    Repository.Delete(id);
                    return Ok();
                }
<<<<<<< HEAD

=======
>>>>>>> 952f819ffb338a99afe76515cea90e5d184c6faa
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
