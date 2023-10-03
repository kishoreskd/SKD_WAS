using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;

namespace WAS.Interface
{
    public interface IDesignationContext : IRepository<Designation>
    {

        void Update(Designation designation);
        Task<int> Commit();
    }
}
