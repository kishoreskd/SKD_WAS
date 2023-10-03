using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WAS.Model;
using WAS.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WAS.Context
{
    public class UserTasksContext : Repository<UserTasks>, IUserTasks
    {
        private readonly ApplicationContext _context;
        public UserTasksContext(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void Update(UserTasks activity)
        {
            _context.UserTasks.Update(activity);
        }
    }
}
