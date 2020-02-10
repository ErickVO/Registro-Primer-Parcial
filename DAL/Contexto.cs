using Microsoft.EntityFrameworkCore;
using RegistroParcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroParcial1.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-9RKG0AB\SQLEXPRESS; DataBase = ArticulosDb; Trusted_Connection: True");
        }
    }
}
