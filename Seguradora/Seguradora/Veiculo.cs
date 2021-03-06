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
    
    public partial class Veiculo
    {
        public Veiculo()
        {
            this.Cotacao = new HashSet<Cotacao>();
        }
    
        public int ID { get; set; }
        public decimal Valor { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; }
        public string CodigoFipe { get; set; }
        public string MesReferencia { get; set; }
        public int TipoVeiculo { get; set; }
        public string SiglaCombustivel { get; set; }
    
        public virtual AnoModelo AnoModelo1 { get; set; }
        public virtual Marca Marca1 { get; set; }
        public virtual Modelo Modelo1 { get; set; }
        public virtual ICollection<Cotacao> Cotacao { get; set; }
    }
}
