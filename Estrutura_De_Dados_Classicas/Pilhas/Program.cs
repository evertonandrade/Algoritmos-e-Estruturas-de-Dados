using System;

namespace Pilhas
{
    class Program
    {
        static void Main(string[] args)
        {
            PilhaDinamica<int> pilha = new PilhaDinamica<int>();
            pilha.Empilhar(1);
            pilha.Empilhar(2);
            pilha.Empilhar(3);
            pilha.Empilhar(4);
            pilha.Empilhar(5);
            System.Console.WriteLine(pilha);
            pilha.Desempilhar();
            pilha.Desempilhar();
            System.Console.WriteLine(pilha);
            pilha.Limpar();
            System.Console.WriteLine(pilha);
            pilha.Empilhar(6);
            pilha.Empilhar(7);
            pilha.Empilhar(8);
            pilha.Empilhar(9);
            System.Console.WriteLine(pilha);
        }
    }
}
