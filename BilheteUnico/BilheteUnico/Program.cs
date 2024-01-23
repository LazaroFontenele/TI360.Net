using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteUnico
    {
        static List<Usuario> users = new List<Usuario>();
        static List<IBilheteUnico> tickets = new List<IBilheteUnico>();

        public static void AddUser()
        {
            Usuario user = new Usuario();

            Console.WriteLine("Digite o nome: ");
            user.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf");
            user.Cpf = Console.ReadLine();
            Console.WriteLine("Digite o telefone: ");
            user.Telefone = (int) Convert.ToInt64( Console.ReadLine() ) ;
            Console.WriteLine("Digite o e-Mail: ");
            user.Email= Console.ReadLine();

            users.Add(user);

            Console.WriteLine("Usuario adicionado com sucesso");

        }

        public static void AddTicket()
        {

            Console.WriteLine("----- Cadastro de Bilhete -----");

            if (users.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados. Cadastre um usuário primeiro.");
                return;
            }


            Console.WriteLine("Tipo de bilhete. 1 - Comum  / 2 - Estudante");
            int typeTicket = (int)Convert.ToInt16(Console.ReadLine());
            while (typeTicket != 1 && typeTicket != 2)
            {
               Console.WriteLine("Tipo de bilhete inválido! Tente novamente");
                Console.WriteLine("Tipo de bilhete. 1 - Comum  / 2 - Estudante");
                typeTicket = (int)Convert.ToInt16(Console.ReadLine());
            }

            Console.WriteLine("CPF do usuario: ");
            string cpf = Console.ReadLine();
            Usuario user = users.Find(u => u.Cpf == cpf);

            IBilheteUnico ticket  = null; 
            if (typeTicket == 1)
            {
                ticket = new BilheteComum();

            }
            else if (typeTicket == 2)
            {
                ticket= new BilheteEstudante();
            }
            Console.WriteLine("Código do bilhete: ");
            ticket.Codigo = (int)Convert.ToInt32(Console.ReadLine());
            ticket.Usuario = user;

            tickets.Add(ticket);
            Console.WriteLine("Bilhete cadastrado com sucesso!");
        }

        public static void RechargeTicket()
        {

        }
        public static void Pay()
        { 

        }
        public static void ShowTickets()
        {

        }
        public static void SearchTicketByCpf()
        {

        }
        static void Main(string[] args)
        {
            int option = 0;
            while (option != 99)
            {
                Console.WriteLine("----- Menu Principal -----");
                Console.WriteLine("1 - Cadastrar Usuário");
                Console.WriteLine("2 - Cadastrar Bilhete");
                Console.WriteLine("3 - Recarregar Bilhete");
                Console.WriteLine("4 - Pagar Passagem");
                Console.WriteLine("5 - Listar Bilhetes");
                Console.WriteLine("6 - Pesquisar Bilhete por CPF");
                Console.WriteLine("99 - Sair");
                Console.WriteLine("--------------------------");
                Console.Write("Selecione uma opção: ");

                try
                {
                    option = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (option)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            AddTicket();
                            break;
                        case 3:
                            RechargeTicket();
                            break;
                        case 4:
                            Pay();
                            break;
                        case 5:
                            ShowTickets();
                            break;
                        case 6:
                            SearchTicketByCpf();
                            break;
                        case 99:
                            Console.WriteLine("Saindo do programa...");
                            break;
                        default:
                            Console.WriteLine("Opção Inválida! Tente novamente.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Opção Inválida! Tente novamente.");
                }

                Console.WriteLine();
            }

        }
    }
}
