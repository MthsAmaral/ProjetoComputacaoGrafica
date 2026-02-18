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
            this.btnCMY = new System.Windows.Forms.Button();
            this.pictBoxImgS = new System.Windows.Forms.PictureBox();
            this.pictBoxImgI = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHSI = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImagemOriginal = new System.Windows.Forms.Button();
            this.textBoxBrilho = new System.Windows.Forms.TextBox();
            this.btnDiminuirBrilho = new System.Windows.Forms.Button();
            this.btnAumentarBrilho = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAumentarHue = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDiminuirHue = new System.Windows.Forms.Button();
            this.textBoxHue = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSegmentarHue = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownFim = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInicio = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.labelHueInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgI)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImg1.Location = new System.Drawing.Point(19, 11);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(495, 488);
            this.pictBoxImg1.TabIndex = 102;
            this.pictBoxImg1.TabStop = false;
            this.pictBoxImg1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictBoxImg1_MouseMove);
            // 
            // pictBoxImgH
            // 
            this.pictBoxImgH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImgH.Location = new System.Drawing.Point(32, 12);
            this.pictBoxImgH.Name = "pictBoxImgH";
            this.pictBoxImgH.Size = new System.Drawing.Size(225, 162);
            this.pictBoxImgH.TabIndex = 105;
            this.pictBoxImgH.TabStop = false;
            // 
            // btnAbrirImagem
            // 
            this.btnAbrirImagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirImagem.Location = new System.Drawing.Point(10, 505);
            this.btnAbrirImagem.Name = "btnAbrirImagem";
            this.btnAbrirImagem.Size = new System.Drawing.Size(101, 23);
            this.btnAbrirImagem.TabIndex = 106;
            this.btnAbrirImagem.Text = "Abrir Imagem";
            this.btnAbrirImagem.UseVisualStyleBackColor = true;
            this.btnAbrirImagem.Click += new System.EventHandler(this.btnAbrirImagem_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(117, 505);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(52, 23);
            this.btnLimpar.TabIndex = 107;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnLuminanciaComDMA
            // 
            this.btnLuminanciaComDMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuminanciaComDMA.Location = new System.Drawing.Point(248, 505);
            this.btnLuminanciaComDMA.Name = "btnLuminanciaComDMA";
            this.btnLuminanciaComDMA.Size = new System.Drawing.Size(99, 23);
            this.btnLuminanciaComDMA.TabIndex = 109;
            this.btnLuminanciaComDMA.Text = "Luminância";
            this.btnLuminanciaComDMA.UseVisualStyleBackColor = true;
            this.btnLuminanciaComDMA.Click += new System.EventHandler(this.btnLuminanciaComDMA_Click);
            // 
            // btnCMY
            // 
            this.btnCMY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCMY.Location = new System.Drawing.Point(353, 505);
            this.btnCMY.Name = "btnCMY";
            this.btnCMY.Size = new System.Drawing.Size(60, 23);
            this.btnCMY.TabIndex = 112;
            this.btnCMY.Text = "CMY";
            this.btnCMY.UseVisualStyleBackColor = true;
            this.btnCMY.Click += new System.EventHandler(this.btnCMY_Click);
            // 
            // pictBoxImgS
            // 
            this.pictBoxImgS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImgS.Location = new System.Drawing.Point(32, 193);
            this.pictBoxImgS.Name = "pictBoxImgS";
            this.pictBoxImgS.Size = new System.Drawing.Size(225, 162);
            this.pictBoxImgS.TabIndex = 113;
            this.pictBoxImgS.TabStop = false;
            // 
            // pictBoxImgI
            // 
            this.pictBoxImgI.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImgI.Location = new System.Drawing.Point(32, 381);
            this.pictBoxImgI.Name = "pictBoxImgI";
            this.pictBoxImgI.Size = new System.Drawing.Size(225, 162);
            this.pictBoxImgI.TabIndex = 114;
            this.pictBoxImgI.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnHSI);
            this.panel1.Controls.Add(this.pictBoxImgI);
            this.panel1.Controls.Add(this.pictBoxImgH);
            this.panel1.Controls.Add(this.pictBoxImgS);
            this.panel1.Location = new System.Drawing.Point(572, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 590);
            this.panel1.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 381);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 122;
            this.label4.Text = "I:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 121;
            this.label3.Text = "S:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "H:";
            // 
            // btnHSI
            // 
            this.btnHSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHSI.Location = new System.Drawing.Point(100, 550);
            this.btnHSI.Name = "btnHSI";
            this.btnHSI.Size = new System.Drawing.Size(99, 23);
            this.btnHSI.TabIndex = 116;
            this.btnHSI.Text = "HSI";
            this.btnHSI.UseVisualStyleBackColor = true;
            this.btnHSI.Click += new System.EventHandler(this.btnHSI_Click);
            // 
            // btnImagemOriginal
            // 
            this.btnImagemOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImagemOriginal.Location = new System.Drawing.Point(10, 548);
            this.btnImagemOriginal.Name = "btnImagemOriginal";
            this.btnImagemOriginal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImagemOriginal.Size = new System.Drawing.Size(61, 52);
            this.btnImagemOriginal.TabIndex = 116;
            this.btnImagemOriginal.Text = "Imagem Original";
            this.btnImagemOriginal.UseVisualStyleBackColor = true;
            this.btnImagemOriginal.Click += new System.EventHandler(this.btnImagemOriginal_Click);
            // 
            // textBoxBrilho
            // 
            this.textBoxBrilho.Enabled = false;
            this.textBoxBrilho.Location = new System.Drawing.Point(74, 4);
            this.textBoxBrilho.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBrilho.Name = "textBoxBrilho";
            this.textBoxBrilho.Size = new System.Drawing.Size(47, 20);
            this.textBoxBrilho.TabIndex = 117;
            // 
            // btnDiminuirBrilho
            // 
            this.btnDiminuirBrilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiminuirBrilho.Location = new System.Drawing.Point(84, 33);
            this.btnDiminuirBrilho.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiminuirBrilho.Name = "btnDiminuirBrilho";
            this.btnDiminuirBrilho.Size = new System.Drawing.Size(37, 24);
            this.btnDiminuirBrilho.TabIndex = 118;
            this.btnDiminuirBrilho.Text = "-";
            this.btnDiminuirBrilho.UseVisualStyleBackColor = true;
            this.btnDiminuirBrilho.Click += new System.EventHandler(this.btnDiminuirBrilho_Click);
            // 
            // btnAumentarBrilho
            // 
            this.btnAumentarBrilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAumentarBrilho.Location = new System.Drawing.Point(20, 33);
            this.btnAumentarBrilho.Margin = new System.Windows.Forms.Padding(2);
            this.btnAumentarBrilho.Name = "btnAumentarBrilho";
            this.btnAumentarBrilho.Size = new System.Drawing.Size(35, 24);
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
            this.panel2.Location = new System.Drawing.Point(248, 533);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(143, 67);
            this.panel2.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Brilho[0,1]:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAumentarHue);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnDiminuirHue);
            this.panel3.Controls.Add(this.textBoxHue);
            this.panel3.Location = new System.Drawing.Point(405, 533);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(143, 67);
            this.panel3.TabIndex = 121;
            // 
            // btnAumentarHue
            // 
            this.btnAumentarHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAumentarHue.Location = new System.Drawing.Point(22, 32);
            this.btnAumentarHue.Margin = new System.Windows.Forms.Padding(2);
            this.btnAumentarHue.Name = "btnAumentarHue";
            this.btnAumentarHue.Size = new System.Drawing.Size(35, 24);
            this.btnAumentarHue.TabIndex = 119;
            this.btnAumentarHue.Text = "+";
            this.btnAumentarHue.UseVisualStyleBackColor = true;
            this.btnAumentarHue.Click += new System.EventHandler(this.btnAumentarHue_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 119;
            this.label5.Text = "Matiz/Hue:";
            // 
            // btnDiminuirHue
            // 
            this.btnDiminuirHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiminuirHue.Location = new System.Drawing.Point(87, 32);
            this.btnDiminuirHue.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiminuirHue.Name = "btnDiminuirHue";
            this.btnDiminuirHue.Size = new System.Drawing.Size(37, 24);
            this.btnDiminuirHue.TabIndex = 118;
            this.btnDiminuirHue.Text = "-";
            this.btnDiminuirHue.UseVisualStyleBackColor = true;
            this.btnDiminuirHue.Click += new System.EventHandler(this.btnDiminuirHue_Click);
            // 
            // textBoxHue
            // 
            this.textBoxHue.Enabled = false;
            this.textBoxHue.Location = new System.Drawing.Point(81, 4);
            this.textBoxHue.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxHue.Name = "textBoxHue";
            this.textBoxHue.Size = new System.Drawing.Size(43, 20);
            this.textBoxHue.TabIndex = 117;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Controls.Add(this.btnSegmentarHue);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.numericUpDownFim);
            this.panel4.Controls.Add(this.numericUpDownInicio);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.labelHueInfo);
            this.panel4.Location = new System.Drawing.Point(89, 533);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(155, 68);
            this.panel4.TabIndex = 121;
            // 
            // btnSegmentarHue
            // 
            this.btnSegmentarHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSegmentarHue.Location = new System.Drawing.Point(96, 21);
            this.btnSegmentarHue.Name = "btnSegmentarHue";
            this.btnSegmentarHue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSegmentarHue.Size = new System.Drawing.Size(54, 33);
            this.btnSegmentarHue.TabIndex = 123;
            this.btnSegmentarHue.Text = "Aplicar";
            this.btnSegmentarHue.UseVisualStyleBackColor = true;
            this.btnSegmentarHue.Click += new System.EventHandler(this.btnSegmentarHue_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 123;
            this.label8.Text = "Fim:";
            // 
            // numericUpDownFim
            // 
            this.numericUpDownFim.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownFim.Location = new System.Drawing.Point(43, 42);
            this.numericUpDownFim.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownFim.Name = "numericUpDownFim";
            this.numericUpDownFim.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownFim.TabIndex = 122;
            // 
            // numericUpDownInicio
            // 
            this.numericUpDownInicio.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownInicio.Location = new System.Drawing.Point(43, 19);
            this.numericUpDownInicio.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownInicio.Name = "numericUpDownInicio";
            this.numericUpDownInicio.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownInicio.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "Inicio: ";
            // 
            // labelHueInfo
            // 
            this.labelHueInfo.AutoSize = true;
            this.labelHueInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHueInfo.Location = new System.Drawing.Point(4, 5);
            this.labelHueInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHueInfo.Name = "labelHueInfo";
            this.labelHueInfo.Size = new System.Drawing.Size(151, 13);
            this.labelHueInfo.TabIndex = 119;
            this.labelHueInfo.Text = "Segmentar Hue 0° a 360°";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 605);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnImagemOriginal);
            this.Controls.Add(this.btnCMY);
            this.Controls.Add(this.btnLuminanciaComDMA);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAbrirImagem);
            this.Controls.Add(this.pictBoxImg1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImgI)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.PictureBox pictBoxImgH;
        private System.Windows.Forms.Button btnAbrirImagem;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLuminanciaComDMA;
        private System.Windows.Forms.Button btnCMY;
        private System.Windows.Forms.PictureBox pictBoxImgS;
        private System.Windows.Forms.PictureBox pictBoxImgI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHSI;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnImagemOriginal;
        private System.Windows.Forms.TextBox textBoxBrilho;
        private System.Windows.Forms.Button btnDiminuirBrilho;
        private System.Windows.Forms.Button btnAumentarBrilho;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAumentarHue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDiminuirHue;
        private System.Windows.Forms.TextBox textBoxHue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelHueInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownFim;
        private System.Windows.Forms.Button btnSegmentarHue;
    }
}