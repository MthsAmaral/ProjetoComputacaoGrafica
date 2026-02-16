namespace ProcessamentoImagens
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictBoxImg1 = new System.Windows.Forms.PictureBox();
            this.pictBoxImgH = new System.Windows.Forms.PictureBox();
            this.btnAbrirImagem = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLuminanciaComDMA = new System.Windows.Forms.Button();
            this.CMY = new System.Windows.Forms.Button();
            this.pictBoxImgS = new System.Windows.Forms.PictureBox();
            this.pictBoxImgI = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonHSI = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImagemOriginal = new System.Windows.Forms.Button();
            this.textBoxBrilho = new System.Windows.Forms.TextBox();
            this.btnDiminuirBrilho = new System.Windows.Forms.Button();
            this.btnAumentarBrilho = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgI)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImg1.Location = new System.Drawing.Point(25, 13);
            this.pictBoxImg1.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(660, 600);
            this.pictBoxImg1.TabIndex = 102;
            this.pictBoxImg1.TabStop = false;
            this.pictBoxImg1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictBoxImg1_MouseMove);
            // 
            // pictBoxImgH
            // 
            this.pictBoxImgH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImgH.Location = new System.Drawing.Point(43, 15);
            this.pictBoxImgH.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxImgH.Name = "pictBoxImgH";
            this.pictBoxImgH.Size = new System.Drawing.Size(300, 200);
            this.pictBoxImgH.TabIndex = 105;
            this.pictBoxImgH.TabStop = false;
            // 
            // btnAbrirImagem
            // 
            this.btnAbrirImagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirImagem.Location = new System.Drawing.Point(13, 630);
            this.btnAbrirImagem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirImagem.Name = "btnAbrirImagem";
            this.btnAbrirImagem.Size = new System.Drawing.Size(135, 28);
            this.btnAbrirImagem.TabIndex = 106;
            this.btnAbrirImagem.Text = "Abrir Imagem";
            this.btnAbrirImagem.UseVisualStyleBackColor = true;
            this.btnAbrirImagem.Click += new System.EventHandler(this.btnAbrirImagem_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(156, 630);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(69, 28);
            this.btnLimpar.TabIndex = 107;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnLuminanciaComDMA
            // 
            this.btnLuminanciaComDMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuminanciaComDMA.Location = new System.Drawing.Point(429, 630);
            this.btnLuminanciaComDMA.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuminanciaComDMA.Name = "btnLuminanciaComDMA";
            this.btnLuminanciaComDMA.Size = new System.Drawing.Size(132, 28);
            this.btnLuminanciaComDMA.TabIndex = 109;
            this.btnLuminanciaComDMA.Text = "Luminância";
            this.btnLuminanciaComDMA.UseVisualStyleBackColor = true;
            this.btnLuminanciaComDMA.Click += new System.EventHandler(this.btnLuminanciaComDMA_Click);
            // 
            // CMY
            // 
            this.CMY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMY.Location = new System.Drawing.Point(569, 630);
            this.CMY.Margin = new System.Windows.Forms.Padding(4);
            this.CMY.Name = "CMY";
            this.CMY.Size = new System.Drawing.Size(132, 28);
            this.CMY.TabIndex = 112;
            this.CMY.Text = "CMY";
            this.CMY.UseVisualStyleBackColor = true;
            this.CMY.Click += new System.EventHandler(this.CMY_Click);
            // 
            // pictBoxImgS
            // 
            this.pictBoxImgS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImgS.Location = new System.Drawing.Point(43, 237);
            this.pictBoxImgS.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxImgS.Name = "pictBoxImgS";
            this.pictBoxImgS.Size = new System.Drawing.Size(300, 200);
            this.pictBoxImgS.TabIndex = 113;
            this.pictBoxImgS.TabStop = false;
            // 
            // pictBoxImgI
            // 
            this.pictBoxImgI.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImgI.Location = new System.Drawing.Point(43, 469);
            this.pictBoxImgI.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxImgI.Name = "pictBoxImgI";
            this.pictBoxImgI.Size = new System.Drawing.Size(300, 200);
            this.pictBoxImgI.TabIndex = 114;
            this.pictBoxImgI.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.buttonHSI);
            this.panel1.Controls.Add(this.pictBoxImgI);
            this.panel1.Controls.Add(this.pictBoxImgH);
            this.panel1.Controls.Add(this.pictBoxImgS);
            this.panel1.Location = new System.Drawing.Point(762, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 726);
            this.panel1.TabIndex = 115;
            // 
            // buttonHSI
            // 
            this.buttonHSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHSI.Location = new System.Drawing.Point(134, 677);
            this.buttonHSI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHSI.Name = "buttonHSI";
            this.buttonHSI.Size = new System.Drawing.Size(132, 28);
            this.buttonHSI.TabIndex = 116;
            this.buttonHSI.Text = "HSI";
            this.buttonHSI.UseVisualStyleBackColor = true;
            this.buttonHSI.Click += new System.EventHandler(this.buttonHSI_Click);
            // 
            // btnImagemOriginal
            // 
            this.btnImagemOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImagemOriginal.Location = new System.Drawing.Point(275, 630);
            this.btnImagemOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.btnImagemOriginal.Name = "btnImagemOriginal";
            this.btnImagemOriginal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImagemOriginal.Size = new System.Drawing.Size(132, 28);
            this.btnImagemOriginal.TabIndex = 116;
            this.btnImagemOriginal.Text = "Imagem Original";
            this.btnImagemOriginal.UseVisualStyleBackColor = true;
            this.btnImagemOriginal.Click += new System.EventHandler(this.btnImagemOriginal_Click);
            // 
            // textBoxBrilho
            // 
            this.textBoxBrilho.Enabled = false;
            this.textBoxBrilho.Location = new System.Drawing.Point(77, 10);
            this.textBoxBrilho.Name = "textBoxBrilho";
            this.textBoxBrilho.Size = new System.Drawing.Size(85, 22);
            this.textBoxBrilho.TabIndex = 117;
            // 
            // btnDiminuirBrilho
            // 
            this.btnDiminuirBrilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiminuirBrilho.Location = new System.Drawing.Point(98, 38);
            this.btnDiminuirBrilho.Name = "btnDiminuirBrilho";
            this.btnDiminuirBrilho.Size = new System.Drawing.Size(49, 29);
            this.btnDiminuirBrilho.TabIndex = 118;
            this.btnDiminuirBrilho.Text = "-";
            this.btnDiminuirBrilho.UseVisualStyleBackColor = true;
            this.btnDiminuirBrilho.Click += new System.EventHandler(this.btnDiminuirBrilho_Click);
            // 
            // btnAumentarBrilho
            // 
            this.btnAumentarBrilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAumentarBrilho.Location = new System.Drawing.Point(29, 40);
            this.btnAumentarBrilho.Name = "btnAumentarBrilho";
            this.btnAumentarBrilho.Size = new System.Drawing.Size(47, 29);
            this.btnAumentarBrilho.TabIndex = 119;
            this.btnAumentarBrilho.Text = "+";
            this.btnAumentarBrilho.UseVisualStyleBackColor = true;
            this.btnAumentarBrilho.Click += new System.EventHandler(this.btnAumentarBrilho_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnAumentarBrilho);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDiminuirBrilho);
            this.panel2.Controls.Add(this.textBoxBrilho);
            this.panel2.Location = new System.Drawing.Point(331, 665);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(191, 74);
            this.panel2.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 119;
            this.label1.Text = "Brilho:";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 745);
            this.Controls.Add(this.btnImagemOriginal);
            this.Controls.Add(this.CMY);
            this.Controls.Add(this.btnLuminanciaComDMA);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAbrirImagem);
            this.Controls.Add(this.pictBoxImg1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgI)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.PictureBox pictBoxImgH;
        private System.Windows.Forms.Button btnAbrirImagem;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLuminanciaComDMA;
        private System.Windows.Forms.Button CMY;
        private System.Windows.Forms.PictureBox pictBoxImgS;
        private System.Windows.Forms.PictureBox pictBoxImgI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonHSI;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnImagemOriginal;
        private System.Windows.Forms.TextBox textBoxBrilho;
        private System.Windows.Forms.Button btnDiminuirBrilho;
        private System.Windows.Forms.Button btnAumentarBrilho;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}