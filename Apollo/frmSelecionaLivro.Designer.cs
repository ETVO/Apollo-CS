namespace Apollo
{
    partial class frmSelecionaLivro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionaLivro));
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.dgvLivro = new System.Windows.Forms.DataGridView();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(687, 82);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(121, 32);
            this.btnSelecionar.TabIndex = 67;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = System.Drawing.Color.White;
            this.txtPesquisa.Location = new System.Drawing.Point(14, 89);
            this.txtPesquisa.MaxLength = 70;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(540, 20);
            this.txtPesquisa.TabIndex = 58;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "Pesquisar";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(753, 497);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(55, 26);
            this.btnFechar.TabIndex = 64;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(14, 497);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 26);
            this.btnVoltar.TabIndex = 63;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click_1);
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Location = new System.Drawing.Point(560, 82);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(121, 32);
            this.btnRecarregar.TabIndex = 61;
            this.btnRecarregar.Text = "Atualizar";
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // dgvLivro
            // 
            this.dgvLivro.AllowUserToAddRows = false;
            this.dgvLivro.AllowUserToDeleteRows = false;
            this.dgvLivro.AllowUserToResizeRows = false;
            this.dgvLivro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLivro.Location = new System.Drawing.Point(14, 120);
            this.dgvLivro.MultiSelect = false;
            this.dgvLivro.Name = "dgvLivro";
            this.dgvLivro.RowHeadersVisible = false;
            this.dgvLivro.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLivro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLivro.ShowCellErrors = false;
            this.dgvLivro.ShowCellToolTips = false;
            this.dgvLivro.ShowEditingIcon = false;
            this.dgvLivro.ShowRowErrors = false;
            this.dgvLivro.Size = new System.Drawing.Size(794, 371);
            this.dgvLivro.StandardTab = true;
            this.dgvLivro.TabIndex = 62;
            this.dgvLivro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivro_CellContentClick);
            this.dgvLivro.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivro_CellDoubleClick);
            this.dgvLivro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvLivro_KeyPress);
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(14, 45);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(794, 30);
            this.lblDesc.TabIndex = 65;
            this.lblDesc.Text = "Clique duas vezes para selecionar o livro que o usuário emprestará";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(14, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(794, 45);
            this.lblTitle.TabIndex = 59;
            this.lblTitle.Text = "Qual livro?";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSelecionaLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 533);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnRecarregar);
            this.Controls.Add(this.dgvLivro);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSelecionaLivro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empréstimo";
            this.Load += new System.EventHandler(this.frmEmprestimoSelecionaLivro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnRecarregar;
        private System.Windows.Forms.DataGridView dgvLivro;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblTitle;
    }
}