namespace ClashRoyal.src.views.options
{
    partial class Score_component
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.danioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elixirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadisticaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMejorPartida = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadisticaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ClashRoyal.Properties.Resources.fondo_Inicio;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 378);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Supercell-Magic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.danioDataGridViewTextBoxColumn,
            this.tiempoDataGridViewTextBoxColumn,
            this.elixirDataGridViewTextBoxColumn,
            this.personajeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.estadisticaBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(449, 354);
            this.dataGridView1.TabIndex = 4;
            // 
            // danioDataGridViewTextBoxColumn
            // 
            this.danioDataGridViewTextBoxColumn.DataPropertyName = "danio";
            this.danioDataGridViewTextBoxColumn.HeaderText = "Daño Recibido";
            this.danioDataGridViewTextBoxColumn.Name = "danioDataGridViewTextBoxColumn";
            // 
            // tiempoDataGridViewTextBoxColumn
            // 
            this.tiempoDataGridViewTextBoxColumn.DataPropertyName = "tiempo";
            this.tiempoDataGridViewTextBoxColumn.HeaderText = "Tiempo";
            this.tiempoDataGridViewTextBoxColumn.Name = "tiempoDataGridViewTextBoxColumn";
            // 
            // elixirDataGridViewTextBoxColumn
            // 
            this.elixirDataGridViewTextBoxColumn.DataPropertyName = "elixir";
            this.elixirDataGridViewTextBoxColumn.HeaderText = "Elixir usado";
            this.elixirDataGridViewTextBoxColumn.Name = "elixirDataGridViewTextBoxColumn";
            // 
            // personajeDataGridViewTextBoxColumn
            // 
            this.personajeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.personajeDataGridViewTextBoxColumn.DataPropertyName = "personaje";
            this.personajeDataGridViewTextBoxColumn.HeaderText = "Personaje más usado";
            this.personajeDataGridViewTextBoxColumn.Name = "personajeDataGridViewTextBoxColumn";
            this.personajeDataGridViewTextBoxColumn.Width = 96;
            // 
            // estadisticaBindingSource
            // 
            this.estadisticaBindingSource.DataSource = typeof(ClashRoyal.src.tools.Objects.Estadistica);
            // 
            // lblMejorPartida
            // 
            this.lblMejorPartida.AutoSize = true;
            this.lblMejorPartida.BackColor = System.Drawing.Color.Transparent;
            this.lblMejorPartida.Font = new System.Drawing.Font("Supercell-Magic", 8F, System.Drawing.FontStyle.Bold);
            this.lblMejorPartida.ForeColor = System.Drawing.Color.White;
            this.lblMejorPartida.Location = new System.Drawing.Point(458, 213);
            this.lblMejorPartida.Name = "lblMejorPartida";
            this.lblMejorPartida.Size = new System.Drawing.Size(119, 16);
            this.lblMejorPartida.TabIndex = 5;
            this.lblMejorPartida.Text = "Puntuaje: ...";
            // 
            // Score_component
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMejorPartida);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Score_component";
            this.Size = new System.Drawing.Size(789, 378);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadisticaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn danioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elixirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource estadisticaBindingSource;
        private System.Windows.Forms.Label lblMejorPartida;
    }
}
