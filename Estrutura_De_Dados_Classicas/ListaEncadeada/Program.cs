using System;

namespace ListaEncadeada
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaLigada<int> lista = new ListaLigada<int>();
            lista.Adicionar(0);
            lista.Adicionar(1);
            lista.Adicionar(2);
            lista.Adicionar(3);
            lista.Adicionar(4);
            lista.Adicionar(5);
            lista.Adicionar(6);
            Console.WriteLine(lista);
            lista.RemoverDoFim();
            Console.WriteLine(lista);
            lista.Remover(3);
            System.Console.WriteLine(lista);
            var a = lista.Pegar(1);
            System.Console.WriteLine(a);
            lista.Limpar();
            System.Console.WriteLine(lista);
        }
    }
}
