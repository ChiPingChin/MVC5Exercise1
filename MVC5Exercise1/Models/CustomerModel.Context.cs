﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5Exercise1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CustomerEntities : DbContext
    {
        public CustomerEntities()
            : base("name=CustomerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<客戶資料> 客戶資料 { get; set; }
        public virtual DbSet<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual DbSet<客戶聯絡人> 客戶聯絡人 { get; set; }
        public virtual DbSet<客戶統計檢視表> 客戶統計檢視表 { get; set; }
    }
}
