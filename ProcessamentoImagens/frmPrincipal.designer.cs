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
            this.pictBoxImg1 = new System.Windows.Forms.PictureBox();
            this.pictBoxImgH = new System.Windows.Forms.PictureBox();
            this.btnAbrirImagem = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLuminanciaComDMA = new System.Windows.Forms.Button();
            this.CMY = new System.Windows.Forms.Button();
            this.pictBoxImgS = new System.Windows.Forms.PictureBox();
            this.pictBoImgI = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonHSI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoImgI)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImg1.Location = new System.Drawing.Point(13, 13);
            this.pictBoxImg1.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(660, 600);
            this.pictBoxImg1.TabIndex = 102;
            this.pictBoxImg1.TabStop = false;
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
            // pictBoImgI
            // 
            this.pictBoImgI.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoImgI.Location = new System.Drawing.Point(43, 469);
            this.pictBoImgI.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoImgI.Name = "pictBoImgI";
            this.pictBoImgI.Size = new System.Drawing.Size(300, 200);
            this.pictBoImgI.TabIndex = 114;
            this.pictBoImgI.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonHSI);
            this.panel1.Controls.Add(this.pictBoImgI);
            this.panel1.Controls.Add(this.pictBoxImgH);
            this.panel1.Controls.Add(this.pictBoxImgS);
            this.panel1.Location = new System.Drawing.Point(762, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 726);
            this.panel1.TabIndex = 115;
            // 
            // buttonHSI
            // 
            this.buttonHSI.Location = new System.Drawing.Point(134, 677);
            this.buttonHSI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHSI.Name = "buttonHSI";
            this.buttonHSI.Size = new System.Drawing.Size(132, 28);
            this.buttonHSI.TabIndex = 116;
            this.buttonHSI.Text = "HSI";
            this.buttonHSI.UseVisualStyleBackColor = true;
            this.buttonHSI.Click += new System.EventHandler(this.buttonHSI_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 745);
            this.Controls.Add(this.CMY);
            this.Controls.Add(this.btnLuminanciaComDMA);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAbrirImagem);
            this.Controls.Add(this.pictBoxImg1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoImgI)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictBoImgI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonHSI;
    }
}

