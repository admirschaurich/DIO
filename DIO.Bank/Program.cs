using System;
using System.Collections.Generic;
//25868
namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario){
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
                        Console.WriteLine("Favor escolher uma das opções para prosseguir!");
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
            private static void Transferir(){
            try{
                Console.WriteLine("Transferir");
                Console.WriteLine("Digite o número da conta de origem: ");     
                int indiceContaOrigem = int.Parse(Console.ReadLine());

                 Console.WriteLine("Digite o número da conta de destino: ");     
                int indiceContaDestino = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor a ser transferido: ");     
                double valorTransferencia = double.Parse(Console.ReadLine());          

                listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            }
            catch(Exception ex){
                Console.WriteLine("Ops, algo deu errado ao transferir, favor reiniciar. Erro: " + ex.Message);
            }
        }
            private static void Depositar(){
            try{
                Console.WriteLine("Depositar");
                Console.WriteLine("Digite o número da conta: ");     
                int indiceConta = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor a ser depositado: ");     
                double valorDeposito = double.Parse(Console.ReadLine());          

                listContas[indiceConta].Depositar(valorDeposito);
            }
            catch(Exception ex){
                Console.WriteLine("Ops, algo deu errado ao depositar, favor reiniciar. Erro: " + ex.Message);
            }
        }
        private static void Sacar(){
            try{
                Console.WriteLine("Sacar");
                Console.WriteLine("Digite o número da conta: ");     
                int indiceConta = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor a ser sacado: ");     
                double valorSaque = double.Parse(Console.ReadLine());          

                listContas[indiceConta].Sacar(valorSaque);
            }
            catch(Exception ex){
                Console.WriteLine("Ops, algo deu errado ao sacar, favor reiniciar. Erro: " + ex.Message);
            }
        }
        private static void ListarContas()
        {
            try{
                Console.WriteLine("Listar Contas");

                if (listContas.Count == 0)
                {
                    Console.WriteLine("Nenhuma conta cadastrada.");
                    return;
                }
                foreach (Conta item in listContas)
                {
                    Console.WriteLine(string.Format("#{0} - {1}", listContas.IndexOf(item), item));
                }
            }
            catch(Exception ex){
                Console.WriteLine("Ops, algo deu errado ao listar as contas, favor reiniciar. Erro: " + ex.Message);
            }
        }

        private static void InserirConta()
        {
            try{
                Console.WriteLine("Inserir uma nova conta");
                Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
                int entradaTipoConta = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Digite o nome do Cliente: ");
                string entradaNome = Console.ReadLine();

                Console.WriteLine("Digite o saldo inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite o crédito: ");
                double entradaCredito = double.Parse(Console.ReadLine());

                listContas.Add(new Conta(tipoConta: (ETipoConta)entradaTipoConta,
                                            saldo: entradaSaldo,
                                            credito: entradaCredito,
                                            nome: entradaNome));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ops, algo deu errado ao criar a nova conta, favor reiniciar. Erro: " + ex.Message);
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a oção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
