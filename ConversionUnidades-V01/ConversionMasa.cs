namespace ConversionUnidades_V01
{
    public class ConversionMasa
    {
        public double gramos { get; set; }
        public double kilogramos { get; set; }
        public double libras { get; set; }
        public double onzas { get; set; }

        private double valorKilogramo=1000;//En gramos
        private double valorOnza = 28.3;//En gramos
        private double valorLibra = 0.453;//En gramos

        //Conversion Kilogramos
        public double CalculaGramosAKilogramos(double gramos)
        {
            this.gramos = gramos;
            return gramos / valorKilogramo;
        }
        public double CalculaKilogramosAGramos(double kilogramos)
        {
            this.kilogramos = kilogramos;
            return kilogramos * valorKilogramo;
        }
        //Conversion onza
        public double CalculaGramosAOnzas(double gramos)
        {
            this.gramos = gramos;
            return gramos / valorOnza;
        }
        public double CalculaOnzasAGramos(double onzas)
        {
            this.onzas = onzas;
            return onzas * valorOnza;
        }

        //Conversion libras
        public double CalculaGramosALibras(double gramos)
        {
            this.gramos = gramos;
            return gramos / valorLibra;
        }
        public double CalcularLibrasAGramos(double libras)
        {
            this.libras = libras;
            return libras * valorLibra;
        }

    }
}
