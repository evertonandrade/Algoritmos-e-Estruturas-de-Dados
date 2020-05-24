using System;
using System.Text;

namespace Pilhas
{
    public class PilhaDinamica<T>
    {
        private Celula<T> Topo; 
        private Celula<T> Inicio;
        private int TotalDeElementos;

        public PilhaDinamica()
        {
            
        }

        public void Empilhar(T elemento)
        {
            Celula<T> nova  = new Celula<T>(elemento);
            if (TotalDeElementos == 0)
            {
                Topo = nova;
                Inicio = nova;
            }
            else 
            {
                Topo.Proxima = nova;
                nova.Anterior = Topo;
                Topo = nova;
            }
            TotalDeElementos++;       
        }

        public bool ExisteDado(T elemento)
        {
            if (EstaVazia())
            {
                throw new Exception("Fila vazia");
            }
            else if (Topo.Elemento.Equals(elemento))
            {
                return true;
            }
            return false;
        }

        public bool EstaVazia()
        {
            return TotalDeElementos == 0;
        }

        public T Recuperar()
        {
            if (EstaVazia())
            {
                throw new Exception("Pilha vazia");
            }

            return Topo.Elemento;
        }

        public void Alterar(T elemento)
        {
            if (EstaVazia())
            {
                throw new Exception("Pilha vazia");
            }
            Topo.Elemento = elemento;
        }
        public void Desempilhar()
        {
            if (EstaVazia())
            {
                throw new Exception("Pilha vazia");
            }

            if (TotalDeElementos == 1)
            {
                Topo = null;
                Inicio = null;
            }
            else if (Topo != null)
            {
                Topo.Anterior.Proxima = null;             
                Topo = Topo.Anterior;        
            }
            TotalDeElementos--;
        }

        public void Limpar()
        {
            Topo = null;
            Inicio = null;
            TotalDeElementos = 0;
        }

        public int Tamanho()
        {
            return TotalDeElementos;
        }

        public override string ToString()
        {
            // Verificando se a Lista esta vazia
            if (TotalDeElementos == 0)
            {
                return "[]";
            }
            StringBuilder builder = new StringBuilder("[");

            Celula<T> atual = Inicio;
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