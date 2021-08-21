using System;
namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}
        private string Nome {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if ((this.Saldo + this.Credito) - valorSaque < 0){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1:C}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1:C}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = $"TipoConta: {this.TipoConta} | Nome: {this.Nome} | Saldo: {this.Saldo:C} | Crédito: {this.Credito:C}";
            return retorno;
        }
        public string getNomeConta() {
            return this.Nome;
        }
    }
}