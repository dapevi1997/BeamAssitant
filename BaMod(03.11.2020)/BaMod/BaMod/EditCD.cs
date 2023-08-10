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
    public partial class EditCD : Form
    {
        Boolean draggable;
        int mouseX, mouseY;
        public EditCD()
        {
            InitializeComponent();
        }

        private void btnCanEditCD_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txtcx1EditCD_KeyPress(object sender, KeyPressEventArgs e)
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

                txtcx1EditCD.Focus();
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

                txtcx1EditCD.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtcx1EditCD.Focus();
                e.Handled = true;
            }
        }

        private void txtcx1EditCD_Click(object sender, EventArgs e)
        {
            txtcx1EditCD.SelectAll();
        }

        private void txtcx2EditCD_KeyPress(object sender, KeyPressEventArgs e)
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

                txtcx2EditCD.Focus();
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

                txtcx2EditCD.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtcx2EditCD.Focus();
                e.Handled = true;
            }
        }

        private void txtcx2EditCD_Click(object sender, EventArgs e)
        {
            txtcx2EditCD.SelectAll();
        }

        private void txtFzInEditCD_KeyPress(object sender, KeyPressEventArgs e)
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

                txtFzInEditCD.Focus();
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
                txtFzInEditCD.Focus();
                e.Handled = true;
            }
        }

        private void txtFzInEditCD_Click(object sender, EventArgs e)
        {
            txtFzInEditCD.SelectAll();
        }

        private void txtFzFinEditCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    btnAgEditCD.PerformClick();
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

                txtFzFinEditCD.Focus();
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
                txtFzFinEditCD.Focus();
                e.Handled = true;
            }
        }

        private void txtFzFinEditCD_Click(object sender, EventArgs e)
        {
            txtFzFinEditCD.SelectAll();
        }

        private void btnAgEditCD_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = Convert.ToDouble(txtcx1EditCD.Text);
                double x2 = Convert.ToDouble(txtcx2EditCD.Text);
                double f1 = Convert.ToDouble(txtFzInEditCD.Text);
                double f2 = Convert.ToDouble(txtFzFinEditCD.Text);

                if (txtcx1EditCD.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada en x1");
                    txtcx1EditCD.Focus();
                }
                else if (Convert.ToDouble(txtcx1EditCD.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x1 no debe exceder la longitud de la viga");
                    txtcx1EditCD.Focus();
                }
                else if (txtFzInEditCD.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese fuerza inicial");
                    txtFzInEditCD.Focus();
                }
                else if (txtFzInEditCD.Text == "0" && txtFzFinEditCD.Text == "0")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Ambas fuerzas no pueden ser 0");
                    txtFzInEditCD.Focus();
                }
                else if (txtcx2EditCD.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada en x2");
                    txtcx2EditCD.Focus();
                }
                else if (Convert.ToDouble(txtcx2EditCD.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x2 no debe exceder la longitud de la viga");
                    txtcx2EditCD.Focus();
                }
                else if (txtFzFinEditCD.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese fuerza final");
                    txtFzFinEditCD.Focus();
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

        private void EditCD_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void EditCD_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void EditCD_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void EditCD_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblcxEditCD.Text = "Coordenada x1 [m]";
                lblcx2EditCD.Text = "Coordenada x2 [m]";
                lblFzInEditCD.Text = "Fuerza inicial [kN]";
                lblFzFinEditCD.Text = "Fuerza final [kN]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblcxEditCD.Text = "Coordenada x1 [ft]";
                lblcx2EditCD.Text = "Coordenada x2 [ft]";
                lblFzInEditCD.Text = "Fuerza inicial [kip]";
                lblFzFinEditCD.Text = "Fuerza final [kip]";
            }

            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void EditCD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
