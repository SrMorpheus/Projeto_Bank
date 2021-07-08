using System;
using System.Collections.Generic;
using TRANSFERENCIA.Src;

namespace TRANSFERENCIA
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){

                switch (opcaoUsuario){
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
            Console.WriteLine("Valew pelo uso do app");
            Console.ReadLine();
        
        
        }
        private static void Depositar(){
            Console.Write("Digite o numero  da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do seu deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito); 

        }
        private static void Sacar(){
            Console.Write("Digite o numero da conta : ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do seu saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);

        }

        private static void Transferir(){
            Console.Write("Digite o número da conta: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tipo de transferência");
            Console.WriteLine(" 1 - Pix");
            Console.WriteLine(" 2 - Ted");
            Console.WriteLine(" 3 - Doc");
            int tipoTransferencia = int.Parse(Console.ReadLine());

            Console.Write("Digite o a ser transferido:");
            double ValorTransfarencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(ValorTransfarencia, listContas[indiceContaDestino], (TipoTransferencia) tipoTransferencia );
           


        }

        private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();
            
            Console.Write("Digite Agência do Cliente: ");
			int entradaAgencia = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta: ");
			int entradaNumero = int.Parse(Console.ReadLine());

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

            Conta conta = new Conta((TipoConta) entradaTipoConta,
                                                    entradaSaldo,
                                                    entradaCredito,
                                                    entradaNome,
                                                    entradaAgencia,
                                                    entradaNumero);
            Conta novaConta = conta;

			listContas.Add(novaConta);
		}

        private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}






    }
}
