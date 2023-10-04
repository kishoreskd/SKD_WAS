using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WAS.Model;
using WAS.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WAS.Context.Manager
{
    public class ProjectAllocationContext : Repository<ProjectAllocation>, IProjectAllocationContext
    {
        private readonly ApplicationContext _context;
        public ProjectAllocationContext(ApplicationContext context) : base(context)
        {
            _context = context;

        }
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
        public void Update(ProjectAllocation project)
        {
            _context.Update(project);
        }
    }
}
