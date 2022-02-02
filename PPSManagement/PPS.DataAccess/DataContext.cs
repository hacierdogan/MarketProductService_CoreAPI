using Microsoft.EntityFrameworkCore;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPS.DataAccess
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-JPVN7MA; Database=PPS_DB;uid=sa;pwd=123;integrated security=true;");
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductTagMapping> ProductTagMappings { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitDetail> UnitDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
