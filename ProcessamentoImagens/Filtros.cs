using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProcessamentoImagens
{
    class Filtros
    {
        //calcular os valores das matrizes RGB, CMY e HSI
        public static void CalculaValores(Bitmap imageBitmap, Classes.Pixel[,] matrizRGB, Classes.Pixel[,] matrizCMY, Classes.Pixel[,] matrizHSI)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;
            int pixelSize = 3, b, g, r;

            //travar os bits
            BitmapData bitmapData = imageBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);


            unsafe
            {
                byte* origem = (byte*)bitmapData.Scan0.ToPointer();
                byte* pixel;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        pixel = origem + y * bitmapData.Stride + x * pixelSize;

                        //modo de acesso: BGR
                        b = *(pixel++);
                        g = *(pixel++);
                        r = *(pixel++);

                        //matriz RGB
                        matrizRGB[x, y] = new Classes.Pixel(r, g, b);

                        //matriz CMY
                        matrizCMY[x, y] = new Classes.Pixel(255 - r, 255 - g, 255 - b);

                        //matriz HSI
                        matrizHSI[x, y] = new Classes.Pixel(0, 0, 0); //inicialização

                        //normalizar 1 unica vez
                        double rNorm = NormalizaR(r, g, b);
                        double gNorm = NormalizaG(r, g, b);
                        double bNorm = NormalizaB(r, g, b);

                        matrizHSI[x, y].R = ConverteH(ObterH(rNorm, gNorm, bNorm));
                        matrizHSI[x, y].G = ConverteS(ObterS(rNorm, gNorm, bNorm));
                        matrizHSI[x, y].B = ConverteI(ObterI(r, g, b));

                    }
                }
                Console.WriteLine("Teste");
            }
            imageBitmap.UnlockBits(bitmapData);
        }

        //--------------------------------------- HSI--------------------------------------
        //---------------------------------------------------------------------------------

        //NORMALIZAÇÕES ---------------------> RGB - HSI
        public static double NormalizaR(int R, int G, int B)
        {
            int soma = R + G + B;
            if (soma > 0)
                return (double)R / soma;
            return 0;
        }
        public static double NormalizaG(int R, int G, int B)
        {
            int soma = R + G + B;
            if (soma > 0)
                return (double)G / soma;
            return 0;
        }
        public static double NormalizaB(int R, int G, int B)
        {
            int soma = R + G + B;
            if (soma > 0)
                return (double)B / soma;
            return 0;
        }

        //OBTENÇÃO DOS VALORES CONCRETOS DE HSI -------------> RGB - HSI
        public static double ObterH(double r, double g, double b)
        {
            double numerador, denominador;
            numerador = 0.5 * ((r - g) + (r - b));
            denominador = Math.Pow(Math.Pow(r - g, 2) + (r - b) * (g - b), 0.5);


            if (denominador != 0)
            {
                double valor = numerador / denominador;
                valor = Math.Max(-1, Math.Min(1, valor));

                double angulo = Math.Acos(valor);

                if (b > g)
                    angulo = 2 * Math.PI - angulo;

                return angulo;
            }
            else
                return 0;
        }
        public static double ObterS(double r, double g, double b)
        {
            return 1 - 3 * Math.Min(r, Math.Min(g, b));
        }
        public static double ObterI(int R, int G, int B)
        {
            return (double)(R + G + B) / (3 * 255);
        }

        //CONVERSÃO PARA OS RANGES DE HSI -> [0,360]; [0,100]; [0,255] ------------> RGB - HSI
        public static int ConverteH(double h)
        {
            return (int)(h * 180 / Math.PI);
        }
        public static int ConverteS(double s)
        {
            return (int)(s * 100);
        }
        public static int ConverteI(double i)
        {
            return (int)(i * 255);
        }
        //---------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------



        //OUTROS FILTROS 
        public static void LuminanciaDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            Int32 gs;

            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                    }
                    src += padding;
                    dst += padding;
                }
            }
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }


        public static void RGBparaCMY(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int padding = bitmapDataSrc.Stride - (width * pixelSize);
            unsafe
            {
                byte* src1 = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();
                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src1++);
                        g = *(src1++);
                        r = *(src1++);

                        *(dst++) = (byte)(255 - b);
                        *(dst++) = (byte)(255 - g);
                        *(dst++) = (byte)(255 - r);
                    }
                    src1 += padding;
                    dst += padding;
                }
            }
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }


        public static void GerarImagensHSI(Bitmap imgBitmapH,Bitmap imgBitmapS, Bitmap imgBitmapI, Classes.Pixel[,] matrizHSI)
        {
            int width = imgBitmapH.Width;
            int height = imgBitmapH.Height;
            int pixelSize = 3;

            BitmapData dataH = imgBitmapH.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);

            BitmapData dataS = imgBitmapS.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData dataI = imgBitmapI.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* origemH = (byte*)dataH.Scan0.ToPointer();
                byte* origemS = (byte*)dataS.Scan0.ToPointer();
                byte* origemI = (byte*)dataI.Scan0.ToPointer();

                byte* pixelH;
                byte* pixelS;
                byte* pixelI;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        pixelH = origemH + y * dataH.Stride + x * pixelSize;
                        pixelS = origemS + y * dataS.Stride + x * pixelSize;
                        pixelI = origemI + y * dataI.Stride + x * pixelSize;

                        int h = matrizHSI[x, y].R;
                        int s = matrizHSI[x, y].G;
                        int i = matrizHSI[x, y].B;

                        // ----- Conversões -----

                        int valorH = (int)(h * 255.0 / 360.0);
                        int valorS = (int)(s * 255.0 / 100.0);
                        int valorI = i;

                        //limitar os valores para o intervalo [0, 255]
                        if(valorH < 0) valorH = 0;
                        if(valorH > 255) valorH = 255;

                        if(valorS < 0) valorS = 0;
                        if(valorS > 255) valorS = 255;

                        if(valorI < 0) valorI = 0;
                        if (valorI > 255) valorI = 255;


                        // H
                        *(pixelH++) = (byte)valorH;
                        *(pixelH++) = (byte)valorH;
                        *(pixelH++) = (byte)valorH;

                        // S
                        *(pixelS++) = (byte)valorS;
                        *(pixelS++) = (byte)valorS;
                        *(pixelS++) = (byte)valorS;

                        // I
                        *(pixelI++) = (byte)valorI;
                        *(pixelI++) = (byte)valorI;
                        *(pixelI++) = (byte)valorI;
                    }
                }
            }
            imgBitmapH.UnlockBits(dataH);
            imgBitmapS.UnlockBits(dataS);
            imgBitmapI.UnlockBits(dataI);
        }

    }
}
