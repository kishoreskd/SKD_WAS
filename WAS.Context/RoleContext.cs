using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;

namespace WAS.Context.Admin
{
    public class RoleContext : Repository<Role>, IRoleContext
    {
        private readonly ApplicationContext _context;
        public RoleContext(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Role role)
        {
            _context.Role.Update(role);
        }
    }
}
