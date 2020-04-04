namespace Filas
{
       public class Celula<T>
    {
        public Celula<T> Anterior { get; set; }
        public Celula<T> Proxima { get; set; }
        public T Elemento { get; set; }
        
        public Celula(T elemento)
        {
            Elemento = elemento;
        }
    }
}