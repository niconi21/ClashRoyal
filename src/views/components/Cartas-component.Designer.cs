namespace ClashRoyal.src.views.components
{
    partial class Cartas_component
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nombre = new System.Windows.Forms.Label();
            this.imagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Font = new System.Drawing.Font("Supercell-Magic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.ForeColor = System.Drawing.SystemColors.Control;
            this.nombre.Location = new System.Drawing.Point(-3, 59);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(52, 16);
            this.nombre.TabIndex = 1;
            this.nombre.Text = "label1";
            // 
            // imagen
            // 
            this.imagen.Location = new System.Drawing.Point(31, 3);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(43, 53);
            this.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagen.TabIndex = 0;
            this.imagen.TabStop = false;
            // 
            // Cartas_component
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(53)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.imagen);
            this.Name = "Cartas_component";
            this.Size = new System.Drawing.Size(108, 80);
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagen;
        private System.Windows.Forms.Label nombre;
    }
}
