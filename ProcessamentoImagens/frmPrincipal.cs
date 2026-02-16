using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Image image;
        private Bitmap imageBitmap;
        private Classes.Pixel[,] matrizCMY;
        private Classes.Pixel[,] matrizRGB;
        private Classes.Pixel[,] matrizHSI;

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
                pictBoxImg1.Image = image;

                //Criar um Bitmap para realizar o calculo e salvamento dos valores nas matrizes:
                //  - RGB
                //  - HSI
                //  - CMY
                Bitmap imgCalculo = new Bitmap(image);
                matrizRGB = new Classes.Pixel[imgCalculo.Width, imgCalculo.Height];
                matrizCMY = new Classes.Pixel[imgCalculo.Width, imgCalculo.Height];
                matrizHSI = new Classes.Pixel[imgCalculo.Width, imgCalculo.Height];
                Filtros.CalculaValores(imgCalculo, matrizRGB, matrizCMY, matrizHSI); //matrizes inicializadas com valores calculados

                //depurar
                Console.WriteLine("Teste");

                pictBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
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

                Filtros.GerarImagensHSI(imgDestH, imgDestS, imgDestI, matrizHSI);

                pictBoxImgH.Image = imgDestH;
                pictBoxImgS.Image = imgDestS;
                pictBoxImgI.Image = imgDestI;
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
                        $"CMY: ({matrizCMY[imgX, imgY].R}, {matrizCMY[imgX, imgY].G}, {matrizCMY[imgX, imgY].B})  " +
                        $"HSI: ({matrizHSI[imgX, imgY].R}, {matrizHSI[imgX, imgY].G}, {matrizHSI[imgX, imgY].B})";

                    //(mensagem,onde mostrar, posição perto do mouse, tempo)
                    toolTip1.Show(texto, pictBoxImg1, e.Location.X + 15, e.Location.Y + 15,1000);
                }
            }
        }

        private void btnImagemOriginal_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                pictBoxImg1.Image = image;
                esticarImgH();
            }
        }

        private void btnAumentarBrilho_Click(object sender, EventArgs e)
        {

        }

        private void btnDiminuirBrilho_Click(object sender, EventArgs e)
        {

        }

        
    }
}
