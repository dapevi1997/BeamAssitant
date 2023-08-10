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
    public partial class AgCD : Form
    {
        string dirFlechaCD = "01";
        int ndeclick = 0;
        Boolean draggable;
        int mouseX, mouseY;
        public AgCD()
        {
            InitializeComponent();
        }

        private void btnCanCD_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void AgCD_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblCx1CD.Text = "Coordenada x1 [m]";
                lblCx2CD.Text = "Coordenada x2 [m]";
                lblM1CD.Text = "Magnitud inicial [kN/m]";
                lblM2CD.Text = "Magnitud final [kN/m]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblCx1CD.Text = "Coordenada x1 [ft]";
                lblCx2CD.Text = "Coordenada x2 [ft]";
                lblM1CD.Text = "Magnitud inicial [kip/ft]";
                lblM2CD.Text = "Magnitud final [kip/ft]";
            }

            ndeclick = 0;
            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnFaAgCD.Image = Image.FromFile("ilustraciones/flecAbj.png");
            btnFarrAgCD.Image = Image.FromFile("ilustraciones/flecArr.png");
            btnFaAgCD.BackColor = SystemColors.Control;
        }

        private void btnFaAgCD_Click(object sender, EventArgs e)
        {
            dirFlechaCD = Convert.ToString(btnFaAgCD.Tag);
            btnFaAgCD.BackColor = SystemColors.Control;
            btnFarrAgCD.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnFarrAgCD_Click(object sender, EventArgs e)
        {
            dirFlechaCD = Convert.ToString(btnFarrAgCD.Tag);
            btnFarrAgCD.BackColor = SystemColors.Control;
            btnFaAgCD.BackColor = System.Drawing.Color.Transparent;
        }

        private void txtCX1CC_KeyPress(object sender, KeyPressEventArgs e)
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

                txtCX1CC.Focus();
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

                txtCX1CC.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtCX1CC.Focus();
                e.Handled = true;
            }
        }

        private void txtCX1CC_Click(object sender, EventArgs e)
        {
            txtCX1CC.SelectAll();
        }

        private void txtCX2CC_KeyPress(object sender, KeyPressEventArgs e)
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

                txtCX2CC.Focus();
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

                txtCX2CC.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtCX2CC.Focus();
                e.Handled = true;
            }
        }

        private void txtCX2CC_Click(object sender, EventArgs e)
        {
            txtCX2CC.SelectAll();
        }

        private void txtM1CD_KeyPress(object sender, KeyPressEventArgs e)
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

                txtM1CD.Focus();
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

                txtM1CD.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtM1CD.Focus();
                e.Handled = true;
            }
        }

        private void txtM1CD_Click(object sender, EventArgs e)
        {
            txtM1CD.SelectAll();
        }

        private void txtM2CD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    btnAgCD.PerformClick();
                }
                else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    btnCanCD.PerformClick();
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

                txtM2CD.Focus();
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

                txtM2CD.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtM2CD.Focus();
                e.Handled = true;
            }
        }

        private void txtM2CD_Click(object sender, EventArgs e)
        {
           
            ndeclick++;
            if (ndeclick == 1)
            {
                txtM2CD.Text = txtM1CD.Text;
            }
            
            txtM2CD.SelectAll();
        }

        private void btnAgCD_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = Convert.ToDouble(txtCX1CC.Text);
                double x2 = Convert.ToDouble(txtCX2CC.Text);
                double f1 = Convert.ToDouble(txtM1CD.Text);
                double f2 = Convert.ToDouble(txtM2CD.Text);

                ndeclick = 0;
                if (txtCX1CC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada x1");
                    txtCX1CC.Focus();
                }
                else if (txtCX2CC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada x2");
                    txtCX2CC.Focus();
                }
                else if (Convert.ToDouble(txtCX1CC.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x1 no debe exceder la longitud de la viga");
                    txtCX1CC.Focus();
                }
                else if (Convert.ToDouble(txtCX2CC.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x2 no debe exceder la longitud de la viga");
                    txtCX2CC.Focus();
                }
                else if (txtM1CD.Text == "" )
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese magnitud inicial");
                    txtM1CD.Focus();
                }
                else if (txtM2CD.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese magnitud final");
                    txtM2CD.Focus();
                }
                else if (txtM1CD.Text == "0" && txtCX2CC.Text == "0")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Magnitudes iniciales y finales no deben ser 0 simualtáneamente");
                    txtM1CD.Focus();
                }
                else
                {
                   
                        int n = PagPrincipal.Pag.dtgFyM.Rows.Add();
                     

                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[0].Value = "CD";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[1].Value = txtCX1CC.Text;
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[2].Value = txtCX2CC.Text;
                        if (dirFlechaCD == "01")
                        {
                        if (f1 == 0)
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[4].Value =   txtM1CD.Text;
                           
                        }
                        else
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[4].Value = "-" + txtM1CD.Text;
                           
                        }
                        if (f2 == 0)
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[5].Value = txtM2CD.Text;
                        }
                        else
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[5].Value = "-" + txtM2CD.Text;
                        }
                           

                        }
                        else if (dirFlechaCD == "02")
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[4].Value = txtM1CD.Text;
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[5].Value = txtM2CD.Text;
                        }

                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[3].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[6].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");

                        PagPrincipal.Pag.tabCgVgPP.Invalidate();

                        txtCX1CC.Text = "";
                        txtCX2CC.Text = "";
                        txtM1CD.Text = "";
                        txtM2CD.Text = "";
                        txtCX1CC.Focus();
                    
               

                }
            }
            catch (Exception)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Formato no válido");

            }

      
        }

        private void AgCD_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void AgCD_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void AgCD_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void AgCD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
        }

      
    }
}
