using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.Classes
{
    public class PixelCMY
    {
        public int C { get; set; }
        public int M { get; set; }
        public int Y { get; set; }
        public PixelCMY(int c, int m, int y)
        {
            C = c;
            M = m;
            Y = y;
        }
    }
}
