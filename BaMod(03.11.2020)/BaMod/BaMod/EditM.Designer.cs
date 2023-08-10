namespace BaMod
{
    partial class EditM
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
            this.lblcxEditM = new System.Windows.Forms.Label();
            this.lblMEditM = new System.Windows.Forms.Label();
            this.txtcxEditM = new System.Windows.Forms.TextBox();
            this.txtMeditM = new System.Windows.Forms.TextBox();
            this.btnAgEditM = new AltoControls.AltoButton();
            this.btnCanEditM = new AltoControls.AltoButton();
            this.SuspendLayout();
            // 
            // lblcxEditM
            // 
            this.lblcxEditM.BackColor = System.Drawing.Color.Transparent;
            this.lblcxEditM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcxEditM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcxEditM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblcxEditM.Location = new System.Drawing.Point(12, 9);
            this.lblcxEditM.Name = "lblcxEditM";
            this.lblcxEditM.Size = new System.Drawing.Size(128, 40);
            this.lblcxEditM.TabIndex = 0;
            this.lblcxEditM.Text = "Coordenada x (ft)";
            this.lblcxEditM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMEditM
            // 
            this.lblMEditM.BackColor = System.Drawing.Color.Transparent;
            this.lblMEditM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMEditM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMEditM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMEditM.Location = new System.Drawing.Point(12, 49);
            this.lblMEditM.Name = "lblMEditM";
            this.lblMEditM.Size = new System.Drawing.Size(128, 40);
            this.lblMEditM.TabIndex = 1;
            this.lblMEditM.Text = "Momento (kips*ft)";
            this.lblMEditM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcxEditM
            // 
            this.txtcxEditM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcxEditM.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtcxEditM.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcxEditM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtcxEditM.Location = new System.Drawing.Point(146, 19);
            this.txtcxEditM.Multiline = true;
            this.txtcxEditM.Name = "txtcxEditM";
            this.txtcxEditM.Size = new System.Drawing.Size(100, 30);
            this.txtcxEditM.TabIndex = 2;
            this.txtcxEditM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcxEditM.Click += new System.EventHandler(this.txtcxEditM_Click);
            this.txtcxEditM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcxEditM_KeyPress);
            // 
            // txtMeditM
            // 
            this.txtMeditM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeditM.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMeditM.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeditM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtMeditM.Location = new System.Drawing.Point(146, 59);
            this.txtMeditM.Multiline = true;
            this.txtMeditM.Name = "txtMeditM";
            this.txtMeditM.Size = new System.Drawing.Size(100, 30);
            this.txtMeditM.TabIndex = 3;
            this.txtMeditM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMeditM.Click += new System.EventHandler(this.txtMeditM_Click);
            this.txtMeditM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeditM_KeyPress);
            // 
            // btnAgEditM
            // 
            this.btnAgEditM.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgEditM.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgEditM.BackColor = System.Drawing.Color.Transparent;
            this.btnAgEditM.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAgEditM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgEditM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgEditM.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgEditM.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnAgEditM.Location = new System.Drawing.Point(40, 103);
            this.btnAgEditM.Name = "btnAgEditM";
            this.btnAgEditM.Radius = 10;
            this.btnAgEditM.Size = new System.Drawing.Size(100, 35);
            this.btnAgEditM.Stroke = true;
            this.btnAgEditM.StrokeColor = System.Drawing.Color.Gray;
            this.btnAgEditM.TabIndex = 4;
            this.btnAgEditM.Text = "Agregar";
            this.btnAgEditM.Transparency = false;
            this.btnAgEditM.Click += new System.EventHandler(this.btnAgEditM_Click);
            // 
            // btnCanEditM
            // 
            this.btnCanEditM.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanEditM.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanEditM.BackColor = System.Drawing.Color.Transparent;
            this.btnCanEditM.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCanEditM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCanEditM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCanEditM.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanEditM.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCanEditM.Location = new System.Drawing.Point(146, 103);
            this.btnCanEditM.Name = "btnCanEditM";
            this.btnCanEditM.Radius = 10;
            this.btnCanEditM.Size = new System.Drawing.Size(100, 35);
            this.btnCanEditM.Stroke = true;
            this.btnCanEditM.StrokeColor = System.Drawing.Color.Gray;
            this.btnCanEditM.TabIndex = 5;
            this.btnCanEditM.Text = "Cancelar";
            this.btnCanEditM.Transparency = false;
            this.btnCanEditM.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // EditM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(258, 150);
            this.ControlBox = false;
            this.Controls.Add(this.btnCanEditM);
            this.Controls.Add(this.btnAgEditM);
            this.Controls.Add(this.txtMeditM);
            this.Controls.Add(this.txtcxEditM);
            this.Controls.Add(this.lblMEditM);
            this.Controls.Add(this.lblcxEditM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "EditM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditM_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditM_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditM_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditM_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EditM_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcxEditM;
        private System.Windows.Forms.Label lblMEditM;
        private System.Windows.Forms.TextBox txtcxEditM;
        private System.Windows.Forms.TextBox txtMeditM;
        private AltoControls.AltoButton btnAgEditM;
        private AltoControls.AltoButton btnCanEditM;
    }
}