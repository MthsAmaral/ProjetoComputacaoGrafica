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
                        
                        if(aumenta)
                            matrizHSI[y, x].B = matrizHSI[y, x].B + valorBrilho; //aumentar o brilho na matriz HSI -> campo 'I'
                        else //diminui
                            matrizHSI[y, x].B = matrizHSI[y, x].B - valorBrilho; //diminuir o brilho na matriz HSI -> campo 'I'

                        int r=0, g=0, b=0;
                        HSIparaRGB(matrizHSI[y, x].R, matrizHSI[y, x].G, matrizHSI[y, x].B, ref r, ref g, ref b);

                        //atualizar a matriz de RGB
                        matrizRGB[y, x].R = r;
                        matrizRGB[y, x].G = g;
                        matrizRGB[y, x].B = b;

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

        public static void AtualizarMatrizCMY(Pixel[,]  matrizCMY, Pixel[,]  matrizRGB, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrizCMY[y, x].R = 255 - matrizRGB[y, x].R;
                    matrizCMY[y, x].G = 255 - matrizRGB[y, x].G;
                    matrizCMY[y, x].B = 255 - matrizRGB[y, x].B;
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
        public static void HSIparaRGB(int H, int S, int I, ref int r, ref int g, ref int b) //RGB por referência
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
