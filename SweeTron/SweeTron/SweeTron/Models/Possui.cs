//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SweeTron.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Possui
    {
        public int ID_Ingrediente { get; set; }
        public int ID_Receita { get; set; }
        public Nullable<double> Quantidade { get; set; }
    
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Receita Receita { get; set; }
    }
}