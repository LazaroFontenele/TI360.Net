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
        static string opcao = "";
        static void mostrarMenu()
        {
            
            while (opcao != "99")
            {
                Console.WriteLine("+----------------------------------------------------+\r\n" +
                              "| Menu Principal                                     |\r\n" +
                              "| Informe a opção desejada ou 99 para sair           |\r\n" +
                              "|----------------------------------------------------|\r\n" +
                              "| 1 = Cadastrar novo Contato na Agenda               |\n" +
                              "| 2 = Excluir Contato da Agenda                      |\n" +
                              "| 3 = Listar contatos da Agenda                      |\n" +
                              "| 4 = Limpar todos os Contatos                       |\n" +
                              "+----------------------------------------------------+");
            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("AGENDA PESSOAL - MODULO 1");
            mostrarMenu();
            opcao = Console.ReadLine();
            switch (opcao)
            {
                default:
                    break;
                case "99":
                    Console.WriteLine("Finalizando programa...");
                    break;
                case "1":
                    Console.WriteLine("VocÊ escolheu a opção 1");
                    break;
            }
            Console.WriteLine("Programa Finalizado. Pressione qualquer tecla para fechar!");
            Console.ReadKey();
        }
    }
}
