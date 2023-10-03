using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;


namespace WAS.Interface
{
    public interface IProjectEstimationContext : IRepository<ProjectEstimation>
    {
        void Update(ProjectEstimation projectEstimation);
        Task<int> Commit();
    }
}
