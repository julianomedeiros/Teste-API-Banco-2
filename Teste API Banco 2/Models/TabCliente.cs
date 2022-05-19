using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teste_API_Banco_2.Models
{
    public partial class TabCliente
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        public string Nome { get; set; }

        [Range(18, 120, ErrorMessage = "Erro ao cadastrar: Motivo idade!!")]
        public int Idade { get; set; }

        public double Saldo { get; set; }

        public bool Ativo { get; set; }
    }
}
