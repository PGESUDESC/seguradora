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
    
    public partial class ObjetoSegurado
    {
        public ObjetoSegurado()
        {
            this.Apolice = new HashSet<Apolice>();
        }
    
        public int Codigo { get; set; }
        public int Segurado { get; set; }
        public string TipoAutomovel { get; set; }
        public string CodigoFipe { get; set; }
        public string Categoria { get; set; }
        public Nullable<int> Marca { get; set; }
        public Nullable<int> Modelo { get; set; }
        public Nullable<int> Potencia { get; set; }
        public Nullable<System.DateTime> AnoDeFabricacao { get; set; }
        public Nullable<System.DateTime> AnoModelo { get; set; }
        public string Chassi { get; set; }
        public string Placa { get; set; }
        public Nullable<int> QtdPortas { get; set; }
        public Nullable<int> NroPassageiros { get; set; }
        public string CepPernoite { get; set; }
        public string Renavam { get; set; }
        public Nullable<decimal> ValorFipe { get; set; }
        public Nullable<decimal> ValorCotado { get; set; }
    
        public virtual Marca Marca1 { get; set; }
        public virtual Modelo Modelo1 { get; set; }
        public virtual Segurado Segurado1 { get; set; }
        public virtual Segurado Segurado2 { get; set; }
        public virtual ICollection<Apolice> Apolice { get; set; }
    }
}