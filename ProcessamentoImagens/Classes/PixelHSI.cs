namespace ProcessamentoImagens.Classes
{
    public class PixelHSI
    {
        public double H { get; set; }
        public double S { get; set; }
        public double I { get; set; }
        public PixelHSI(double h, double s, double i)
        {
            H = h;
            S = s;
            I = i;
        }
    }
}
