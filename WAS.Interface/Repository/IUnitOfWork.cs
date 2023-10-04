using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WAS.Interface;

namespace WAS.Interface
{
    public interface IUnitOfWork
    {
        public IUserTasks UserTasks { get; }
        public IEmployeeContext Employee { get; }
        public IUserTaskStatusContext UserTaskStatus { get;  }
        public IProjectAllocationContext ProjectAllocation { get; }

        public Task<int> Commit();
    }
}
