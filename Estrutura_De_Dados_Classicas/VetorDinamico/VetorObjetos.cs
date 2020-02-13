using System;
using System.Text;

namespace VetorDinamico
{
    public class VetorObjetos
    {
        public Object[] Elementos { get; private set; }
        public int Tamanho { get; private set; }

        public VetorObjetos(int capacidade)
        {
            Elementos = new Object[capacidade];
            Tamanho = 0;
        }

        public bool Adicionar(Object elemento)
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

        public bool Adicionar(int posicao, Object elemento)
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
            Elementos[Tamanho] = null;
            Tamanho--;

        }

        public void Remover(Object elemento)
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
                Object[] elementosNovos = new Object[Elementos.Length * 2];

                for (int i = 0; i < Elementos.Length; i++)
                {
                    elementosNovos[i] = Elementos[i];
                }

                Elementos = elementosNovos;
            }
        }

        public Object Buscar(int posicao)
        {
            if (!(posicao >= 0 && posicao < Tamanho))
            {
                throw new ArgumentException("Posição invalida!");
            }

            return Elementos[posicao];
        }

        public int Buscar(Object elemento)
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