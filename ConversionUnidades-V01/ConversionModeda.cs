using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionUnidades_V01
{
    public class ConversionModeda
    {
        public double pesos { get; set; }
        public double dolares { get; set; }
        //Contemplando que el valor del dolar es de 20.90 pesos
        private double ValorDolarActual;
        

        public double CalculaPesosADolares(double pesos)
        {
            ValorDolarActual = 20.90;
            this.pesos = pesos;
            //this.dolares = dolares;
            return this.pesos / ValorDolarActual;
        }
        public double CalculaDolaresAPesos(double dolares)
        {
            ValorDolarActual = 20.90;
            //this.pesos = pesos;
            this.dolares = dolares;
            return this.dolares * ValorDolarActual;
        }
    }
}
