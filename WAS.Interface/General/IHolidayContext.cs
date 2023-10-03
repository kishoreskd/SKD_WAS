using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;

namespace WAS.Interface
{
    public interface IHolidayContext : IRepository<Holiday>
    {

        void Update(Holiday holiday);
        Task<int> Commit();
    }
}
