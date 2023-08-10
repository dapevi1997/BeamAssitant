using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BaMod
{
    public partial class PagInicio : Form
    {
        string qr1, qr2, qr3, qr4, qr5, qr6,qr7;
        string conStrg1, conStrg2;
        SQLiteConnection con1, con2;
        SQLiteDataAdapter adp1, adp2, adp3, adp4, adp5,adp6, adp7;
        private static DataTable acero11 = new DataTable();
        private static DataTable pwus11 = new DataTable();
        private static DataTable psus11 = new DataTable();
        private static DataTable pwis11 = new DataTable();
        private static DataTable psis11 = new DataTable();
        private static DataTable pcis11 = new DataTable();
        private static DataTable pcus11 = new DataTable();

        public static DataTable Acero1
        {
            get
            {
                return acero11;

            }

        }

        public static DataTable Pwus1
        {
            get
            {
                return pwus11;
            }
        }
        public static DataTable Psus1
        {
            get
            {
                return psus11;
            }
        }
        public static DataTable Pwis1
        {
            get
            {
                return pwis11;
            }
        }
        public static DataTable Psis1
        {
            get
            {
                return psis11;
            }
        }

        public static DataTable Pcis1
        {
            get
            {
                return pcis11;
            }
        }
        public static DataTable Pcus1
        {
            get
            {
                return pcus11;
            }
        }


        public PagInicio()
        {
            InitializeComponent();
        }

        private void tmInicio_Tick(object sender, EventArgs e)
        {
            tmInicio.Enabled = false;
            PagPrincipal PP = new PagPrincipal();
            this.Hide();
            PP.Show();
            

        }

        private void PagInicio_Load(object sender, EventArgs e)
        {

            this.BackgroundImage = Image.FromFile("ilustraciones/inicio.png");
        
            conStrg1 = "Data Source=basesdedatos/materiales/material.db;Version=3;New=True;Compress=True;";
            conStrg2 = "Data Source=basesdedatos/perfiles/perfiles.db;Version=3;New=True;Compress=True;";
           



            con1 = new SQLiteConnection(conStrg1);
            con2 = new SQLiteConnection(conStrg2);
            qr1 = "SELECT id,nombre,tus,cus,tis,cis  FROM acero";
            qr2 = "SELECT id,nombre,sminus,dus,pesous,bfus,tfus,twus,ixus FROM pwus";
            qr3 = "SELECT id,nombre,sminus,dus,pesous,bfus,tfus,twus,ixus FROM psus";
            qr4 = "SELECT id,nombre,sminis,dis,pesois,bfis,tfis,twis,ixis FROM pwis";
            qr5 = "SELECT id,nombre,sminis,dis,pesois,bfis,tfis,twis,ixis FROM psis";
            qr6 = "SELECT id,nombre,sminis,dis,pesois,bfis,tfis,twis,ixis FROM pcis";
            qr7 = "SELECT id,nombre,sminus,dus,pesous,bfus,tfus,twus,ixus FROM pcus";

            try
            {

                con1.Open();
                con2.Open();
                adp1 = new SQLiteDataAdapter(qr1, con1);
                adp2 = new SQLiteDataAdapter(qr2, con2);
                adp3 = new SQLiteDataAdapter(qr3, con2);
                adp4 = new SQLiteDataAdapter(qr4, con2);
                adp5 = new SQLiteDataAdapter(qr5, con2);
                adp6 = new SQLiteDataAdapter(qr6, con2);
                adp7 = new SQLiteDataAdapter(qr7, con2);
                adp1.Fill(acero11);
                adp2.Fill(pwus11);
                adp3.Fill(psus11);
                adp4.Fill(pwis11);
                adp5.Fill(psis11);
                adp6.Fill(pcis11);
                adp7.Fill(pcus11);

                con1.Close();
                con2.Close();

                //PagPrincipal.Pag.Pwus1 = pwus11;
                //PagPrincipal.Pag.Acero1 = acero11;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            pbsalPI.Image = Image.FromFile("ilustraciones/btnsalir.png");
        }

        private void pbsalPI_MouseEnter(object sender, EventArgs e)
        {
            pbsalPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(242)))));
        }

        private void pbsalPI_MouseLeave(object sender, EventArgs e)
        {
            pbsalPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(146)))), ((int)(((byte)(220)))));
        }

        private void pbsalPI_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
