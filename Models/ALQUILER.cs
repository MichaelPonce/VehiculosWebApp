//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehiculosWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALQUILER
    {
        public int IdAlquiler { get; set; }
        public string Localizacion { get; set; }
        public Nullable<System.DateTime> FechaDeEntrega { get; set; }
        public Nullable<System.DateTime> FechaDeDevolucion { get; set; }
        public Nullable<int> FK_IdClientes { get; set; }
        public Nullable<int> FK_Placa { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual VEHICULO VEHICULO { get; set; }
    }
}