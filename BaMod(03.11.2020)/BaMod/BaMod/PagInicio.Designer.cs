namespace BaMod
{
    partial class PagInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmInicio = new System.Windows.Forms.Timer(this.components);
            this.pbsalPI = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbsalPI)).BeginInit();
            this.SuspendLayout();
            // 
            // tmInicio
            // 
            this.tmInicio.Enabled = true;
            this.tmInicio.Interval = 2000;
            this.tmInicio.Tick += new System.EventHandler(this.tmInicio_Tick);
            // 
            // pbsalPI
            // 
            this.pbsalPI.Location = new System.Drawing.Point(447, 12);
            this.pbsalPI.Name = "pbsalPI";
            this.pbsalPI.Size = new System.Drawing.Size(25, 25);
            this.pbsalPI.TabIndex = 3;
            this.pbsalPI.TabStop = false;
            this.pbsalPI.Click += new System.EventHandler(this.pbsalPI_Click);
            this.pbsalPI.MouseEnter += new System.EventHandler(this.pbsalPI_MouseEnter);
            this.pbsalPI.MouseLeave += new System.EventHandler(this.pbsalPI_MouseLeave);
            // 
            // PagInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 284);
            this.ControlBox = false;
            this.Controls.Add(this.pbsalPI);
            this.Name = "PagInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PagInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbsalPI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmInicio;
        private System.Windows.Forms.PictureBox pbsalPI;
    }
}

