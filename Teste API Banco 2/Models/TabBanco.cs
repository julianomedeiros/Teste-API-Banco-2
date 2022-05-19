using System;
using System.Collections.Generic;

namespace Teste_API_Banco_2.Models
{
    public partial class TabBanco
    {
        public int IdBanco { get; set; }
        public double Saldo { get; set; }
        public bool Ativo { get; set; }
    }
}
