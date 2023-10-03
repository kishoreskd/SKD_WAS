using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WAS.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WAS.Interface;

namespace WAS.Context.Manager
{
    public class ProjectContext : Repository<Project>, IProjectContext
    {
        private readonly ApplicationContext _context;
        public ProjectContext(ApplicationContext context) : base(context)
        {
            _context = context;

        }
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
        public void Update(Project project)
        {

            _context.Update(project);

            //var entity = _context.Project.Attach(project);
            //entity.Entry(project).State = EntityState.Modified;
            //entity.SaveChanges();
            //return updatedUser;


            //Project proj = _context.Project.
            //    Where(p => p.ProjectId == project.ProjectId)
            //   .Include(pe => pe.ProjectEstimation)
            //   .FirstOrDefault();

            //var proj = GetFirstOrDefault(p => p.ProjectId == project.ProjectId, inCludePropperties: "ProjectEstimation");

            ////Update Parent
            //_context.Entry(project).CurrentValues.SetValues(project);
            ////_context.ProjectEstimation.Remove(proj.ProjectEstimation);

            //ProjectEstimation projectEstimation = _context.ProjectEstimation.Where(pe => pe.ProjectId == project.ProjectId).FirstOrDefault();

            //_context.Entry(project.ProjectEstimation).CurrentValues.SetValues(project.ProjectEstimation);


            //IEnumerable<EntityEntry> entries = _context.ChangeTracker.Entries();

            //foreach (EntityEntry item in entries)
            //{
            //    Console.WriteLine("Entity Name : {0}", item.Entity.GetType().Name);
            //    Console.WriteLine("Status : {0}", item.State);
            //}
        }
    }
}
