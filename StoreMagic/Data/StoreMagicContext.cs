using Microsoft.EntityFrameworkCore;
using StoreMagic.Models;
using StoreMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMagic.Data
{
    public class StoreMagicContext : DbContext
    {
        public StoreMagicContext(DbContextOptions<StoreMagicContext> options) : base(options)
        {

        }
        public DbSet<StoreMagic.Models.Vans> Vans { get; set; }


    }
}
