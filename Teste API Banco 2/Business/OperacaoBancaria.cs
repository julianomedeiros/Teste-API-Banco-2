using Teste_API_Banco_2.Models;

namespace Teste_API_Banco_2.Business
{
    public class OperacaoBancaria
    {
        public bool Deposito(double valorDeposito)
        {
            if (valorDeposito > 0)
            {
                TabCliente cliente = new TabCliente();
                cliente.Saldo = +valorDeposito;
                return true;
            }
            else { return false; } 
        }

        public void Retirada(string nomeDoTitular, float valorRetirada)
        {

        }

        public void Transfere(string nomeDoTitular, float valorTransferencia, string nomeTitularRecebe)
        {

        }
        
    }
}
