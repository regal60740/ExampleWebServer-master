using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ResourcesController : ApiController
    {
        private WebApplicationContext db = new WebApplicationContext();

        // GET: api/Resources
        public IQueryable<Resources> GetResources()
        {
            return db.Resources;
        }

        // GET: api/Resources/2
        [ResponseType(typeof(Resources))]
        public async Task<IHttpActionResult> GetResources(int id)
        {
            Resources resources = await db.Resources.FindAsync(id);
            if (resources == null)
            {
                return NotFound();
            }

            return Ok(resources);
        }

        // PUT: api/Resources/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResources(int id, Resources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resources.Id)
            {
                return BadRequest();
            }

            db.Entry(resources).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourcesExists(id))
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

        // POST: api/Resources
        [ResponseType(typeof(Resources))]
        public async Task<IHttpActionResult> PostResources(Resources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Resources.Add(resources);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = resources.Id }, resources);
        }

        // DELETE: api/Resources/5
        [ResponseType(typeof(Resources))]
        public async Task<IHttpActionResult> DeleteResources(int id)
        {
            Resources resources = await db.Resources.FindAsync(id);
            if (resources == null)
            {
                return NotFound();
            }

            db.Resources.Remove(resources);
            await db.SaveChangesAsync();

            return Ok(resources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResourcesExists(int id)
        {
            return db.Resources.Count(e => e.Id == id) > 0;
        }
    }
}