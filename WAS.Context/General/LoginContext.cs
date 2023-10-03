using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;


namespace WAS.Context.Login
{
    public class LoginContext : Repository<WAS.Model.Login>, ILoginContext
    {
        private readonly ApplicationContext _context;
        public LoginContext(ApplicationContext context) : base(context)
        {
            _context = context;

        }
    }
}
