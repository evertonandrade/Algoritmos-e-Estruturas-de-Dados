using System;
using System.Text;

namespace ListaEncadeada
{
    class ListaLigada
    {
        private Celula Primeira;
        private Celula Ultima;
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
                Celula nova = new Celula(elemento);
                Ultima.Proxima = nova;
                Ultima = nova;
                TotalDeElementos++;
            }
        }

        public void AdicionarNoComeco(object elemento)
        {
            Celula nova = new Celula(Primeira, elemento);
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
                Celula anterior = this.PegarCelula(posicao - 1);
                Celula nova = new Celula(anterior.Proxima, elemento);
                anterior.Proxima = nova;
                TotalDeElementos++;
            }
        }

        private Celula PegarCelula(int posicao)
        {
            if (!PosicaoOcupada(posicao))
            {
                throw new ArgumentException("Posição não existe");
            }

            Celula atual = Primeira;
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
           
            Celula penultima = PegarCelula(TotalDeElementos - 2);
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
               Celula anterior = PegarCelula(posicao - 1);
               Celula atual = anterior.Proxima;
               Celula proxima = atual.Proxima;

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
            Celula atual = Primeira;

            while (atual != null)
            {
                if (atual.Elemento.Equals(elemento))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            // Verificando se a Lista esta vazia
            if (TotalDeElementos == 0)
            {
                return "[]";
            }
            StringBuilder builder = new StringBuilder("[");

            Celula atual = Primeira;
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
