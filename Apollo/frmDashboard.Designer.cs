namespace Apollo
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLivros = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabEmprestimos = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnDashboardAdm = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabLivros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabLivros);
            this.tabControl.Controls.Add(this.tabEmprestimos);
            this.tabControl.Location = new System.Drawing.Point(15, 81);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(689, 386);
            this.tabControl.TabIndex = 23;
            // 
            // tabLivros
            // 
            this.tabLivros.Controls.Add(this.dataGridView1);
            this.tabLivros.Location = new System.Drawing.Point(4, 22);
            this.tabLivros.Name = "tabLivros";
            this.tabLivros.Padding = new System.Windows.Forms.Padding(3);
            this.tabLivros.Size = new System.Drawing.Size(681, 360);
            this.tabLivros.TabIndex = 0;
            this.tabLivros.Text = "Livros";
            this.tabLivros.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(674, 269);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabEmprestimos
            // 
            this.tabEmprestimos.Location = new System.Drawing.Point(4, 22);
            this.tabEmprestimos.Name = "tabEmprestimos";
            this.tabEmprestimos.Size = new System.Drawing.Size(681, 360);
            this.tabEmprestimos.TabIndex = 2;
            this.tabEmprestimos.Text = "Empréstimos";
            this.tabEmprestimos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(495, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 46);
            this.label2.TabIndex = 22;
            this.label2.Text = "Biblioteca";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(12, 29);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 26);
            this.btnVoltar.TabIndex = 21;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(12, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(45, 17);
            this.lblNome.TabIndex = 19;
            this.lblNome.Text = "Nome";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(649, 474);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(55, 26);
            this.btnFechar.TabIndex = 24;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnDashboardAdm
            // 
            this.btnDashboardAdm.Location = new System.Drawing.Point(73, 29);
            this.btnDashboardAdm.Name = "btnDashboardAdm";
            this.btnDashboardAdm.Size = new System.Drawing.Size(81, 26);
            this.btnDashboardAdm.TabIndex = 28;
            this.btnDashboardAdm.Text = "Administração";
            this.btnDashboardAdm.UseVisualStyleBackColor = true;
            this.btnDashboardAdm.Visible = false;
            this.btnDashboardAdm.Click += new System.EventHandler(this.btnDashboardAdm_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 512);
            this.Controls.Add(this.btnDashboardAdm);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apollo - Panorama da Biblioteca";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.tabControl.ResumeLayout(false);
            this.tabLivros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLivros;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabEmprestimos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnDashboardAdm;
    }
}