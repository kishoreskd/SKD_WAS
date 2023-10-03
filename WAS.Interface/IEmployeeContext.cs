using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;

namespace WAS.Interface
{
    public interface IEmployeeContext : IRepository<Employee>
    {
        void Update(Employee employee);
        Task<int> Commit();
    }
}
