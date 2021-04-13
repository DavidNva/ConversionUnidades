namespace ConversionUnidades_V01
{
    class ConversionTemperatura
    {
        public double Celsius { get; set; }
        public double Fahrenhet { get; set; }
        public double Kelvin { get; set; }

        private double valorCelsusF = 32;//En farhenheit
        private double valorCelsusK = 273.15;//En Kelvin

        private double valorFahrenheitC = -17.77778;//En celsius

        public double CalculaCelsiusAFahre(double Celsius)
        {
            this.Celsius = Celsius;
            return Celsius * 9 / 5 + 32;
        }
        public double CalculaFahrenheitACelsius(double Fahrenheit)
        {
            this.Fahrenhet = Fahrenheit;
            return ((Fahrenheit - 32) * 5 / 9);
        }
    }
}
