using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;



namespace WAS.Interface
{
    public interface IProjectAllocationContext : IRepository<Project>
    {
        void Update(ProjectAllocation project);
        Task<int> Commit();
    }
}
