//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class producto
    {
        public producto()
        {
            this.det_factura = new HashSet<det_factura>();
        }
    
        public int cod_producto { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio_unitario { get; set; }
    
        public virtual ICollection<det_factura> det_factura { get; set; }
    }
}
