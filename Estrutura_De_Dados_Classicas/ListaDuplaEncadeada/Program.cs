using System;

namespace ListaDuplaEncadeada
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaLigada<string> list = new ListaLigada<string>();
            list.Adicionar("a1");
            list.Adicionar("b1");
            list.Adicionar("c1");
            list.Adicionar("d1");
            list.Adicionar(1, "a2");
            System.Console.WriteLine(list);
            list.RemoverDoFim();
            list.RemoverDoFim();
            list.RemoverDoFim();
            list.RemoverDoFim();
            list.RemoverDoFim();
            System.Console.WriteLine(list);
            list.Adicionar("a1");
            list.Adicionar("b1");
            list.Adicionar("c1");
            list.Adicionar("d1");
            list.Adicionar(1, "a2");

            

            
            System.Console.WriteLine(list);
        }
    }
}

