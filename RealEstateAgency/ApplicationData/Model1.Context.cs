﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealEstateAgency.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReaEntities : DbContext
    {
        public ReaEntities()
            : base("name=ReaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdressPhoto> AdressPhoto { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Destiny> Destiny { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<IsThereAHouse> IsThereAHouse { get; set; }
        public virtual DbSet<QuantityRoom> QuantityRoom { get; set; }
        public virtual DbSet<RealtyEarth> RealtyEarth { get; set; }
        public virtual DbSet<RealtyFlat> RealtyFlat { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ViewRealt> ViewRealt { get; set; }
    }
}
