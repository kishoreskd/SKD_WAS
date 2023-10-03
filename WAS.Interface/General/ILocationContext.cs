using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;

namespace WAS.Interface
{
    public interface ILocationContext : IRepository<Location>
    {
        void Update(Location location);
        Task<int> Commit();
    }
}
