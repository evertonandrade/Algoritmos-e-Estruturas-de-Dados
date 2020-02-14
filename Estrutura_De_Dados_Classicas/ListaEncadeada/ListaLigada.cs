using System;
using System.Text;

namespace ListaEncadeada
{
    class ListaLigada<T>
    {
        private Celula<T> Primeira;
        private Celula<T> Ultima;
        public int TotalDeElementos { get; private set; }

        public ListaLigada()
        {
            
        }


        public void Adicionar(object elemento)
        {
            if (TotalDeElementos == 0)
            {
                AdicionarNoComeco(elemento);
            }
            else
            {
                Celula<T> nova = new Celula<T>(elemento);
                Ultima.Proxima = nova;
                Ultima = nova;
                TotalDeElementos++;
            }
        }

        public void AdicionarNoComeco(object elemento)
        {
            Celula<T> nova = new Celula<T>(Primeira, elemento);
            Primeira = nova;

            if (TotalDeElementos == 0)
            {
                //caso especial da lista vazia
                Ultima = Primeira;
            }

            TotalDeElementos++;
        }


        public void Adicionar(int posicao, object elemento)
        {
            if (posicao == 0)
            { 
                // No começo.
                AdicionarNoComeco(elemento);
            }
            else if (posicao == TotalDeElementos)
            { 
                // No fim.
                Adicionar(elemento);
            }
            else
            {
                Celula<T> anterior = this.PegarCelula(posicao - 1);
                Celula<T> nova = new Celula<T>(anterior.Proxima, elemento);
                anterior.Proxima = nova;
                TotalDeElementos++;
            }
        }

        private Celula<T> PegarCelula(int posicao)
        {
            if (!PosicaoOcupada(posicao))
            {
                throw new ArgumentException("Posição não existe");
            }

            Celula<T> atual = Primeira;
            for (int i = 0; i < posicao; i++)
            {
                atual = atual.Proxima;
            }
            return atual;
        }

        public object Pegar(int posicao)
        {
            return PegarCelula(posicao).Elemento;
        }

        private bool PosicaoOcupada(int posicao)
        {
            return posicao >= 0 && posicao < this.TotalDeElementos;
        }


        public bool ExisteDado(T elemento)
        {
           return false;
        }

        public void RemoverDoComeco() 
        {
            if (!PosicaoOcupada(0))
            {
                throw new ArgumentException("Posição não existe!");
            }

            Primeira = Primeira.Proxima;
            TotalDeElementos--;

            if (TotalDeElementos == 0)
            {
                Ultima = null;
            }
        }

        public void RemoverDoFim()
        {
           if( !PosicaoOcupada(TotalDeElementos - 1) )
           {
               throw new ArgumentException("Posição não existe!");
           }

           if ( TotalDeElementos == 1)
           {
               RemoverDoComeco();
           }
           
            Celula<T> penultima = PegarCelula(TotalDeElementos - 2);
            penultima.Proxima = null;
            Ultima = penultima;
            TotalDeElementos--;
        }

        public void Remover(int posicao) 
        {
             if( !PosicaoOcupada(posicao) )
           {
               throw new ArgumentException("Posição não existe!");
           }

           if (posicao == 0)
           {
               RemoverDoComeco();
           }
           else if (posicao == TotalDeElementos - 1) 
           {
               RemoverDoFim();
           }
           else 
           {
               Celula<T> anterior = PegarCelula(posicao - 1);
               Celula<T> atual = anterior.Proxima;
               Celula<T> proxima = atual.Proxima;

               anterior.Proxima = proxima;
               TotalDeElementos--;
           }
        }

        public int Tamanho()
        {
            return this.TotalDeElementos;;
        }

        public bool Contem(object elemento)
        {
            Celula<T> atual = Primeira;

            while (atual != null)
            {
                if (atual.Elemento.Equals(elemento))
                {
                    return true;
                }
            }
            return false;
        }

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
