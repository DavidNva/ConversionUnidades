namespace ConversionUnidades_V01
{
    public class ConversionLongitud
    {
        public decimal milimetros { get; set; }
        public decimal centimetros { get; set; }
        public decimal metros { get; set; }
        public decimal kilometros { get; set; }

        private decimal valorMetro = 100; //En centimetros
        private decimal valorKilometros = 1000;//En metros
        private decimal valorKilometrosCm = 100 * 1000;//En centimetros
        private decimal valorCm = 10;//En milimetros

        public decimal CalculaCmAMetros(decimal centimetros)
        {
            this.centimetros = centimetros;
            return centimetros / valorMetro;
        }
        public decimal CalculaMetrosACentimetros(decimal metros)
        {
            this.metros = metros;
            return metros * valorMetro;
        }
        public decimal CalculaMetrosAKilometros(decimal metros)
        {
            this.metros = metros;
            return metros / valorKilometros;
        }
        public decimal CalculaKmAMetros(decimal kilometros)
        {
            this.kilometros = kilometros;
            return kilometros * valorKilometros;
        }
        public decimal CalculaCmAKilometros(decimal centimetros)
        {
            this.centimetros = centimetros;
            return centimetros / valorKilometrosCm;
        }
        public decimal CalculaKmACentimetros(decimal kilometros)
        {
            this.kilometros = kilometros;
            return kilometros * valorKilometrosCm;
        }
        public decimal CalculaMiliACentimetros(decimal milimetros)
        {
            this.milimetros = milimetros;
            return milimetros / valorCm;
        }

        public decimal CalculaCmAMilimetros(decimal centimetros)
        {
            this.centimetros = centimetros;
            return centimetros * valorCm;
        }

    }
}
