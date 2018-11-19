namespace Apollo
{
    partial class frmCadastroAutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroAutor));
            this.panelGenero = new System.Windows.Forms.Panel();
            this.txtDataNasc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCria = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelGenero.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGenero
            // 
            this.panelGenero.Controls.Add(this.txtDataNasc);
            this.panelGenero.Controls.Add(this.label1);
            this.panelGenero.Controls.Add(this.btnFechar);
            this.panelGenero.Controls.Add(this.btnCria);
            this.panelGenero.Controls.Add(this.txtNome);
            this.panelGenero.Controls.Add(this.label3);
            this.panelGenero.Location = new System.Drawing.Point(12, 72);
            this.panelGenero.Name = "panelGenero";
            this.panelGenero.Size = new System.Drawing.Size(339, 201);
            this.panelGenero.TabIndex = 21;
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.BackColor = System.Drawing.Color.White;
            this.txtDataNasc.Location = new System.Drawing.Point(77, 81);
            this.txtDataNasc.MaxLength = 12;
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(185, 20);
            this.txtDataNasc.TabIndex = 2;
            this.txtDataNasc.TextChanged += new System.EventHandler(this.txtDataNasc_TextChanged);
            this.txtDataNasc.Enter += new System.EventHandler(this.txtDataNasc_Enter);
            this.txtDataNasc.Leave += new System.EventHandler(this.txtDataNasc_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Ano de Nascimento";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(276, 165);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(55, 26);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCria
            // 
            this.btnCria.Location = new System.Drawing.Point(83, 117);
            this.btnCria.Name = "btnCria";
            this.btnCria.Size = new System.Drawing.Size(173, 42);
            this.btnCria.TabIndex = 3;
            this.btnCria.Text = "Cadastrar Autor";
            this.btnCria.UseVisualStyleBackColor = true;
            this.btnCria.Click += new System.EventHandler(this.btnCria_Click);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(77, 29);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(185, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Nome *";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 45);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Cadastre um Autor";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(13, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(338, 16);
            this.label5.TabIndex = 63;
            this.label5.Text = "* campos que devem ser preenchidos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCadastroAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 272);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelGenero);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadastroAutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCadastroAutor_Load);
            this.panelGenero.ResumeLayout(false);
            this.panelGenero.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGenero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCria;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtDataNasc;
        private System.Windows.Forms.Label label5;
    }
}