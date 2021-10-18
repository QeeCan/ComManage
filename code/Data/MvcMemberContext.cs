using Community.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Data
{
    public class MvcMemberContext : DbContext
    {
        public MvcMemberContext(DbContextOptions<MvcMemberContext> options)
           : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
