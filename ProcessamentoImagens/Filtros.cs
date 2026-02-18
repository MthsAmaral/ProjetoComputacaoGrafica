using ProcessamentoImagens.Classes;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProcessamentoImagens
{
    
    class Filtros
    {
        //ajustar o brilho da imagem
        public static void AjustarBrilho(Bitmap imageBitmap, int valorBrilho, PixelRGB[,] matrizRGB, PixelCMY[,] matrizCMY, PixelHSI[,] matrizHSI, bool aumenta)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;
            int pixelSize = 3;
            int r = 0, g = 0, b = 0;

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

                        if (aumenta)
                        {
                            //I += delta;      // delta pode ser 0.1, -0.05 etc
                            matrizHSI[x, y].I += valorBrilho;
                            matrizHSI[x, y].I = Math.Max(0.0, Math.Min(1.0, matrizHSI[x, y].I));
                            
                        }
                        else //diminui
                        {
                            matrizHSI[x, y].I -= valorBrilho;
                        }

                        matrizHSI[x, y].I = Math.Max(0.0, Math.Min(255, matrizHSI[x, y].I));

                        HSIparaRGB(matrizHSI[x, y].H, matrizHSI[x, y].S, matrizHSI[x, y].I, ref r, ref g, ref b);

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

        //ajustar a matiz
        public static void AjustarHue(Bitmap imageBitmap, int matiz, PixelRGB[,] matrizRGB, PixelCMY[,] matrizCMY, PixelHSI[,] matrizHSI, bool aumenta)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;
            int pixelSize = 3;
            int r = 0, g = 0, b = 0;

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

                        if (aumenta)
                        {
                            matrizHSI[x, y].H += matiz;
                        }
                        else //diminui
                        {
                            matrizHSI[x, y].H -= matiz;
                        }

                        // normalização circular
                        //matrizHSI[x, y].H = matrizHSI[x, y].H % 360.0;

                        //if (matrizHSI[x, y].H < 0)
                        //    matrizHSI[x, y].H += 360.0;

                        HSIparaRGB(matrizHSI[x, y].H, matrizHSI[x, y].S, matrizHSI[x, y].I, ref r, ref g, ref b);

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

        public static void AtualizarMatrizCMY(PixelCMY[,] matrizCMY, PixelRGB[,] matrizRGB, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrizCMY[x, y].C = 255 - matrizRGB[x, y].R;
                    matrizCMY[x, y].M = 255 - matrizRGB[x, y].G;
                    matrizCMY[x, y].Y = 255 - matrizRGB[x, y].B;
                }
            }
        }

        //calcular os valores das matrizes RGB, CMY e HSI
        public static void CalculaValores(Bitmap imageBitmap, PixelRGB[,] matrizRGB, PixelCMY[,] matrizCMY, PixelHSI[,] matrizHSI)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;
            int pixelSize = 3, b, g, r;
            double h=0, s=0, i=0;

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
                        matrizRGB[x, y] = new PixelRGB(r, g, b);

                        //matriz CMY
                        matrizCMY[x, y] = new PixelCMY(255 - r, 255 - g, 255 - b);

                        //matriz HSI
                        matrizHSI[x, y] = new PixelHSI(0, 0, 0); //inicialização

                        RGBparaHSI(r, g, b, ref h, ref s, ref i); //faz a conversão de RGB para HSI
                        matrizHSI[x, y].H = h;
                        matrizHSI[x, y].S = s;
                        matrizHSI[x, y].I = i;
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
        public static int ConverteI(double i, int R, int G, int B)
        {
            return (R+G+B)/3;
        }

        //---------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------

        //----------------------- HSI para RGB --------------------------------------------
        //public static void HSIparaRGB(int coordX, int coordY, PixelHSI[,] matrizHSI, double H, double S, double I, ref int r, ref int g, ref int b) //RGB por referência
        //{
        //    double h, s, i, x, y, z;

        //    //valores de HSI reais
        //    h = H * Math.PI / 180.0; //conversão de graus para radianos
        //    s = S / 100.0; //conversão de porcentagem para o intervalo [0,1]
        //    i = I / 255.0; //conversão de intensidade para o intervalo [0,1]

        //    //calculo de x, y, z
        //    x = i * (1 - s);
        //    y = i * (1 + (s * Math.Cos(h) / Math.Cos(Math.PI / 3 - h)));
        //    z = 3 * i - (x + y);

        //    //reescalar para o intervalo [0,255]
        //    x = x * 255;
        //    y = y * 255;
        //    z = z * 255;

        //    //verificações para atribuição correta de RGB
        //    if (0<=h && h < 2*Math.PI / 3)
        //    {
        //        b = (int)x;
        //        r = (int)y;
        //        g = (int)z;
        //    }
        //    else if(2*Math.PI/3 <= h && h < 4*Math.PI/3)
        //    {
        //        //matrizHSI[coordX, coordY].H = H - 2 * Math.PI / 3; //mudar o valor real
        //        r = (int)x;
        //        g = (int)y;
        //        b = (int)z;
        //    }
        //    else if(4*Math.PI/3 <= h && h < 2*Math.PI)
        //    {
        //        //matrizHSI[coordX, coordY].H = H - 4 * Math.PI / 3; //mudar o valor real
        //        g = (int)x;
        //        b = (int)y;
        //        r = (int)z;
        //    }
        //}
        public static void HSIparaRGB(double H, double S, double I, ref int R, ref int G, ref int B)
        {
            double r, g, b;

            if (S == 0) //se não tem saturação, é um pixel acromático ou comumente chamado de cinza
            {
                // Pixel acromático (cinza)
                r = g = b = I;
            }
            else if (H < 2 * Math.PI / 3)
            {
                double x = I * (1 - S);
                double y = I * (1 + (S * Math.Cos(H) / Math.Cos(Math.PI / 3 - H)));
                double z = 3 * I - (x + y);

                r = y;
                g = z;
                b = x;
            }
            else if (H < 4 * Math.PI / 3)
            {
                H -= 2 * Math.PI / 3;

                double x = I * (1 - S);
                double y = I * (1 + (S * Math.Cos(H) / Math.Cos(Math.PI / 3 - H)));
                double z = 3 * I - (x + y);

                r = x;
                g = y;
                b = z;
            }
            else
            {
                H -= 4 * Math.PI / 3;

                double x = I * (1 - S);
                double y = I * (1 + (S * Math.Cos(H) / Math.Cos(Math.PI / 3 - H)));
                double z = 3 * I - (x + y);

                r = z;
                g = x;
                b = y;
            }

            // Clamp final -> deixar no intervalo [0,255]
            R = (int)Math.Round(Math.Max(0, Math.Min(1, r)) * 255);
            G = (int)Math.Round(Math.Max(0, Math.Min(1, g)) * 255);
            B = (int)Math.Round(Math.Max(0, Math.Min(1, b)) * 255);
        }

        //----------------------- RGB para HSI --------------------------------------------
        //public static void RGBparaHSI(int R, int G, int B, ref double h, ref double s, ref double i) //HSI por referência
        //{
        //    double rNorm, gNorm, bNorm;
        //    int soma = R+G+B;

        //    //normalizar os valores de RGB

        //    //R ---------------------------
        //    if (soma > 0)
        //        rNorm = (double)R / soma;
        //    else
        //        rNorm = 0;

        //    //G ---------------------------
        //    if (soma > 0)
        //        gNorm = (double)G / soma;
        //    else
        //        gNorm = 0;

        //    //B ---------------------------
        //    if (soma > 0)
        //        bNorm = (double)B / soma;
        //    else
        //        bNorm = 0;


        //    //obtenção dos valores de HSI

        //    //H ----------------------------------------------------------------------------------------
        //    double numerador, denominador;
        //    numerador = 0.5 * ((rNorm - gNorm) + (rNorm - bNorm)); //corrigido
        //    denominador = Math.Pow(Math.Pow(rNorm - gNorm, 2) + (rNorm - bNorm) * (gNorm - bNorm), 0.5); //corrigido
        //    if (denominador != 0)
        //    {
        //        double valor = numerador / denominador;
        //        valor = Math.Max(-1, Math.Min(1, valor));

        //        double theta = Math.Acos(valor);

        //        if (bNorm > gNorm)
        //            theta = 2 * Math.PI - theta;

        //        h = theta; //aqui está no intervalo [0,2*PI]

        //        h = h*180/Math.PI; //para deixar no intervalo [0,360]
        //    }
        //    else
        //        h = 0;

        //    //S ----------------------------------------------------------------------------------------
        //    s = 1 - 3 * Math.Min(rNorm, Math.Min(gNorm, bNorm)); //aqui está no intervalo [0,1]
        //    s *= 100; //para deixar no intervalo [0,100]

        //    //I ----------------------------------------------------------------------------------------
        //    i = (double)(R + G + B) / (3*255); //aqui está no intervalo [0,1]
        //    i = i*255; //para deixar no intervalo [0,255]
        //}
        public static void RGBparaHSI(int R, int G, int B, ref double H, ref double S, ref double I)
        {
            // Normalização para [0,1]
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            // Intensidade
            I = (r + g + b) / 3.0;

            // Saturação
            double min = Math.Min(r, Math.Min(g, b));

            if (I == 0)
                S = 0;
            else
                S = 1.0 - (min / I);

            // Hue
            double numerador = 0.5 * ((r - g) + (r - b));
            double denominador = Math.Sqrt(
                (r - g) * (r - g) +
                (r - b) * (g - b)
            );

            if (denominador == 0)
            {
                H = 0;
            }
            else
            {
                double valor = numerador / denominador;

                // Clamp para estabilidade numérica
                valor = Math.Max(-1.0, Math.Min(1.0, valor));

                double theta = Math.Acos(valor);

                if (b > g)
                    theta = 2 * Math.PI - theta;

                H = theta;
            }
        }

        public static void RGBparaCMY(Bitmap imageBitmapSrc, Bitmap imageBitmapDest) //converte a imagem diretamente
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
                        //usar a matriz CMY já salva
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

        public static void CinzaHSI(Bitmap imgBitmap,  PixelHSI[,] matrizHSI, PixelRGB[,] matrizRGB) //simplesmente zera a Saturação 'S'
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


                        matrizHSI[x, y].S = 0;

                        HSIparaRGB(matrizHSI[x, y].H, matrizHSI[x, y].S, matrizHSI[x, y].I, ref r, ref g, ref b);

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

        //métodos para o cinza de cada canal do HSI
        public static void CinzaHSI_Canal(Bitmap imgBitmap, PixelHSI[,] matrizHSI, PixelRGB[,] matrizRGB, char canal)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* origem = (byte*)img.Scan0.ToPointer();
                byte* pixel;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        pixel = origem + y * img.Stride + x * pixelSize;

                        if(canal == 'H') //canal H
                        {
                            int h = ConverteH(matrizHSI[x, y].H);
                            pixel[0] = (byte)h;
                            pixel[1] = (byte)h;
                            pixel[2] = (byte)h;
                        }
                        else if (canal == 'S') //canal S
                        {
                            int s = ConverteS(matrizHSI[x, y].S);
                            pixel[0] = (byte)s;
                            pixel[1] = (byte)s;
                            pixel[2] = (byte)s;
                        }
                        else //canal I
                        {
                            int i = ConverteI(matrizHSI[x, y].I, matrizRGB[x, y].R, matrizRGB[x, y].G, matrizRGB[x, y].B);
                            pixel[0] = (byte)matrizHSI[x, y].I;
                            pixel[1] = (byte)matrizHSI[x, y].I;
                            pixel[2] = (byte)matrizHSI[x, y].I;
                        }
                    }
                }
            }
            imgBitmap.UnlockBits(img);
        }
    }
}
