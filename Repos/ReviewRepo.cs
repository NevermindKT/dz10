using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    class ReviewRepo : Repository<Review>
    {
        public ReviewRepo(string connectionString) : base(connectionString) { }
    }
}