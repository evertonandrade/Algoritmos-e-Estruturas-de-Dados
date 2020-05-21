namespace ListaEncadeadaCircular
{
    public class Celula<T>
    {
        public Celula<T> Anterior { get; set; }
        public Celula<T> Proxima { get; set; }

        public T Elemento { get; private set; }

        public Celula()
        {
            
        }


        public Celula(Celula<T> anterior, Celula<T> proxima, T elemento)
        {
            Anterior = anterior;
            Proxima = proxima;
            Elemento = elemento;
        }

        public Celula(Celula<T> anterior, T elemento)
        {
            Anterior = anterior;
            Elemento = elemento;
        }


        public Celula(T elemento)
        {
            Elemento = elemento;
        }

    }
}