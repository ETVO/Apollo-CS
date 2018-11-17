namespace Apollo
{
    partial class frmCadastroLivro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroLivro));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLivro = new System.Windows.Forms.Panel();
            this.btnFecharUser = new System.Windows.Forms.Button();
            this.btnVoltarUser = new System.Windows.Forms.Button();
            this.btnCriaAluno = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panelLivro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(343, 45);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Cadastre um Livro";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLivro
            // 
            this.panelLivro.Controls.Add(this.textBox2);
            this.panelLivro.Controls.Add(this.label2);
            this.panelLivro.Controls.Add(this.textBox1);
            this.panelLivro.Controls.Add(this.label1);
            this.panelLivro.Controls.Add(this.btnFecharUser);
            this.panelLivro.Controls.Add(this.btnVoltarUser);
            this.panelLivro.Controls.Add(this.btnCriaAluno);
            this.panelLivro.Controls.Add(this.txtSenha);
            this.panelLivro.Controls.Add(this.label7);
            this.panelLivro.Controls.Add(this.txtGenero);
            this.panelLivro.Controls.Add(this.label6);
            this.panelLivro.Controls.Add(this.txtTitulo);
            this.panelLivro.Controls.Add(this.label4);
            this.panelLivro.Controls.Add(this.txtCodigo);
            this.panelLivro.Controls.Add(this.label3);
            this.panelLivro.Location = new System.Drawing.Point(13, 60);
            this.panelLivro.Name = "panelLivro";
            this.panelLivro.Size = new System.Drawing.Size(338, 433);
            this.panelLivro.TabIndex = 18;
            // 
            // btnFecharUser
            // 
            this.btnFecharUser.Location = new System.Drawing.Point(276, 395);
            this.btnFecharUser.Name = "btnFecharUser";
            this.btnFecharUser.Size = new System.Drawing.Size(55, 26);
            this.btnFecharUser.TabIndex = 12;
            this.btnFecharUser.Text = "&Fechar";
            this.btnFecharUser.UseVisualStyleBackColor = true;
            // 
            // btnVoltarUser
            // 
            this.btnVoltarUser.Location = new System.Drawing.Point(7, 395);
            this.btnVoltarUser.Name = "btnVoltarUser";
            this.btnVoltarUser.Size = new System.Drawing.Size(55, 26);
            this.btnVoltarUser.TabIndex = 11;
            this.btnVoltarUser.Text = "&Voltar";
            this.btnVoltarUser.UseVisualStyleBackColor = true;
            // 
            // btnCriaAluno
            // 
            this.btnCriaAluno.Location = new System.Drawing.Point(83, 347);
            this.btnCriaAluno.Name = "btnCriaAluno";
            this.btnCriaAluno.Size = new System.Drawing.Size(173, 42);
            this.btnCriaAluno.TabIndex = 10;
            this.btnCriaAluno.Text = "Criar minha conta";
            this.btnCriaAluno.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(74, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 60;
            this.label7.Text = "Autor *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 58;
            this.label6.Text = "Gênero *";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(77, 84);
            this.txtTitulo.MaxLength = 7;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(185, 20);
            this.txtTitulo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Título *";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Location = new System.Drawing.Point(77, 29);
            this.txtCodigo.MaxLength = 70;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(185, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Código *";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(77, 193);
            this.txtSenha.MaxLength = 100;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(185, 20);
            this.txtSenha.TabIndex = 4;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(77, 139);
            this.txtGenero.MaxLength = 20;
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(185, 20);
            this.txtGenero.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 249);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 61;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Editora *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Ano de Publicação";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 305);
            this.textBox2.MaxLength = 100;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 20);
            this.textBox2.TabIndex = 65;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // frmCadastroLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 494);
            this.Controls.Add(this.panelLivro);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadastroLivro";
            this.Text = "Cadastre um Livro";
            this.panelLivro.ResumeLayout(false);
            this.panelLivro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLivro;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFecharUser;
        private System.Windows.Forms.Button btnVoltarUser;
        private System.Windows.Forms.Button btnCriaAluno;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
    }
}