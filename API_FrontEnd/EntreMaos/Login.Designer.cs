namespace EntreMaos
{
    partial class LoginFundo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFundo));
            this.caixaLogin = new System.Windows.Forms.PictureBox();
            this.LoginLogo = new System.Windows.Forms.PictureBox();
            this.label_entrar = new System.Windows.Forms.Label();
            this.textBox_emailLogin = new System.Windows.Forms.TextBox();
            this.textBox_senhaLogin = new System.Windows.Forms.TextBox();
            this.label_emailLogin = new System.Windows.Forms.Label();
            this.label_senhaLogin = new System.Windows.Forms.Label();
            this.botaoEntrarLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.caixaLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // caixaLogin
            // 
            this.caixaLogin.BackColor = System.Drawing.Color.Transparent;
            this.caixaLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.caixaLogin.Image = ((System.Drawing.Image)(resources.GetObject("caixaLogin.Image")));
            this.caixaLogin.Location = new System.Drawing.Point(703, 12);
            this.caixaLogin.Name = "caixaLogin";
            this.caixaLogin.Size = new System.Drawing.Size(613, 725);
            this.caixaLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caixaLogin.TabIndex = 0;
            this.caixaLogin.TabStop = false;
            // 
            // LoginLogo
            // 
            this.LoginLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.LoginLogo.Image = ((System.Drawing.Image)(resources.GetObject("LoginLogo.Image")));
            this.LoginLogo.Location = new System.Drawing.Point(828, 31);
            this.LoginLogo.Name = "LoginLogo";
            this.LoginLogo.Size = new System.Drawing.Size(376, 137);
            this.LoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoginLogo.TabIndex = 1;
            this.LoginLogo.TabStop = false;
            // 
            // label_entrar
            // 
            this.label_entrar.AutoSize = true;
            this.label_entrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label_entrar.Font = new System.Drawing.Font("Ebrima", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_entrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label_entrar.Location = new System.Drawing.Point(878, 199);
            this.label_entrar.Name = "label_entrar";
            this.label_entrar.Size = new System.Drawing.Size(260, 40);
            this.label_entrar.TabIndex = 2;
            this.label_entrar.Text = "Entrar no Sistema";
            // 
            // textBox_emailLogin
            // 
            this.textBox_emailLogin.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_emailLogin.Location = new System.Drawing.Point(744, 336);
            this.textBox_emailLogin.Name = "textBox_emailLogin";
            this.textBox_emailLogin.Size = new System.Drawing.Size(535, 36);
            this.textBox_emailLogin.TabIndex = 3;
            this.textBox_emailLogin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_senhaLogin
            // 
            this.textBox_senhaLogin.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_senhaLogin.Location = new System.Drawing.Point(744, 415);
            this.textBox_senhaLogin.Name = "textBox_senhaLogin";
            this.textBox_senhaLogin.Size = new System.Drawing.Size(535, 36);
            this.textBox_senhaLogin.TabIndex = 4;
            this.textBox_senhaLogin.UseSystemPasswordChar = true;
            // 
            // label_emailLogin
            // 
            this.label_emailLogin.AutoSize = true;
            this.label_emailLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label_emailLogin.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_emailLogin.ForeColor = System.Drawing.Color.White;
            this.label_emailLogin.Location = new System.Drawing.Point(746, 303);
            this.label_emailLogin.Name = "label_emailLogin";
            this.label_emailLogin.Size = new System.Drawing.Size(63, 30);
            this.label_emailLogin.TabIndex = 5;
            this.label_emailLogin.Text = "Email";
            // 
            // label_senhaLogin
            // 
            this.label_senhaLogin.AutoSize = true;
            this.label_senhaLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label_senhaLogin.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_senhaLogin.ForeColor = System.Drawing.Color.White;
            this.label_senhaLogin.Location = new System.Drawing.Point(739, 382);
            this.label_senhaLogin.Name = "label_senhaLogin";
            this.label_senhaLogin.Size = new System.Drawing.Size(70, 30);
            this.label_senhaLogin.TabIndex = 6;
            this.label_senhaLogin.Text = "Senha";
            // 
            // botaoEntrarLogin
            // 
            this.botaoEntrarLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(153)))), ((int)(((byte)(113)))));
            this.botaoEntrarLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botaoEntrarLogin.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoEntrarLogin.Location = new System.Drawing.Point(848, 642);
            this.botaoEntrarLogin.Name = "botaoEntrarLogin";
            this.botaoEntrarLogin.Size = new System.Drawing.Size(317, 47);
            this.botaoEntrarLogin.TabIndex = 7;
            this.botaoEntrarLogin.Text = "Entrar";
            this.botaoEntrarLogin.UseVisualStyleBackColor = false;
            this.botaoEntrarLogin.Click += new System.EventHandler(this.botaoEntrarLogin_Click);
            // 
            // LoginFundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.botaoEntrarLogin);
            this.Controls.Add(this.label_senhaLogin);
            this.Controls.Add(this.label_emailLogin);
            this.Controls.Add(this.textBox_senhaLogin);
            this.Controls.Add(this.textBox_emailLogin);
            this.Controls.Add(this.label_entrar);
            this.Controls.Add(this.LoginLogo);
            this.Controls.Add(this.caixaLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginFundo";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginFundo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.caixaLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox caixaLogin;
        private System.Windows.Forms.PictureBox LoginLogo;
        private System.Windows.Forms.Label label_entrar;
        private System.Windows.Forms.TextBox textBox_emailLogin;
        private System.Windows.Forms.TextBox textBox_senhaLogin;
        private System.Windows.Forms.Label label_emailLogin;
        private System.Windows.Forms.Label label_senhaLogin;
        private System.Windows.Forms.Button botaoEntrarLogin;
    }
}

