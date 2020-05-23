using System;

namespace ListaEncadedaComNoCabeca
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDuplaComNoCabeca<int> list = new ListaDuplaComNoCabeca<int>();
            list.Adicionar(0);
            list.Adicionar(1);
            list.Adicionar(2);
            list.Adicionar(3);
            list.Adicionar(4);
            list.Adicionar(5);
            System.Console.WriteLine(list);
            ListaDuplaComNoCabeca<int> list2 = new ListaDuplaComNoCabeca<int>();
            list2.AdicionarNoComeco(100);
            list2.AdicionarNoComeco(100);
            list2.AdicionarNoComeco(100);
            System.Console.WriteLine(list2);
            list.Concatenar(list2);
            System.Console.WriteLine(list);
            list.Limpar();
            System.Console.WriteLine(list);

        
        }
    }
}
