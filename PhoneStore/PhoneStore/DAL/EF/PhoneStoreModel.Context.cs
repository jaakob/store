﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneStore.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhoneStoreContext : DbContext
    {
        public PhoneStoreContext()
            : base("name=PhoneStoreContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ImageEntity> Images { get; set; }
        public virtual DbSet<PhoneEntity> Phones { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
    }
}