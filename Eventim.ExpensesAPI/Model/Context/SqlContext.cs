using Eventim.ExpensesAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;

namespace Eventim.Expenses.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ExpensesGroupsPeople>().HasOne(x => x.ExpensesGroups).WithMany(x => x.expensesGroupsPeople);
            modelBuilder.Entity<ExpensesGroups>().HasMany(x => x.expenses).WithOne(x => x.ExpensesGroups);            
            modelBuilder.Entity<Expenses>().HasOne(x => x.ExpensesGroups).WithMany(x=> x.expenses);
            modelBuilder.Entity<Expenses>().HasOne(x => x.ExpensesGroupsPeople);
        }

        public DbSet<Expenses> _Expenses { get; set; }
        public DbSet<ExpensesGroups> _ExpensesGroups { get; set; }
        public DbSet<Payments> _Payments { get; set; }
        public DbSet<ExpensesGroupsPeople> _ExpensesGroupsPeople { get; set; }
    }
}
