using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;



namespace WAS.Context.Admin
{
    public class EmployeeContext : Repository<Employee>, IEmployeeContext
    {
        private readonly ApplicationContext _context;
        public EmployeeContext(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Employee employee)
        {
            _context.Employee.Update(employee);
        }

        public int GetCount()
        {
            IQueryable<Employee> iquery = _context.Employee;

            return (from row in iquery
                    where row.Id > 0
                    select row).Count();
        }
    }
}
