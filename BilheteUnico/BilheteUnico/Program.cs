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
            try
            {
                Usuario user = new Usuario();

                Console.WriteLine("Digite o nome: ");
                user.Nome = Console.ReadLine();
                Console.WriteLine("Digite o cpf");
                user.Cpf = Console.ReadLine();
                VerifyExistingUser(user.Cpf);
                Console.WriteLine("Digite o telefone: ");
                user.Telefone = (int)Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Digite o e-Mail: ");
                user.Email = Console.ReadLine();
                users.Add(user);

                Console.WriteLine("Usuario adicionado com sucesso");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }

        public static void VerifyExistingUser(string cpf)
        {
            foreach (Usuario existingUser in users)
            {
                if (existingUser.Cpf == cpf)
                {
                    throw new Exception ("Usuário já cadastrado");
                }
            }
            
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
                    Console.WriteLine($"Código do bilhete: {ticket.Codigo}");
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
        enum TicketTypes
        {
            Comum = 1,
            Estudante = 2
        }
        

        public static IBilheteUnico SelectTicketType()
        {
            Console.WriteLine("Tipo de bilhete. 1 - Comum  / 2 - Estudante");
            TicketTypes typeTicket = (TicketTypes)Convert.ToInt16(Console.ReadLine());
            while (typeTicket != TicketTypes.Comum && typeTicket != TicketTypes.Estudante)
            {
                Console.WriteLine("Tipo de bilhete inválido! Tente novamente");
                Console.WriteLine("Tipo de bilhete. 1 - Comum  / 2 - Estudante");
                typeTicket = (TicketTypes)Convert.ToInt16(Console.ReadLine());
            }
            IBilheteUnico ticket = null;
            if (typeTicket == TicketTypes.Comum)
            {
                ticket = new BilheteComum();
            }
            else if (typeTicket == TicketTypes.Estudante)
            {
                ticket = new BilheteEstudante();
            }
            return ticket;
        }
      
        public static void RechargeTicket()
        {
            Console.WriteLine("Digite o valor da recarga: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            int op = 0;
            try
            {
                while (op != 99)
                {

                    Console.WriteLine("Digite o numero do cartão: ");
                    string Ticketcode = Console.ReadLine();
                    IBilheteUnico ticket = tickets.Find(t => t.Codigo == Ticketcode);
                    if (ticket != null)
                    {
                        ticket.RecarregarBilhete(valor);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bilhete não encontrado!");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente ou digite 99 para voltar ao menu principal.");
                        op = Convert.ToInt16(Console.ReadLine());
                    }

                }

            }
            catch (Exception)
            {

                RechargeTicket();
            }


            
        }
        public static void Pay()
        {
            int op = 0;
            try
            {
                while (op != 99)
                {

                    Console.WriteLine("Digite o numero do cartão: ");
                    string Ticketcode = Console.ReadLine();
                    IBilheteUnico ticket = tickets.Find(t => t.Codigo == Ticketcode);
                    if (ticket != null)
                    {
                        ticket.PagarPassagem();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bilhete não encontrado!");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente ou digite 99 para voltar ao menu principal.");
                        op = Convert.ToInt16(Console.ReadLine());
                    }

                }

            }
            catch (Exception)
            {

                Pay();
            }

        }
        public static void ShowTickets()
        {

            Console.WriteLine("----- Listagem de Bilhetes -----");
            int i = 1;
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Bilhete {i}: ");
                Console.WriteLine($"Código do bilhete: {ticket.Codigo}");
                Console.WriteLine($"Usuário: {ticket.Usuario.Nome}");
                Console.WriteLine($"CPF: {ticket.Usuario.Cpf}");
                Console.WriteLine($"Telefone: {ticket.Usuario.Telefone}");
                Console.WriteLine($"Saldo: {ticket.Saldo}");

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
