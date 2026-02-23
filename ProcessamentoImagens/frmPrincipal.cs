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
        private PixelCMY[,] matrizCMY; //valores inteiros
        private PixelRGB[,] matrizRGB; //valores inteiros
        private PixelHSI[,] matrizHSI; //valores reais (double)
        private int matiz = 10;
        private double brilho = 0.05;

        public frmPrincipal()
        {
            InitializeComponent();
            //inicia programa com os botões de manipulação desabilitados
            ControlarBotoes(false);

            //cria mensagem de ajuda para o campo de texto do Hue, explicando o que cada valor representa
            toolTip1.SetToolTip(labelHueInfo,
            "0° = Vermelho\n" +
            "60° = Amarelo\n" +
            "120° = Verde\n" +
            "180° = Ciano\n" +
            "240° = Azul\n" +
            "300° = Magenta\n" +
            "360° = Vermelho");
            toolTip1.IsBalloon = true;      // estilo balão

        }

        private void abrindo()
        {
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
            textBoxBrilho.Text = CalculaBrilhoMedio().ToString("F2");
            textBoxHue.Text = CalculaHueMedio().ToString("F2") + "°";

            //habilitar os botões
            ControlarBotoes(true);

            pictBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
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
                abrindo();
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
            ControlarBotoes(false);

            textBoxHue.Text = "";
            textBoxBrilho.Text = "";

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

        private void btnCMY_Click(object sender, EventArgs e)
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

        private void btnHSI_Click(object sender, EventArgs e)
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

        

        private void btnImagemOriginal_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                pictBoxImg1.Image = imageOriginal;
                image = imageOriginal;
                abrindo();
                
                //imageBitmap = (Bitmap)image;
                //Filtros.CalculaValores(imageBitmap, matrizRGB, matrizCMY, matrizHSI);
                //textBoxHue.Text = CalculaHueMedio().ToString();
                //textBoxBrilho.Text = CalculaBrilhoMedio().ToString();
                //esticarImgH();
            }
        }

        private void btnAumentarHue_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imgBitmap = new Bitmap(image);

                Filtros.AjustarHue(imgBitmap, matiz, matrizRGB, matrizCMY, matrizHSI, true); //o true aumenta o angulo da matiz
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxHue.Text = CalculaHueMedio().ToString("F2") +"°";
            }
        }

        private void btnDiminuirHue_Click(object sender, EventArgs e)
        {
            
            if (image != null)
            {
                Bitmap imgBitmap = new Bitmap(image);

                Filtros.AjustarHue(imgBitmap, matiz, matrizRGB, matrizCMY, matrizHSI, false); //o false diminui o angulo da matiz
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxHue.Text = CalculaHueMedio().ToString("F2") + "°";
            }
        }

        private void btnAumentarBrilho_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imgBitmap = new Bitmap(image);

                Filtros.AjustarBrilho(imgBitmap, brilho, matrizRGB, matrizCMY, matrizHSI, true); //o true aumenta o brilho
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxBrilho.Text = CalculaBrilhoMedio().ToString("F2");
            }
        }

        private void btnDiminuirBrilho_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imgBitmap = new Bitmap(image);

                Filtros.AjustarBrilho(imgBitmap, brilho, matrizRGB, matrizCMY, matrizHSI, false); //o false diminui o brilho
                pictBoxImg1.Image = imgBitmap;
                image = imgBitmap;

                textBoxBrilho.Text = CalculaBrilhoMedio().ToString("F2");
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
                        $"HSI: ({matrizHSI[imgX, imgY].H:F4} , {matrizHSI[imgX, imgY].S:F4} , {matrizHSI[imgX, imgY].I:F4})";

                    //(mensagem,onde mostrar, posição perto do mouse, tempo)
                    toolTip1.Show(texto, pictBoxImg1, e.Location.X + 15, e.Location.Y + 15, 1000);
                }
            }
        }

        private void btnSegmentarHue_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                int inicio = (int)numericUpDownInicio.Value;
                int fim = (int)numericUpDownFim.Value;

                
                Bitmap imgDest = new Bitmap(image);
                imageBitmap = (Bitmap)image;

                Filtros.SegmentarHue(imageBitmap, imgDest, matrizHSI, inicio, fim);


                pictBoxImg1.Image = imgDest;

                esticarImgH();
            }
        }

        private void ControlarBotoes(bool habilitar)
        {
            btnLimpar.Enabled = habilitar;
            btnImagemOriginal.Enabled = habilitar;
            btnLuminanciaComDMA.Enabled = habilitar;
            btnCMY.Enabled = habilitar;

            btnAumentarBrilho.Enabled = habilitar;
            btnDiminuirBrilho.Enabled = habilitar;

            btnAumentarHue.Enabled = habilitar;
            btnDiminuirHue.Enabled = habilitar;

            btnHSI.Enabled = habilitar;

            btnSegmentarHue.Enabled = habilitar;
            numericUpDownInicio.Enabled = habilitar;
            numericUpDownFim.Enabled = habilitar;

        }

    }
}
