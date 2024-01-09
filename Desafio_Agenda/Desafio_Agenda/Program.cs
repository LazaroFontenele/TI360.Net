using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Agenda
{
    internal class Program

    {
        const int maxContatos = 20;
        const string sair = "99";
        static void MenuPrincipal()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+----------------------------------------------------+\r\n" +
                              "| Menu Principal                                     |\r\n" +
                              "| Informe a opção desejada ou 99 para sair           |\r\n" +
                              "|----------------------------------------------------|\r\n" +
                              "| 1 = Cadastrar novo Contato na Agenda               |\n" +
                              "| 2 = Excluir Contato da Agenda                      |\n" +
                              "| 3 = Listar contatos da Agenda                      |\n" +
                              "| 4 = Limpar todos os Contatos                       |\n" +
                              "+----------------------------------------------------+");
               string opcao = Console.ReadLine();          
               if (opcao == sair)
                {
                    Console.WriteLine("Finalizando programa...");
                    return;
                }
                ProcessarOpcao(opcao);
            }
        }
        static void ProcessarOpcao(string opcao)
        {
            switch (opcao)
            {

                case "99":
                    break;
                case "1":
                    GravarContato();
                    break;
                case "2":
                    ExcluirContato();
                    break;
                case "3":
                    ListarContatos();
                    break;
                case "4":
                    LimparAgenda();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }

        public static List<string> nomes = new List<string>();
        public static List<long> telefones = new List<long>();

        static void GravarContato()
        {

            if (nomes.Count >= maxContatos)
            {
                
                Console.WriteLine("Você atingiu a quantidade máxima de contatos. Não é permitido cadastrar mais de 20 contatos.");
            }
            else
            {
                Console.WriteLine("Digite o nome: ");
                string nome = Console.ReadLine();
                while (nome == "")
                {
                    Console.WriteLine("O nome não pode ser vazio");
                    Console.WriteLine("Digite o nome: ");
                    nome = Console.ReadLine();
                }
                long telefone;
                const int minCharTelefone = 8;
                while (true)
                {
                    Console.WriteLine("Digite o telefone: ");
                    if (long.TryParse(Console.ReadLine(), out telefone))
                    {
                        if (telefone.ToString().Length >= minCharTelefone)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Número de telefone inválido. Deve ter no mínimo 8 dígitos. Tente novamente");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Número de telefone inválido. Tente novamente");
                    }
                }

                nomes.Add(nome);
                telefones.Add(telefone);
                Console.WriteLine("Registro gravado com sucesso!");

                while (true)
                {
                    
                    if (nomes.Count >= maxContatos)
                    {

                        Console.WriteLine("Você atingiu a quantidade máxima de contatos. Retornando ao menu principal...");
                        break;
                    }
                    Console.WriteLine("O que deseja fazer agora?\n"+
                                      "1 = Gravar outro contato / 2 = Voltar ao menu inicial");
                    string op = Console.ReadLine();
                    if(op == "1")
                    {
                        GravarContato();
                    }
                    else if(op == "2")
                    {
                        break;
                    }
                    break;
                }
            }
        }
        static void ListarContatos()
        {
            if (nomes.Count > 0)
            {
                int i = 0;
                foreach (var nome in nomes)
                {
                    Console.WriteLine($"Contato {i+1}: ");
                    Console.WriteLine($"Nome: {nome}");
                    Console.WriteLine($"Telefone: {telefones[i]}");
                    Console.WriteLine("----------------------------");
                    i++;
                }
                Console.WriteLine("Não há mais contatos para exibir!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nenhum contato na lista.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        }
        static void ExcluirContato()
        {
            Console.WriteLine("Digite o nome do contato que deseja excluir:");
            string nome = Console.ReadLine();
            if (nomes.Contains(nome))
            {
                int indice = nomes.IndexOf(nome);
                telefones.RemoveAt(indice);
                nomes.Remove(nome);
                int removido = nomes.IndexOf(nome);
                if (removido == -1) 
                {
                    Console.WriteLine("Contato excluído com sucesso!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
               Console.WriteLine("Contato não encontrado.");
               Console.WriteLine("Pressione qualquer tecla para continuar...");
               Console.ReadKey();
            }

        }
        static void LimparAgenda()
        {
            nomes.Clear();
            telefones.Clear();
        }
        public static void Main(string[] args)
        {
            
            Console.WriteLine("AGENDA PESSOAL - MODULO 1");
            MenuPrincipal();
            Console.WriteLine("Programa Finalizado. Pressione qualquer tecla para fechar!");
            Console.ReadKey();

        }
    }
}
