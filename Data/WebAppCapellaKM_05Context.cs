using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05.Data
{
    public class WebAppCapellaKM_05Context : DbContext
    {
        public WebAppCapellaKM_05Context (DbContextOptions<WebAppCapellaKM_05Context> options)
            : base(options)
        {
        }

        public DbSet<WebAppCapellaKM_05.Models.Author> Author { get; set; }

        public DbSet<WebAppCapellaKM_05.Models.Publication> Publication { get; set; }
    }
}
