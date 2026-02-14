using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

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

            int padding = bitmapData.Stride - (width * pixelSize);

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

                        matrizRGB[x, y] = new Classes.Pixel(r, g, b);
                        matrizCMY[x, y] = new Classes.Pixel(255 - r, 255 - g, 255 - b);
                        matrizHSI[x, y] = new Classes.Pixel(0, 0, 0); //inicialização
                        matrizHSI[x, y].R = GetH(r, g, b);
                        matrizHSI[x, y].G = GetS(r, g, b);
                        matrizHSI[x, y].B = GetI(r, g, b);
                        //GetRGBparaHSI(r, g, b, matrizHSI[x, y].R, matrizHSI[x, y].G, matrizHSI[x, y].B);

                        //depurar
                        Console.WriteLine("Teste!");
                    }
                }
                Console.WriteLine("Teste");
            }
            imageBitmap.UnlockBits(bitmapData);
        }

        //converter pra cinza = luminancia
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


        //métodos auxiliares para conversão de RGB para HSI

        //CHAMADA A OUTRAS FUNÇÕES
        public static int GetH(int R, int G, int B)
        {
            double r, g, b;
            r = NormalizaR(R, G, B);
            g = NormalizaG(R, G, B);
            b = NormalizaB(R, G, B);
            return ConverteH(ObterH(r, g, b));
        }
        public static int GetS(int R, int G, int B)
        {
            double r, g, b;
            r = NormalizaR(R, G, B);
            g = NormalizaG(R, G, B);
            b = NormalizaB(R, G, B);
            return ConverteS(ObterS(r, g, b));
        }
        public static int GetI(int R, int G, int B)
        {
            double r, g, b;
            r = NormalizaR(R, G, B);
            g = NormalizaG(R, G, B);
            b = NormalizaB(R, G, B);
            return ConverteI(ObterI(R, G, B));
        }
        public static void GetRGBparaHSI(int R, int G, int B, int H, int S, int I)
        {
            double r, g, b, h, s, i;

            //normalizar
            r = NormalizaR(R, G, B);
            g = NormalizaG(R, G, B);
            b = NormalizaB(R, G, B);

            //obter os valores concretos de HSI
            h = ObterH(r, g, b);
            s = ObterS(r, g, b);
            i = ObterI(R, G, B);

            //converter para os ranges de HSI -> [0,360]; [0,100]; [0,255]
            H = ConverteH(h);
            S = ConverteS(s);
            I = ConverteI(i);
        }

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

            if (b<=g)
            {
                return Math.Acos(numerador / denominador);
            }
            else
            {
                return 2 * Math.PI - Math.Acos(numerador / denominador);
            }
        }
        public static double ObterS(double r, double g, double b)
        {
            return 1 - 3 * Math.Min(r, Math.Min(g, b));
        }
        public static double ObterI(int R, int G, int B)
        {
            return (R + G + B) / (3 * 255);
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
    }
}
