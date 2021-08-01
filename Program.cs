using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Account> listAccounts = new List<Account>();
        static void Main(string[] args)
        {
            string option = GetOption();

            while (option.ToUpper() != "X")
            {
                switch (option)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        ToTransfer();
                        break;
                    case "4":
                        ToWithdraw();
                        break;
                    case "5":
                        ToDeposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                option = GetOption();
            }
        }

        private static void ListAccounts()
        {
            Console.WriteLine("Listar contas");

            if (listAccounts.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para pessoa física ou 2 para jurídica: ");
            int typeAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string name = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double balance = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double credit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(typeAccount: (TypeAccount)typeAccount,
                                             balance: balance,
                                             credit: credit,
                                             name: name);

            listAccounts.Add(newAccount);
        }

        private static void ToTransfer()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indexAccountSource = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indexAccountDestination = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valueTransfer = double.Parse(Console.ReadLine());

            listAccounts[indexAccountSource].ToTransfer(valueTransfer, listAccounts[indexAccountDestination]);
        }

        private static void ToWithdraw()
        {
            Console.Write("Digite o número da conta: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valueDeposit = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].ToWithdraw(valueDeposit);
        }

        private static void ToDeposit()
        {
            Console.Write("Digite o número da conta: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valueWithdraw = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].ToDeposit(valueWithdraw);
        }

        private static string GetOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string option = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return option;
        }

    }
}
