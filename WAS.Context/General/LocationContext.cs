using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;



namespace WAS.Context.Admin
{
    public class LocationContext : Repository<Location>, ILocationContext
    {
        private readonly ApplicationContext _context;
        public LocationContext(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Location loc)
        {
            _context.Location.Update(loc);
        }
    }
}
