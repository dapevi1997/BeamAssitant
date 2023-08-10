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
    public partial class AgMt : Form
    {
        private double eT, eC,mE;
        int Tabpag;
        int LtInd1;
        Boolean draggable;
        int mouseX, mouseY;
        int btnpresionado;// indica si hubo o no selección del material
        public AgMt()
        {
            InitializeComponent();
        }

        public double ep
        {
            get { return eT; }
        }
        public double ecp
        {
            get { return eC; }
        }
        public double me
        {
            get { return mE; }
        }
        public int tp
        {
            get { return Tabpag; }
        }
        public int ltind1
        {
            get { return LtInd1; }
        }
        public int Btnpresionado
        {
            get { return btnpresionado; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

                txtRT.Focus();
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

                txtRT.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtRT.Focus();
                e.Handled = true;
            }
        }

        private void txtRT_Click(object sender, EventArgs e)
        {
            txtRT.SelectAll();
        }

        private void txtRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    btnAgMt.PerformClick();
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

                txtRC.Focus();
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

                txtRC.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtRC.Focus();
                e.Handled = true;
            }
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            btnpresionado = 0;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAgCC_Click(object sender, EventArgs e)
        {


            if (Tabpag==1)
            {
                if (txtRT.Text == "0" || txtRT.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Ingresar 'Resistencia a la Tensión'");
                    txtRT.Focus();
                }
                else if (txtRC.Text == "0" || txtRC.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Ingresar 'Resistencia al corte'");
                    txtRC.Focus();
                }
                else if (txtME.Text == "0" || txtME.Text == "")
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Ingresar Módulo de Elasticidad");
                    txtRC.Focus();
                }
                else
                {
                    try
                    {
                      
                        btnpresionado = 1;
                        lbAcer.SelectedIndex = -1;
                        LtInd1 = -1;
                        eT = Convert.ToDouble(txtRT.Text);
                        eC = Convert.ToDouble(txtRC.Text);
                        mE = Convert.ToDouble(txtME.Text);

                        this.Close();
                    }
                    catch (Exception)
                    {
                        MssBox mssBox = new MssBox();
                        mssBox.Muestra("Formato no válido");
                       
                    }
               
                }
            }
            else if (Tabpag == 0)
            {
                if (lbAcer.SelectedIndex == -1)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Escoger material válido");
                    txtRT.Focus();
                }
              
                else
                {
                    Tabpag = TabCtrlAgMt.SelectedIndex;
                    LtInd1 = lbAcer.SelectedIndex;
                    Tabpag = TabCtrlAgMt.SelectedIndex;

                    btnpresionado = 1;
                   
                    this.Close();
                }
            }
       
           
         
        }

        private void AgMt_Load(object sender, EventArgs e)
        {
            if (PagPrincipal.Pag.unidadesget == 0)
            {
                lblTAgMt.Text = "Tensión [MPa]";
                lblCAgMt.Text = "Cortante [MPa]";
                lblME.Text = "Módulo de elasticidad [GPa]";
            }
            else if (PagPrincipal.Pag.unidadesget == 1)
            {
                lblTAgMt.Text = "Tensión [ksi]";
                lblCAgMt.Text = "Cortante [ksi]";
                lblME.Text = "Módulo de elasticidad [Mpsi]";
            }

            btnpresionado = 0;
            this.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           
            tabperzoAgMt.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            tabperzoAgMt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            TabCtrlAgMt.SelectedIndex = PagPrincipal.Pag.indPestMtget;
            lbAcer.SelectedIndex = PagPrincipal.Pag.indLisBXMatget;
            Tabpag = PagPrincipal.Pag.indPestMtget;


            if (PagPrincipal.Pag.indLisBXMatget != -1 && PagPrincipal.Pag.indPestMtget == 0)
            {
                txtRT.Text = "0";
                txtRC.Text = "0";
                txtME.Text = "0";
            }
            else
            {
                txtRT.Text = PagPrincipal.Pag.ETget.ToString();
                txtRC.Text = PagPrincipal.Pag.ECget.ToString();
                txtME.Text = PagPrincipal.Pag.MEget.ToString();

            }

           
        }

        private void TabCtrlAgMt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabpag = TabCtrlAgMt.SelectedIndex;
        }

        private void AgMt_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void AgMt_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void txtME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    btnAgMt.PerformClick();
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

                txtME.Focus();
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

                txtME.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtME.Focus();
                e.Handled = true;
            }
        }

        private void txtME_Click(object sender, EventArgs e)
        {
            txtME.SelectAll();
        }

        private void AgMt_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void AgMt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtRC_Click(object sender, EventArgs e)
        {
            txtRC.SelectAll();
        }
    }
}
