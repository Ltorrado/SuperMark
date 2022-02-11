using Microsoft.EntityFrameworkCore;
using SuperMark.Common.Model;
using SuperMark.Repository.EntityMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.DbContexts
{
   public class SupermakDbcontext: DbContext
    {

        public string _connectionString { get; set; }
        public SupermakDbcontext(string connectionString)
        {
            _connectionString = connectionString;


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// IDEPRO- tabla de perfiles
        /// </summary>
        public DbSet<Profile> Profiles { get; set; }
        /// <summary>
        /// SMPVEN - VENTAS
        /// </summary>
        public DbSet<Sale> Sales { get; set; }
        /// <summary>
        /// IDEUSU - tabla de usuario
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// SMPPRO - tabla de productos
        /// </summary>
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new SaleMapping());
        }
    }
}
