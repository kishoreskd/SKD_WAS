using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;

namespace WAS.Context.Admin
{
    public class HolidayContext : Repository<Holiday>, IHolidayContext
    {
        private readonly ApplicationContext _context;
        public HolidayContext(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Holiday holiday)
        {
            _context.Holiday.Update(holiday);
        }

        public int GetCount()
        {
            IQueryable<Holiday> iquery = _context.Holiday;

            return (from row in iquery
                    where row.HolidayId > 0
                    select row).Count();
        }
    }
}
