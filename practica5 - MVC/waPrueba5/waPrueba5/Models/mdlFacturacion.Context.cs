﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace waPrueba5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ctxPruebas : DbContext
    {
        public ctxPruebas()
            : base("name=ctxPruebas")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<cliente> cliente { get; set; }
        public DbSet<det_factura> det_factura { get; set; }
        public DbSet<factura> factura { get; set; }
        public DbSet<producto> producto { get; set; }
        public DbSet<entrada> entrada { get; set; }
    }
}
