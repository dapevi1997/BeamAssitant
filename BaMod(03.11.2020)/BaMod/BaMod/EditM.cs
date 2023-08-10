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
    public partial class EditM : Form
    {
        Boolean draggable;
        int mouseX, mouseY;
        public EditM()
        {
            InitializeComponent();
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txtcxEditM_KeyPress(object sender, KeyPressEventArgs e)
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

                txtcxEditM.Focus();
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

                txtcxEditM.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtcxEditM.Focus();
                e.Handled = true;
            }
        }

        private void txtcxEditM_Click(object sender, EventArgs e)
        {
            txtcxEditM.SelectAll();
        }

        private void txtMeditM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    btnAgEditM.PerformClick();
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

                txtMeditM.Focus();
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
                txtMeditM.Focus();
                e.Handled = true;
            }
        }

        private void txtMeditM_Click(object sender, EventArgs e)
        {
            txtMeditM.SelectAll();
        }

        private void btnAgEditM_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtcxEditM.Text);
                double m = Convert.ToDouble(txtMeditM.Text);

                if (txtcxEditM.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada en x");
                    txtcxEditM.Focus();
                }
                else if (Convert.ToDouble(txtcxEditM.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x no debe exceder la longitud de la viga");
                    txtcxEditM.Focus();
                }
                else if (txtMeditM.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese momento");
                    txtMeditM.Focus();
                }
                else if (txtMeditM.Text == "0")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese momento diferente de 0");
                    txtMeditM.Focus();
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

        private void EditM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void EditM_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void EditM_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void EditM_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void EditM_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblcxEditM.Text = "Coordenada x [m]";
                lblMEditM.Text = "Momento [kN*m]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblcxEditM.Text = "Coordenada x [ft]";
                lblMEditM.Text = "Momento [kip*ft]";
            }

            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
    }
}
