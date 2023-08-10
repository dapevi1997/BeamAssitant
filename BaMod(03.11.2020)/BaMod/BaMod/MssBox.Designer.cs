namespace BaMod
{
    partial class MssBox
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
            this.pnInferiorMssBox = new System.Windows.Forms.Panel();
            this.btnResolPP = new AltoControls.AltoButton();
            this.lblMssBox = new System.Windows.Forms.Label();
            this.pnlblMssBox = new System.Windows.Forms.Panel();
            this.pnlblMssBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnInferiorMssBox
            // 
            this.pnInferiorMssBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnInferiorMssBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnInferiorMssBox.Location = new System.Drawing.Point(0, 142);
            this.pnInferiorMssBox.Name = "pnInferiorMssBox";
            this.pnInferiorMssBox.Size = new System.Drawing.Size(284, 20);
            this.pnInferiorMssBox.TabIndex = 0;
            // 
            // btnResolPP
            // 
            this.btnResolPP.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnResolPP.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnResolPP.BackColor = System.Drawing.Color.Transparent;
            this.btnResolPP.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnResolPP.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnResolPP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResolPP.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnResolPP.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnResolPP.Location = new System.Drawing.Point(107, 106);
            this.btnResolPP.Name = "btnResolPP";
            this.btnResolPP.Radius = 10;
            this.btnResolPP.Size = new System.Drawing.Size(70, 30);
            this.btnResolPP.Stroke = true;
            this.btnResolPP.StrokeColor = System.Drawing.Color.Gray;
            this.btnResolPP.TabIndex = 3;
            this.btnResolPP.Text = "Listo";
            this.btnResolPP.Transparency = false;
            this.btnResolPP.Click += new System.EventHandler(this.btnResolPP_Click);
            // 
            // lblMssBox
            // 
            this.lblMssBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMssBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMssBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMssBox.Location = new System.Drawing.Point(0, 0);
            this.lblMssBox.Name = "lblMssBox";
            this.lblMssBox.Size = new System.Drawing.Size(200, 53);
            this.lblMssBox.TabIndex = 4;
            this.lblMssBox.Text = "label1";
            this.lblMssBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlblMssBox
            // 
            this.pnlblMssBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlblMssBox.Controls.Add(this.lblMssBox);
            this.pnlblMssBox.Location = new System.Drawing.Point(50, 37);
            this.pnlblMssBox.Name = "pnlblMssBox";
            this.pnlblMssBox.Size = new System.Drawing.Size(200, 63);
            this.pnlblMssBox.TabIndex = 5;
            // 
            // MssBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.ControlBox = false;
            this.Controls.Add(this.pnlblMssBox);
            this.Controls.Add(this.btnResolPP);
            this.Controls.Add(this.pnInferiorMssBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "MssBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MssBox_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MssBox_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MssBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MssBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MssBox_MouseUp);
            this.pnlblMssBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnInferiorMssBox;
        private AltoControls.AltoButton btnResolPP;
        private System.Windows.Forms.Label lblMssBox;
        private System.Windows.Forms.Panel pnlblMssBox;
    }
}