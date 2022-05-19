using System;
using System.Collections.Generic;

namespace Teste_API_Banco_2.Models
{
    public partial class TabHistorico
    {
        public int Idhistorico { get; set; }
        public string NomeDoTitular { get; set; }
        public string Descricao { get; set; }
        public double ValorMovimentacao { get; set; }
        public double ValorFinal { get; set; }
    }
}
