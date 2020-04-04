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
                lista.Adicionar(2);
                Console.WriteLine(lista);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(" => " + e.Message);
            }
        }
    }
}
