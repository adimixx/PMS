﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMS.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class photogEntities : DbContext
    {
        public photogEntities()
            : base("name=photogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<ChatKey> ChatKeys { get; set; }
        public virtual DbSet<DbBackupRecord> DbBackupRecords { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobCharge> JobCharges { get; set; }
        public virtual DbSet<JobDate> JobDates { get; set; }
        public virtual DbSet<JobDateUser> JobDateUsers { get; set; }
        public virtual DbSet<JobStatu> JobStatus { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<StudioLink> StudioLinks { get; set; }
        public virtual DbSet<StudioRole> StudioRoles { get; set; }
        public virtual DbSet<SystemRole> SystemRoles { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFeedback> UserFeedbacks { get; set; }
        public virtual DbSet<UserStudio> UserStudios { get; set; }
        public virtual DbSet<UserSystemRole> UserSystemRoles { get; set; }
    }
}
