namespace BaMod
{
    partial class PagVgTV
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
            this.lblUbApyTV = new System.Windows.Forms.Label();
            this.txtUbApyTV = new System.Windows.Forms.TextBox();
            this.btnCanPagTV = new AltoControls.AltoButton();
            this.btnLisPagTV = new AltoControls.AltoButton();
            this.SuspendLayout();
            // 
            // lblUbApyTV
            // 
            this.lblUbApyTV.BackColor = System.Drawing.Color.Transparent;
            this.lblUbApyTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUbApyTV.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbApyTV.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUbApyTV.Location = new System.Drawing.Point(12, 20);
            this.lblUbApyTV.Name = "lblUbApyTV";
            this.lblUbApyTV.Size = new System.Drawing.Size(165, 40);
            this.lblUbApyTV.TabIndex = 5;
            this.lblUbApyTV.Text = "Ubicación del apoyo (ft)";
            this.lblUbApyTV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUbApyTV
            // 
            this.txtUbApyTV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUbApyTV.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUbApyTV.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUbApyTV.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtUbApyTV.Location = new System.Drawing.Point(171, 30);
            this.txtUbApyTV.Multiline = true;
            this.txtUbApyTV.Name = "txtUbApyTV";
            this.txtUbApyTV.Size = new System.Drawing.Size(100, 30);
            this.txtUbApyTV.TabIndex = 6;
            this.txtUbApyTV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUbApyTV.Click += new System.EventHandler(this.txtUbApyTV_Click);
            this.txtUbApyTV.TextChanged += new System.EventHandler(this.txtUbApyTV_TextChanged);
            this.txtUbApyTV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUbApyTV_KeyPress);
            // 
            // btnCanPagTV
            // 
            this.btnCanPagTV.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanPagTV.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanPagTV.BackColor = System.Drawing.Color.Transparent;
            this.btnCanPagTV.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCanPagTV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCanPagTV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCanPagTV.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanPagTV.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCanPagTV.Location = new System.Drawing.Point(162, 63);
            this.btnCanPagTV.Name = "btnCanPagTV";
            this.btnCanPagTV.Radius = 10;
            this.btnCanPagTV.Size = new System.Drawing.Size(100, 35);
            this.btnCanPagTV.Stroke = true;
            this.btnCanPagTV.StrokeColor = System.Drawing.Color.Gray;
            this.btnCanPagTV.TabIndex = 7;
            this.btnCanPagTV.Text = "Cancelar";
            this.btnCanPagTV.Transparency = false;
            this.btnCanPagTV.Click += new System.EventHandler(this.btnCanPagTV_Click);
            // 
            // btnLisPagTV
            // 
            this.btnLisPagTV.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnLisPagTV.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnLisPagTV.BackColor = System.Drawing.Color.Transparent;
            this.btnLisPagTV.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLisPagTV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLisPagTV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLisPagTV.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnLisPagTV.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnLisPagTV.Location = new System.Drawing.Point(56, 63);
            this.btnLisPagTV.Name = "btnLisPagTV";
            this.btnLisPagTV.Radius = 10;
            this.btnLisPagTV.Size = new System.Drawing.Size(100, 35);
            this.btnLisPagTV.Stroke = true;
            this.btnLisPagTV.StrokeColor = System.Drawing.Color.Gray;
            this.btnLisPagTV.TabIndex = 8;
            this.btnLisPagTV.Text = "Listo";
            this.btnLisPagTV.Transparency = false;
            this.btnLisPagTV.Click += new System.EventHandler(this.btnLisPagTV_Click);
            // 
            // PagVgTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(274, 111);
            this.ControlBox = false;
            this.Controls.Add(this.btnLisPagTV);
            this.Controls.Add(this.btnCanPagTV);
            this.Controls.Add(this.txtUbApyTV);
            this.Controls.Add(this.lblUbApyTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "PagVgTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PagVgTV_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PagVgTV_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PagVgTV_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PagVgTV_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PagVgTV_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUbApyTV;
        private System.Windows.Forms.TextBox txtUbApyTV;
        private AltoControls.AltoButton btnCanPagTV;
        private AltoControls.AltoButton btnLisPagTV;
    }
}