using System;

namespace VetorDinamico
{
    class Program
    {
        static void Main(string[] args)
        {
            VetorObjetos v = new VetorObjetos(10);
            Lista<int> lista = new Lista<int>(5);
            try
            {
                lista.Adicionar(1);
                lista.Adicionar(7);
                lista.Adicionar(5);
                lista.Adicionar(9);
                lista.Remover(2);
                lista.Remover(0);
                lista.Adicionar(69);
                Console.WriteLine(lista);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(" => " + e.Message);
            }
        }
    }
}
