using System;
using System.Text;

namespace ListaEncadeadaCircular
{
    public class ListaLigadaCircular<T>
    {
        private Celula<T> Primeira;
        private Celula<T> Ultima;
        public int TotalDeElementos { get; private set; }

        public bool EstaVazia()
        {
            return (Primeira == null);
        }

        public void InserirNoInicio(T elemento)
        {
            Celula<T> nova  = new Celula<T>(elemento);

            if (EstaVazia())
            {
                nova.Proxima = nova;
                nova.Anterior = nova;
                Primeira = nova;
                Ultima = nova;
            }
            else 
            {
                nova.Anterior = Ultima;
                nova.Proxima = Primeira;
                Primeira = nova;
                Ultima.Proxima = nova;  
            }
            TotalDeElementos++;
        }

        public void RemoverDoFinal()
        {
            if(EstaVazia())
            {
                throw new Exception("Lista vazia. Impossivel remover!");
            }

            //verifica se a lista VAI FICAR vazia
            if (Primeira.Proxima == Primeira)
            {
                Primeira = null;
                Ultima = null;
            }
            else 
            {
                Celula<T> penultima = PegarCelula(TotalDeElementos - 2);
                penultima.Proxima = Primeira;
                Primeira.Anterior = penultima;
                Ultima = penultima;
            }

            TotalDeElementos--;
        }

        public void RemoverValoresDuplicados()
        {
    


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
               throw new ArgumentException("nao é possivel remover do inicio");
           }
           else if (posicao == TotalDeElementos - 1) 
           {
               RemoverDoFinal();
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
            return posicao >= 0 && posicao < TotalDeElementos;
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