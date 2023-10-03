using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;

namespace WAS.Interface
{
    public interface IRoleContext : IRepository<Role>
    {
        void Update(Role location);
        Task<int> Commit();
    }
}
