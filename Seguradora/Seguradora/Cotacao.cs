//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seguradora
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cotacao
    {
        public Cotacao()
        {
            this.Apolice = new HashSet<Apolice>();
        }
    
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public Nullable<int> NumeroAditivo { get; set; }
        public Nullable<int> Modalidade { get; set; }
        public Nullable<System.DateTime> DataInicial { get; set; }
        public Nullable<System.DateTime> DataFinal { get; set; }
    
        public virtual ICollection<Apolice> Apolice { get; set; }
    }
}