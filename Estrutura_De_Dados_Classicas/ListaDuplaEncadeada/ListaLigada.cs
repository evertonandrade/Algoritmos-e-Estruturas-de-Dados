using System;
using System.Text;

namespace ListaDuplaEncadeada
{
    public class ListaLigada<T>
    {
        private Celula<T> Primeira;
        private Celula<T> Ultima;
        public int TotalDeElementos { get; private set; }

        public ListaLigada()
        {
            
        }

        public void AdicionarNoComeco(T elemento)
        {
            if (TotalDeElementos == 0)
            {
                Celula<T> nova  = new Celula<T>(elemento);
                Primeira = nova;
                Ultima = Primeira;
            }
            else
            {
                Celula<T> nova = new Celula<T>(Primeira, elemento);
                nova.Proxima = Primeira;
                Primeira.Anterior = nova;
                Primeira = nova;
            }
            TotalDeElementos++;
        }
        

        public void Adicionar(T elemento)
        {
            if (TotalDeElementos == 0)
            {
                AdicionarNoComeco(elemento);
            }
            else 
            {
                Celula<T> nova = new Celula<T>(elemento);
                Ultima.Proxima = nova;
                nova.Anterior = Ultima;
                Ultima = nova;
                TotalDeElementos++;
            }
        }

        public void Adicionar(int posicao, T elemento)
        {
            if(posicao == 0)
            {
                AdicionarNoComeco(elemento);
            }
            else if (posicao == TotalDeElementos)
            {
                Adicionar(elemento);
            }
            else 
            {
                Celula<T> anterior = PegarCelula(posicao - 1);
                Celula<T> proxima = anterior.Proxima;
                Celula<T> nova = new Celula<T>(elemento);
                nova.Anterior = anterior;
                nova.Proxima = proxima;
                anterior.Proxima = nova;
                proxima.Anterior = nova;
                TotalDeElementos++;
            }
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

           else if (Ultima != null)
           {

            Ultima.Anterior.Proxima = null;
            
            Ultima = Ultima.Anterior;

            TotalDeElementos--;
           }
           
            
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

        private bool PosicaoOcupada(int posicao)
        {
            return posicao >= 0 && posicao < this.TotalDeElementos;
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