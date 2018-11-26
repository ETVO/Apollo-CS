namespace Apollo
{
    partial class frmAtraso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtraso));
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblMulta = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblDias = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.panelPadrao = new System.Windows.Forms.Panel();
            this.btnRenovar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOp = new System.Windows.Forms.Panel();
            this.lblOp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJustificativa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radNao = new System.Windows.Forms.RadioButton();
            this.radSim = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panelPadrao.SuspendLayout();
            this.panelOp.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(272, 565);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(55, 26);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 114);
            this.panel1.TabIndex = 122;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel13.Controls.Add(this.lblMulta);
            this.panel13.Location = new System.Drawing.Point(40, 78);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(238, 24);
            this.panel13.TabIndex = 196;
            // 
            // lblMulta
            // 
            this.lblMulta.AutoEllipsis = true;
            this.lblMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMulta.Location = new System.Drawing.Point(3, 0);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(285, 25);
            this.lblMulta.TabIndex = 91;
            this.lblMulta.Text = "R$0,00";
            this.lblMulta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(37, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 15);
            this.label13.TabIndex = 195;
            this.label13.Text = "Multa";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel12.Controls.Add(this.lblDias);
            this.panel12.Location = new System.Drawing.Point(40, 30);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(238, 24);
            this.panel12.TabIndex = 194;
            // 
            // lblDias
            // 
            this.lblDias.AutoEllipsis = true;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.Location = new System.Drawing.Point(3, 0);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(285, 25);
            this.lblDias.TabIndex = 91;
            this.lblDias.Text = "Dias de Atraso";
            this.lblDias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(37, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 15);
            this.label11.TabIndex = 193;
            this.label11.Text = "Dias de Atraso";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(315, 45);
            this.lblTitle.TabIndex = 105;
            this.lblTitle.Text = "Atrasado :(";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(12, 44);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(315, 30);
            this.lblDesc.TabIndex = 106;
            this.lblDesc.Text = "Este empréstimo está atrasado";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPadrao
            // 
            this.panelPadrao.Controls.Add(this.btnRenovar);
            this.panelPadrao.Controls.Add(this.btnDevolver);
            this.panelPadrao.Controls.Add(this.label1);
            this.panelPadrao.Location = new System.Drawing.Point(12, 195);
            this.panelPadrao.Name = "panelPadrao";
            this.panelPadrao.Size = new System.Drawing.Size(315, 117);
            this.panelPadrao.TabIndex = 1;
            // 
            // btnRenovar
            // 
            this.btnRenovar.Location = new System.Drawing.Point(17, 51);
            this.btnRenovar.Name = "btnRenovar";
            this.btnRenovar.Size = new System.Drawing.Size(134, 42);
            this.btnRenovar.TabIndex = 122;
            this.btnRenovar.Text = "Renovar";
            this.btnRenovar.UseVisualStyleBackColor = true;
            this.btnRenovar.Click += new System.EventHandler(this.btnRenovar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(163, 51);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(134, 42);
            this.btnDevolver.TabIndex = 123;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 30);
            this.label1.TabIndex = 121;
            this.label1.Text = "Escolha uma das opções";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelOp
            // 
            this.panelOp.Controls.Add(this.lblOp);
            this.panelOp.Controls.Add(this.label7);
            this.panelOp.Controls.Add(this.txtJustificativa);
            this.panelOp.Controls.Add(this.label6);
            this.panelOp.Controls.Add(this.panel3);
            this.panelOp.Controls.Add(this.label5);
            this.panelOp.Controls.Add(this.btnAutorizar);
            this.panelOp.Controls.Add(this.txtSenha);
            this.panelOp.Controls.Add(this.label4);
            this.panelOp.Controls.Add(this.txtUser);
            this.panelOp.Controls.Add(this.label3);
            this.panelOp.Location = new System.Drawing.Point(12, 195);
            this.panelOp.Name = "panelOp";
            this.panelOp.Size = new System.Drawing.Size(315, 359);
            this.panelOp.TabIndex = 1;
            // 
            // lblOp
            // 
            this.lblOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOp.Location = new System.Drawing.Point(65, 6);
            this.lblOp.Name = "lblOp";
            this.lblOp.Size = new System.Drawing.Size(185, 45);
            this.lblOp.TabIndex = 228;
            this.lblOp.Text = "Renovação";
            this.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 17);
            this.label7.TabIndex = 227;
            this.label7.Text = "A multa será paga?";
            // 
            // txtJustificativa
            // 
            this.txtJustificativa.AcceptsReturn = true;
            this.txtJustificativa.Location = new System.Drawing.Point(34, 132);
            this.txtJustificativa.MaxLength = 400;
            this.txtJustificativa.Multiline = true;
            this.txtJustificativa.Name = "txtJustificativa";
            this.txtJustificativa.Size = new System.Drawing.Size(238, 38);
            this.txtJustificativa.TabIndex = 219;
            this.txtJustificativa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJustificativa_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 17);
            this.label6.TabIndex = 226;
            this.label6.Text = "Justificativa do Atraso";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radNao);
            this.panel3.Controls.Add(this.radSim);
            this.panel3.Location = new System.Drawing.Point(34, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 29);
            this.panel3.TabIndex = 218;
            // 
            // radNao
            // 
            this.radNao.AutoSize = true;
            this.radNao.Location = new System.Drawing.Point(130, 6);
            this.radNao.Name = "radNao";
            this.radNao.Size = new System.Drawing.Size(45, 17);
            this.radNao.TabIndex = 2;
            this.radNao.Text = "Não";
            this.radNao.UseVisualStyleBackColor = true;
            // 
            // radSim
            // 
            this.radSim.AutoSize = true;
            this.radSim.Checked = true;
            this.radSim.Location = new System.Drawing.Point(61, 6);
            this.radSim.Name = "radSim";
            this.radSim.Size = new System.Drawing.Size(42, 17);
            this.radSim.TabIndex = 1;
            this.radSim.TabStop = true;
            this.radSim.Text = "Sim";
            this.radSim.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 225;
            this.label5.Text = "Administrador";
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Location = new System.Drawing.Point(61, 318);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(185, 38);
            this.btnAutorizar.TabIndex = 222;
            this.btnAutorizar.Text = "Autorizar Renovação";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(34, 283);
            this.txtSenha.MaxLength = 100;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(238, 20);
            this.txtSenha.TabIndex = 221;
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 224;
            this.label4.Text = "Senha";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(34, 231);
            this.txtUser.MaxLength = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(238, 20);
            this.txtUser.TabIndex = 220;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 223;
            this.label3.Text = "RA ou Login";
            // 
            // frmAtraso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 603);
            this.Controls.Add(this.panelOp);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPadrao);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAtraso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empréstimo Atrasado";
            this.Load += new System.EventHandler(this.frmAtraso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panelPadrao.ResumeLayout(false);
            this.panelOp.ResumeLayout(false);
            this.panelOp.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Panel panelPadrao;
        private System.Windows.Forms.Panel panelOp;
        private System.Windows.Forms.Button btnRenovar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtJustificativa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radNao;
        private System.Windows.Forms.RadioButton radSim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label label11;
    }
}