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
    
    public partial class Modelo
    {
        public Modelo()
        {
            this.AnoModelo = new HashSet<AnoModelo>();
            this.ObjetoSegurado = new HashSet<ObjetoSegurado>();
            this.Veiculo = new HashSet<Veiculo>();
            this.Aditamento = new HashSet<Aditamento>();
            this.Cotacao = new HashSet<Cotacao>();
        }
    
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Marca { get; set; }
        public int TipoVeiculo { get; set; }
    
        public virtual ICollection<AnoModelo> AnoModelo { get; set; }
        public virtual Marca Marca1 { get; set; }
        public virtual ICollection<ObjetoSegurado> ObjetoSegurado { get; set; }
        public virtual ICollection<Veiculo> Veiculo { get; set; }
        public virtual ICollection<Aditamento> Aditamento { get; set; }
        public virtual ICollection<Cotacao> Cotacao { get; set; }
    }
}
