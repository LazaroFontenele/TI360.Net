using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Agenda
{
    internal class Program

    {
        static void MostrarMenu()
        {
            string opcao = "";
            while (opcao != "99")
            {
                Console.WriteLine("+----------------------------------------------------+\n" +
                                  "| Menu Principal                                     |\n" +
                                  "| Informe a opção desejada ou 99 para sair           |\n" +
                                  "|----------------------------------------------------|\n" +
                                  "| 1 = Cadastrar novo Contato na Agenda               |\n" +
                                  "| 2 = Excluir Contato da Agenda                      |\n" +
                                  "| 3 = Listar contatos da Agenda                      |\n" +
                                  "| 4 = Limpar todos os Contatos                       |\n" +
                                  "+----------------------------------------------------+");
                opcao = Console.ReadLine();          
                switch (opcao)
                {
                    default:
                        break;
                    case "99":
                        Console.WriteLine("Finalizando programa...");
                        break;
                    case "1":
                        GravarContato();
                        break;
                    case "2":
                        break;
                    case "3":
                        ListarContatos();
                        break;
                    case "4":
                       ExcluirContato();
                       break;
                }
            }
        }

        public static List<string> nomes = new List<string>();
        public static List<int> telefones = new List<int>();
        static void GravarContato()
        {

            if (nomes.Count >= 20)
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
                Console.WriteLine("Digite o telefone: ");
                int telefone = Convert.ToInt32(Console.ReadLine());
                while (telefone is int == false)
                {
                    Console.WriteLine("Numero de telefone inválido. Tente novamente");
                    Console.WriteLine("Digite o telefone: ");
                    telefone = Convert.ToInt32(Console.ReadLine());
                }
                nomes.Add(nome);
                telefones.Add(telefone);
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
                    Console.WriteLine("Contato excluído com sucesso");
                }
            }
            else
            {
               Console.WriteLine("Contato não encontrado.");
            }
        }
        public static void Main(string[] args)
        {
            
            Console.WriteLine("AGENDA PESSOAL - MODULO 1");
            MostrarMenu();
            Console.WriteLine("Programa Finalizado. Pressione qualquer tecla para fechar!");
            Console.ReadKey();

        }
    }
}
