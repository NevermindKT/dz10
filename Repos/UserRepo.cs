using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    class UserRepo : Repository<User>
    {
        public UserRepo(MyDbContext context) : base(context) { }
    }
}