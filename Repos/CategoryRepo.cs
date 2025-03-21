using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    class CategoryRepo : Repository<Category>
    {
        public CategoryRepo(string connectionString) : base(connectionString) { }
    }
}