using System;

namespace Filas
{
    class Program
    {
        static void Main(string[] args)
        {
            FilaDinamica<int> f1 = new FilaDinamica<int>();
            f1.Inserir(1);
            f1.Inserir(2);
            f1.Inserir(3);
            f1.Inserir(4);
            f1.Inserir(5);
            Console.WriteLine(f1);
            Console.WriteLine(f1.ExisteDado(1));
            Console.WriteLine(f1.Recuperar());
            f1.Alterar(10);
            Console.WriteLine(f1);
            f1.Remover();
            f1.Remover();
            f1.Remover();
            f1.Remover();
            f1.Remover();
            Console.WriteLine(f1);
            f1.Inserir(10);
            f1.Inserir(20);
            Console.WriteLine(f1);
            f1.Limpar();
            Console.WriteLine(f1);
        }
    }
}
