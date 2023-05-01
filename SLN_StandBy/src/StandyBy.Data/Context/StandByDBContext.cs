using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandyBy.Data.Context
{
    public class StandByDBContext : DbContext
    {
        public StandByDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
