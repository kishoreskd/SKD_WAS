using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;

namespace WAS.Context.Manager
{
    public class ProjectEstimationContext : Repository<ProjectEstimation>, IProjectEstimationContext
    {
        private readonly ApplicationContext _context;
        public ProjectEstimationContext(ApplicationContext context) : base(context)
        {
            _context = context;

        }
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
        public void Update(ProjectEstimation projectEstimation)
        {
            _context.ProjectEstimation.Update(projectEstimation);
        }
    }
}
