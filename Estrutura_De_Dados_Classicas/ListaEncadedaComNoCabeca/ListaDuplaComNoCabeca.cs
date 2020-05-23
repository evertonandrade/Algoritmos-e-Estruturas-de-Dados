using System;
using System.Text;

namespace ListaEncadedaComNoCabeca
{
    public class ListaDuplaComNoCabeca<T>
    {
        private Celula<T> Primeira;
        private Celula<T> Ultima;
        private Celula<T> Cabeca;
        public int TotalDeElementos { get; private set; }

        public ListaDuplaComNoCabeca()
        {
            Cabeca = new Celula<T>();
            Cabeca.Proxima = this.Ultima;
            Cabeca.Anterior = this.Primeira;
        }

        public bool EstaVazia()
        {
            return (Primeira == null);
        }

        public void AdicionarNoComeco(T elemento)
        {
            Celula<T> nova = new Celula<T>(elemento);
            if (EstaVazia())
            {
                Primeira = nova;
                Ultima = nova;
            }
            else
            {
                nova.Proxima = Primeira;
                Primeira.Anterior = nova;
                Primeira = nova;

                Primeira.Anterior = Ultima;
                Ultima.Proxima = Primeira;
            }
            TotalDeElementos++;
        }

        public void Adicionar(T elemento)
        {
            if (EstaVazia())
            {
                AdicionarNoComeco(elemento);
            }
            else
            {
                Celula<T> nova = new Celula<T>(elemento);
                Ultima.Proxima = nova;
                nova.Anterior = Ultima;
                Ultima = nova;

                Primeira.Anterior = Ultima;
                Ultima.Proxima = Primeira;
                TotalDeElementos++;
            }
        }

        public void Adicionar(int posicao, T elemento)
        {
            if (posicao == 0)
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

        public void RemoverDoFinal()
        {
            if (TotalDeElementos == 1)
            {
                RemoverDoComeco();
            }
            else
            {
                Celula<T> penultima = Ultima.Anterior;
                penultima.Proxima = Primeira;
                Primeira.Proxima = penultima;
                Ultima = penultima;
                TotalDeElementos--;
            }
        }

        public void RemoverDoComeco()
        {
            if (EstaVazia())
            {
                throw new ArgumentException("Lista vazia. Impossivel remover!");
            }
            if (Primeira == Ultima)
            {
                Primeira = null;
                Ultima = null;
            }
            else
            {
                Primeira = Primeira.Proxima;
                Primeira.Anterior = Ultima;
                Ultima.Proxima = Primeira;
            }
            TotalDeElementos--;
        }

        public void Concatenar(ListaDuplaComNoCabeca<T> lista)
        {
            Intercalar(TotalDeElementos, lista);
        }

        public void Intercalar(int indice, ListaDuplaComNoCabeca<T> lista)
        {
            if (EstaVazia())
            {
                Primeira = lista.Primeira;
                Ultima = lista.Ultima;
            }
            else if (indice == 0)
            {
                lista.Ultima.Proxima = Primeira;
                Primeira.Anterior = lista.Ultima;
                Ultima = lista.Primeira;
                lista.Primeira = Ultima;
                Primeira = lista.Primeira;
            }
            else if (indice == TotalDeElementos)
            {
                Ultima.Proxima = lista.Primeira;
                lista.Primeira.Anterior = Ultima;
                Primeira.Anterior = lista.Ultima;
                lista.Ultima.Proxima = Primeira;
                Ultima = lista.Primeira;
            }
            else
            {
                Celula<T> antecessora = PegarCelula(indice - 1);
                Celula<T> sucessora = PegarCelula(indice);
                antecessora.Proxima = lista.Primeira;
                lista.Primeira.Anterior = antecessora;
                lista.Ultima.Proxima = sucessora;
                sucessora.Anterior = lista.Ultima;
            }

            TotalDeElementos += lista.TotalDeElementos;
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