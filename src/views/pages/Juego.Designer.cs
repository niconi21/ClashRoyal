namespace ClashRoyal.src.views.pages
{
    partial class Juego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            this.panel_cargar_jugador = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar5 = new System.Windows.Forms.ProgressBar();
            this.progressBar6 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_cargar_jugador
            // 
            this.panel_cargar_jugador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_cargar_jugador.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_cargar_jugador.Location = new System.Drawing.Point(0, 0);
            this.panel_cargar_jugador.Name = "panel_cargar_jugador";
            this.panel_cargar_jugador.Size = new System.Drawing.Size(108, 605);
            this.panel_cargar_jugador.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(166, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(549, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 605);
            this.panel1.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(219, 141);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(51, 12);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 100;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(386, 141);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(51, 12);
            this.progressBar2.TabIndex = 5;
            this.progressBar2.Value = 100;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(303, 76);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(56, 19);
            this.progressBar3.TabIndex = 6;
            this.progressBar3.Value = 100;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(303, 509);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(56, 19);
            this.progressBar4.TabIndex = 7;
            this.progressBar4.Value = 100;
            // 
            // progressBar5
            // 
            this.progressBar5.Location = new System.Drawing.Point(219, 469);
            this.progressBar5.Name = "progressBar5";
            this.progressBar5.Size = new System.Drawing.Size(51, 12);
            this.progressBar5.TabIndex = 8;
            this.progressBar5.Value = 100;
            // 
            // progressBar6
            // 
            this.progressBar6.Location = new System.Drawing.Point(386, 469);
            this.progressBar6.Name = "progressBar6";
            this.progressBar6.Size = new System.Drawing.Size(51, 12);
            this.progressBar6.TabIndex = 9;
            this.progressBar6.Value = 100;
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(657, 605);
            this.Controls.Add(this.progressBar6);
            this.Controls.Add(this.progressBar5);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_cargar_jugador);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juego";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_cargar_jugador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar5;
        private System.Windows.Forms.ProgressBar progressBar6;
    }
}