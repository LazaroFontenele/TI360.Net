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
            
            while (true)
            {
                Console.WriteLine("CPF do usuario: ");
                string cpf = Console.ReadLine();
                Usuario user = users.Find(u => u.Cpf == cpf);
                if (user != null)
                {
                    IBilheteUnico ticket = SelectTicketType();
                    ticket.Codigo = ticket.GenerateTicketCode();
                    ticket.Usuario = user;
                    tickets.Add(ticket);
                    Console.WriteLine("Bilhete cadastrado com sucesso!");
                    break;
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado. Pressione qualquer tecla para tentar novamente ou pressione 99 para cancelar");
                    int op = (Int32)Console.ReadKey().KeyChar;
                    if (op == 99)
                    {
                        break;
                    }
                }

            }


            
            
        }

        public static IBilheteUnico SelectTicketType()
        {
            Console.WriteLine("Tipo de bilhete. 1 - Comum  / 2 - Estudante");
            int typeTicket = (int)Convert.ToInt16(Console.ReadLine());
            while (typeTicket != 1 && typeTicket != 2)
            {
                Console.WriteLine("Tipo de bilhete inválido! Tente novamente");
                Console.WriteLine("Tipo de bilhete. 1 - Comum  / 2 - Estudante");
                typeTicket = (int)Convert.ToInt16(Console.ReadLine());
            }
            IBilheteUnico ticket = null;
            if (typeTicket == 1)
            {
                ticket = new BilheteComum();
                

            }
            else if (typeTicket == 2)
            {
                ticket = new BilheteEstudante();
            }
            return ticket;
        }
      
        public static void RechargeTicket()
        {
            Console.WriteLine("Digite o valor da recarga: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Numero do cartão: ");
            string Ticketcode = Console.ReadLine();
            IBilheteUnico ticket = tickets.Find(t => t.Codigo == Ticketcode);
            if (ticket != null)
            {
                ticket.RecarregarBilhete(valor);
            }
            
        }
        public static void Pay()
        { 

        }
        public static void ShowTickets()
        {

            Console.WriteLine("----- Listagem de Bilhetes -----");
            int i = 1;
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Bilhete {i}: ");
                Console.WriteLine($"Nº do bilhete: {ticket.Codigo}");
                Console.WriteLine($"Usuário: {ticket.Usuario.Nome}");
                Console.WriteLine($"CPF: {ticket.Usuario.Cpf}");
                Console.WriteLine($"Telefone: {ticket.Usuario.Telefone}");
                
                i++;
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine("----- Fim da lista -----");
            Console.WriteLine("----- Pressione qualquer tecla para continuar -----");
            Console.ReadKey(); 
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
