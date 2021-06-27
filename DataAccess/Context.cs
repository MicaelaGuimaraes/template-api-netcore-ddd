using DataAccess.Mappings;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               @"Server=serverTemplate;Initial Catalog=Template;Persist Security Info=False;User ID=template;Password=template;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TemplateMappings());

        }

        public DbSet<Template> Template { get; set; }

    }
}
