﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi_BudgeManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BudgetManagerEntities : DbContext
    {
        public BudgetManagerEntities()
            : base("name=BudgetManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<expense> expenses { get; set; }
        public virtual DbSet<income> incomes { get; set; }
        public virtual DbSet<o_expense> o_expense { get; set; }
        public virtual DbSet<o_income> o_income { get; set; }
        public virtual DbSet<trasaction> trasactions { get; set; }
        public virtual DbSet<user> users { get; set; }

        public System.Data.Entity.DbSet<WebApi_BudgeManagementSystem.ViewModels.IncomeViewModel> IncomeViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApi_BudgeManagementSystem.ViewModels.ExpenseViewModel> ExpenseViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApi_BudgeManagementSystem.ViewModels.UserViewModel> UserViewModels { get; set; }
    }
}
