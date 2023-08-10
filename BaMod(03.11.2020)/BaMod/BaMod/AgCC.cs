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
    public partial class AgCC : Form
    {
        string dirFlecha = "01";
        Boolean draggable;
        int mouseX, mouseY;
        public AgCC()
        {
            InitializeComponent();
           
        }

        private void btnCanAgCC_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void AgCC_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnFaAgCC.Image = Image.FromFile("ilustraciones/flecAbj.png");
            btnFarrCC.Image = Image.FromFile("ilustraciones/flecArr.png");
            btnFaAgCC.BackColor = SystemColors.Control;

            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblCxCC.Text = "Coordenada x [m]";
                lblMgCC.Text = "Magnitud [kN]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblCxCC.Text = "Coordenada x [ft]";
                lblMgCC.Text = "Magnitud [kip]";
            }

        }

        private void txtCXCC_KeyPress(object sender, KeyPressEventArgs e)
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

                txtCXCC.Focus();
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

                txtCXCC.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtCXCC.Focus();
                e.Handled = true;
            }
        }

        private void txtCXCC_Click(object sender, EventArgs e)
        {
            txtCXCC.SelectAll();
        }

        private void txtMgCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    btnAgCC.PerformClick();
                }
                else
                {
                    e.Handled = false;
                }

            }
            else if (Convert.ToString(e.KeyChar) == "-")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("No se admiten números negativos");

                txtMgCC.Focus();
                e.Handled = true;
            }
            else if (Convert.ToString(e.KeyChar) == ".")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Decimales con coma");

                txtMgCC.Focus();
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
                txtMgCC.Focus();
                e.Handled = true;
            }
        }

        private void txtMgCC_Click(object sender, EventArgs e)
        {
            txtMgCC.SelectAll();
        }

        private void btnAgCC_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtCXCC.Text);
                double m = Convert.ToDouble(txtMgCC.Text);

                if (PagPrincipal.Pag.TabCtrlPanelPrincipal.Controls.Contains(PagPrincipal.Pag.tabDiag) == true)
                {
                    PagPrincipal.Pag.TabCtrlPanelPrincipal.TabPages.Remove(PagPrincipal.Pag.tabDiag);
                }
                if (PagPrincipal.Pag.TabCtrlPanelPrincipal.Controls.Contains(PagPrincipal.Pag.tabPerf) == true)
                {
                    PagPrincipal.Pag.TabCtrlPanelPrincipal.TabPages.Remove(PagPrincipal.Pag.tabPerf);
                }
                if (txtCXCC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese coordenada en x");
                    txtCXCC.Focus();
                }
                else if (Convert.ToDouble(txtCXCC.Text) > PagPrincipal.LV)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Coordenada x no debe exceder la longitud de la viga");
                    txtCXCC.Focus();
                }
                else if (txtMgCC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese magnitud");
                    txtMgCC.Focus();
                }
                else if (txtMgCC.Text == "0")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Por favor, ingrese magnitud diferente de 0");
                    txtMgCC.Focus();
                }
                else
                {
                   
                        int n = PagPrincipal.Pag.dtgFyM.Rows.Add();

                   

                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[0].Value = "CC";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[1].Value = txtCXCC.Text;
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[2].Value = txtCXCC.Text;
                        if (dirFlecha == "01")
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[3].Value = "-" + txtMgCC.Text;
                        }
                        else if (dirFlecha == "02")
                        {
                            PagPrincipal.Pag.dtgFyM.Rows[n].Cells[3].Value = txtMgCC.Text;
                        }

                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[4].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[5].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[6].Value = "NA";
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                        PagPrincipal.Pag.dtgFyM.Rows[n].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");

                        PagPrincipal.Pag.tabCgVgPP.Invalidate();

                        txtCXCC.Text = "";
                        txtMgCC.Text = "";
                        txtCXCC.Focus();
                    
               

                }
            }
            catch (Exception)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Formato no válido");

            }

       
           
         
        }

        private void btnFaAgCC_Click(object sender, EventArgs e)
        {
            dirFlecha = Convert.ToString(btnFaAgCC.Tag);
            btnFaAgCC.BackColor = SystemColors.Control;
            btnFarrCC.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnFarrCC_Click(object sender, EventArgs e)
        {
            dirFlecha = Convert.ToString(btnFarrCC.Tag);
            btnFarrCC.BackColor = SystemColors.Control;
            btnFaAgCC.BackColor = System.Drawing.Color.Transparent;
        }

        private void AgCC_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void AgCC_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void AgCC_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void AgCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
