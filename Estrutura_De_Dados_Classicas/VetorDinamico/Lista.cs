using System;
using System.Text;

namespace VetorDinamico
{
    public class Lista<T>
    {
        public T[] Elementos { get; private set; }
        public int Tamanho { get; private set; }

        public Lista(int capacidade)
        {
            Elementos = new T[capacidade];
            Tamanho = 0;
        }

        public bool Adicionar(T elemento)
        {
            // aumenta a capacidade se for preciso
            AumentarCapacidade();

            if (Tamanho < Elementos.Length)
            {
                Elementos[Tamanho] = elemento;
                Tamanho++;
                return true;
            }

            return false;
        }

        public bool Adicionar(int posicao, T elemento)
        {
            //verificação 
            if (!(posicao >= 0 && posicao < Tamanho))
            {
                throw new ArgumentException("Posição invalida!");
            }
            
            // aumenta a capacidade se for preciso
            AumentarCapacidade();

            // mover todos os elementos
            for (int i = Tamanho - 1; i >= posicao; i--)
            {
                Elementos[i + 1] = Elementos[i];
            }

            // atribuição e atualização do tamanho
            Elementos[posicao] = elemento;
            Tamanho++;

            return true;
        }

        public void Remover(int posicao)
        {
            //verificação 
            if (!(posicao >= 0 && posicao < Tamanho))
            {
                throw new ArgumentException("Posição invalida!");
            }

            //move todos os elementos a partir da posição a ser removida
            for (int i = posicao; i < Tamanho - 1; i++)
            {
                Elementos[i] = Elementos[i + 1];
            }

            // remove elemento que ficou na ultima posição e atualiza o tmanho
            Elementos[Tamanho] = default;
            Tamanho--;

        }

        public void Remover(T elemento)
        {
            int posicao = Buscar(elemento);
            if(posicao == -1)
            {
                throw new ArgumentException("Elemento não existe!");
            }
            Remover(posicao);
        }

        private void AumentarCapacidade()
        {
            if (Tamanho == Elementos.Length)
            {
                T[] elementosNovos = new T[Elementos.Length * 2];

                for (int i = 0; i < Elementos.Length; i++)
                {
                    elementosNovos[i] = Elementos[i];
                }

                Elementos = elementosNovos;
            }
        }

        public T Buscar(int posicao)
        {
            if (!(posicao >= 0 && posicao < Tamanho))
            {
                throw new ArgumentException("Posição invalida!");
            }

            return Elementos[posicao];
        }

        public int Buscar(T elemento)
        {
            for (int i = 0; i < Tamanho; i++)
            {
                if (Elementos[i].Equals(elemento))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contem(T elemento)
        {
            return Buscar(elemento) > -1;

        }

        public void Limpar() 
        {
            Elementos = new T[Elementos.Length];
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("[");
            for (int i = 0; i < Tamanho - 1; i++){
                s.Append(Elementos[i]);
                s.Append(", ");
            }
            if (Tamanho > 0) {
                s.Append(Elementos[Tamanho-1]);
            }
            s.Append("]");
            return s.ToString();
        }
        
    }
}