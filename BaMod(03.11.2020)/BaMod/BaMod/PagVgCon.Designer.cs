namespace BaMod
{
    partial class PagVgCon
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
            this.lblUbApyCon = new System.Windows.Forms.Label();
            this.txtUbApyCon = new System.Windows.Forms.TextBox();
            this.btnLisPagCon = new AltoControls.AltoButton();
            this.btnCanPagCon = new AltoControls.AltoButton();
            this.SuspendLayout();
            // 
            // lblUbApyCon
            // 
            this.lblUbApyCon.BackColor = System.Drawing.Color.Transparent;
            this.lblUbApyCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUbApyCon.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbApyCon.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUbApyCon.Location = new System.Drawing.Point(12, 20);
            this.lblUbApyCon.Name = "lblUbApyCon";
            this.lblUbApyCon.Size = new System.Drawing.Size(165, 40);
            this.lblUbApyCon.TabIndex = 6;
            this.lblUbApyCon.Text = "Ubicación del apoyo (ft)";
            this.lblUbApyCon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUbApyCon
            // 
            this.txtUbApyCon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUbApyCon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUbApyCon.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUbApyCon.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtUbApyCon.Location = new System.Drawing.Point(171, 30);
            this.txtUbApyCon.Multiline = true;
            this.txtUbApyCon.Name = "txtUbApyCon";
            this.txtUbApyCon.Size = new System.Drawing.Size(100, 30);
            this.txtUbApyCon.TabIndex = 7;
            this.txtUbApyCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUbApyCon.Click += new System.EventHandler(this.txtUbApyCon_Click);
            this.txtUbApyCon.TextChanged += new System.EventHandler(this.txtUbApyCon_TextChanged);
            this.txtUbApyCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUbApyCon_KeyPress);
            // 
            // btnLisPagCon
            // 
            this.btnLisPagCon.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnLisPagCon.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnLisPagCon.BackColor = System.Drawing.Color.Transparent;
            this.btnLisPagCon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLisPagCon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLisPagCon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLisPagCon.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnLisPagCon.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnLisPagCon.Location = new System.Drawing.Point(56, 63);
            this.btnLisPagCon.Name = "btnLisPagCon";
            this.btnLisPagCon.Radius = 10;
            this.btnLisPagCon.Size = new System.Drawing.Size(100, 35);
            this.btnLisPagCon.Stroke = true;
            this.btnLisPagCon.StrokeColor = System.Drawing.Color.Gray;
            this.btnLisPagCon.TabIndex = 9;
            this.btnLisPagCon.Text = "Listo";
            this.btnLisPagCon.Transparency = false;
            this.btnLisPagCon.Click += new System.EventHandler(this.btnLisPagCon_Click);
            // 
            // btnCanPagCon
            // 
            this.btnCanPagCon.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanPagCon.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanPagCon.BackColor = System.Drawing.Color.Transparent;
            this.btnCanPagCon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCanPagCon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCanPagCon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCanPagCon.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanPagCon.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCanPagCon.Location = new System.Drawing.Point(162, 63);
            this.btnCanPagCon.Name = "btnCanPagCon";
            this.btnCanPagCon.Radius = 10;
            this.btnCanPagCon.Size = new System.Drawing.Size(100, 35);
            this.btnCanPagCon.Stroke = true;
            this.btnCanPagCon.StrokeColor = System.Drawing.Color.Gray;
            this.btnCanPagCon.TabIndex = 10;
            this.btnCanPagCon.Text = "Cancelar";
            this.btnCanPagCon.Transparency = false;
            this.btnCanPagCon.Click += new System.EventHandler(this.btnCanPagCon_Click);
            // 
            // PagVgCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 113);
            this.Controls.Add(this.btnCanPagCon);
            this.Controls.Add(this.btnLisPagCon);
            this.Controls.Add(this.txtUbApyCon);
            this.Controls.Add(this.lblUbApyCon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PagVgCon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PagVgCon";
            this.Load += new System.EventHandler(this.PagVgCon_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PagVgCon_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PagVgCon_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PagVgCon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PagVgCon_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUbApyCon;
        private System.Windows.Forms.TextBox txtUbApyCon;
        private AltoControls.AltoButton btnLisPagCon;
        private AltoControls.AltoButton btnCanPagCon;
    }
}