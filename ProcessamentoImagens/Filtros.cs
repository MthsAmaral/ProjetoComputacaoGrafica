using ProcessamentoImagens.Classes;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProcessamentoImagens
{
    
    class Filtros
    {
        //aumentar o brilho da imagem
        public static void AjustarBrilho(Bitmap imageBitmap, int valorBrilho, Pixel[,] matrizRGB, Pixel[,] matrizCMY, Pixel[,] matrizHSI, bool aumenta)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;
            int pixelSize = 3;

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

                        double fator;
                        int novoI;

                        if (aumenta)
                        {
                            fator = 1 + (valorBrilho / 100.0); //calcular o fator de aumento do brilho
                        }
                        else //diminui
                        {
                            fator = 1 - (valorBrilho / 100.0); //calcular o fator de diminuição do brilho
                        }

                        novoI = (int)(matrizHSI[x, y].B * fator);

                        if (novoI > 255) novoI = 255; //limitar o valor máximo do brilho a 255
                        if (novoI < 0) novoI = 0; //limitar o valor mínimo do brilho a 0

                        matrizHSI[x, y].B = novoI;

                        int r = 0, g = 0, b = 0;
                        HSIparaRGB(matrizHSI[x, y].R, matrizHSI[x, y].G, matrizHSI[x, y].B, ref r, ref g, ref b);

                        //atualizar a matriz de RGB
                        matrizRGB[x, y].R = r;
                        matrizRGB[x, y].G = g;
                        matrizRGB[x, y].B = b;

                        //atualizar a imagem com os novos valores de RGB
                        pixel[0] = (byte)b;
                        pixel[1] = (byte)g;
                        pixel[2] = (byte)r;
                    }
                }
                //atualizar a matriz de CMY
                AtualizarMatrizCMY(matrizCMY, matrizRGB, width, height);
            }
            imageBitmap.UnlockBits(bitmapData);
        }

        public static void AtualizarMatrizCMY(Pixel[,] matrizCMY, Pixel[,] matrizRGB, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrizCMY[x, y].R = 255 - matrizRGB[x, y].R;
                    matrizCMY[x, y].G = 255 - matrizRGB[x, y].G;
                    matrizCMY[x, y].B = 255 - matrizRGB[x, y].B;
                }
            }
        }

        //calcular os valores das matrizes RGB, CMY e HSI
        public static void CalculaValores(Bitmap imageBitmap, Pixel[,] matrizRGB, Pixel[,] matrizCMY, Pixel[,] matrizHSI)
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
                        matrizRGB[x, y] = new Pixel(r, g, b);

                        //matriz CMY
                        matrizCMY[x, y] = new Pixel(255 - r, 255 - g, 255 - b);

                        //matriz HSI
                        matrizHSI[x, y] = new Pixel(0, 0, 0); //inicialização

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

        //--------------------------------------- HSI --------------------------------------
        //----------------------------------------------------------------------------------

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

        //----------------------- HSI para RGB --------------------------------------------
        public static void HSIparaRGB(double H, double S, double I, ref int r, ref int g, ref int b) //RGB por referência
        {
            double h, s, i, x, y, z;

            //valores de HSI reais
            h = H * Math.PI / 180.0;
            s = S / 100.0;
            i = I / 255.0;

            //calculo de x, y, z
            x = i * (1 - s);
            y = i * (1 + s * Math.Cos(h) / Math.Cos(Math.PI / 3 - h));
            z = 3 * i - (x + y);

            //reescalar para o intervalo [0,255]
            x = x * 255;
            y = y * 255;
            z = z * 255;

            //verificações para atribuição correta de RGB
            if (h < 2*Math.PI / 3)
            {
                b = (int)x;
                r = (int)y;
                g = (int)z;
            }
            else if(2*Math.PI/3 <= h && h < 4*Math.PI/3)
            {
                h = h- 2 * Math.PI / 3;
                r = (int)x;
                g = (int)y;
                b = (int)z;
            }
            else if(4*Math.PI/3 <= h && h < 2*Math.PI)
            {
                h = h - 4 * Math.PI / 3;
                g = (int)x;
                b = (int)y;
                r = (int)z;
            }
        }

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


       



        public static void CinzaHSI(Bitmap imgBitmap,  Pixel[,] matrizHSI, Pixel[,] matrizRGB)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData dataH = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* origem = (byte*)dataH.Scan0.ToPointer();
                byte* pixel;
                int r=0, g=0, b=0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        pixel = origem + y * dataH.Stride + x * pixelSize;


                        matrizHSI[x, y].G = 0;

                        HSIparaRGB(matrizHSI[x, y].R, matrizHSI[x, y].G, matrizHSI[x, y].B, ref r, ref g, ref b);

                        matrizRGB[x, y].R = r;
                        matrizRGB[x, y].G = g;
                        matrizRGB[x, y].B = b;

                        pixel[0] = (byte)b;
                        pixel[1] = (byte)g;
                        pixel[2] = (byte)r;

                    }
                }
            }

            imgBitmap.UnlockBits(dataH);
        }
    }


}
