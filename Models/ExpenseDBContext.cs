using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWallet.Models
{
    public class ExpenseDBContext : DbContext
    {
        public virtual DbSet<ExpenseReport> ExpenseReport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FamilyWallet;Trusted_Connection=True;");
            }
        }
    }
}