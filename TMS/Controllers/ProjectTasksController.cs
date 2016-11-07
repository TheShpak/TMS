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
using TMS.DAL;
using TMS.Models;

namespace TMS.Controllers
{
    public class ProjectTasksController : ApiController
    {
        private TMSContext db = new TMSContext();

        // GET: api/ProjectTasks
        public List<ProjectTask> GetTasks()
        {
            return db.Tasks.ToList();
        }

        // GET: api/ProjectTasks/5
        [ResponseType(typeof(ProjectTask))]
        public async Task<IHttpActionResult> GetProjectTask(int id)
        {
            ProjectTask projectTask = await db.Tasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return Ok(projectTask);
        }

        // PUT: api/ProjectTasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProjectTask(int id, ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTask.ID)
            {
                return BadRequest();
            }

            db.Entry(projectTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTaskExists(id))
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

        // POST: api/ProjectTasks
        [ResponseType(typeof(ProjectTask))]
        public async Task<IHttpActionResult> PostProjectTask(ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(projectTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = projectTask.ID }, projectTask);
        }

        // DELETE: api/ProjectTasks/5
        [ResponseType(typeof(ProjectTask))]
        public async Task<IHttpActionResult> DeleteProjectTask(int id)
        {
            ProjectTask projectTask = await db.Tasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(projectTask);
            await db.SaveChangesAsync();

            return Ok(projectTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectTaskExists(int id)
        {
            return db.Tasks.Count(e => e.ID == id) > 0;
        }
    }
}