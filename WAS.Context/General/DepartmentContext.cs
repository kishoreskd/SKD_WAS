using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;



namespace WAS.Context.Admin
{
    public class DepartmentContext : Repository<Department>, IDepartmentContext
    {
        private readonly ApplicationContext _context;
        public DepartmentContext(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Department dep)
        {
            _context.Department.Update(dep);
        }


    }
}
