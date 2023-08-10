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
    public partial class AgM : Form
    {
        string dirFlechaM = "01";
        Boolean draggable;
        int mouseX, mouseY;
        public AgM()
        {
            InitializeComponent();
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void AgM_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblcxAgM.Text = "Coordenada x [m]";
                lblMAgM.Text = "Magnitud [kN*m]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblcxAgM.Text = "Coordenada x [ft]";
                lblMAgM.Text = "Magnitud [kip*ft]";
            }

            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnMP.Image = Image.FromFile("ilustraciones/flechamomentopos.png");
            btnMN.Image = Image.FromFile("ilustraciones/flechamomentoneg.png");
            btnMP.BackColor = SystemColors.Control;
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            dirFlechaM = Convert.ToString(btnMP.Tag);
            btnMP.BackColor = SystemColors.Control;
            btnMN.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnMN_Click(object sender, EventArgs e)
        {
            dirFlechaM = Convert.ToString(btnMN.Tag);
            btnMN.BackColor = SystemColors.Control;
            btnMP.BackColor = System.Drawing.Color.Transparent;
        }

        private void txtcxAgM_Click(object sender, EventArgs e)
        {
            txtcxAgM.SelectAll();
        }

        private void txtMAgM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
       
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    btnAgM.PerformClick();
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

                txtMAgM.Focus();
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

                txtMAgM.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtMAgM.Focus();
                e.Handled = true;
            }
        }

        private void txtMAgM_Click(object sender, EventArgs e)
        {
            txtMAgM.SelectAll();
        }

        private void btnAgM_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtcxAgM.Text);
                double m = Convert.ToDouble(txtMAgM.Text);

                if (txtcxAgM.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada x");
                    txtcxAgM.Focus();
                }
                else if ( x > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x no debe exceder la longitud de la viga");
                    txtcxAgM.Focus();
                }
                else if (txtMAgM.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese magnitud");
                    txtMAgM.Focus();
                }
                else
                {
                  
                        int n = PagPrincipal.Pag.dtgFyM.Rows.Add();

                      

                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[0].Value = "M";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[1].Value = txtcxAgM.Text;
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[2].Value = txtcxAgM.Text;
                        if (dirFlechaM == "02")
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[6].Value = "-" + txtMAgM.Text;
                        }
                        else if (dirFlechaM == "01")
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[6].Value = txtMAgM.Text;
                        }

                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[3].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[4].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[5].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");

                        PagPrincipal.Pag.tabCgVgPP.Invalidate();

                        txtcxAgM.Text = "";
                        txtMAgM.Text = "";
                        txtcxAgM.Focus();
                    
                


                }
            }
            catch (Exception)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Formato no válido");
            }

         
        }

        private void AgM_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void AgM_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void AgM_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void txtcxAgM_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
