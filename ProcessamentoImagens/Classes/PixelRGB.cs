using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.Classes
{
    public class PixelRGB
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public PixelRGB(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
