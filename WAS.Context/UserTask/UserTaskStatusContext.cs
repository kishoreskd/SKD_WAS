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
    public class UserTaskStatusContext : Repository<UserTaskStatus>, IUserTaskStatusContext
    {
        private readonly ApplicationContext _context;
        public UserTaskStatusContext(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void Update(UserTaskStatus status)
        {
            _context.UserTaskStatus.Update(status);
        }
    }
}
