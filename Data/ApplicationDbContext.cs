using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebAppCapellaKM_05.Models.Author> Author { get; set; }
        public DbSet<WebAppCapellaKM_05.Models.Publication> Publication { get; set; }
        public DbSet<WebAppCapellaKM_05.Models.PubWork> PubWork { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Author>().ToTable("Author");
    //        modelBuilder.Entity<Publication>().ToTable("Publication");

    //        modelBuilder.Entity<PubWork>()
    //            .HasKey(c => new { c.AuthorID, c.PublicationID });
    //    }
    }
}
