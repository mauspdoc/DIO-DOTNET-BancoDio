using System;
using System.Collections.Generic;
using Figgle;

namespace DIO.Bank
{
    class Program
    {   
        static List<Conta> listContas = new List<Conta>();
        static private bool firstRun = true;
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObterOpcaoUsuario();
            firstRun = false;
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
            
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = 0;
            if (!int.TryParse(Console.ReadLine(), out indiceContaOrigem))
            {
                EscrevaLinhaEmVermelho("Entrada inválida");
                return;
            }
            if (!isValidAccount(indiceContaOrigem)) {
                EscrevaLinhaEmVermelho("Conta inválida");
                return;
            }

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = 0;
            if (!int.TryParse(Console.ReadLine(), out indiceContaDestino))
            {   
                EscrevaLinhaEmVermelho("Entrada inválida");
                return;
            }
            if (!isValidAccount(indiceContaDestino)) {
                EscrevaLinhaEmVermelho("Conta inválida");
                return;
            }

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = 0.0;
            if (!double.TryParse(Console.ReadLine(), out valorTransferencia))
            {
                Console.WriteLine("Entrada inválida");
                return;
            }

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }
        private static void EscrevaLinhaEmVermelho(string mensagem)
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mensagem);
                Console.ResetColor();
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = 0;
            if (!int.TryParse(Console.ReadLine(), out indiceConta))
            {
                EscrevaLinhaEmVermelho("Entrada inválida");
                return;
            }
            if (!isValidAccount(indiceConta)) {
                EscrevaLinhaEmVermelho("Conta inválida");
                return;
            }

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = 0.0;
            if (!double.TryParse(Console.ReadLine(), out valorDeposito))
            {
                EscrevaLinhaEmVermelho("Entrada inválida");
                return;
            }
            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = 0;
            if (!int.TryParse(Console.ReadLine(), out indiceConta))
            {
                EscrevaLinhaEmVermelho("Entrada inválida");
                return;
            }
            if (!isValidAccount(indiceConta)) {
                EscrevaLinhaEmVermelho("Conta inválida");
                return;
            }

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = 0.0;
            if (!double.TryParse(Console.ReadLine(), out valorSaque))
            {
                EscrevaLinhaEmVermelho("Entrada inválida");
                return;
            }
            listContas[indiceConta].Sacar(valorSaque);
        }
    
        private static bool isValidAccount(int index) {return hasIndexAccount(index);}
        private static bool hasIndexAccount(int index)
        {
            if (index < listContas.Count) {return true;}
            return false;
        }
        private static void ListarContas()
        {   
            if (listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastada");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta");

            Console.Write("Digite 1 para Conta Física e 2 para Conta Jurídica: ");
            int entradaTipoConta = 0;
            if(!int.TryParse(Console.ReadLine(), out entradaTipoConta)) {
                Console.Clear();
                EscrevaLinhaEmVermelho("Entrada inválida!");
                return;
            }

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = 0.0;
            if(!double.TryParse(Console.ReadLine(), out entradaSaldo)) {
                Console.Clear();
                EscrevaLinhaEmVermelho("Entrada inválida!");
                return;
            }

            Console.Write("Digite o crédito: ");
            double entradaCredito = 0.0;
            if(!double.TryParse(Console.ReadLine(), out entradaCredito)) {
                Console.Clear();
                EscrevaLinhaEmVermelho("Entrada inválida!");
                return;
            }

            Conta novaConta = new Conta(
                tipoConta: (TipoConta) entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome
                );
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            if (firstRun)
            {
                Console.WriteLine(FiggleFonts.Starwars.Render("BANCO DIO"));
            }
            Console.WriteLine("Bem vindo ao banco DIO. Estamos ao seu dispor!!!");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar a tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }

    
}
