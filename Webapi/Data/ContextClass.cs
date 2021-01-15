using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Data
{
    public class ContextClass:DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options)
            :base(options)
        {

        }
        public DbSet<Employees> Employees { get; set; }
    }
}
