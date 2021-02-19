using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class tb_gastosController : ApiController
    {
        private ApiEntities1 db = new ApiEntities1();

        // GET: api/tb_gastos
        public IQueryable<tb_gastos> Gettb_gastos()
        {
            return db.tb_gastos;
        }

        // GET: api/tb_gastos/5
        [ResponseType(typeof(tb_gastos))]
        public IHttpActionResult Gettb_gastos(int id)
        {
            tb_gastos tb_gastos = db.tb_gastos.Find(id);
            if (tb_gastos == null)
            {
                return NotFound();
            }

            return Ok(tb_gastos);
        }

        // PUT: api/tb_gastos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_gastos(int id, tb_gastos tb_gastos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_gastos.id_gasto)
            {
                return BadRequest();
            }

            db.Entry(tb_gastos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_gastosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tb_gastos
        [ResponseType(typeof(tb_gastos))]
        public IHttpActionResult Posttb_gastos(tb_gastos tb_gastos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_gastos.Add(tb_gastos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_gastos.id_gasto }, tb_gastos);
        }

        // DELETE: api/tb_gastos/5
        [ResponseType(typeof(tb_gastos))]
        public IHttpActionResult Deletetb_gastos(int id)
        {
            tb_gastos tb_gastos = db.tb_gastos.Find(id);
            if (tb_gastos == null)
            {
                return NotFound();
            }

            db.tb_gastos.Remove(tb_gastos);
            db.SaveChanges();

            return Ok(tb_gastos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_gastosExists(int id)
        {
            return db.tb_gastos.Count(e => e.id_gasto == id) > 0;
        }
    }
}