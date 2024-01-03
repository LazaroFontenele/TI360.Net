using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutura_Sequencial
{
    internal class Exercícios
    {
        public static void Exercicio1()
        {
            int a = 2;
            int b = 3;
            int c = 5;

            int x = a + b / c;
            Console.WriteLine(x);
            


        }
        public static void Exercicio2()
        {
            float nota1 = 6;
            float nota2 = 8;
            float nota3 =9;

            float media = ((nota1 * 2) + (nota2 * 3) + (nota3 * 5)) / 10;
            Console.WriteLine(Math.Round(media, 2));

        }
        public static void Exercicio3()
        {
            int segundosTotal = 4380;
            int horaSegundos = 3600;

            int horasEvento = segundosTotal / horaSegundos;
            int minutosEvento = (segundosTotal % horaSegundos) / 60;
            int segundosEvento = (segundosTotal % horaSegundos) % 60;

            Console.WriteLine($"O evento ocorreu em: {horasEvento} hora(s) {minutosEvento} minuto(s) e {segundosEvento} segundo(s)");

        }
    }
}
