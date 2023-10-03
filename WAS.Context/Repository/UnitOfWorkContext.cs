using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;
using WAS.Context.Admin;
using WAS.Context.Manager;

namespace WAS.Context.Repository
{
    public class UnitOfWorkContext : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWorkContext(ApplicationContext context)
        {
            this._context = context;
            this.UserTasks = new UserTasksContext(_context);
            this.Employee = new EmployeeContext(_context);
            this.Project = new ProjectContext(_context);
            this.UserTaskStatus = new UserTaskStatusContext(_context);
            this.ProjectAllocation = new ProjectAllocationContext(_context);
        }

        public IUserTasks UserTasks { get; private set; }
        public IEmployeeContext Employee { get; private set; }
        public IProjectContext Project { get; private set; }
        public IUserTaskStatusContext UserTaskStatus { get; private set; }


        public IProjectAllocationContext ProjectAllocation { get; private set; }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
