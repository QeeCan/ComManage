using Community.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Data
{
    public class MvcCommuniContext : DbContext
    {
        public MvcCommuniContext(DbContextOptions<MvcCommuniContext> options)
           : base(options)
        {
        }

        public DbSet<Communi> Communis { get; set; }
    }
}
