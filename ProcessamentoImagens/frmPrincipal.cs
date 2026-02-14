using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Image image;
        private Bitmap imageBitmap;

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
                pictBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
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
            Filtros.luminanciaDMA(imageBitmap, imgDest);
<<<<<<< HEAD
            pictBoxImg2.Image = imgDest;
            pictBoxImg2.SizeMode = PictureBoxSizeMode.StretchImage;
=======
            pictBoxImgH.Image = imgDest;
>>>>>>> 9738137b628ee9fb1543826d92d9c1539c8cea58
        }

        private void CMY_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
<<<<<<< HEAD
            Filtros.negativoDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
            pictBoxImg2.SizeMode = PictureBoxSizeMode.StretchImage;
=======
            Filtros.RGBparaCMY(imageBitmap, imgDest);
            pictBoxImgH.Image = imgDest;
        }

        private void buttonHSI_Click(object sender, EventArgs e)
        {

>>>>>>> 9738137b628ee9fb1543826d92d9c1539c8cea58
        }
    }
}
