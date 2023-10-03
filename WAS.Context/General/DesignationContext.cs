using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;



namespace WAS.Context.Admin
{
    public class DesignationContext : Repository<Designation>, IDesignationContext
    {
        private readonly ApplicationContext _context;
        public DesignationContext(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Designation des)
        {
            _context.Designation.Update(des);
        }

        public int GetCount()
        {
            IQueryable<Designation> iquery = _context.Designation;

            return (from row in iquery
                    where row.DesignationId > 0
                    select row).Count();
        }

    }
}
