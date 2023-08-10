using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaMod
{
    public partial class MssBox : Form
    {
        Boolean draggable;
        int mouseX, mouseY;
        public MssBox()
        {
            InitializeComponent();
        }

        public void Muestra(string mensaje)
        {
            lblMssBox.Text = mensaje;
            this.ShowDialog();
        }
        private void MssBox_Load(object sender, EventArgs e)
        {
            pnInferiorMssBox.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            pnInferiorMssBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void btnResolPP_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void MssBox_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void MssBox_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void MssBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void MssBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
