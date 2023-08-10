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
    public partial class PagVgTV : Form
    {
        double lvgax;
        Boolean draggable;
        int mouseX, mouseY;
        public PagVgTV()
        {
            InitializeComponent();
        }

        private void PagVgTV_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblUbApyTV.Text = "Ubicación del apoyo [m]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblUbApyTV.Text = "Ubicación del apoyo [ft]";
            }

            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            txtUbApyTV.Text = PagPrincipal.Pag.ltvget.ToString();
        }
        private void btnCanPagTV_Click(object sender, EventArgs e)
        {

            PagPrincipal.LTV = 0;

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txtUbApyTV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvgax = Convert.ToDouble(txtUbApyTV.Text);
            }
            catch (FormatException)
            {

                txtUbApyTV.Text = "";
            }
        }

        private void btnLisPagTV_Click(object sender, EventArgs e)
        {
            if (txtUbApyTV.Text == "" || txtUbApyTV.Text == "0")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingrese coordenada válida");
                txtUbApyTV.Focus();
            }
            else
            {
                if (Convert.ToDouble(txtUbApyTV.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Ubicación x no debe exceder la longitud de la viga");
                    txtUbApyTV.Focus();
                }
                else
                {
                    PagPrincipal.LTV = lvgax;
                    PagPrincipal.Pag.ltvst.Visible = true;
                    PagPrincipal.Pag.ltvst.Text = "ltv: " + lvgax.ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                PagPrincipal.Pag.tabCgVgPP.Invalidate();
            }
           

        }

        private void txtUbApyTV_KeyPress(object sender, KeyPressEventArgs e)
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
                    btnLisPagTV.PerformClick();
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

                txtUbApyTV.Focus();
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
                txtUbApyTV.Focus();
                e.Handled = true;
            }
        }

        private void txtUbApyTV_Click(object sender, EventArgs e)
        {
            txtUbApyTV.SelectAll();
        }

        private void PagVgTV_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void PagVgTV_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void PagVgTV_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void PagVgTV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
