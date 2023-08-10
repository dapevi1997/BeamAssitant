namespace BaMod
{
    partial class AgMt
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
            this.TabCtrlAgMt = new MetroFramework.Controls.MetroTabControl();
            this.tabaceroAgMt = new MetroFramework.Controls.MetroTabPage();
            this.lbAcer = new System.Windows.Forms.ListBox();
            this.tabperzoAgMt = new MetroFramework.Controls.MetroTabPage();
            this.txtRC = new System.Windows.Forms.TextBox();
            this.txtRT = new System.Windows.Forms.TextBox();
            this.lblCAgMt = new System.Windows.Forms.Label();
            this.lblTAgMt = new System.Windows.Forms.Label();
            this.lblRUAgMt = new System.Windows.Forms.Label();
            this.btnAgMt = new AltoControls.AltoButton();
            this.altoButton1 = new AltoControls.AltoButton();
            this.lblME = new System.Windows.Forms.Label();
            this.txtME = new System.Windows.Forms.TextBox();
            this.TabCtrlAgMt.SuspendLayout();
            this.tabaceroAgMt.SuspendLayout();
            this.tabperzoAgMt.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCtrlAgMt
            // 
            this.TabCtrlAgMt.Controls.Add(this.tabaceroAgMt);
            this.TabCtrlAgMt.Controls.Add(this.tabperzoAgMt);
            this.TabCtrlAgMt.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabCtrlAgMt.Location = new System.Drawing.Point(0, 0);
            this.TabCtrlAgMt.Name = "TabCtrlAgMt";
            this.TabCtrlAgMt.SelectedIndex = 1;
            this.TabCtrlAgMt.Size = new System.Drawing.Size(297, 194);
            this.TabCtrlAgMt.TabIndex = 1;
            this.TabCtrlAgMt.UseCustomBackColor = true;
            this.TabCtrlAgMt.UseCustomForeColor = true;
            this.TabCtrlAgMt.UseSelectable = true;
            this.TabCtrlAgMt.SelectedIndexChanged += new System.EventHandler(this.TabCtrlAgMt_SelectedIndexChanged);
            // 
            // tabaceroAgMt
            // 
            this.tabaceroAgMt.Controls.Add(this.lbAcer);
            this.tabaceroAgMt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabaceroAgMt.HorizontalScrollbarBarColor = true;
            this.tabaceroAgMt.HorizontalScrollbarHighlightOnWheel = false;
            this.tabaceroAgMt.HorizontalScrollbarSize = 10;
            this.tabaceroAgMt.Location = new System.Drawing.Point(4, 38);
            this.tabaceroAgMt.Name = "tabaceroAgMt";
            this.tabaceroAgMt.Size = new System.Drawing.Size(276, 152);
            this.tabaceroAgMt.TabIndex = 0;
            this.tabaceroAgMt.Text = "Acero";
            this.tabaceroAgMt.VerticalScrollbarBarColor = true;
            this.tabaceroAgMt.VerticalScrollbarHighlightOnWheel = false;
            this.tabaceroAgMt.VerticalScrollbarSize = 10;
            // 
            // lbAcer
            // 
            this.lbAcer.BackColor = System.Drawing.SystemColors.Window;
            this.lbAcer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbAcer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAcer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbAcer.FormattingEnabled = true;
            this.lbAcer.ItemHeight = 16;
            this.lbAcer.Items.AddRange(new object[] {
            "*ASTM-A36",
            "*ASTM-A709 ",
            "*ASTM-A913 ",
            "*ASTM-A992 "});
            this.lbAcer.Location = new System.Drawing.Point(19, 17);
            this.lbAcer.Name = "lbAcer";
            this.lbAcer.Size = new System.Drawing.Size(152, 96);
            this.lbAcer.TabIndex = 0;
            // 
            // tabperzoAgMt
            // 
            this.tabperzoAgMt.Controls.Add(this.txtME);
            this.tabperzoAgMt.Controls.Add(this.lblME);
            this.tabperzoAgMt.Controls.Add(this.txtRC);
            this.tabperzoAgMt.Controls.Add(this.txtRT);
            this.tabperzoAgMt.Controls.Add(this.lblCAgMt);
            this.tabperzoAgMt.Controls.Add(this.lblTAgMt);
            this.tabperzoAgMt.Controls.Add(this.lblRUAgMt);
            this.tabperzoAgMt.HorizontalScrollbarBarColor = true;
            this.tabperzoAgMt.HorizontalScrollbarHighlightOnWheel = false;
            this.tabperzoAgMt.HorizontalScrollbarSize = 10;
            this.tabperzoAgMt.Location = new System.Drawing.Point(4, 38);
            this.tabperzoAgMt.Name = "tabperzoAgMt";
            this.tabperzoAgMt.Size = new System.Drawing.Size(289, 152);
            this.tabperzoAgMt.TabIndex = 1;
            this.tabperzoAgMt.Text = "Personalizado";
            this.tabperzoAgMt.VerticalScrollbarBarColor = true;
            this.tabperzoAgMt.VerticalScrollbarHighlightOnWheel = false;
            this.tabperzoAgMt.VerticalScrollbarSize = 10;
            // 
            // txtRC
            // 
            this.txtRC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRC.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtRC.Location = new System.Drawing.Point(203, 84);
            this.txtRC.Multiline = true;
            this.txtRC.Name = "txtRC";
            this.txtRC.Size = new System.Drawing.Size(78, 27);
            this.txtRC.TabIndex = 17;
            this.txtRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRC.Click += new System.EventHandler(this.txtRC_Click);
            this.txtRC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRC_KeyPress);
            // 
            // txtRT
            // 
            this.txtRT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRT.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRT.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtRT.Location = new System.Drawing.Point(203, 50);
            this.txtRT.Multiline = true;
            this.txtRT.Name = "txtRT";
            this.txtRT.Size = new System.Drawing.Size(78, 28);
            this.txtRT.TabIndex = 16;
            this.txtRT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRT.Click += new System.EventHandler(this.txtRT_Click);
            this.txtRT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblCAgMt
            // 
            this.lblCAgMt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCAgMt.AutoSize = true;
            this.lblCAgMt.BackColor = System.Drawing.Color.Transparent;
            this.lblCAgMt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCAgMt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCAgMt.Location = new System.Drawing.Point(14, 85);
            this.lblCAgMt.Name = "lblCAgMt";
            this.lblCAgMt.Size = new System.Drawing.Size(94, 16);
            this.lblCAgMt.TabIndex = 15;
            this.lblCAgMt.Text = "Cortante (ksi)";
            // 
            // lblTAgMt
            // 
            this.lblTAgMt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTAgMt.AutoSize = true;
            this.lblTAgMt.BackColor = System.Drawing.Color.Transparent;
            this.lblTAgMt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTAgMt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTAgMt.Location = new System.Drawing.Point(14, 51);
            this.lblTAgMt.Name = "lblTAgMt";
            this.lblTAgMt.Size = new System.Drawing.Size(88, 16);
            this.lblTAgMt.TabIndex = 14;
            this.lblTAgMt.Text = "Tensión (ksi)";
            // 
            // lblRUAgMt
            // 
            this.lblRUAgMt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRUAgMt.AutoSize = true;
            this.lblRUAgMt.BackColor = System.Drawing.Color.Transparent;
            this.lblRUAgMt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRUAgMt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRUAgMt.Location = new System.Drawing.Point(45, 16);
            this.lblRUAgMt.Name = "lblRUAgMt";
            this.lblRUAgMt.Size = new System.Drawing.Size(124, 16);
            this.lblRUAgMt.TabIndex = 13;
            this.lblRUAgMt.Text = "Resistencia Última";
            // 
            // btnAgMt
            // 
            this.btnAgMt.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgMt.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgMt.BackColor = System.Drawing.Color.Transparent;
            this.btnAgMt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAgMt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgMt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgMt.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.btnAgMt.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnAgMt.Location = new System.Drawing.Point(12, 214);
            this.btnAgMt.Name = "btnAgMt";
            this.btnAgMt.Radius = 10;
            this.btnAgMt.Size = new System.Drawing.Size(100, 35);
            this.btnAgMt.Stroke = true;
            this.btnAgMt.StrokeColor = System.Drawing.Color.Gray;
            this.btnAgMt.TabIndex = 2;
            this.btnAgMt.Text = "Agregar";
            this.btnAgMt.Transparency = false;
            this.btnAgMt.Click += new System.EventHandler(this.btnAgCC_Click);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.altoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.altoButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.altoButton1.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
            this.altoButton1.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.altoButton1.Location = new System.Drawing.Point(122, 214);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 10;
            this.altoButton1.Size = new System.Drawing.Size(100, 35);
            this.altoButton1.Stroke = true;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 0;
            this.altoButton1.Text = "Cancelar";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // lblME
            // 
            this.lblME.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblME.AutoSize = true;
            this.lblME.BackColor = System.Drawing.Color.Transparent;
            this.lblME.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblME.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblME.Location = new System.Drawing.Point(14, 122);
            this.lblME.Name = "lblME";
            this.lblME.Size = new System.Drawing.Size(145, 16);
            this.lblME.TabIndex = 18;
            this.lblME.Text = "Módulo de elasticidad";
            // 
            // txtME
            // 
            this.txtME.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtME.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtME.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtME.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtME.Location = new System.Drawing.Point(203, 117);
            this.txtME.Multiline = true;
            this.txtME.Name = "txtME";
            this.txtME.Size = new System.Drawing.Size(78, 27);
            this.txtME.TabIndex = 19;
            this.txtME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtME.Click += new System.EventHandler(this.txtME_Click);
            this.txtME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtME_KeyPress);
            // 
            // AgMt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(297, 261);
            this.ControlBox = false;
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.btnAgMt);
            this.Controls.Add(this.TabCtrlAgMt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "AgMt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AgMt_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AgMt_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AgMt_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AgMt_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AgMt_MouseUp);
            this.TabCtrlAgMt.ResumeLayout(false);
            this.tabaceroAgMt.ResumeLayout(false);
            this.tabperzoAgMt.ResumeLayout(false);
            this.tabperzoAgMt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl TabCtrlAgMt;
        private MetroFramework.Controls.MetroTabPage tabaceroAgMt;
        private MetroFramework.Controls.MetroTabPage tabperzoAgMt;
        private System.Windows.Forms.ListBox lbAcer;
        private AltoControls.AltoButton btnAgMt;
        private AltoControls.AltoButton altoButton1;
        private System.Windows.Forms.TextBox txtRC;
        private System.Windows.Forms.TextBox txtRT;
        private System.Windows.Forms.Label lblCAgMt;
        private System.Windows.Forms.Label lblTAgMt;
        private System.Windows.Forms.Label lblRUAgMt;
        private System.Windows.Forms.TextBox txtME;
        private System.Windows.Forms.Label lblME;
    }
}