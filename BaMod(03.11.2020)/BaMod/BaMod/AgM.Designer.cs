namespace BaMod
{
    partial class AgM
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
            this.btnMP = new System.Windows.Forms.Button();
            this.btnMN = new System.Windows.Forms.Button();
            this.lblcxAgM = new System.Windows.Forms.Label();
            this.lblMAgM = new System.Windows.Forms.Label();
            this.txtcxAgM = new System.Windows.Forms.TextBox();
            this.txtMAgM = new System.Windows.Forms.TextBox();
            this.btnAgM = new AltoControls.AltoButton();
            this.btnCanAgM = new AltoControls.AltoButton();
            this.SuspendLayout();
            // 
            // btnMP
            // 
            this.btnMP.BackColor = System.Drawing.Color.Transparent;
            this.btnMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMP.Location = new System.Drawing.Point(26, 43);
            this.btnMP.Name = "btnMP";
            this.btnMP.Size = new System.Drawing.Size(70, 90);
            this.btnMP.TabIndex = 0;
            this.btnMP.Tag = "01";
            this.btnMP.UseVisualStyleBackColor = false;
            this.btnMP.Click += new System.EventHandler(this.btnMP_Click);
            // 
            // btnMN
            // 
            this.btnMN.BackColor = System.Drawing.Color.Transparent;
            this.btnMN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMN.Location = new System.Drawing.Point(146, 43);
            this.btnMN.Name = "btnMN";
            this.btnMN.Size = new System.Drawing.Size(70, 90);
            this.btnMN.TabIndex = 1;
            this.btnMN.Tag = "02";
            this.btnMN.UseVisualStyleBackColor = false;
            this.btnMN.Click += new System.EventHandler(this.btnMN_Click);
            // 
            // lblcxAgM
            // 
            this.lblcxAgM.BackColor = System.Drawing.Color.Transparent;
            this.lblcxAgM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcxAgM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcxAgM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblcxAgM.Location = new System.Drawing.Point(12, 157);
            this.lblcxAgM.Name = "lblcxAgM";
            this.lblcxAgM.Size = new System.Drawing.Size(128, 40);
            this.lblcxAgM.TabIndex = 2;
            this.lblcxAgM.Text = "Coordenada x (ft)";
            this.lblcxAgM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMAgM
            // 
            this.lblMAgM.BackColor = System.Drawing.Color.Transparent;
            this.lblMAgM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMAgM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAgM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMAgM.Location = new System.Drawing.Point(12, 196);
            this.lblMAgM.Name = "lblMAgM";
            this.lblMAgM.Size = new System.Drawing.Size(128, 40);
            this.lblMAgM.TabIndex = 3;
            this.lblMAgM.Text = "Magnitud (kips/ft)";
            this.lblMAgM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcxAgM
            // 
            this.txtcxAgM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcxAgM.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtcxAgM.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcxAgM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtcxAgM.Location = new System.Drawing.Point(136, 160);
            this.txtcxAgM.Multiline = true;
            this.txtcxAgM.Name = "txtcxAgM";
            this.txtcxAgM.Size = new System.Drawing.Size(100, 30);
            this.txtcxAgM.TabIndex = 4;
            this.txtcxAgM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcxAgM.Click += new System.EventHandler(this.txtcxAgM_Click);
            this.txtcxAgM.TextChanged += new System.EventHandler(this.txtcxAgM_TextChanged);
            this.txtcxAgM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMAgM_KeyPress);
            // 
            // txtMAgM
            // 
            this.txtMAgM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMAgM.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMAgM.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAgM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtMAgM.Location = new System.Drawing.Point(136, 199);
            this.txtMAgM.Multiline = true;
            this.txtMAgM.Name = "txtMAgM";
            this.txtMAgM.Size = new System.Drawing.Size(100, 30);
            this.txtMAgM.TabIndex = 5;
            this.txtMAgM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMAgM.Click += new System.EventHandler(this.txtMAgM_Click);
            this.txtMAgM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMAgM_KeyPress);
            // 
            // btnAgM
            // 
            this.btnAgM.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgM.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgM.BackColor = System.Drawing.Color.Transparent;
            this.btnAgM.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAgM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgM.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgM.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnAgM.Location = new System.Drawing.Point(26, 239);
            this.btnAgM.Name = "btnAgM";
            this.btnAgM.Radius = 10;
            this.btnAgM.Size = new System.Drawing.Size(100, 35);
            this.btnAgM.Stroke = true;
            this.btnAgM.StrokeColor = System.Drawing.Color.Gray;
            this.btnAgM.TabIndex = 6;
            this.btnAgM.Text = "Agregar";
            this.btnAgM.Transparency = false;
            this.btnAgM.Click += new System.EventHandler(this.btnAgM_Click);
            // 
            // btnCanAgM
            // 
            this.btnCanAgM.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanAgM.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanAgM.BackColor = System.Drawing.Color.Transparent;
            this.btnCanAgM.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCanAgM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCanAgM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCanAgM.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnCanAgM.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCanAgM.Location = new System.Drawing.Point(136, 239);
            this.btnCanAgM.Name = "btnCanAgM";
            this.btnCanAgM.Radius = 10;
            this.btnCanAgM.Size = new System.Drawing.Size(100, 35);
            this.btnCanAgM.Stroke = true;
            this.btnCanAgM.StrokeColor = System.Drawing.Color.Gray;
            this.btnCanAgM.TabIndex = 7;
            this.btnCanAgM.Text = "Cancelar";
            this.btnCanAgM.Transparency = false;
            this.btnCanAgM.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // AgM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(248, 290);
            this.ControlBox = false;
            this.Controls.Add(this.btnCanAgM);
            this.Controls.Add(this.btnAgM);
            this.Controls.Add(this.txtMAgM);
            this.Controls.Add(this.txtcxAgM);
            this.Controls.Add(this.lblMAgM);
            this.Controls.Add(this.lblcxAgM);
            this.Controls.Add(this.btnMN);
            this.Controls.Add(this.btnMP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "AgM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AgM_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AgM_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AgM_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AgM_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AgM_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMP;
        private System.Windows.Forms.Button btnMN;
        private System.Windows.Forms.Label lblcxAgM;
        private System.Windows.Forms.Label lblMAgM;
        private System.Windows.Forms.TextBox txtcxAgM;
        private System.Windows.Forms.TextBox txtMAgM;
        private AltoControls.AltoButton btnAgM;
        private AltoControls.AltoButton btnCanAgM;
    }
}