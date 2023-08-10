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
    public partial class PagVgCon : Form
    {
        double lvgax;
        Boolean draggable;
        int mouseX, mouseY;

        private void PagVgCon_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblUbApyCon.Text = "Ubicación del apoyo [m]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblUbApyCon.Text = "Ubicación del apoyo [ft]";
            }

            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            txtUbApyCon.Text = PagPrincipal.Pag.ltvget.ToString();
        }

        private void btnCanPagCon_Click(object sender, EventArgs e)
        {
            PagPrincipal.LCON = 0;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txtUbApyCon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvgax = Convert.ToDouble(txtUbApyCon.Text);
            }
            catch (FormatException)
            {

                txtUbApyCon.Text = "";
            }
        }

        private void btnLisPagCon_Click(object sender, EventArgs e)
        {
            if (txtUbApyCon.Text == "" || txtUbApyCon.Text == "0")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingrese coordenada válida");
                txtUbApyCon.Focus();
            }
            else
            {
                if (Convert.ToDouble(txtUbApyCon.Text) >= PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Ubicación x no válida");
                    txtUbApyCon.Focus();
                }
                else
                {
                    PagPrincipal.LCON = lvgax;
                    //PagPrincipal.Pag.ltvst.Visible = true;
                    //PagPrincipal.Pag.ltvst.Text = "ltv: " + lvgax.ToString();
                    PagPrincipal.Pag.lconstset = "lcon = " + lvgax.ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                PagPrincipal.Pag.tabCgVgPP.Invalidate();
            }
        }

        private void txtUbApyCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    PagPrincipal.LTV = lvgax;
                    btnLisPagCon.PerformClick();
                    //DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    e.Handled = false;
                }

            }

            else if (Convert.ToString(e.KeyChar) == ".")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Decimales con coma");

                txtUbApyCon.Focus();
                e.Handled = true;
            }
            else if (Convert.ToString(e.KeyChar) == ",")
            {

                e.Handled = false;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtUbApyCon.Focus();
                e.Handled = true;
            }
        }

        private void txtUbApyCon_Click(object sender, EventArgs e)
        {
            txtUbApyCon.SelectAll();
        }

        private void PagVgCon_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void PagVgCon_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void PagVgCon_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void PagVgCon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public PagVgCon()
        {
            InitializeComponent();
        }
    }
}
