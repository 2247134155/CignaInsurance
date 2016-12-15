using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CignaInsurance.Models;

namespace CignaInsurance.Dal
{
    public class CustomerDal : DbContext
    {
        public CustomerDal() : base("name= HealthInsuranceDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
        public DbSet<Customer> Customer { get; set; }
    }
}