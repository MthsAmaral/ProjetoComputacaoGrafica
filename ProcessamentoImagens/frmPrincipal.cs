using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom;

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

                //Deixar a imagem esticada para melhor
                pictBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void esticarImgH()
        {
            pictBoxImgH.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pictBoxImg1.Image = null;
            pictBoxImgH.Image = null;
        }

        private void btnLuminanciaComDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.LuminanciaDMA(imageBitmap, imgDest);
            pictBoxImgH.Image = imgDest;
            esticarImgH();
        }

        private void CMY_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.RGBparaCMY(imageBitmap, imgDest);
            pictBoxImgH.Image = imgDest;
            esticarImgH();
        }

        private void buttonHSI_Click(object sender, EventArgs e)
        {

        }
    }
}
