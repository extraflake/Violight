using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection") { }

        // Master 
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model.Type> Types { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        // Transaction
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Item> Items { get; set; }

        // Account
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
    }
}
