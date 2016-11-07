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
    public class ProjectsController : ApiController
    {
        private TMSContext db = new TMSContext();

        // GET: api/Projects
        public List<ProjectDTO> GetProjects()
        {
            List<Project> projects = db.Projects.ToList();
            List<ProjectDTO> projectsDTO = new List<ProjectDTO>();
            foreach (Project project in projects)
            {
                int time = 0;
                HashSet<int> employees = new HashSet<int>();
                foreach (ProjectTask task in project.Tasks)
                {
                    TimeSpan diff = task.TimeEnd - task.TimeStart;
                    if ((int)diff.TotalMinutes > 0)
                    {
                        time += (int)diff.TotalMinutes;
                    }
                    

                    employees.Add(task.EmployeeID);
                }
                ProjectDTO projectDTO = new ProjectDTO { ID = project.ID, Description = project.Description, Name = project.Name, Status = project.Status, TimeElapsedInMinutes = time, CountOfEmployees = employees.Count };
                projectsDTO.Add(projectDTO);
            }

            return projectsDTO;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetProject(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ID)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> DeleteProject(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            await db.SaveChangesAsync();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ID == id) > 0;
        }
    }
}