namespace ClashRoyal.src.views.pages
{
    partial class Cargar
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
            this.barra = new System.Windows.Forms.ProgressBar();
            this.porcentaje = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // barra
            // 
            this.barra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barra.ForeColor = System.Drawing.SystemColors.Control;
            this.barra.Location = new System.Drawing.Point(0, 422);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(744, 34);
            this.barra.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barra.TabIndex = 1;
            // 
            // porcentaje
            // 
            this.porcentaje.AutoSize = true;
            this.porcentaje.BackColor = System.Drawing.Color.Transparent;
            this.porcentaje.Font = new System.Drawing.Font("Supercell-Magic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porcentaje.ForeColor = System.Drawing.Color.White;
            this.porcentaje.Location = new System.Drawing.Point(299, 400);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(130, 19);
            this.porcentaje.TabIndex = 7;
            this.porcentaje.Text = "Cargando 0%";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClashRoyal.Properties.Resources.cargar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(744, 422);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Cargar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 456);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cargar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar barra;
        private System.Windows.Forms.Label porcentaje;
    }
}