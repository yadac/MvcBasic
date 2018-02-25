using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcBasic.Models
{
    public class MvcBasicContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}