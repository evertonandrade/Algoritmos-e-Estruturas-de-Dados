using System;

namespace Recursividade
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Potenciacao(2, 3));
            System.Console.WriteLine(Inverter(12345));
        }

        static int Potenciacao(int num_base, int num_expoente)
        {
            if (num_expoente==0)
            {
                return 1;
            }
                
            return num_base * Potenciacao(num_base, num_expoente - 1);
        }

        static int Inverter(int num, int total = 0)
        {
            if(num == 0)
            {
                return total;
            }
            else
            {
                return Inverter(num / 10, total * 10 + num % 10);
            }
        }
    }
}
