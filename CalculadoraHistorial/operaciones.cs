namespace EspacioCalculadora
{
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }

    public class Operacion
    {
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion operacion;

        public double Resultado
        {
            get
            {
                return operacion switch
                {
                    TipoOperacion.Suma => resultadoAnterior + nuevoValor,
                    TipoOperacion.Resta => resultadoAnterior - nuevoValor,
                    TipoOperacion.Multiplicacion => resultadoAnterior * nuevoValor,
                    TipoOperacion.Division => nuevoValor == 0 ? double.NaN : resultadoAnterior / nuevoValor,
                    TipoOperacion.Limpiar => 0,
                    _ => resultadoAnterior
                };
            }
        }

        public double NuevoValor => nuevoValor;
        public TipoOperacion Tipo => operacion;

        public Operacion(double anterior, double nuevo, TipoOperacion tipo)
        {
            resultadoAnterior = anterior;
            nuevoValor = nuevo;
            operacion = tipo;
        }

        public override string ToString()
        {
            return $"{resultadoAnterior} {Simbolo()} {nuevoValor} = {Resultado}";
        }

        private string Simbolo()
        {
            return operacion switch
            {
                TipoOperacion.Suma => "+",
                TipoOperacion.Resta => "-",
                TipoOperacion.Multiplicacion => "*",
                TipoOperacion.Division => "/",
                TipoOperacion.Limpiar => "-> limpiar",
                _ => "?"
            };
        }
    }
}
