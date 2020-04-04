using System;
using System.Text;

namespace Filas
{
    public class FilaDinamica<T>
    {
        private Celula<T> Primeira;
        private Celula<T> Ultima;
        public int TotalDeElementos { get; private set; }
        public FilaDinamica()
        {
            Primeira = null;
            Ultima = null;
            TotalDeElementos = 0;
        }
        //Adiciona um elemento no fim da Fila
        public void Inserir(T elemento) 
        {
            if (TotalDeElementos == 0)
            {
                Celula<T> nova  = new Celula<T>(elemento);
                Primeira = nova;
                Ultima = nova;
            }
            else 
            {
                Celula<T> nova = new Celula<T>(elemento);
                Ultima.Proxima = nova;
                nova.Anterior = Ultima;
                Ultima = nova;
            }
            TotalDeElementos++;
        }

        //verifica se o dado existe no inicio da fila
        public bool ExisteDado(T elemento)
        {
            if (EstaVazia())
            {
                throw new Exception("Fila vazia");
            }
            else if (Primeira.Elemento.Equals(elemento))
            {
                return true;
            }
            return false;
        }
        //Verifica se a Fila está vazia;
        public bool EstaVazia()
        {
            if (TotalDeElementos == 0)
            {
                return true;
            }
            return false;
        }
        //Recupera o objeto do início da Fila, não remove;
        public T Recuperar()
        {
            if (EstaVazia())
            {
                throw new Exception("Fila vazia");
            }

            return Primeira.Elemento;
        }
        // Altera o valor do objeto do início da Fila;
        public void Alterar(T elemento)
        {
            if (EstaVazia())
            {
                throw new Exception("Fila vazia");
            }

            Primeira.Elemento = elemento;
        }
        //Remove o objeto do início da Fila;
        public void Remover()
        {
            if (EstaVazia())
            {
                throw new Exception("Fila vazia");
            }

            Primeira = Primeira.Proxima;
            TotalDeElementos--;

            if (TotalDeElementos == 0)
            {
                Ultima = null;
            }
        }
        //Retorna o tamanho da Fila (quantidade de elementos inseridos)
        public int Tamanho()
        {
            return TotalDeElementos;
        }
        // Exclui todos os elementos da Fila;
        public void Limpar()
        {
            Primeira = null;
            Ultima = null;
            TotalDeElementos = 0;
        }

        public override string ToString()
        {
            // Verificando se a Lista esta vazia
            if (TotalDeElementos == 0)
            {
                return "[]";
            }
            StringBuilder builder = new StringBuilder("[");

            Celula<T> atual = Primeira;
            // Percorrendo ate o penultimo elemento.
            for (int i = 0; i < TotalDeElementos - 1; i++)
            { 
                builder.Append(atual.Elemento);
                builder.Append(", ");
                atual = atual.Proxima;
            }
            // ultimo elemento
            builder.Append(atual.Elemento);
            builder.Append("]");
            return builder.ToString();
        }

    }
}