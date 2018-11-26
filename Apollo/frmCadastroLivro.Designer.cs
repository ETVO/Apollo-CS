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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroLivro));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLivro = new System.Windows.Forms.Panel();
            this.txtAnoPublicacao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkCadastroEditora = new System.Windows.Forms.LinkLabel();
            this.linkCadastroAutor = new System.Windows.Forms.LinkLabel();
            this.linkCadastroGenero = new System.Windows.Forms.LinkLabel();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.txtEditora = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.cmbEditora = new System.Windows.Forms.ComboBox();
            this.cmbAutor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnCria = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddAutor = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.listAutores = new System.Windows.Forms.ListBox();
            this.btnExcluiAutor = new System.Windows.Forms.Button();
            this.btnExcluiTodos = new System.Windows.Forms.Button();
            this.panelLivro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 45);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Cadastre um Livro";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLivro
            // 
            this.panelLivro.Controls.Add(this.btnExcluiTodos);
            this.panelLivro.Controls.Add(this.btnExcluiAutor);
            this.panelLivro.Controls.Add(this.listAutores);
            this.panelLivro.Controls.Add(this.btnAddAutor);
            this.panelLivro.Controls.Add(this.txtAnoPublicacao);
            this.panelLivro.Controls.Add(this.txtCodigo);
            this.panelLivro.Controls.Add(this.label3);
            this.panelLivro.Controls.Add(this.linkCadastroEditora);
            this.panelLivro.Controls.Add(this.linkCadastroAutor);
            this.panelLivro.Controls.Add(this.linkCadastroGenero);
            this.panelLivro.Controls.Add(this.txtGenero);
            this.panelLivro.Controls.Add(this.cmbGenero);
            this.panelLivro.Controls.Add(this.txtEditora);
            this.panelLivro.Controls.Add(this.txtAutor);
            this.panelLivro.Controls.Add(this.cmbEditora);
            this.panelLivro.Controls.Add(this.cmbAutor);
            this.panelLivro.Controls.Add(this.label2);
            this.panelLivro.Controls.Add(this.label1);
            this.panelLivro.Controls.Add(this.btnFechar);
            this.panelLivro.Controls.Add(this.btnVoltar);
            this.panelLivro.Controls.Add(this.btnCria);
            this.panelLivro.Controls.Add(this.label7);
            this.panelLivro.Controls.Add(this.label6);
            this.panelLivro.Controls.Add(this.txtTitulo);
            this.panelLivro.Controls.Add(this.label4);
            this.panelLivro.Location = new System.Drawing.Point(13, 73);
            this.panelLivro.Name = "panelLivro";
            this.panelLivro.Size = new System.Drawing.Size(338, 526);
            this.panelLivro.TabIndex = 18;
            // 
            // txtAnoPublicacao
            // 
            this.txtAnoPublicacao.Location = new System.Drawing.Point(81, 348);
            this.txtAnoPublicacao.MaxLength = 9;
            this.txtAnoPublicacao.Name = "txtAnoPublicacao";
            this.txtAnoPublicacao.Size = new System.Drawing.Size(185, 20);
            this.txtAnoPublicacao.TabIndex = 5;
            this.txtAnoPublicacao.TextChanged += new System.EventHandler(this.txtAnoPublicacao_TextChanged_1);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(81, 402);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(185, 20);
            this.txtCodigo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "Código *";
            // 
            // linkCadastroEditora
            // 
            this.linkCadastroEditora.AutoSize = true;
            this.linkCadastroEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCadastroEditora.Location = new System.Drawing.Point(214, 274);
            this.linkCadastroEditora.Name = "linkCadastroEditora";
            this.linkCadastroEditora.Size = new System.Drawing.Size(52, 13);
            this.linkCadastroEditora.TabIndex = 8;
            this.linkCadastroEditora.TabStop = true;
            this.linkCadastroEditora.Text = "Cadastrar";
            this.linkCadastroEditora.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCadastroEditora_LinkClicked);
            // 
            // linkCadastroAutor
            // 
            this.linkCadastroAutor.AutoSize = true;
            this.linkCadastroAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCadastroAutor.Location = new System.Drawing.Point(183, 113);
            this.linkCadastroAutor.Name = "linkCadastroAutor";
            this.linkCadastroAutor.Size = new System.Drawing.Size(52, 13);
            this.linkCadastroAutor.TabIndex = 3;
            this.linkCadastroAutor.TabStop = true;
            this.linkCadastroAutor.Text = "Cadastrar";
            this.linkCadastroAutor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCadastroAutor_LinkClicked);
            // 
            // linkCadastroGenero
            // 
            this.linkCadastroGenero.AutoSize = true;
            this.linkCadastroGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCadastroGenero.Location = new System.Drawing.Point(214, 59);
            this.linkCadastroGenero.Name = "linkCadastroGenero";
            this.linkCadastroGenero.Size = new System.Drawing.Size(52, 13);
            this.linkCadastroGenero.TabIndex = 2;
            this.linkCadastroGenero.TabStop = true;
            this.linkCadastroGenero.Text = "Cadastrar";
            this.linkCadastroGenero.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCadastroGenero_LinkClicked);
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(61, 77);
            this.txtGenero.MaxLength = 100;
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(14, 20);
            this.txtGenero.TabIndex = 71;
            this.txtGenero.Visible = false;
            this.txtGenero.TextChanged += new System.EventHandler(this.txtGenero_TextChanged);
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(81, 77);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(185, 21);
            this.cmbGenero.TabIndex = 2;
            this.cmbGenero.SelectedIndexChanged += new System.EventHandler(this.cmbGenero_SelectedIndexChanged);
            // 
            // txtEditora
            // 
            this.txtEditora.Location = new System.Drawing.Point(61, 292);
            this.txtEditora.MaxLength = 100;
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.Size = new System.Drawing.Size(14, 20);
            this.txtEditora.TabIndex = 69;
            this.txtEditora.Visible = false;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(61, 131);
            this.txtAutor.MaxLength = 100;
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(14, 20);
            this.txtAutor.TabIndex = 68;
            this.txtAutor.Visible = false;
            // 
            // cmbEditora
            // 
            this.cmbEditora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEditora.FormattingEnabled = true;
            this.cmbEditora.Location = new System.Drawing.Point(81, 292);
            this.cmbEditora.Name = "cmbEditora";
            this.cmbEditora.Size = new System.Drawing.Size(185, 21);
            this.cmbEditora.TabIndex = 8;
            this.cmbEditora.SelectedIndexChanged += new System.EventHandler(this.cmbEditora_SelectedIndexChanged);
            // 
            // cmbAutor
            // 
            this.cmbAutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAutor.FormattingEnabled = true;
            this.cmbAutor.Location = new System.Drawing.Point(81, 131);
            this.cmbAutor.Name = "cmbAutor";
            this.cmbAutor.Size = new System.Drawing.Size(154, 21);
            this.cmbAutor.TabIndex = 3;
            this.cmbAutor.SelectedIndexChanged += new System.EventHandler(this.cmbAutor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Ano de Publicação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Editora *";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(276, 489);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(55, 26);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(7, 489);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 26);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnCria
            // 
            this.btnCria.Location = new System.Drawing.Point(82, 437);
            this.btnCria.Name = "btnCria";
            this.btnCria.Size = new System.Drawing.Size(173, 42);
            this.btnCria.TabIndex = 11;
            this.btnCria.Text = "Cadastrar Livro";
            this.btnCria.UseVisualStyleBackColor = true;
            this.btnCria.Click += new System.EventHandler(this.btnCria_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(78, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 60;
            this.label7.Text = "Autor(es) *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 58;
            this.label6.Text = "Gênero *";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(81, 22);
            this.txtTitulo.MaxLength = 100;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(185, 20);
            this.txtTitulo.TabIndex = 1;
            this.txtTitulo.Enter += new System.EventHandler(this.txtTitulo_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Título *";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(13, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(338, 16);
            this.label5.TabIndex = 64;
            this.label5.Text = "* campos que devem ser preenchidos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddAutor
            // 
            this.btnAddAutor.Location = new System.Drawing.Point(241, 131);
            this.btnAddAutor.Name = "btnAddAutor";
            this.btnAddAutor.Size = new System.Drawing.Size(25, 21);
            this.btnAddAutor.TabIndex = 4;
            this.btnAddAutor.Text = "+";
            this.btnAddAutor.UseVisualStyleBackColor = true;
            this.btnAddAutor.Click += new System.EventHandler(this.btnAddAutor_Click);
            // 
            // listAutores
            // 
            this.listAutores.FormattingEnabled = true;
            this.listAutores.Location = new System.Drawing.Point(81, 158);
            this.listAutores.Name = "listAutores";
            this.listAutores.Size = new System.Drawing.Size(185, 82);
            this.listAutores.TabIndex = 5;
            // 
            // btnExcluiAutor
            // 
            this.btnExcluiAutor.Location = new System.Drawing.Point(81, 242);
            this.btnExcluiAutor.Name = "btnExcluiAutor";
            this.btnExcluiAutor.Size = new System.Drawing.Size(87, 21);
            this.btnExcluiAutor.TabIndex = 6;
            this.btnExcluiAutor.Text = "Excluir Autor";
            this.btnExcluiAutor.UseVisualStyleBackColor = true;
            this.btnExcluiAutor.Click += new System.EventHandler(this.btnExcluiAutor_Click);
            // 
            // btnExcluiTodos
            // 
            this.btnExcluiTodos.Location = new System.Drawing.Point(174, 242);
            this.btnExcluiTodos.Name = "btnExcluiTodos";
            this.btnExcluiTodos.Size = new System.Drawing.Size(92, 21);
            this.btnExcluiTodos.TabIndex = 7;
            this.btnExcluiTodos.Text = "Excluir Todos";
            this.btnExcluiTodos.UseVisualStyleBackColor = true;
            this.btnExcluiTodos.Click += new System.EventHandler(this.btnExcluiTodos_Click);
            // 
            // frmCadastroLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 599);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelLivro);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadastroLivro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastre um Livro";
            this.Load += new System.EventHandler(this.frmCadastroLivro_Load);
            this.panelLivro.ResumeLayout(false);
            this.panelLivro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLivro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnCria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEditora;
        private System.Windows.Forms.ComboBox cmbAutor;
        private System.Windows.Forms.TextBox txtEditora;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.LinkLabel linkCadastroEditora;
        private System.Windows.Forms.LinkLabel linkCadastroAutor;
        private System.Windows.Forms.LinkLabel linkCadastroGenero;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnoPublicacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddAutor;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnExcluiTodos;
        private System.Windows.Forms.Button btnExcluiAutor;
        private System.Windows.Forms.ListBox listAutores;
    }
}