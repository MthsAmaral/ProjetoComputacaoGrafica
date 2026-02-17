using ProcessamentoImagens.Classes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Image image, imageOriginal;
        private Bitmap imageBitmap;
        private PixelCMY[,] matrizCMY;
        private PixelRGB[,] matrizRGB;
        private PixelHSI[,] matrizHSI;
        private int brilho = 15, matiz = 15;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAbrirImagem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                imageOriginal = image;//somente para salvar imagem original, caso queira voltar a ela
                pictBoxImg1.Image = image;

                //Criar um Bitmap para realizar o calculo e salvamento dos valores nas matrizes:
                //  - RGB
                //  - HSI
                //  - CMY
                Bitmap imgCalculo = new Bitmap(image);
                matrizRGB = new PixelRGB[imgCalculo.Width, imgCalculo.Height];
                matrizCMY = new PixelCMY[imgCalculo.Width, imgCalculo.Height];
                matrizHSI = new PixelHSI[imgCalculo.Width, imgCalculo.Height];
                Filtros.CalculaValores(imgCalculo, matrizRGB, matrizCMY, matrizHSI); //matrizes inicializadas com valores calculados

                //atualizar o valor do brilho no campo de texto
                textBoxBrilho.Text = CalculaBrilhoMedio().ToString();

                //depurar
                Console.WriteLine("Teste");

                pictBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private double CalculaBrilhoMedio()
        {
            double soma = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    soma += matrizHSI[x, y].I; //B -> equivalente ao 'I' -> brilho do HSI
                }
            }
            return soma / (image.Height * image.Width);
        }

        private double CalculaHueMedio()
        {
            double soma = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    soma += matrizHSI[x, y].H; //R -> equivalente ao 'H' -> angulo de cores
                }
            }
            return soma / (image.Height * image.Width);
        }

        private void esticarImgH()
        {
            pictBoxImgH.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            image = null;
            imageBitmap = null;
            pictBoxImg1.Image = null;
            pictBoxImgS.Image = null;
            pictBoxImgH.Image = null;
            pictBoxImgI.Image = null;
        }

        private void btnLuminanciaComDMA_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                Bitmap imgDest = new Bitmap(image);
                imageBitmap = (Bitmap)image;
                Filtros.LuminanciaDMA(imageBitmap, imgDest);
                pictBoxImg1.Image = imgDest;
                esticarImgH();
            }
        }

        private void CMY_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                Bitmap imgDest = new Bitmap(image);
                imageBitmap = (Bitmap)image;
                Filtros.RGBparaCMY(imageBitmap, imgDest);
                pictBoxImg1.Image = imgDest;
                esticarImgH();
            }
        }

        private void buttonHSI_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                imageBitmap = (Bitmap)image;

                Bitmap imgDestH = new Bitmap(image);
                Bitmap imgDestS = new Bitmap(image);
                Bitmap imgDestI = new Bitmap(image);

                Filtros.CinzaHSI_Canal(imgDestH, matrizHSI, matrizRGB, 'H');
                Filtros.CinzaHSI_Canal(imgDestS, matrizHSI, matrizRGB, 'S');
                Filtros.CinzaHSI_Canal(imgDestI, matrizHSI, matrizRGB, 'I');

                pictBoxImgH.Image = imgDestH;
                pictBoxImgH.SizeMode = PictureBoxSizeMode.StretchImage;
                pictBoxImgS.Image = imgDestS;
                pictBoxImgS.SizeMode = PictureBoxSizeMode.StretchImage;
                pictBoxImgI.Image = imgDestI;
                pictBoxImgI.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void pictBoxImg1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictBoxImg1.Image != null)
            {
                int imgX = e.X * pictBoxImg1.Image.Width / pictBoxImg1.Width;
                int imgY = e.Y * pictBoxImg1.Image.Height / pictBoxImg1.Height;

                if (imgX >= 0 && imgX < pictBoxImg1.Image.Width &&
                    imgY >= 0 && imgY < pictBoxImg1.Image.Height)
                {
                 
                    string texto =
                        $"Pixel: ({imgX}, {imgY})\n" +
                        $"RGB: ({matrizRGB[imgX, imgY].R},{matrizRGB[imgX, imgY].G}, {matrizRGB[imgX, imgY].B})  " +
                        $"CMY: ({matrizCMY[imgX, imgY].C}, {matrizCMY[imgX, imgY].M}, {matrizCMY[imgX, imgY].Y})  " +
                        $"HSI: ({matrizHSI[imgX, imgY].H}, {matrizHSI[imgX, imgY].S}, {matrizHSI[imgX, imgY].I})";

                    //(mensagem,onde mostrar, posição perto do mouse, tempo)
                    toolTip1.Show(texto, pictBoxImg1, e.Location.X + 15, e.Location.Y + 15,1000);
                }
            }
        }

        private void btnImagemOriginal_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                pictBoxImg1.Image = imageOriginal;
                esticarImgH();
            }
        }

        private void btnAumentarBrilho_Click(object sender, EventArgs e)
        {
            Bitmap imgBitmap = new Bitmap(image);
            if (image != null)
            {
                Filtros.AjustarBrilho(imgBitmap, brilho, matrizRGB, matrizCMY, matrizHSI, true); //o true aumenta o brilho
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxBrilho.Text = CalculaBrilhoMedio().ToString();
            }
        }

        private void btnCinzaHSI_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                imageBitmap = (Bitmap)image;

                Bitmap imgDest = new Bitmap(image);
                

                Filtros.CinzaHSI(imgDest, matrizHSI, matrizRGB);

                pictBoxImg1.Image = imgDest;
            }
        }

        private void btnAumentarHue_Click(object sender, EventArgs e)
        {
            Bitmap imgBitmap = new Bitmap(image);
            if (image != null)
            {
                Filtros.AjustarHue(imgBitmap, matiz, matrizRGB, matrizCMY, matrizHSI, true); //o true aumenta o angulo da matiz
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxHue.Text = CalculaHueMedio().ToString();
            }
        }

        private void btnDiminuirHue_Click(object sender, EventArgs e)
        {
            Bitmap imgBitmap = new Bitmap(image);
            if (image != null)
            {
                Filtros.AjustarHue(imgBitmap, matiz, matrizRGB, matrizCMY, matrizHSI, false); //o false diminui o angulo da matiz
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxHue.Text = CalculaHueMedio().ToString();
            }
        }

        private void btnDiminuirBrilho_Click(object sender, EventArgs e)
        {
            Bitmap imgBitmap = new Bitmap(image);
            if (image != null)
            {
                Filtros.AjustarBrilho(imgBitmap, brilho, matrizRGB, matrizCMY, matrizHSI, false); //o false diminui o brilho
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxBrilho.Text = CalculaBrilhoMedio().ToString();
            }
        }
    }
}
