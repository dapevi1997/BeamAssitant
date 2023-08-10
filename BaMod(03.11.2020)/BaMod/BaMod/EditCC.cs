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
    public partial class EditCC : Form
    {
        Boolean draggable;
        int mouseX, mouseY;
        public EditCC()
        {
            InitializeComponent();
        }

        private void btnCanEditCC_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
           
        }

        private void txtcxEditcC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Convert.ToString(e.KeyChar) == ".")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Decimales con coma");

                txtcxEditcC.Focus();
                e.Handled = true;
            }
            else if (Convert.ToString(e.KeyChar) == ",")
            {

                e.Handled = false;
            }
            else if (Convert.ToString(e.KeyChar) == "-")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("No se admiten números negativos");

                txtcxEditcC.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtcxEditcC.Focus();
                e.Handled = true;
            }
        }

        private void txtcxEditcC_Click(object sender, EventArgs e)
        {
            txtcxEditcC.SelectAll();
        }

        private void txtFzEditCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    btnAgEditCC.PerformClick();
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

                txtFzEditCC.Focus();
                e.Handled = true;
            }
            else if (Convert.ToString(e.KeyChar) == ",")
            {

                e.Handled = false;
            }
            else if (Convert.ToString(e.KeyChar) == "-")
            {
           
                e.Handled = false;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtFzEditCC.Focus();
                e.Handled = true;
            }
        }

        private void txtFzEditCC_Click(object sender, EventArgs e)
        {
            txtFzEditCC.SelectAll();
        }

        private void btnAgEditCC_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtcxEditcC.Text);
                double m = Convert.ToDouble(txtFzEditCC.Text);

                if (txtcxEditcC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada en x");
                    txtcxEditcC.Focus();
                }
                else if (Convert.ToDouble(txtcxEditcC.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x no debe exceder la longitud de la viga");
                    txtcxEditcC.Focus();
                }
                else if (txtFzEditCC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese fuerza");
                    txtFzEditCC.Focus();
                }
                else if (txtFzEditCC.Text == "0")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese fuerza diferente de 0");
                    txtFzEditCC.Focus();
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }

            }
            catch (Exception)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Formato no válido");

            }

       
        }

        private void EditCC_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblcxEditCC.Text = "Coordenada x [m]";
                lblFzEditCC.Text = "Fuerza [kN]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblcxEditCC.Text = "Coordenada x [ft]";
                lblFzEditCC.Text = "Fuerza [kip]";
            }

            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void EditCC_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void EditCC_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void EditCC_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void EditCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
