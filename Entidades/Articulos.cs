using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroParcial1.Entidades
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public float Existencia { get; set; }
        public float Costo { get; set; }
        public float ValorInventario { get; set; }
    
        public Articulos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }
    
    }
}
