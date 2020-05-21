using System;

namespace ListaEncadeadaCircular
{
    public class Program
    {
        static void Main(string[] args)
        {
           ListaLigadaCircular<int> list = new ListaLigadaCircular<int>();
           list.InserirNoInicio(3);
           list.InserirNoInicio(2);
           list.InserirNoInicio(1);
           System.Console.WriteLine(list);
           list.RemoverDoFinal();
           list.RemoverDoFinal();
           list.RemoverDoFinal();
           System.Console.WriteLine(list);
             

        }
    }
}
