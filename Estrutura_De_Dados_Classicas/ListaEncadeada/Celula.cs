using System;

namespace ListaEncadeada
{
    class Celula<T>
    {
        public Celula<T> Proxima { get; set; }
        public object Elemento { get; private set; }
        

        public Celula(Celula<T> proxima, object elemento)
        {
            Proxima = proxima;
            Elemento = elemento;
        }

        public Celula(object elemento)
        {
            Elemento = elemento;
        }
    }
}

