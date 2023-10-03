using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;



namespace WAS.Interface
{
    public interface IProjectContext : IRepository<Project>
    {
        void Update(Project project);
        Task<int> Commit();
    }
}
