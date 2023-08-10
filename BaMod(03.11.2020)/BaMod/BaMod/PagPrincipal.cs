using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;


//using System.Windows.Forms.DataVisualization.Charting;

namespace BaMod
{
    public partial class PagPrincipal : Form
    {
        Read rr;
        //variables para hacer la forma draggable desde el panel
        Boolean draggable;
        int mouseX, mouseY;
        bool maximizado;// estado de la pagina principal
        //indice para ver qué tipo de apoyo es
        int indTipApoy;
        //variables de imagenes para la pantalla 
        Graphics g1, g2, g3,g4;
        Pen pluma = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219))))), 4);
        Pen pluma1 = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(162)))), ((int)(((byte)(128))))), 2);
        Pen pluma2 = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219))))), 4);
        Pen pluma3 = new Pen(Color.FromArgb(100,245,51,37) , 4);

        Font fuente1 = new Font(new FontFamily("Arial"), 10, FontStyle.Regular,GraphicsUnit.Point);
     
        Font fuenteperfiles = new Font(new FontFamily("Arial"), 15, FontStyle.Italic, GraphicsUnit.Point);
        SolidBrush bsuave = new SolidBrush(Color.FromArgb(242,205,177));
        SolidBrush bfuerte = new SolidBrush(Color.FromArgb(239,162,128));


        System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation anotacion = new System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation();
        System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation anotacionM = new System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation();
        System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation anotacionp = new System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation();
        System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation anotaciond = new System.Windows.Forms.DataVisualization.Charting.Border3DAnnotation();




        //vectores para extraer valores del datagridview para dibujar
        List<double> cxCC = new List<double>();
        List<double> MgCC = new List<double>();
        List<int> locationxCC = new List<int>();
        List<double> cx1CD = new List<double>();
        List<double> cx2CD = new List<double>();
        List<double> M1CD = new List<double>();
        List<double> M2CD = new List<double>();
        List<int> locationx1CD = new List<int>();
        List<int> locationx2CD = new List<int>();
        List<double> cxM = new List<double>();
        List<double> MgM = new List<double>();
        List<int> locationxM = new List<int>();

        //vectores auxiliares para el boton resolver
        List<double> f1c = new List<double>();
        List<double> a1c = new List<double>();
        List<double> a2c = new List<double>();
        List<double> f1tp = new List<double>();
        List<double> a1tp = new List<double>();
        List<double> a2tp = new List<double>();
        List<double> f1tn = new List<double>();
        List<double> a1tn = new List<double>();
        List<double> a2tn = new List<double>();
        List<double> f1trp = new List<double>();
        List<double> f2trp = new List<double>();
        List<double> a1trp = new List<double>();
        List<double> a2trp = new List<double>();
        List<double> f1trn = new List<double>();
        List<double> f2trn = new List<double>();
        List<double> a1trn = new List<double>();
        List<double> a2trn = new List<double>();
        List<double> xlabel = new List<double>();
        List<double> yDgCte = new List<double>();
        List<double> yDgMto = new List<double>();
        List<double> yDgPend = new List<double>();
        List<double> yDgDflx = new List<double>();
        //labels personalizados
        List<double> xaux = new List<double>();
        List<double> x1 = new List<double>();
        List<double> x2 = new List<double>();
        List<double> yaux = new List<double>();
        List<double> y1 = new List<double>();
        List<double> y2 = new List<double>();
        List<double> yauxM = new List<double>();
        List<double> y1M = new List<double>();
        List<double> y2M = new List<double>();
        //vectores fijos
        double[] yDgCteOpen = new double[2];
        double[] yDgCteClose = new double[2];
        double[] yDgMtoOpen = new double[2];
        double[] yDgMtoClose = new double[2];
        double[] yDgPOpen = new double[2];
        double[] yDgPClose = new double[2];
        double[] yDgDOpen = new double[2];
        double[] yDgDClose = new double[2];
        //bases de datos
        List<double> SmenSminpeso = new List<double>();
        List<int> SmenSminpesoid = new List<int>();
        List<double> pesoidPW = new List<double>();

       
        List<string> SmenSminpesoname = new List<string>();

        List<string> SmenSminpesoname1 = new List<string>();

        List<double> SmenSminpesoPS = new List<double>();
        List<string> SmenSminpesoPSname = new List<string>();
        List<string> SmenSminpesoPSname1 = new List<string>();
        List<int> SmenSminpesoPSid = new List<int>();
        List<double> pesoidPS = new List<double>();
        List<double> SmenSminpesoPC = new List<double>();
        List<int> SmenSminpesoPCid = new List<int>();
        List<string> SmenSminpesoPCname = new List<string>();
        List<double> pesoidPC = new List<double>();

        List<string> namevg = new List<string>();
        List<int> idvgautm = new List<int>();
        private DataTable autom = new DataTable("tabla");
        ListBox lbperf = new ListBox();
        ListBox lbnameperf = new ListBox();


        private DataTable acero1;
        private DataTable pwus1;
        private DataTable psus1;
        private DataTable pwis1;
        private DataTable psis1;
        private DataTable pcis1;
        private DataTable pcus1;
        int idvgsda = 0;


        double SumaMomentos, SumaFuerzas; 
        double FS = 1; //factor de seguridad y longitud
        private static double ltv=0,l,lcon=0;
        double R2,R1, yDgCtemay, yDgCtemen, yDgCtemayABS, yDgCtemenABS, yDgMtomay, yDgMtomen, yDgMtomayABS, yDgMtomenABS,MR;
        double yDgpenmen, yDgpenmay, yDgpenmayABS, yDgpenmenABS;
        double yDgdflxmen, yDgdflxmay, yDgdflxmenABS, yDgdflxmayABS;
        double ET; //esfuerzo normal permisible para material personalizado
        double EC; //esfuerzo cortante permisible para material personalizado
        double ETP=0; // Esfuerzo a tensión permisible para cualquier material que se selecciones
        double ECP=0; // Esfuerzo cortante permisible para cuqlueir material qu se selecciones
        double ME = 0; // módulo de elasticidad
        double In = 0; // momento de inercia
        double ei = 0;//multiplicacion de ME*In con conversiones
        double Smin;

        //variables para viga continua
        double Ra, Rb, Rc;
        //variable viga con un tramo en ....
        double Ma,Mb;
        


        int indPesñMat;
        int indLisBxMat;
        int x1igualx2 = 0, x1diferentex2, xdelyCtemayorABS, xdelyMtomayorABS, xdePenmayABS, xdeDflxABS;
        int ns = 3,ns1=3;//si se toma una viga con tramo en voladizo organizar las series dentro del chart
        int tv; // tramo en voladizo seleccionado desde abrir o desde drop
        int tc; // viga continua seleccionada desde abrir o desde drop
        int haymaterial; // indica si hay o no material escogido
        int unidades; // muestra en qupe unidades se está trabajando 0 para si y 1 para eu
        string fsincc, fsinr; // texto que contiene la función de singularidad

        //variables para anotaciones debajo de los chart
        double cteenxigual, x11=0, Mtoenxigual, x11M = 0, xp,xd,penxigual,denxigual;

     

        //accesores 
        public static PagPrincipal Pag;
        public string Mtset
        {
            
            set { Mtst.Text = value; }
        }
        public string lconstset
        {

            set { lconst.Text = value; }
        }
        public double ETget
        {
            get { return ET; }
        }
        public double ECget
        {
            get { return EC; }
        }
        public double MEget
        {
            get { return ME; }
        }
        public int indPestMtget
        {
            get { return indPesñMat; }
        }
        public int indLisBXMatget
        {
            get { return indLisBxMat; }
        }

        public int unidadesget
        {
            get { return unidades; }
        }
        public static double LTV
        {
            set
            {
                ltv = value;
            }
        }
        public static double LCON
        {
            set
            {
                lcon = value;
            }
        }

        public double ltvget
        {
            get { return ltv; }
        }
        public static double LV
        {
            get
            {
                return l;
            }
        }
     
        public double YxSA(double x)
        {
            double y=0;
          

            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FsingCP(cxCC[j], x) //cargas puntuales
                + f1c[j] * Fn.FSingMCP(a1c[j], x) - f1c[j] * Fn.FSingMCP(a2c[j], x) //carga rectangular
                + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) // triangulo pendiente positiva
                + (f1tn[j]) * Fn.FSingMCP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], x) //triandulo pendiente negativa
                + f1trp[j] * Fn.FSingMCP(a1trp[j], x) - f1trp[j] * Fn.FSingMCP(a2trp[j], x) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], x) //trapecio pendiente positiva
                + f2trn[j] * Fn.FSingMCP(a1trn[j], x) - f2trn[j] * Fn.FSingMCP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], x); //trapecio pendiente negativa

            }
           
          

            y = y + R1 * Fn.FsingCP(0, x) + R2 * Fn.FsingCP(l, x);

            y = Math.Round(y, 4);
            return y;
            
        }

        public double YMxSA(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCP(cxCC[j], x) +
                        +f1c[j] * Fn.FSingMCDR(a1c[j], x) - f1c[j] * Fn.FSingMCDR(a2c[j], x) + //
                        +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                        +f1tn[j] * Fn.FSingMCDR(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], x) +
                        +f1trp[j] * Fn.FSingMCDR(a1trp[j], x) - f1trp[j] * Fn.FSingMCDR(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], x) +
                        +f2trn[j] * Fn.FSingMCDR(a1trn[j], x) - f2trn[j] * Fn.FSingMCDR(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], x) +
                        -MgM[j] * Fn.FsingCP(cxM[j], x);
            }
            y = y + R1 * Fn.FSingMCP(0, x) + R2 * Fn.FSingMCP(l, x);
            y = Math.Round(y, 4);

            return y;

        }

        public double YxTV(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FsingCP(cxCC[j], x) +
                            +f1tp[j] * Fn.FSingMCP(a1tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                            +f1c[j] * Fn.FSingMCP(a1c[j], x) - f1c[j] * Fn.FSingMCP(a2c[j], x) //carga rectangular
                            + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                            +(f1tn[j]) * Fn.FSingMCP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], x) +
                            +f1trp[j] * Fn.FSingMCP(a1trp[j], x) - f1trp[j] * Fn.FSingMCP(a2trp[j], x) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], x) +
                            +f2trn[j] * Fn.FSingMCP(a1trn[j], x) - f2trn[j] * Fn.FSingMCP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], x);

            }
            y = y + R1 * Fn.FsingCP(0, x) + R2 * Fn.FsingCP(ltv, x);
            y = Math.Round(y, 4);
            return y;

        }

        public double YMxTV(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCP(cxCC[j], x) 
                     +f1c[j] * Fn.FSingMCDR(a1c[j], x) - f1c[j] * Fn.FSingMCDR(a2c[j], x)
                                      + f1tp[j] * Fn.FSingMCDR(a1tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                                      +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                                      +f1tn[j] * Fn.FSingMCDR(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], x) +
                                      +f1trp[j] * Fn.FSingMCDR(a1trp[j], x) - f1trp[j] * Fn.FSingMCDR(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], x) +
                                      +f2trn[j] * Fn.FSingMCDR(a1trn[j], x) - f2trn[j] * Fn.FSingMCDR(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], x) +
                                      -MgM[j] * Fn.FsingCP(cxM[j], x);
            }
            y = y + R1 * Fn.FSingMCP(0, x) + R2 * Fn.FSingMCP(ltv, x);
            y = Math.Round(y, 4);

            return y;

        }

        public double YxEI(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FsingCP(cxCC[j], x) 
                     +f1c[j] * Fn.FSingMCP(a1c[j], x) - f1c[j] * Fn.FSingMCP(a2c[j], x) //carga rectangular
                     + f1tp[j] * Fn.FSingMCP(a1tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tn[j]) * Fn.FSingMCP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], x) +
                     +f1trp[j] * Fn.FSingMCP(a1trp[j], x) - f1trp[j] * Fn.FSingMCP(a2trp[j], x) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], x) +
                     +f2trn[j] * Fn.FSingMCP(a1trn[j], x) - f2trn[j] * Fn.FSingMCP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], x);

            }
            y = y + R1 * Fn.FsingCP(0, x);
            y = Math.Round(y, 4);
            return y;

        }

        public double YMxEI(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCDR(a1c[j], x) - f1c[j] * Fn.FSingMCDR(a2c[j], x) + //
                   +f1tp[j] * Fn.FSingMCDR(a1tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +f1tn[j] * Fn.FSingMCDR(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], x) +
                   +f1trp[j] * Fn.FSingMCDR(a1trp[j], x) - f1trp[j] * Fn.FSingMCDR(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], x) +
                   +f2trn[j] * Fn.FSingMCDR(a1trn[j], x) - f2trn[j] * Fn.FSingMCDR(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], x) +
                   -MgM[j] * Fn.FsingCP(cxM[j], x);

            }
            y = y + R1 * Fn.FSingMCP(0, x) - MR * Fn.FsingCP(0, x);
            y = Math.Round(y, 4);

            return y;

        }

        public double YxC(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FsingCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCP(a1c[j], x) - f1c[j] * Fn.FSingMCP(a2c[j], x) //carga rectangular
                     + f1tp[j] * Fn.FSingMCP(a1tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tn[j]) * Fn.FSingMCP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], x) +
                     +f1trp[j] * Fn.FSingMCP(a1trp[j], x) - f1trp[j] * Fn.FSingMCP(a2trp[j], x) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], x) +
                     +f2trn[j] * Fn.FSingMCP(a1trn[j], x) - f2trn[j] * Fn.FSingMCP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], x);

            }
            y = y + Ra * Fn.FsingCP(0, x) + Rc * Fn.FsingCP(l, x) + Rb * Fn.FsingCP(lcon, x);
            y = Math.Round(y, 4);
            return y;

        }

        public double YMxC(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCDR(a1c[j], x) - f1c[j] * Fn.FSingMCDR(a2c[j], x) + //
                   +f1tp[j] * Fn.FSingMCDR(a1tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +f1tn[j] * Fn.FSingMCDR(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], x) +
                   +f1trp[j] * Fn.FSingMCDR(a1trp[j], x) - f1trp[j] * Fn.FSingMCDR(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], x) +
                   +f2trn[j] * Fn.FSingMCDR(a1trn[j], x) - f2trn[j] * Fn.FSingMCDR(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], x) +
                   -MgM[j] * Fn.FsingCP(cxM[j], x);

            }
            y = y + Ra * Fn.FSingMCP(0, x) + Rc * Fn.FSingMCP(l, x) + Rb * Fn.FSingMCP(lcon, x);
            y = Math.Round(y, 4);

            return y;

        }

        public double Yx5(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FsingCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCP(a1c[j], x) - f1c[j] * Fn.FSingMCP(a2c[j], x) //carga rectangular
                     + f1tp[j] * Fn.FSingMCP(a1tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tn[j]) * Fn.FSingMCP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], x) +
                     +f1trp[j] * Fn.FSingMCP(a1trp[j], x) - f1trp[j] * Fn.FSingMCP(a2trp[j], x) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], x) +
                     +f2trn[j] * Fn.FSingMCP(a1trn[j], x) - f2trn[j] * Fn.FSingMCP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], x);

            }
            y = y + Ra * Fn.FsingCP(0, x)  + Rb * Fn.FsingCP(l, x);
            y = Math.Round(y, 4);
            return y;

        }

        public double YMx5(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCDR(a1c[j], x) - f1c[j] * Fn.FSingMCDR(a2c[j], x) + //
                   +f1tp[j] * Fn.FSingMCDR(a1tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +f1tn[j] * Fn.FSingMCDR(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], x) +
                   +f1trp[j] * Fn.FSingMCDR(a1trp[j], x) - f1trp[j] * Fn.FSingMCDR(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], x) +
                   +f2trn[j] * Fn.FSingMCDR(a1trn[j], x) - f2trn[j] * Fn.FSingMCDR(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], x) +
                   -MgM[j] * Fn.FsingCP(cxM[j], x);

            }
            y = y + Ra * Fn.FSingMCP(0, x) -  Ma* Fn.FsingCP(0, x) + Rb * Fn.FSingMCP(l, x);
            y = Math.Round(y, 4);

            return y;

        }

        public double fsin3(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCDR(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCDTPP(a1c[j], x) - f1c[j] * Fn.FSingMCDTPP(a2c[j], x) + //
                   +f1tp[j] * Fn.FSingMCDTPP(a1tp[j], x) - f1tp[j] * Fn.FSingMCDTPP(a2tp[j], x) +
                   +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSing4(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSing4(a2tp[j], x) - f1tp[j] * Fn.FSingMCDTPP(a2tp[j], x) +
                   +f1tn[j] * Fn.FSingMCDTPP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSing4(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSing4(a2tn[j], x) +
                   +f1trp[j] * Fn.FSingMCDTPP(a1trp[j], x) - f1trp[j] * Fn.FSingMCDTPP(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSing4(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSing4(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDTPP(a2trp[j], x) +
                   +f2trn[j] * Fn.FSingMCDTPP(a1trn[j], x) - f2trn[j] * Fn.FSingMCDTPP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDTPP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSing4(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSing4(a2trn[j], x) +
                   -MgM[j] * Fn.FSingMCP(cxM[j], x);

            }
          

            return y;

        }

        public double fsin4(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCDTPP(cxCC[j], x) +
                     +f1c[j] * Fn.FSing4(a1c[j], x) - f1c[j] * Fn.FSing4(a2c[j], x) + //
                   +f1tp[j] * Fn.FSing4(a1tp[j], x) - f1tp[j] * Fn.FSing4(a2tp[j], x) +
                   +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSing5(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSing5(a2tp[j], x) - f1tp[j] * Fn.FSing4(a2tp[j], x) +
                   +f1tn[j] * Fn.FSing4(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSing5(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSing5(a2tn[j], x) +
                   +f1trp[j] * Fn.FSing4(a1trp[j], x) - f1trp[j] * Fn.FSing4(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSing5(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSing5(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSing4(a2trp[j], x) +
                   +f2trn[j] * Fn.FSing4(a1trn[j], x) - f2trn[j] * Fn.FSing4(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSing4(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSing5(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSing5(a2trn[j], x) +
                   -MgM[j] * Fn.FSingMCDR(cxM[j], x);

            }


            return y;

        }

        public double Yx6(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FsingCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCP(a1c[j], x) - f1c[j] * Fn.FSingMCP(a2c[j], x) //carga rectangular
                     + f1tp[j] * Fn.FSingMCP(a1tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], x) - f1tp[j] * Fn.FSingMCP(a2tp[j], x) +
                     +(f1tn[j]) * Fn.FSingMCP(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], x) +
                     +f1trp[j] * Fn.FSingMCP(a1trp[j], x) - f1trp[j] * Fn.FSingMCP(a2trp[j], x) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], x) +
                     +f2trn[j] * Fn.FSingMCP(a1trn[j], x) - f2trn[j] * Fn.FSingMCP(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], x);

            }
            y = y + Ra * Fn.FsingCP(0, x) + Rb * Fn.FsingCP(l, x);
            y = Math.Round(y, 4);
            return y;

        }

        public double YMx6(double x)
        {
            double y = 0;
            for (int j = 0; j < dtgFyM.Rows.Count; j++)
            {
                y += MgCC[j] * Fn.FSingMCP(cxCC[j], x) +
                     +f1c[j] * Fn.FSingMCDR(a1c[j], x) - f1c[j] * Fn.FSingMCDR(a2c[j], x) + //
                   +f1tp[j] * Fn.FSingMCDR(a1tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], x) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], x) - f1tp[j] * Fn.FSingMCDR(a2tp[j], x) +
                   +f1tn[j] * Fn.FSingMCDR(a1tn[j], x) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], x) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], x) +
                   +f1trp[j] * Fn.FSingMCDR(a1trp[j], x) - f1trp[j] * Fn.FSingMCDR(a2trp[j], x) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], x) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], x) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], x) +
                   +f2trn[j] * Fn.FSingMCDR(a1trn[j], x) - f2trn[j] * Fn.FSingMCDR(a2trn[j], x) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], x) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], x) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], x) +
                   -MgM[j] * Fn.FsingCP(cxM[j], x);

            }
            y = y + Ra * Fn.FSingMCP(0, x) + Rb * Fn.FSingMCP(l, x) + Ma * Fn.FsingCP(0, x) - Mb * Fn.FsingCP(l, x);
            y = Math.Round(y, 4);

            return y;

        }

        public double Ypsa(double x)
        {
            double C1, C2,y;

            C2 = -fsin4(0);
            C1 = -R1 * Math.Pow(l, 2) / 6 - fsin4(l) / l - C2 / l;
        
            y = R1 * Math.Pow(x, 2) / 2 + fsin3(x) + C1;
            y = (y) / (ei);
            
            return y;


        }

        public double Ydsa(double x)
        {
            double C1, C2, y;

            C2 = -fsin4(0);
            C1 = -R1 * Math.Pow(l, 2) / 6 - fsin4(l) / l - C2 / l;

            y = R1 * Math.Pow(x, 3) / 6 + fsin4(x) + C1 * x + C2;
            y = (y) / (ei);
            y = (y) * 1000;

            return y;


        }

        public double Yptv(double x)
        {
            double C1, C2,y;

            C2 = -fsin4(0);
            C1 = -R1 * Math.Pow(ltv, 2) / 6 - fsin4(ltv) / ltv - C2 / ltv;

        

           
                y = R1 * Math.Pow(x, 2) / 2 + fsin3(x) + C1 + R2 * Fn.FSingMCDR(ltv, x);
                y = (y) / (ei);

            return y;


        }

        public double Ydtv(double x)
        {
            double C1, C2,y;

            C2 = -fsin4(0);
            C1 = -R1 * Math.Pow(ltv, 2) / 6 - fsin4(ltv) / ltv - C2 / ltv;

       

           
                y = R1 * Math.Pow(x, 3) / 6 + fsin4(x) + C1 * x + C2 + R2 * Fn.FSingMCDTPP(ltv, x);
                y = (y) / (ei);
                y = (y) * 1000;

            return y;

        }

        public double Ypei(double x)
        {
            double C1, C2, y;

            C2 = -fsin4(0);
            C1 = -fsin3(0);




            y = R1 * Math.Pow(x, 2) / 2 + fsin3(x) + C1 - MR * x;
                y = (y) / (ei);
        
            

            return y;


        }

        public double Ydei(double x)
        {
            double C1, C2, y;
          

            C2 = -fsin4(0);
            C1 = -fsin3(0);

      

           
             
                y = R1 * Math.Pow(x, 3) / 6 + fsin4(x) + C1 * x + C2 - MR * Fn.FSingMCDR(0, x);
                y = (y) / (ei);
                y = (y) * 1000;
            

            return y;

        }

        public double Ypc(double x)
        {
            double C1, C2, y;

            C2 = -fsin4(0);
            C1 = -Ra * Math.Pow(lcon, 2) / 6 - fsin4(lcon) / lcon - C2 / l;

      

          
                y = Ra * Math.Pow(x, 2) / 2 + Rb * Fn.FSingMCDR(lcon, x) + fsin3(x) + C1;
                y = (y) / (ei);
         
            

            return y;
        }

        public double Ydc(double x)
        {
            double C1, C2, y;


            C2 = -fsin4(0);
            C1 = -Ra * Math.Pow(lcon, 2) / 6 - fsin4(lcon) / lcon - C2 / l;

    

           
              
                y = Ra * Math.Pow(x, 3) / 6 + Rb * Fn.FSingMCDTPP(lcon, x) + fsin4(x) + C1 * x + C2;
                y = (y) / (ei);
                y = (y) * 1000;
            


            return y;

        }

        public double Yp5(double x)
        {
            double C1, C2, y;

            C2 = -fsin4(0);
            C1 = -fsin3(0);


           
                y = Ra * Math.Pow(x, 2) / 2 - Ma * x + fsin3(x) + C1;
                y = (y) / (ei);
             
            



            return y;
        }

        public double Yd5(double x)
        {
            double C1, C2, y;


            C2 = -fsin4(0);
            C1 = -fsin3(0);

       

            
            
                y = Ra * Math.Pow(x, 3) / 6 - Ma * Math.Pow(x, 2) / 2 + fsin4(x) + C1 * x + C2;
                y = (y) / (ei);
                y = (y) * 1000;
            



            return y;

        }

        public double Yp6(double x)
        {
            double C1, C2, y;

            C2 = -fsin4(0);
            C1 = -fsin3(0);

     

         
                y = Ra * Math.Pow(x, 2) / 2 + Ma * x + fsin3(x) + C1;
                y = (y) / (ei);
           
            





            return y;
        }

        public double Yd6(double x)
        {
            double C1, C2, y;


            C2 = -fsin4(0);
            C1 = -fsin3(0);

     

          
           
                y = Ra * Math.Pow(x, 3) / 6 + Ma * Math.Pow(x, 2) / 2 + fsin4(x) + C1 * x + C2;
                y = (y) / (ei);
                y = (y) * 1000;
            




            return y;

        }
        public PagPrincipal()
        {
            InitializeComponent();
            PagPrincipal.Pag = this;
         
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PagPrincipal_Load(object sender, EventArgs e)
        {
            unidades = 0;
            if (unidades == 0)
            {
                lblLPP.Text = "                Longitud [m]";
                cx1.HeaderText = "Coordenada x1 [m]";
                cx2.HeaderText = "Coordenada x2 [m]";
                Fza.HeaderText = "Fuerza [kN]";
                Fza1.HeaderText = "Fuerza inicial [kN/m]";
                Fza2.HeaderText = "Fuerza final [kN/m]";
                Mto.HeaderText = "Momento [kN*m]";
            }
            else if (unidades == 1)
            {
                lblLPP.Text = "                Longitud [ft]";
                cx1.HeaderText = "Coordenada x1 [ft]";
                cx2.HeaderText = "Coordenada x2 [ft]";
                Fza.HeaderText = "Fuerza [kip]";
                Fza1.HeaderText = "Fuerza inicial [kip/ft]";
                Fza2.HeaderText = "Fuerza final [kip/ft]";
                Mto.HeaderText = "Momento [kip*ft]";
            }

            maximizado = false;
            pbMaxPP.Image = Image.FromFile("ilustraciones/btnmax0.png");

            pblogo.Image = Image.FromFile("ilustraciones/logo.png");
            pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            pnlIzquierdo.BackgroundImage = Image.FromFile("ilustraciones/degradado.png");
            pnlSuperior.BackgroundImage = Image.FromFile("ilustraciones/degradadosuperior.png");
           
            lblFSPP.Image = Image.FromFile("ilustraciones/factordeseguridad.png");
            lblFSPP.ImageAlign = ContentAlignment.MiddleLeft;
            lblAp.Image = Image.FromFile("ilustraciones/apoyo.png");
            lblAp.ImageAlign = ContentAlignment.MiddleLeft;
            lblLPP.Image = Image.FromFile("ilustraciones/longitud.png");
            lblLPP.ImageAlign = ContentAlignment.MiddleLeft;
            lblPfPP.Image = Image.FromFile("ilustraciones/perfil.png");
            lblPfPP.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgMtPP.Image = Image.FromFile("ilustraciones/material.png");
            btnAgMtPP.ImageAlign = ContentAlignment.MiddleLeft;
            btnCPPP.Image = Image.FromFile("ilustraciones/cargacon.png");
            btnCPPP.ImageAlign = ContentAlignment.MiddleLeft;
            btnCDPP.Image = Image.FromFile("ilustraciones/cargadis.png");
            btnCDPP.ImageAlign = ContentAlignment.MiddleLeft;
            btnMPP.Image = Image.FromFile("ilustraciones/momentoi.png");
            btnMPP.ImageAlign = ContentAlignment.MiddleLeft;

            pbsalPP.Image = Image.FromFile("ilustraciones/btnsalir.png");
            pbminPP.Image = Image.FromFile("ilustraciones/btnminimizar.png");
         
            pbfaPP.Image = Image.FromFile("ilustraciones/fabjbtn.png");
            pbfaPP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbfaPP.Location = new Point (263,14);
            btnCgyMPP.Controls.Add(pbfaPP);

         

            cbApyPP.SelectedIndex = 0;
            cbPfPP.SelectedIndex = 0;
            chkbSDPP.Checked = true;
            TabCtrlPanelPrincipal.SelectedIndex = 0;
            pnlCyMPP.Hide();
            dtgFyM.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dtgFyM.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtgFyM.AlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            indLisBxMat = -1;
            Mtst.Visible = false;
            ltvst.Visible = false;
            pyc.Visible = false;
            pyc2.Visible = false;
            pyc3.Visible = false;
            R1st.Visible = false;
            R2st.Visible = false;
            MRst.Visible = false;
            pyc4.Visible = false;
            pyc5.Visible = false;
            pyc6.Visible = false;
            pyc7.Visible = false;
            pyc8.Visible = false;
            pyc9.Visible = false;
            pyc10.Visible = false;
            Rast.Visible = false;
            Rbst.Visible = false;
            Rcst.Visible = false;
            Mast.Visible = false;
            Mbst.Visible = false;


            if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }

            //traer bases de datos
            acero1 = PagInicio.Acero1;
            pwus1 = PagInicio.Pwus1;
            psus1 = PagInicio.Psus1;
            pwis1 = PagInicio.Pwis1;
            psis1 = PagInicio.Psis1;
            pcis1 = PagInicio.Pcis1;
            pcus1 = PagInicio.Pcus1;


        }

        private void pictBxSPP_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //botones minimizar y salir de la pagina principal
        private void pbminPP_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbsalPP_MouseEnter(object sender, EventArgs e)
        {
            pbsalPP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(242)))));
        }

        private void pbsalPP_MouseLeave(object sender, EventArgs e)
        {
            pbsalPP.BackColor = Color.Transparent;
        }

        private void pbminPP_MouseEnter(object sender, EventArgs e)
        {
            pbminPP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(242)))));
        }

        private void pbminPP_MouseLeave(object sender, EventArgs e)
        {
            pbminPP.BackColor = Color.Transparent;
        }

        //Panel izquierdo

 

        private void btnAgMtPP_Click(object sender, EventArgs e)
        {
            int btnpresionado;


            AgMt miformaAgmt = new AgMt();
            miformaAgmt.ShowDialog();
           
            indPesñMat = miformaAgmt.tp;
            indLisBxMat = miformaAgmt.ltind1;
            btnpresionado = miformaAgmt.Btnpresionado;
            if (btnpresionado == 0 && haymaterial == 0)
            {
                haymaterial = 0;
            }
            else if (btnpresionado == 1)
            {
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx))
                {
                    TabCtrlPanelPrincipal.Controls.Remove(tabPenyDflx);
                }
                if (indPesñMat == 0 && indLisBxMat != -1)
                {
                    if (unidades == 0)
                    {
                        
                        ET = double.Parse(acero1.Rows[indLisBxMat][4].ToString());
                        EC = double.Parse(acero1.Rows[indLisBxMat][5].ToString());
                        Mtst.Text = "Mt: " + acero1.Rows[indLisBxMat][1];
                        haymaterial = 1;
                    }
                    else if (unidades == 1)
                    {
                       
                        ET = double.Parse(acero1.Rows[indLisBxMat][2].ToString());
                        EC = double.Parse(acero1.Rows[indLisBxMat][3].ToString());
                        Mtst.Text = "Mt: " + acero1.Rows[indLisBxMat][1];
                        haymaterial = 1;
                    }
                 
                }
                else if (indPesñMat == 1)
                {
                    ET = miformaAgmt.ep;
                    EC = miformaAgmt.ecp;
                    ME = miformaAgmt.me;
                    Mtst.Text = "Mt: Perzonalizado";
                    haymaterial = 1;
                }
            }

     

            ETP = ET / FS;
            ECP = EC / FS;

            Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
               + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();

            Mtst.Visible = true;
            if (cbApyPP.SelectedIndex == 1)
            {
                ltvst.Visible = true;
                pyc.Visible = true;

            }
            else
            {
                ltvst.Visible = false;
                pyc.Visible = false;
            }

            if (cbApyPP.SelectedIndex == 3)
            {
                lconst.Visible = true;
                pyc9.Visible = true;
            }
            else
            {
                lconst.Visible = false;
                pyc9.Visible = false;
            }
            R1st.Visible = false;
            R2st.Visible = false;
            MRst.Visible = false;
            pyc2.Visible = false;
            pyc3.Visible = false;
            pyc4.Visible = false;
            pyc5.Visible = false;
            pyc6.Visible = false;
            pyc7.Visible = false;
            pyc8.Visible = false;
            Rast.Visible = false;
            Rbst.Visible = false;
            Rcst.Visible = false;
            Mbst.Visible = false;
            pyc9.Visible = false;
            lconst.Visible = false;
        }

        private void txtFSPP_TextChanged(object sender, EventArgs e)
        {
            Mtst.Visible = true;
            if (cbApyPP.SelectedIndex == 1)
            {
                ltvst.Visible = true;
                pyc.Visible = true;

            }
            else
            {
                ltvst.Visible = false;
                pyc.Visible = false;
            }

            R1st.Visible = false;
            R2st.Visible = false;
            MRst.Visible = false;
            pyc2.Visible = false;
            pyc3.Visible = false;
            pyc4.Visible = false;

            if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }

            try
            {
                if (Convert.ToDouble(txtFSPP.Text) >= 1)
                {
                    FS = Convert.ToDouble(txtFSPP.Text);
                    ETP = ET / FS;
                    ECP = EC / FS;

                    Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                  + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                }
                else
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Factor de seguridad debe ser mayor o igual que 1");
                }
             
            }
            catch (FormatException)
            {

                txtFSPP.Text = "";
            }
        }

        private void chkbSDPP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbSDPP.Checked == true)
            {
                chkbDyPPP.Checked = false;

                Mtst.Visible = false;
                R1st.Visible = false;
                R2st.Visible = false;
                MRst.Visible = false;
                Rast.Visible = false;
                Rbst.Visible = false;
                Rcst.Visible = false;
                Mast.Visible = false;
                Mbst.Visible = false;
                pyc2.Visible = false;
                pyc3.Visible = false;
                pyc4.Visible = false;
                pyc.Visible = false;
                pyc5.Visible = false;
                pyc6.Visible = false;
                pyc7.Visible = false;
                pyc8.Visible = false;
                pyc9.Visible = false;
                pyc10.Visible = false;
                if (cbApyPP.SelectedIndex == 1)
                {
                    ltvst.Visible = true;
                }
                else
                {
                    ltvst.Visible = false;
                }
                if (cbApyPP.SelectedIndex == 3)
                {
                    lconst.Visible = true;
                }
                else
                {
                    lconst.Visible = false;
                }


                btnAgMtPP.Hide();
                lblFSPP.Hide();
                txtFSPP.Hide();
                lblPfPP.Hide();
                cbPfPP.Hide();
                lblLPP.Location = new Point(0, 230);
                txtLPP.Location = new Point(200, 235);
                lblAp.Location = new Point(0, 270);
                cbApyPP.Location = new Point(150, 275);
                btnCgyMPP.Location = new Point(0, 310);
                pnlCyMPP.Location = new Point(0, 350);

                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }

            }
            else
            {
                chkbDyPPP.Checked = true;

                Mtst.Visible = true;
                R1st.Visible = false;
                R2st.Visible = false;
                MRst.Visible = false;
                pyc2.Visible = false;
                pyc3.Visible = false;
                pyc4.Visible = false;
                pyc5.Visible = false;
                pyc6.Visible = false;
                pyc7.Visible = false;
                pyc8.Visible = false;
            
                pyc10.Visible = false;
                Rast.Visible = false;
                Rbst.Visible = false;
                Rcst.Visible = false;
                Mast.Visible = false;
                Mbst.Visible = false;
                if (cbApyPP.SelectedIndex == 1)
                {
                    ltvst.Visible = true;
                    pyc.Visible = true;
                }
                else
                {
                    ltvst.Visible = false;
                    pyc.Visible = false;
                }
                if (cbApyPP.SelectedIndex == 3)
                {
                    lconst.Visible = true;
                    pyc9.Visible = true;
                }
                else
                {
                    lconst.Visible = false;
                    pyc9.Visible = false;
                }

                btnAgMtPP.Location = new Point(0,230);
                btnAgMtPP.Show();
                lblFSPP.Show();
                txtFSPP.Show();
                lblFSPP.Location = new Point(0, 270);
                txtFSPP.Location = new Point(200, 275);
                lblPfPP.Location = new Point(0,310);
                lblPfPP.Show();
                cbPfPP.Location = new Point(150,318);
                cbPfPP.Show();
                lblLPP.Location = new Point(0, 350);
                txtLPP.Location = new Point(200, 355);
                lblAp.Location = new Point(0, 390);
                cbApyPP.Location = new Point(150, 395);
                btnCgyMPP.Location = new Point(0, 430);
                pnlCyMPP.Location = new Point(0, 470);

                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }
            }
        }

        private void chartV_MouseMove(object sender, MouseEventArgs e)
        {
            if (indTipApoy == 0)
            {
                if (btncxV.Checked == true)
                {
                    chartV.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartV.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartV.ChartAreas[0].CursorY.SetCursorPosition(YxSA(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartV.Series[ns+5].Points.Clear();
                            chartV.Series[ns+5].Points.AddXY(pX, YxSA(pX));
                            chartV.Series[ns+5].MarkerSize = 8;
                            chartV.Series[ns+5].Color = Color.Blue;
                            chartV.Series[ns+5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartV.Annotations.Clear();

                            anotacion.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacion.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacion.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacion.LineColor = System.Drawing.Color.Empty;
                            anotacion.Name = "ant";
                            anotacion.Text = "x: " + pX.ToString() + "\r\n" + "V: " + YxSA(pX).ToString();
                            anotacion.AxisXName = "ChartArea1\\rX";
                            anotacion.YAxisName = "ChartArea1\\rY";
                            anotacion.X = pX;
                            anotacion.Y = YxSA(pX);
                            chartV.Annotations.Add(anotacion);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartV.Series[ns+5].Points.Clear();
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartV.Annotations.Clear();

                }
            }
            else if (indTipApoy == 1)
            {
                if (btncxV.Checked == true)
                {
                    chartV.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartV.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartV.ChartAreas[0].CursorY.SetCursorPosition(YxTV(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartV.Series[ns+5].Points.Clear();
                            chartV.Series[ns+5].Points.AddXY(pX, YxTV(pX));
                            chartV.Series[ns+5].MarkerSize = 8;
                            chartV.Series[ns+5].Color = Color.Blue;
                            chartV.Series[ns+5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartV.Annotations.Clear();

                            anotacion.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacion.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacion.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacion.LineColor = System.Drawing.Color.Empty;
                            anotacion.Name = "ant";
                            anotacion.Text = "x: " + pX.ToString() + "\r\n" + "V: " + YxTV(pX).ToString();
                            anotacion.AxisXName = "ChartArea1\\rX";
                            anotacion.YAxisName = "ChartArea1\\rY";
                            anotacion.X = pX;
                            anotacion.Y = YxTV(pX);
                            chartV.Annotations.Add(anotacion);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartV.Series[ns+5].Points.Clear();
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartV.Annotations.Clear();

                }
            }
            else if (indTipApoy == 2)
            {
                if (btncxV.Checked == true)
                {
                    chartV.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartV.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartV.ChartAreas[0].CursorY.SetCursorPosition(YxEI(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartV.Series[ns+5].Points.Clear();
                            chartV.Series[ns+5].Points.AddXY(pX, YxEI(pX));
                            chartV.Series[ns+5].MarkerSize = 8;
                            chartV.Series[ns+5].Color = Color.Blue;
                            chartV.Series[ns+5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartV.Annotations.Clear();

                            anotacion.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacion.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacion.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacion.LineColor = System.Drawing.Color.Empty;
                            anotacion.Name = "ant";
                            anotacion.Text = "x: " + pX.ToString() + "\r\n" + "V: " + YxEI(pX).ToString();
                            anotacion.AxisXName = "ChartArea1\\rX";
                            anotacion.YAxisName = "ChartArea1\\rY";
                            anotacion.X = pX;
                            anotacion.Y = YxEI(pX);
                            chartV.Annotations.Add(anotacion);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartV.Series[ns+5].Points.Clear();
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartV.Annotations.Clear();

                }
            }
            else if (indTipApoy == 3)
            {
                if (btncxV.Checked == true)
                {
                    chartV.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartV.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartV.ChartAreas[0].CursorY.SetCursorPosition(YxC(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartV.Series[ns + 5].Points.Clear();
                            chartV.Series[ns + 5].Points.AddXY(pX, YxC(pX));
                            chartV.Series[ns + 5].MarkerSize = 8;
                            chartV.Series[ns + 5].Color = Color.Blue;
                            chartV.Series[ns + 5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartV.Annotations.Clear();

                            anotacion.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacion.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacion.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacion.LineColor = System.Drawing.Color.Empty;
                            anotacion.Name = "ant";
                            anotacion.Text = "x: " + pX.ToString() + "\r\n" + "V: " + YxC(pX).ToString();
                            anotacion.AxisXName = "ChartArea1\\rX";
                            anotacion.YAxisName = "ChartArea1\\rY";
                            anotacion.X = pX;
                            anotacion.Y = YxC(pX);
                            chartV.Annotations.Add(anotacion);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartV.Series[ns + 5].Points.Clear();
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartV.Annotations.Clear();

                }
            }
            else if (indTipApoy == 4)
            {
                if (btncxV.Checked == true)
                {
                    chartV.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartV.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartV.ChartAreas[0].CursorY.SetCursorPosition(Yx5(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartV.Series[ns + 5].Points.Clear();
                            chartV.Series[ns + 5].Points.AddXY(pX, Yx5(pX));
                            chartV.Series[ns + 5].MarkerSize = 8;
                            chartV.Series[ns + 5].Color = Color.Blue;
                            chartV.Series[ns + 5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartV.Annotations.Clear();

                            anotacion.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacion.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacion.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacion.LineColor = System.Drawing.Color.Empty;
                            anotacion.Name = "ant";
                            anotacion.Text = "x: " + pX.ToString() + "\r\n" + "V: " + Yx5(pX).ToString();
                            anotacion.AxisXName = "ChartArea1\\rX";
                            anotacion.YAxisName = "ChartArea1\\rY";
                            anotacion.X = pX;
                            anotacion.Y = Yx5(pX);
                            chartV.Annotations.Add(anotacion);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartV.Series[ns + 5].Points.Clear();
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartV.Annotations.Clear();

                }
            }
            else if (indTipApoy == 5)
            {
                if (btncxV.Checked == true)
                {
                    chartV.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartV.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartV.ChartAreas[0].CursorY.SetCursorPosition(Yx6(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartV.Series[ns + 5].Points.Clear();
                            chartV.Series[ns + 5].Points.AddXY(pX, Yx6(pX));
                            chartV.Series[ns + 5].MarkerSize = 8;
                            chartV.Series[ns + 5].Color = Color.Blue;
                            chartV.Series[ns + 5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartV.Annotations.Clear();

                            anotacion.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacion.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacion.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacion.LineColor = System.Drawing.Color.Empty;
                            anotacion.Name = "ant";
                            anotacion.Text = "x: " + pX.ToString() + "\r\n" + "V: " + Yx6(pX).ToString();
                            anotacion.AxisXName = "ChartArea1\\rX";
                            anotacion.YAxisName = "ChartArea1\\rY";
                            anotacion.X = pX;
                            anotacion.Y = Yx6(pX);
                            chartV.Annotations.Add(anotacion);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartV.Series[ns + 5].Points.Clear();
                    chartV.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartV.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartV.Annotations.Clear();

                }
            }
           
      
       
         
        }

        private void txtctexplot_KeyPress(object sender, KeyPressEventArgs e)
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

                txtctexplot.Focus();
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

                txtctexplot.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtctexplot.Focus();
                e.Handled = true;
            }
        }

        private void chartM_MouseMove(object sender, MouseEventArgs e)
        {
            if (indTipApoy == 0)
            {
                if (btncxV.Checked == true)
                {
                    chartM.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartM.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartM.ChartAreas[0].CursorY.SetCursorPosition(YMxSA(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartM.Series[ns+5].Points.Clear();
                            chartM.Series[ns+5].Points.AddXY(pX, YMxSA(pX));
                            chartM.Series[ns+5].MarkerSize = 8;
                            chartM.Series[ns+5].Color = Color.Blue;
                            chartM.Series[ns+5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartM.Annotations.Clear();

                            anotacionM.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionM.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionM.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionM.LineColor = System.Drawing.Color.Empty;
                            anotacionM.Name = "ant";
                            anotacionM.Text = "x: " + pX.ToString() + "\r\n" + "M: " + YMxSA(pX).ToString();
                            anotacionM.AxisXName = "ChartArea1\\rX";
                            anotacionM.YAxisName = "ChartArea1\\rY";
                            anotacionM.X = pX;
                            anotacionM.Y = YMxSA(pX);
                            chartM.Annotations.Add(anotacionM);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartM.Series[ns+5].Points.Clear();
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartM.Annotations.Clear();

                }
            }

            else if (indTipApoy == 1)
            {
                if (btncxV.Checked == true)
                {
                    chartM.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartM.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartM.ChartAreas[0].CursorY.SetCursorPosition(YMxTV(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartM.Series[ns+5].Points.Clear();
                            chartM.Series[ns+5].Points.AddXY(pX, YMxTV(pX));
                            chartM.Series[ns+5].MarkerSize = 8;
                            chartM.Series[ns+5].Color = Color.Blue;
                            chartM.Series[ns+5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartM.Annotations.Clear();

                            anotacionM.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionM.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionM.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionM.LineColor = System.Drawing.Color.Empty;
                            anotacionM.Name = "ant";
                            anotacionM.Text = "x: " + pX.ToString() + "\r\n" + "M: " + YMxEI(pX).ToString();
                            anotacionM.AxisXName = "ChartArea1\\rX";
                            anotacionM.YAxisName = "ChartArea1\\rY";
                            anotacionM.X = pX;
                            anotacionM.Y = YMxTV(pX);
                            chartM.Annotations.Add(anotacionM);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartM.Series[ns+5].Points.Clear();
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartM.Annotations.Clear();

                }
            }

            else if (indTipApoy == 2)
            {
                if (btncxV.Checked == true)
                {
                    chartM.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartM.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartM.ChartAreas[0].CursorY.SetCursorPosition(YMxEI(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartM.Series[ns+5].Points.Clear();
                            chartM.Series[ns+5].Points.AddXY(pX, YMxEI(pX));
                            chartM.Series[ns+5].MarkerSize = 8;
                            chartM.Series[ns+5].Color = Color.Blue;
                            chartM.Series[ns+5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartM.Annotations.Clear();

                            anotacionM.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionM.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionM.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionM.LineColor = System.Drawing.Color.Empty;
                            anotacionM.Name = "ant";
                            anotacionM.Text = "x: " + pX.ToString() + "\r\n" + "M: " + YMxEI(pX).ToString();
                            anotacionM.AxisXName = "ChartArea1\\rX";
                            anotacionM.YAxisName = "ChartArea1\\rY";
                            anotacionM.X = pX;
                            anotacionM.Y = YMxEI(pX);
                            chartM.Annotations.Add(anotacionM);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartM.Series[ns+5].Points.Clear();
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartM.Annotations.Clear();

                }
            }
            else if (indTipApoy == 3)
            {
                if (btncxV.Checked == true)
                {
                    chartM.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartM.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartM.ChartAreas[0].CursorY.SetCursorPosition(YMxC(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartM.Series[ns + 5].Points.Clear();
                            chartM.Series[ns + 5].Points.AddXY(pX, YMxC(pX));
                            chartM.Series[ns + 5].MarkerSize = 8;
                            chartM.Series[ns + 5].Color = Color.Blue;
                            chartM.Series[ns + 5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartM.Annotations.Clear();

                            anotacionM.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionM.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionM.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionM.LineColor = System.Drawing.Color.Empty;
                            anotacionM.Name = "ant";
                            anotacionM.Text = "x: " + pX.ToString() + "\r\n" + "M: " + YMxC(pX).ToString();
                            anotacionM.AxisXName = "ChartArea1\\rX";
                            anotacionM.YAxisName = "ChartArea1\\rY";
                            anotacionM.X = pX;
                            anotacionM.Y = YMxC(pX);
                            chartM.Annotations.Add(anotacionM);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartM.Series[ns + 5].Points.Clear();
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartM.Annotations.Clear();

                }
            }
            else if (indTipApoy == 4)
            {
                if (btncxV.Checked == true)
                {
                    chartM.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartM.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartM.ChartAreas[0].CursorY.SetCursorPosition(YMx5(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartM.Series[ns + 5].Points.Clear();
                            chartM.Series[ns + 5].Points.AddXY(pX, YMx5(pX));
                            chartM.Series[ns + 5].MarkerSize = 8;
                            chartM.Series[ns + 5].Color = Color.Blue;
                            chartM.Series[ns + 5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartM.Annotations.Clear();

                            anotacionM.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionM.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionM.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionM.LineColor = System.Drawing.Color.Empty;
                            anotacionM.Name = "ant";
                            anotacionM.Text = "x: " + pX.ToString() + "\r\n" + "M: " + YMx5(pX).ToString();
                            anotacionM.AxisXName = "ChartArea1\\rX";
                            anotacionM.YAxisName = "ChartArea1\\rY";
                            anotacionM.X = pX;
                            anotacionM.Y = YMx5(pX);
                            chartM.Annotations.Add(anotacionM);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartM.Series[ns + 5].Points.Clear();
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartM.Annotations.Clear();

                }
            }
            else if (indTipApoy == 5)
            {
                if (btncxV.Checked == true)
                {
                    chartM.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartM.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartM.ChartAreas[0].CursorY.SetCursorPosition(YMx6(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartM.Series[ns + 5].Points.Clear();
                            chartM.Series[ns + 5].Points.AddXY(pX, YMx6(pX));
                            chartM.Series[ns + 5].MarkerSize = 8;
                            chartM.Series[ns + 5].Color = Color.Blue;
                            chartM.Series[ns + 5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartM.Annotations.Clear();

                            anotacionM.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionM.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionM.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionM.LineColor = System.Drawing.Color.Empty;
                            anotacionM.Name = "ant";
                            anotacionM.Text = "x: " + pX.ToString() + "\r\n" + "M: " + YMx6(pX).ToString();
                            anotacionM.AxisXName = "ChartArea1\\rX";
                            anotacionM.YAxisName = "ChartArea1\\rY";
                            anotacionM.X = pX;
                            anotacionM.Y = YMx6(pX);
                            chartM.Annotations.Add(anotacionM);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartM.Series[ns + 5].Points.Clear();
                    chartM.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartM.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartM.Annotations.Clear();

                }
            }
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

                txtxMtoplot.Focus();
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

                txtxMtoplot.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtxMtoplot.Focus();
                e.Handled = true;
            }
        }



        private void pnlDibPerf_Paint(object sender, PaintEventArgs e)
        {
            //if (cbPfPP.SelectedIndex == 0)
            //{
            //    foreach (char pletra in txtVgsda.Text)
            //    {
            //        if (pletra.ToString() == "W")
            //        {
            //            g5 = pnlDibPerf.CreateGraphics();

            //            Point[] ptsPerfW = { new Point(20, 20), new Point(320, 20), new Point(320,70), new Point(195,70), 
            //            new Point(195,285),new Point(320,285) ,new Point(320,335), new Point(20,335), new Point(20,285), new Point(145,285),
            //            new Point(145,70), new Point(20,70), new Point(20,20)};

            //            Point[] ptpuntacota1 = { new Point(405, 30), new Point(415, 30), new Point(410, 20), new Point(405, 30) };
            //            Point[] ptpuntacota2 = { new Point(405, 325), new Point(415, 325), new Point(410, 335), new Point(405, 325) };
            //            Point[] ptpuntacota3 = { new Point(345, 275), new Point(355, 275), new Point(350, 285), new Point(345, 275) };
            //            Point[] ptpuntacota4 = { new Point(345, 345), new Point(355, 345), new Point(350, 335), new Point(345, 345) };
            //            Point[] ptpuntacota5 = { new Point(30, 350), new Point(30, 350), new Point(20, 355), new Point(30, 360) };
            //            Point[] ptpuntacota6 = { new Point(310, 350), new Point(310, 360), new Point(320, 355), new Point(310, 350) };
            //            Point[] ptpuntacota7 = { new Point(135, 172), new Point(135, 182), new Point(145, 177), new Point(135, 172) };
            //            Point[] ptpuntacota8 = { new Point(205, 172), new Point(205, 182), new Point(195, 177), new Point(205, 172) };

            //            g5.DrawLines(pluma1, ptsPerfW);
            //            g5.FillPolygon(bsuave,ptsPerfW);

            //            g5.DrawLine(Pens.Black,new Point(330,20),new Point(450,20));
            //            g5.DrawLine(Pens.Black, new Point(330,335), new Point(450,335));
            //            g5.DrawLine(Pens.Black, new Point(330,285), new Point(380,285));
            //            g5.DrawLine(Pens.Black, new Point(410, 20), new Point(410, 335));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota1);
            //            g5.FillPolygon(Brushes.Black, ptpuntacota2);

            //            g5.DrawLine(Pens.Black, new Point(350, 285), new Point(350, 240));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota3);
            //            g5.DrawLine(Pens.Black, new Point(350, 335), new Point(350, 375));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota4);

            //            g5.DrawLine(Pens.Black, new Point(20,340), new Point(20,370));
            //            g5.DrawLine(Pens.Black, new Point(320, 340), new Point(320, 370));
                 
            //            g5.DrawLine(Pens.Black, new Point(20, 355), new Point(320, 355));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota5);
            //            g5.FillPolygon(Brushes.Black, ptpuntacota6);

            //            g5.DrawLine(Pens.Black, new Point(100, 177), new Point(145, 177));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota7);
            //            g5.DrawLine(Pens.Black, new Point(195, 177), new Point(240, 177));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota8);


            //            g5.DrawString("d", fuenteperfiles, Brushes.Black, 420, 177);
            //            g5.DrawString("t", fuenteperfiles, Brushes.Black, 360, 250);
            //            g5.DrawString("f", fuente1, Brushes.Black, 368, 260);
            //            g5.DrawString("b", fuenteperfiles, Brushes.Black, 160, 360);
            //            g5.DrawString("f", fuente1, Brushes.Black, 173, 370);
            //            g5.DrawString("t", fuenteperfiles, Brushes.Black, 217, 155);
            //            g5.DrawString("w", fuente1, Brushes.Black, 225, 162);
            //            //g5.DrawString("w", fuente1, Brushes.Black, 225, 162);
            //            //g5.DrawString("w", fuente1, Brushes.Black, 225, 162);
            //            g5.FillEllipse(Brushes.Red, 166, 16, 8, 8);
            //            g5.FillEllipse(Brushes.Red, 166, 66, 8, 8);
            //            g5.DrawString("a", fuenteperfiles, Brushes.Red, 180, 5);
            //            g5.DrawString("b", fuenteperfiles, Brushes.Red, 180, 55);


            //            g5.Dispose();
            //            break;
            //        }
            //        else if (pletra.ToString() == "S")
            //        {
            //            int n = 65;
            //            g5 = pnlDibPerf.CreateGraphics();

            //            Point[] ptsPerfW = { new Point(20+n, 20), new Point(320-n, 20), new Point(320-n,70), new Point(195,70),
            //            new Point(195,285),new Point(320-n,285) ,new Point(320-n,335), new Point(20+n,335), new Point(20+n,285), new Point(145,285),
            //            new Point(145,70), new Point(20+n,70), new Point(20+n,20)};

            //            Point[] ptpuntacota1 = { new Point(405-n, 30), new Point(415-n, 30), new Point(410-n, 20), new Point(405-n, 30) };
            //            Point[] ptpuntacota2 = { new Point(405-n, 325), new Point(415-n, 325), new Point(410-n, 335), new Point(405-n, 325) };
            //            Point[] ptpuntacota3 = { new Point(345-n, 275), new Point(355-n, 275), new Point(350-n, 285), new Point(345-n, 275) };
            //            Point[] ptpuntacota4 = { new Point(345-n, 345), new Point(355-n, 345), new Point(350-n, 335), new Point(345-n, 345) };
            //            Point[] ptpuntacota5 = { new Point(30+n, 350), new Point(30+n, 350), new Point(20+n, 355), new Point(30+n, 360) };
            //            Point[] ptpuntacota6 = { new Point(310-n, 350), new Point(310-n, 360), new Point(320-n, 355), new Point(310-n, 350) };
            //            Point[] ptpuntacota7 = { new Point(135, 172), new Point(135, 182), new Point(145, 177), new Point(135, 172) };
            //            Point[] ptpuntacota8 = { new Point(205, 172), new Point(205, 182), new Point(195, 177), new Point(205, 172) };

            //            g5.DrawLines(pluma1, ptsPerfW);
            //            g5.FillPolygon(bsuave, ptsPerfW);

            //            g5.DrawLine(Pens.Black, new Point(330 - n, 20), new Point(450-n, 20));
            //            g5.DrawLine(Pens.Black, new Point(330 - n, 335), new Point(450-n, 335));
            //            g5.DrawLine(Pens.Black, new Point(330 - n, 285), new Point(380-n, 285));
            //            g5.DrawLine(Pens.Black, new Point(410-n, 20), new Point(410-n, 335));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota1);
            //            g5.FillPolygon(Brushes.Black, ptpuntacota2);

            //            g5.DrawLine(Pens.Black, new Point(350-n, 285), new Point(350-n, 240));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota3);
            //            g5.DrawLine(Pens.Black, new Point(350-n, 335), new Point(350-n, 375));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota4);

            //            g5.DrawLine(Pens.Black, new Point(20+n, 340), new Point(20+n, 370));
            //            g5.DrawLine(Pens.Black, new Point(320-n, 340), new Point(320-n, 370));

            //            g5.DrawLine(Pens.Black, new Point(20+n, 355), new Point(320-n, 355));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota5);
            //            g5.FillPolygon(Brushes.Black, ptpuntacota6);

            //            g5.DrawLine(Pens.Black, new Point(100, 177), new Point(145, 177));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota7);
            //            g5.DrawLine(Pens.Black, new Point(195, 177), new Point(240, 177));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota8);


            //            g5.DrawString("d", fuenteperfiles, Brushes.Black, 420 - n, 177);
            //            g5.DrawString("t", fuenteperfiles, Brushes.Black, 360-n, 250);
            //            g5.DrawString("f", fuente1, Brushes.Black, 368 - n, 260);
            //            g5.DrawString("b", fuenteperfiles, Brushes.Black, 160, 360);
            //            g5.DrawString("f", fuente1, Brushes.Black, 173, 370);
            //            g5.DrawString("t", fuenteperfiles, Brushes.Black, 217, 155);
            //            g5.DrawString("w", fuente1, Brushes.Black, 225, 162);

            //            g5.FillEllipse(Brushes.Red, 166, 16, 8, 8);
            //            g5.FillEllipse(Brushes.Red, 166, 66, 8, 8);
            //            g5.DrawString("a", fuenteperfiles, Brushes.Red, 180, 5);
            //            g5.DrawString("b", fuenteperfiles, Brushes.Red, 180, 55);

            //            g5.Dispose();
            //            break;

            //        }
            //        else if (pletra.ToString() == "C")
            //        {
            //            int n = 65;
            //            g5 = pnlDibPerf.CreateGraphics();

            //            Point[] ptsPerfW = { new Point(20+n, 20), new Point(320-n, 20), new Point(320-n,70), new Point(20+n+50,70),
            //            new Point(20+n+50,285),new Point(320-n,285) ,new Point(320-n,335), new Point(20+n,335), new Point(20+n,20)
            //           };

            //            Point[] ptpuntacota1 = { new Point(405 - n, 30), new Point(415 - n, 30), new Point(410 - n, 20), new Point(405 - n, 30) };
            //            Point[] ptpuntacota2 = { new Point(405 - n, 325), new Point(415 - n, 325), new Point(410 - n, 335), new Point(405 - n, 325) };
            //            Point[] ptpuntacota3 = { new Point(345 - n, 275), new Point(355 - n, 275), new Point(350 - n, 285), new Point(345 - n, 275) };
            //            Point[] ptpuntacota4 = { new Point(345 - n, 345), new Point(355 - n, 345), new Point(350 - n, 335), new Point(345 - n, 345) };
            //            Point[] ptpuntacota5 = { new Point(30 + n, 350), new Point(30 + n, 350), new Point(20 + n, 355), new Point(30 + n, 360) };
            //            Point[] ptpuntacota6 = { new Point(310 - n, 350), new Point(310 - n, 360), new Point(320 - n, 355), new Point(310 - n, 350) };
            //            Point[] ptpuntacota7 = { new Point(135 - 60, 172), new Point(135 - 60, 182), new Point(145 - 60, 177), new Point(135 - 60, 172) };
            //            Point[] ptpuntacota8 = { new Point(205 - 60, 172), new Point(205 - 60, 182), new Point(195 - 60, 177), new Point(205 - 60, 172) };

            //            g5.DrawLines(pluma1, ptsPerfW);
            //            g5.FillPolygon(bsuave, ptsPerfW);

            //            g5.DrawLine(Pens.Black, new Point(330 - n, 20), new Point(450 - n, 20));
            //            g5.DrawLine(Pens.Black, new Point(330 - n, 335), new Point(450 - n, 335));
            //            g5.DrawLine(Pens.Black, new Point(330 - n, 285), new Point(380 - n, 285));
            //            g5.DrawLine(Pens.Black, new Point(410 - n, 20), new Point(410 - n, 335));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota1);
            //            g5.FillPolygon(Brushes.Black, ptpuntacota2);

            //            g5.DrawLine(Pens.Black, new Point(350 - n, 285), new Point(350 - n, 240));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota3);
            //            g5.DrawLine(Pens.Black, new Point(350 - n, 335), new Point(350 - n, 375));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota4);

            //            g5.DrawLine(Pens.Black, new Point(20 + n, 340), new Point(20 + n, 370));
            //            g5.DrawLine(Pens.Black, new Point(320 - n, 340), new Point(320 - n, 370));

            //            g5.DrawLine(Pens.Black, new Point(20 + n, 355), new Point(320 - n, 355));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota5);
            //            g5.FillPolygon(Brushes.Black, ptpuntacota6);

            //            g5.DrawLine(Pens.Black, new Point(100 - 60, 177), new Point(145 - 62, 177));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota7);
            //            g5.DrawLine(Pens.Black, new Point(195 - 60, 177), new Point(240 - 62, 177));
            //            g5.FillPolygon(Brushes.Black, ptpuntacota8);


            //            g5.DrawString("d", fuenteperfiles, Brushes.Black, 420 - n, 177);
            //            g5.DrawString("t", fuenteperfiles, Brushes.Black, 360 - n, 250);
            //            g5.DrawString("f", fuente1, Brushes.Black, 368 - n, 260);
            //            g5.DrawString("b", fuenteperfiles, Brushes.Black, 160, 360);
            //            g5.DrawString("f", fuente1, Brushes.Black, 173, 370);
            //            g5.DrawString("t", fuenteperfiles, Brushes.Black, 217 - 60, 155);
            //            g5.DrawString("w", fuente1, Brushes.Black, 225 - 60, 162);

            //            g5.FillEllipse(Brushes.Red, 166, 16, 8, 8);
            //            g5.FillEllipse(Brushes.Red, 166, 66, 8, 8);
            //            g5.DrawString("a", fuenteperfiles, Brushes.Red, 180, 5);
            //            g5.DrawString("b", fuenteperfiles, Brushes.Red, 180, 55);

            //            g5.Dispose();
            //            break;
            //        }



            //    }

            //}
            //else if (cbPfPP.SelectedIndex == 1)
            //{
            //    g5 = pnlDibPerf.CreateGraphics();

            //    Point[] ptsPerfW = { new Point(20, 20), new Point(320, 20), new Point(320,70), new Point(195,70),
            //            new Point(195,285),new Point(320,285) ,new Point(320,335), new Point(20,335), new Point(20,285), new Point(145,285),
            //            new Point(145,70), new Point(20,70), new Point(20,20)};

            //    Point[] ptpuntacota1 = { new Point(405, 30), new Point(415, 30), new Point(410, 20), new Point(405, 30) };
            //    Point[] ptpuntacota2 = { new Point(405, 325), new Point(415, 325), new Point(410, 335), new Point(405, 325) };
            //    Point[] ptpuntacota3 = { new Point(345, 275), new Point(355, 275), new Point(350, 285), new Point(345, 275) };
            //    Point[] ptpuntacota4 = { new Point(345, 345), new Point(355, 345), new Point(350, 335), new Point(345, 345) };
            //    Point[] ptpuntacota5 = { new Point(30, 350), new Point(30, 350), new Point(20, 355), new Point(30, 360) };
            //    Point[] ptpuntacota6 = { new Point(310, 350), new Point(310, 360), new Point(320, 355), new Point(310, 350) };
            //    Point[] ptpuntacota7 = { new Point(135, 172), new Point(135, 182), new Point(145, 177), new Point(135, 172) };
            //    Point[] ptpuntacota8 = { new Point(205, 172), new Point(205, 182), new Point(195, 177), new Point(205, 172) };

            //    g5.DrawLines(pluma1, ptsPerfW);
            //    g5.FillPolygon(bsuave, ptsPerfW);

            //    g5.DrawLine(Pens.Black, new Point(330, 20), new Point(450, 20));
            //    g5.DrawLine(Pens.Black, new Point(330, 335), new Point(450, 335));
            //    g5.DrawLine(Pens.Black, new Point(330, 285), new Point(380, 285));
            //    g5.DrawLine(Pens.Black, new Point(410, 20), new Point(410, 335));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota1);
            //    g5.FillPolygon(Brushes.Black, ptpuntacota2);

            //    g5.DrawLine(Pens.Black, new Point(350, 285), new Point(350, 240));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota3);
            //    g5.DrawLine(Pens.Black, new Point(350, 335), new Point(350, 375));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota4);

            //    g5.DrawLine(Pens.Black, new Point(20, 340), new Point(20, 370));
            //    g5.DrawLine(Pens.Black, new Point(320, 340), new Point(320, 370));

            //    g5.DrawLine(Pens.Black, new Point(20, 355), new Point(320, 355));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota5);
            //    g5.FillPolygon(Brushes.Black, ptpuntacota6);

            //    g5.DrawLine(Pens.Black, new Point(100, 177), new Point(145, 177));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota7);
            //    g5.DrawLine(Pens.Black, new Point(195, 177), new Point(240, 177));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota8);


            //    g5.DrawString("d", fuenteperfiles, Brushes.Black, 420, 177);
            //    g5.DrawString("t", fuenteperfiles, Brushes.Black, 360, 250);
            //    g5.DrawString("f", fuente1, Brushes.Black, 368, 260);
            //    g5.DrawString("b", fuenteperfiles, Brushes.Black, 160, 360);
            //    g5.DrawString("f", fuente1, Brushes.Black, 173, 370);
            //    g5.DrawString("t", fuenteperfiles, Brushes.Black, 217, 155);
            //    g5.DrawString("w", fuente1, Brushes.Black, 225, 162);
            //    //g5.DrawString("w", fuente1, Brushes.Black, 225, 162);
            //    //g5.DrawString("w", fuente1, Brushes.Black, 225, 162);
            //    g5.FillEllipse(Brushes.Red, 166, 16, 8, 8);
            //    g5.FillEllipse(Brushes.Red, 166, 66, 8, 8);
            //    g5.DrawString("a", fuenteperfiles, Brushes.Red, 180, 5);
            //    g5.DrawString("b", fuenteperfiles, Brushes.Red, 180, 55);

            //    g5.Dispose();
            //}
            //else if (cbPfPP.SelectedIndex == 2)
            //{
            //    int n = 65;
            //    g5 = pnlDibPerf.CreateGraphics();

            //    Point[] ptsPerfW = { new Point(20+n, 20), new Point(320-n, 20), new Point(320-n,70), new Point(195,70),
            //            new Point(195,285),new Point(320-n,285) ,new Point(320-n,335), new Point(20+n,335), new Point(20+n,285), new Point(145,285),
            //            new Point(145,70), new Point(20+n,70), new Point(20+n,20)};

            //    Point[] ptpuntacota1 = { new Point(405 - n, 30), new Point(415 - n, 30), new Point(410 - n, 20), new Point(405 - n, 30) };
            //    Point[] ptpuntacota2 = { new Point(405 - n, 325), new Point(415 - n, 325), new Point(410 - n, 335), new Point(405 - n, 325) };
            //    Point[] ptpuntacota3 = { new Point(345 - n, 275), new Point(355 - n, 275), new Point(350 - n, 285), new Point(345 - n, 275) };
            //    Point[] ptpuntacota4 = { new Point(345 - n, 345), new Point(355 - n, 345), new Point(350 - n, 335), new Point(345 - n, 345) };
            //    Point[] ptpuntacota5 = { new Point(30 + n, 350), new Point(30 + n, 350), new Point(20 + n, 355), new Point(30 + n, 360) };
            //    Point[] ptpuntacota6 = { new Point(310 - n, 350), new Point(310 - n, 360), new Point(320 - n, 355), new Point(310 - n, 350) };
            //    Point[] ptpuntacota7 = { new Point(135, 172), new Point(135, 182), new Point(145, 177), new Point(135, 172) };
            //    Point[] ptpuntacota8 = { new Point(205, 172), new Point(205, 182), new Point(195, 177), new Point(205, 172) };

            //    g5.DrawLines(pluma1, ptsPerfW);
            //    g5.FillPolygon(bsuave, ptsPerfW);

            //    g5.DrawLine(Pens.Black, new Point(330 - n, 20), new Point(450 - n, 20));
            //    g5.DrawLine(Pens.Black, new Point(330 - n, 335), new Point(450 - n, 335));
            //    g5.DrawLine(Pens.Black, new Point(330 - n, 285), new Point(380 - n, 285));
            //    g5.DrawLine(Pens.Black, new Point(410 - n, 20), new Point(410 - n, 335));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota1);
            //    g5.FillPolygon(Brushes.Black, ptpuntacota2);

            //    g5.DrawLine(Pens.Black, new Point(350 - n, 285), new Point(350 - n, 240));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota3);
            //    g5.DrawLine(Pens.Black, new Point(350 - n, 335), new Point(350 - n, 375));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota4);

            //    g5.DrawLine(Pens.Black, new Point(20 + n, 340), new Point(20 + n, 370));
            //    g5.DrawLine(Pens.Black, new Point(320 - n, 340), new Point(320 - n, 370));

            //    g5.DrawLine(Pens.Black, new Point(20 + n, 355), new Point(320 - n, 355));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota5);
            //    g5.FillPolygon(Brushes.Black, ptpuntacota6);

            //    g5.DrawLine(Pens.Black, new Point(100, 177), new Point(145, 177));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota7);
            //    g5.DrawLine(Pens.Black, new Point(195, 177), new Point(240, 177));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota8);


            //    g5.DrawString("d", fuenteperfiles, Brushes.Black, 420 - n, 177);
            //    g5.DrawString("t", fuenteperfiles, Brushes.Black, 360 - n, 250);
            //    g5.DrawString("f", fuente1, Brushes.Black, 368 - n, 260);
            //    g5.DrawString("b", fuenteperfiles, Brushes.Black, 160, 360);
            //    g5.DrawString("f", fuente1, Brushes.Black, 173, 370);
            //    g5.DrawString("t", fuenteperfiles, Brushes.Black, 217, 155);
            //    g5.DrawString("w", fuente1, Brushes.Black, 225, 162);


            //    g5.FillEllipse(Brushes.Red, 166, 16, 8, 8);
            //    g5.FillEllipse(Brushes.Red, 166, 66, 8, 8);
            //    g5.DrawString("a", fuenteperfiles, Brushes.Red, 180, 5);
            //    g5.DrawString("b", fuenteperfiles, Brushes.Red, 180, 55);

            //    g5.Dispose();
               
            //}
            //else if (cbPfPP.SelectedIndex == 3)
            //{
            //    int n = 65;
            //    g5 = pnlDibPerf.CreateGraphics();

            //    Point[] ptsPerfW = { new Point(20+n, 20), new Point(320-n, 20), new Point(320-n,70), new Point(20+n+50,70),
            //            new Point(20+n+50,285),new Point(320-n,285) ,new Point(320-n,335), new Point(20+n,335), new Point(20+n,20)
            //           };

            //    Point[] ptpuntacota1 = { new Point(405 - n, 30), new Point(415 - n, 30), new Point(410 - n, 20), new Point(405 - n, 30) };
            //    Point[] ptpuntacota2 = { new Point(405 - n, 325), new Point(415 - n, 325), new Point(410 - n, 335), new Point(405 - n, 325) };
            //    Point[] ptpuntacota3 = { new Point(345 - n, 275), new Point(355 - n, 275), new Point(350 - n, 285), new Point(345 - n, 275) };
            //    Point[] ptpuntacota4 = { new Point(345 - n, 345), new Point(355 - n, 345), new Point(350 - n, 335), new Point(345 - n, 345) };
            //    Point[] ptpuntacota5 = { new Point(30 + n, 350), new Point(30 + n, 350), new Point(20 + n, 355), new Point(30 + n, 360) };
            //    Point[] ptpuntacota6 = { new Point(310 - n, 350), new Point(310 - n, 360), new Point(320 - n, 355), new Point(310 - n, 350) };
            //    Point[] ptpuntacota7 = { new Point(135-60, 172), new Point(135-60, 182), new Point(145-60, 177), new Point(135-60, 172) };
            //    Point[] ptpuntacota8 = { new Point(205-60, 172), new Point(205-60, 182), new Point(195-60, 177), new Point(205-60, 172) };

            //    g5.DrawLines(pluma1, ptsPerfW);
            //    g5.FillPolygon(bsuave, ptsPerfW);

            //    g5.DrawLine(Pens.Black, new Point(330 - n, 20), new Point(450 - n, 20));
            //    g5.DrawLine(Pens.Black, new Point(330 - n, 335), new Point(450 - n, 335));
            //    g5.DrawLine(Pens.Black, new Point(330 - n, 285), new Point(380 - n, 285));
            //    g5.DrawLine(Pens.Black, new Point(410 - n, 20), new Point(410 - n, 335));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota1);
            //    g5.FillPolygon(Brushes.Black, ptpuntacota2);

            //    g5.DrawLine(Pens.Black, new Point(350 - n, 285), new Point(350 - n, 240));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota3);
            //    g5.DrawLine(Pens.Black, new Point(350 - n, 335), new Point(350 - n, 375));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota4);

            //    g5.DrawLine(Pens.Black, new Point(20 + n, 340), new Point(20 + n, 370));
            //    g5.DrawLine(Pens.Black, new Point(320 - n, 340), new Point(320 - n, 370));

            //    g5.DrawLine(Pens.Black, new Point(20 + n, 355), new Point(320 - n, 355));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota5);
            //    g5.FillPolygon(Brushes.Black, ptpuntacota6);

            //    g5.DrawLine(Pens.Black, new Point(100-60, 177), new Point(145-62, 177));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota7);
            //    g5.DrawLine(Pens.Black, new Point(195-60, 177), new Point(240-62, 177));
            //    g5.FillPolygon(Brushes.Black, ptpuntacota8);


            //    g5.DrawString("d", fuenteperfiles, Brushes.Black, 420 - n, 177);
            //    g5.DrawString("t", fuenteperfiles, Brushes.Black, 360 - n, 250);
            //    g5.DrawString("f", fuente1, Brushes.Black, 368 - n, 260);
            //    g5.DrawString("b", fuenteperfiles, Brushes.Black, 160, 360);
            //    g5.DrawString("f", fuente1, Brushes.Black, 173, 370);
            //    g5.DrawString("t", fuenteperfiles, Brushes.Black, 217-60, 155);
            //    g5.DrawString("w", fuente1, Brushes.Black, 225-60, 162);

            //    g5.FillEllipse(Brushes.Red, 166, 16, 8, 8);
            //    g5.FillEllipse(Brushes.Red, 166, 66, 8, 8);
            //    g5.DrawString("a", fuenteperfiles, Brushes.Red, 180, 5);
            //    g5.DrawString("b", fuenteperfiles, Brushes.Red, 180, 55);

            //    g5.Dispose();
               
            //}



        }

      

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            Stream myStream = null;
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.InitialDirectory = "c:\\";
            openfile.Filter = "txt files (*.txt)|*.txt";
            openfile.FilterIndex = 0;
            openfile.RestoreDirectory = true;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openfile.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            rr = null;
                            rr = new Read(myStream);
                            if (rr.get_unidades() == "0")
                            {
                                SItsitem.PerformClick();
                            }
                            else if (rr.get_unidades() == "1")
                            {
                                EUtsitem.PerformClick();
                            }

                            if (Convert.ToInt32(rr.get_Chkbpregunta()) == 1)
                            {
                                chkbSDPP.Checked = true;
                                Mtst.Visible = false;
                                
                            }
                            else
                            {
                                chkbSDPP.Checked = false;
                                Mtst.Visible = true;
                            }

                            indPesñMat = Convert.ToInt32(rr.get_indpstMt());

                            if (indPesñMat == 0 && Convert.ToInt32(rr.get_indlb()) != -1)
                            {
                                if (unidades == 0)
                                {
                                    ET = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][4].ToString());
                                    EC = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][5].ToString());
                                    ETP = ET / FS;
                                    ECP = EC / FS;
                                    Mtset = "Mt: " + acero1.Rows[Convert.ToInt32(rr.get_indlb())][1];
                                    Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                       + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                                }
                                else if (unidades == 1)
                                {
                                    ET = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][2].ToString());
                                    EC = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][3].ToString());
                                    ETP = ET / FS;
                                    ECP = EC / FS;
                                    Mtset = "Mt: " + acero1.Rows[Convert.ToInt32(rr.get_indlb())][1];
                                    Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                       + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                                }
                               
                              

                            }
                            else if (indPesñMat == 1)
                            {
                               
                                ET = Convert.ToDouble(rr.get_et()); 
                                EC = Convert.ToDouble(rr.get_ec());
                                ME = Convert.ToDouble(rr.get_me());
                                ETP = ET / FS;
                                ECP = EC / FS;
                                Mtset = "Mt: Personalizado";
                                Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                    + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                            }
                            //factor de seguridad
                            txtFSPP.Text = rr.get_fs();
                            FS = Convert.ToDouble(rr.get_fs());
                            ETP = ET / FS;
                            ECP = EC / FS;
                            ME = Convert.ToDouble(rr.get_me());
                            Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                   + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                            //combo box perfil
                            cbPfPP.SelectedIndex = Convert.ToInt32(rr.get_cbPf());

                            //longitud
                            txtLPP.Text = rr.get_l();
                            l = Convert.ToDouble(rr.get_l());

                            //apoyo
                            indTipApoy = Convert.ToInt32(rr.get_apy());
                            if (indTipApoy == 1)
                            {
                                tv = 1;
                                cbApyPP.SelectedIndex = 1;
                               


                                tv = 0;
                            }
                            else if (indTipApoy == 3)
                            {
                                tc = 1;
                                cbApyPP.SelectedIndex = 3;



                                tc = 0;
                            }
                           
                            
                            

                            //longitud de apoyo en tramo en voladizo
                            if (indTipApoy == 1)
                            {
                                ltv = Convert.ToDouble(rr.get_ltv());
                                ltvst.Visible = true;
                                ltvst.Text = "ltv = " + ltv.ToString();
                            }
                            else
                            {
                                ltvst.Visible = false;
                            }
                            if (indTipApoy == 3)
                            {
                                lcon = Convert.ToDouble(rr.get_lcon());
                                lconst.Visible = true;
                                lconst.Text = "lcon = " + lcon.ToString();
                            }
                            else
                            {
                                lconst.Visible = false;
                            }
                            ////////////cargas y momentos/////////////////
                            int nfilas;
                            nfilas = Convert.ToInt32(rr.get_nfilas());

                            DataTable dtaux1 = new DataTable("datatableaux1");
                            dtaux1 = rr.get_dtaux();

                            dtgFyM.Rows.Clear();
                            if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                            {
                                TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                            }
                            if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                            {
                                TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                            }
                            for (int i = 0; i < nfilas; i++)
                            {
                                if (dtaux1.Rows[i][0].ToString() == "CC")
                                {
                                    dtgFyM.Rows.Add();

                                    dtgFyM.Rows[i].Cells[0].Value = "CC";
                                    dtgFyM.Rows[i].Cells[1].Value = dtaux1.Rows[i][1].ToString();
                                    dtgFyM.Rows[i].Cells[2].Value = dtaux1.Rows[i][2].ToString();
                                    dtgFyM.Rows[i].Cells[3].Value = dtaux1.Rows[i][3].ToString();
                                    dtgFyM.Rows[i].Cells[4].Value = dtaux1.Rows[i][4].ToString();
                                    dtgFyM.Rows[i].Cells[5].Value = dtaux1.Rows[i][5].ToString();
                                    dtgFyM.Rows[i].Cells[6].Value = dtaux1.Rows[i][6].ToString();

                                    dtgFyM.Rows[i].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                                    dtgFyM.Rows[i].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");
                                }
                                else if (dtaux1.Rows[i][0].ToString() == "CD")
                                {
                                    dtgFyM.Rows.Add();

                                    dtgFyM.Rows[i].Cells[0].Value = "CD";
                                    dtgFyM.Rows[i].Cells[1].Value = dtaux1.Rows[i][1].ToString();
                                    dtgFyM.Rows[i].Cells[2].Value = dtaux1.Rows[i][2].ToString();
                                    dtgFyM.Rows[i].Cells[3].Value = dtaux1.Rows[i][3].ToString();
                                    dtgFyM.Rows[i].Cells[4].Value = dtaux1.Rows[i][4].ToString();
                                    dtgFyM.Rows[i].Cells[5].Value = dtaux1.Rows[i][5].ToString();
                                    dtgFyM.Rows[i].Cells[6].Value = dtaux1.Rows[i][6].ToString();

                                    dtgFyM.Rows[i].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                                    dtgFyM.Rows[i].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");
                                }
                                else if (dtaux1.Rows[i][0].ToString() == "M")
                                {
                                    dtgFyM.Rows.Add();

                                    dtgFyM.Rows[i].Cells[0].Value = "M";
                                    dtgFyM.Rows[i].Cells[1].Value = dtaux1.Rows[i][1].ToString();
                                    dtgFyM.Rows[i].Cells[2].Value = dtaux1.Rows[i][2].ToString();
                                    dtgFyM.Rows[i].Cells[3].Value = dtaux1.Rows[i][3].ToString();
                                    dtgFyM.Rows[i].Cells[4].Value = dtaux1.Rows[i][4].ToString();
                                    dtgFyM.Rows[i].Cells[5].Value = dtaux1.Rows[i][5].ToString();
                                    dtgFyM.Rows[i].Cells[6].Value = dtaux1.Rows[i][6].ToString();

                                    dtgFyM.Rows[i].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                                    dtgFyM.Rows[i].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");
                                }
                            }

                            tabCgVgPP.Invalidate();

                            haymaterial = Convert.ToInt32(rr.get_haymaterial());

                            if (Convert.ToInt32(rr.get_tabdiag()) == 1)
                            {
                                btnResolPP.PerformClick();
                                TabCtrlPanelPrincipal.SelectedIndex = Convert.ToInt32( rr.get_stabprin());
                            }

                            

                           
                            myStream.Close();

                        }
                    }
                }
                catch (Exception)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Se ha presentado un error al abrir archivo");
                
                }


            }


        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Rtachkbpregunta;

            AgMt agMt = new AgMt();

            if (chkbSDPP.Checked == true)
            {
                Rtachkbpregunta = 1;
            }
            else
            {
                Rtachkbpregunta = 0;
            }

          

            SaveFileDialog sf = new SaveFileDialog();

            sf.InitialDirectory = "c:\\";
            sf.Filter = "txt files (*.txt)|*.txt";
            sf.FilterIndex = 0;
            sf.RestoreDirectory = true;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sf.FileName))
                {
                    string namefile = sf.FileName;




                    StreamWriter linetowrite = File.CreateText(namefile);
                    //linetowrite = File.CreateText(namefile);
                    linetowrite.WriteLine(unidades.ToString());
                    linetowrite.WriteLine(Rtachkbpregunta.ToString() );
                    linetowrite.WriteLine(indPesñMat.ToString());
                    linetowrite.WriteLine(indLisBxMat.ToString());
                    linetowrite.WriteLine(ET.ToString() );
                    linetowrite.WriteLine(EC.ToString());
                    linetowrite.WriteLine(FS.ToString());
                    linetowrite.WriteLine(cbPfPP.SelectedIndex.ToString());
                    linetowrite.WriteLine(l.ToString());
                    linetowrite.WriteLine(indTipApoy.ToString());
                    linetowrite.WriteLine(ltv.ToString());
                    linetowrite.WriteLine(dtgFyM.Rows.Count.ToString());
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                       string tipo = dtgFyM.Rows[i].Cells[0].Value.ToString();
                        string x1 = dtgFyM.Rows[i].Cells[1].Value.ToString();
                        string x2 = dtgFyM.Rows[i].Cells[2].Value.ToString();
                        string fz = dtgFyM.Rows[i].Cells[3].Value.ToString();
                        string fz1 = dtgFyM.Rows[i].Cells[4].Value.ToString();
                        string fz2 = dtgFyM.Rows[i].Cells[5].Value.ToString();
                        string mto = dtgFyM.Rows[i].Cells[6].Value.ToString();

                        linetowrite.Write(tipo);
                        linetowrite.Write(";");
                        linetowrite.Write(x1);
                        linetowrite.Write(";");
                        linetowrite.Write(x2);
                        linetowrite.Write(";");
                        linetowrite.Write(fz);
                        linetowrite.Write(";");
                        linetowrite.Write(fz1);
                        linetowrite.Write(";");
                        linetowrite.Write(fz2);
                        linetowrite.Write(";");
                        linetowrite.WriteLine(mto);

                    }

                    if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                    {
                        linetowrite.WriteLine("1");
                    }
                    else
                    {
                        linetowrite.WriteLine("0");
                    }
                    if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                    {
                        linetowrite.WriteLine("1");
                    }
                    else
                    {
                        linetowrite.WriteLine("0");
                    }

                    linetowrite.WriteLine(TabCtrlPanelPrincipal.SelectedIndex.ToString());
                    linetowrite.WriteLine(haymaterial.ToString());
                    linetowrite.WriteLine(lcon.ToString());
                    linetowrite.WriteLine(ME.ToString());
                  

                    linetowrite.Flush();
                    linetowrite.Close();


                }
                else
                {
                    string namefile = sf.FileName;
                    StreamWriter linetowrite = File.CreateText(namefile);
                    linetowrite.WriteLine(unidades.ToString());
                    linetowrite.WriteLine(Rtachkbpregunta.ToString());
                    linetowrite.WriteLine(indPesñMat.ToString());
                    linetowrite.WriteLine(indLisBxMat.ToString());
                    linetowrite.WriteLine(ET.ToString());
                    linetowrite.WriteLine(EC.ToString());
                    linetowrite.WriteLine(FS.ToString());
                    linetowrite.WriteLine(cbPfPP.SelectedIndex.ToString());
                    linetowrite.WriteLine(l.ToString());
                    linetowrite.WriteLine(indTipApoy.ToString());
                    linetowrite.WriteLine(ltv.ToString());
                    linetowrite.WriteLine(dtgFyM.Rows.Count.ToString());
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        string tipo = dtgFyM.Rows[i].Cells[0].Value.ToString();
                        string x1 = dtgFyM.Rows[i].Cells[1].Value.ToString();
                        string x2 = dtgFyM.Rows[i].Cells[2].Value.ToString();
                        string fz = dtgFyM.Rows[i].Cells[3].Value.ToString();
                        string fz1 = dtgFyM.Rows[i].Cells[4].Value.ToString();
                        string fz2 = dtgFyM.Rows[i].Cells[5].Value.ToString();
                        string mto = dtgFyM.Rows[i].Cells[6].Value.ToString();

                        linetowrite.Write(tipo);
                        linetowrite.Write(";");
                        linetowrite.Write(x1);
                        linetowrite.Write(";");
                        linetowrite.Write(x2);
                        linetowrite.Write(";");
                        linetowrite.Write(fz);
                        linetowrite.Write(";");
                        linetowrite.Write(fz1);
                        linetowrite.Write(";");
                        linetowrite.Write(fz2);
                        linetowrite.Write(";");
                        linetowrite.WriteLine(mto);

                    }
                    if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                    {
                        linetowrite.WriteLine("1");
                    }
                    else
                    {
                        linetowrite.WriteLine("0");
                    }
                    if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                    {
                        linetowrite.WriteLine("1");
                    }
                    else
                    {
                        linetowrite.WriteLine("0");
                    }

                    linetowrite.WriteLine(TabCtrlPanelPrincipal.SelectedIndex.ToString());
                    linetowrite.WriteLine(haymaterial.ToString());
                    linetowrite.WriteLine(lcon.ToString());

                    linetowrite.Flush();
                    linetowrite.Close();
                }

            }


        }

        private void tabCgVgPP_DragDrop(object sender, DragEventArgs e)
        {
            //string chkbpregunta;

            string[] archivo = (string[])e.Data.GetData(DataFormats.FileDrop,false);
            Stream myStream = null;
            StreamReader lector = File.OpenText(archivo[0]);

            try
            {
                if ((myStream = lector.BaseStream) != null)
                {
                    using (myStream)
                    {
                        rr = null;
                        rr = new Read(myStream);

                        if (rr.get_unidades() == "0")
                        {
                            SItsitem.PerformClick();
                        }
                        else if (rr.get_unidades() == "1")
                        {
                            EUtsitem.PerformClick();
                        }

                        if (Convert.ToInt32(rr.get_Chkbpregunta()) == 1)
                        {
                            chkbSDPP.Checked = true;
                            
                            Mtst.Visible = false;

                        }
                        else
                        {
                            chkbSDPP.Checked = false;
                            Mtst.Visible = true;
                        }

                        indPesñMat = Convert.ToInt32(rr.get_indpstMt());

                        if (indPesñMat == 0 && Convert.ToInt32(rr.get_indlb()) != -1)
                        {
                            if (unidades == 0)
                            {
                                ET = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][4].ToString());
                                EC = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][5].ToString());
                                ETP = ET / FS;
                                ECP = EC / FS;
                                Mtset = "Mt: " + acero1.Rows[Convert.ToInt32(rr.get_indlb())][1];
                                Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                   + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                            }
                            else if (unidades == 1)
                            {
                                ET = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][2].ToString());
                                EC = double.Parse(acero1.Rows[Convert.ToInt32(rr.get_indlb())][3].ToString());
                                ETP = ET / FS;
                                ECP = EC / FS;
                                Mtset = "Mt: " + acero1.Rows[Convert.ToInt32(rr.get_indlb())][1];
                                Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                   + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                            }

                        }
                        else if (indPesñMat == 1)
                        {

                            ET = Convert.ToDouble(rr.get_et());
                            EC = Convert.ToDouble(rr.get_ec());
                            ME = Convert.ToDouble(rr.get_me());
                            ETP = ET / FS;
                            ECP = EC / FS;
                            Mtset = "Mt: Personalizado";
                            Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                                + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                        }
                        //factor de seguridad
                        txtFSPP.Text = rr.get_fs();
                        FS = Convert.ToDouble(rr.get_fs());
                        ETP = ET / FS;
                        ECP = EC / FS;
                        ME = Convert.ToDouble(rr.get_me());
                        Mtst.ToolTipText = "Resistencia última a tensión: " + ET.ToString() + "\r" + "Resistencia última a cortante: " + EC.ToString()
                                               + "\r" + "Esfuerzo a la tensión permisible: " + ETP.ToString() + "\r" + "Esfuerzo cortante permisible: " + ECP.ToString();
                        //combo box perfil
                        cbPfPP.SelectedIndex = Convert.ToInt32(rr.get_cbPf());

                        //longitud
                        txtLPP.Text = rr.get_l();
                        l = Convert.ToDouble(rr.get_l());

                        //apoyo
                        indTipApoy = Convert.ToInt32(rr.get_apy());
                        if (indTipApoy == 1)
                        {
                            tv = 1;
                            cbApyPP.SelectedIndex = 1;



                            tv = 0;
                        }
                        else if (indTipApoy == 3)
                        {
                            tc = 1;
                            cbApyPP.SelectedIndex = 3;

                            tc = 0;
                        }




                        //longitud de apoyo en tramo en voladizo
                        if (indTipApoy == 1)
                        {
                            ltv = Convert.ToDouble(rr.get_ltv());
                            ltvst.Visible = true;
                            ltvst.Text = "ltv: " + ltv.ToString();
                        }
                        else
                        {
                            ltvst.Visible = false;
                        }
                        if (indTipApoy == 3)
                        {
                            lcon = Convert.ToDouble(rr.get_lcon());
                            lconst.Visible = true;
                            lconst.Text = "lcon = " + lcon.ToString();
                        }
                        else
                        {
                            lconst.Visible = false;
                        }

                        ////////////cargas y momentos/////////////////
                        int nfilas;
                        nfilas = Convert.ToInt32(rr.get_nfilas());

                        DataTable dtaux1 = new DataTable("datatableaux1");
                        dtaux1 = rr.get_dtaux();

                        dtgFyM.Rows.Clear();
                        if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                        {
                            TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                        }
                        if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                        {
                            TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                        }
                        for (int i = 0; i < nfilas; i++)
                        {
                            if (dtaux1.Rows[i][0].ToString() == "CC")
                            {
                                dtgFyM.Rows.Add();

                                dtgFyM.Rows[i].Cells[0].Value = "CC";
                                dtgFyM.Rows[i].Cells[1].Value = dtaux1.Rows[i][1].ToString();
                                dtgFyM.Rows[i].Cells[2].Value = dtaux1.Rows[i][2].ToString();
                                dtgFyM.Rows[i].Cells[3].Value = dtaux1.Rows[i][3].ToString();
                                dtgFyM.Rows[i].Cells[4].Value = dtaux1.Rows[i][4].ToString();
                                dtgFyM.Rows[i].Cells[5].Value = dtaux1.Rows[i][5].ToString();
                                dtgFyM.Rows[i].Cells[6].Value = dtaux1.Rows[i][6].ToString();

                                dtgFyM.Rows[i].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                                dtgFyM.Rows[i].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");
                            }
                            else if (dtaux1.Rows[i][0].ToString() == "CD")
                            {
                                dtgFyM.Rows.Add();

                                dtgFyM.Rows[i].Cells[0].Value = "CD";
                                dtgFyM.Rows[i].Cells[1].Value = dtaux1.Rows[i][1].ToString();
                                dtgFyM.Rows[i].Cells[2].Value = dtaux1.Rows[i][2].ToString();
                                dtgFyM.Rows[i].Cells[3].Value = dtaux1.Rows[i][3].ToString();
                                dtgFyM.Rows[i].Cells[4].Value = dtaux1.Rows[i][4].ToString();
                                dtgFyM.Rows[i].Cells[5].Value = dtaux1.Rows[i][5].ToString();
                                dtgFyM.Rows[i].Cells[6].Value = dtaux1.Rows[i][6].ToString();

                                dtgFyM.Rows[i].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                                dtgFyM.Rows[i].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");
                            }
                            else if (dtaux1.Rows[i][0].ToString() == "M")
                            {
                                dtgFyM.Rows.Add();

                                dtgFyM.Rows[i].Cells[0].Value = "M";
                                dtgFyM.Rows[i].Cells[1].Value = dtaux1.Rows[i][1].ToString();
                                dtgFyM.Rows[i].Cells[2].Value = dtaux1.Rows[i][2].ToString();
                                dtgFyM.Rows[i].Cells[3].Value = dtaux1.Rows[i][3].ToString();
                                dtgFyM.Rows[i].Cells[4].Value = dtaux1.Rows[i][4].ToString();
                                dtgFyM.Rows[i].Cells[5].Value = dtaux1.Rows[i][5].ToString();
                                dtgFyM.Rows[i].Cells[6].Value = dtaux1.Rows[i][6].ToString();

                                dtgFyM.Rows[i].Cells[7].Value = Image.FromFile("ilustraciones/btnlapiz.png");
                                dtgFyM.Rows[i].Cells[8].Value = Image.FromFile("ilustraciones/btnborrar.png");
                            }
                        }

                        tabCgVgPP.Invalidate();

                        haymaterial = Convert.ToInt32(rr.get_haymaterial());
                        if (Convert.ToInt32(rr.get_tabdiag()) == 1)
                        {
                            btnResolPP.PerformClick();
                            TabCtrlPanelPrincipal.SelectedIndex = Convert.ToInt32(rr.get_stabprin());
                        }

                      
                        myStream.Close();
              
                    }
                }
              
            }
            catch (Exception)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Se ha presentado un error al abrir archivo");
            }
        }

        private void btnAntPerf_Click(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }

            int sind;
            sind = lbperf.SelectedIndex;
            int siname;
            siname = lbnameperf.SelectedIndex;

            if (cbPfPP.SelectedIndex == 0)
            {
                if (sind == lbperf.Items.Count - 1)
                {
                    btnAntPerf.Enabled = false;
                }

                else
                {

                    string name;

                    lbperf.SelectedIndex = sind + 1;
                    lbnameperf.SelectedIndex = siname + 1;

                    idvgsda = (int)lbperf.SelectedItem;
                    name = lbnameperf.SelectedItem.ToString();

                    foreach (char primerapalabra in name)
                    {
                        if (primerapalabra.ToString() == "W")
                        {
                            if (unidades == 0)
                            {
                                txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                                txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                                txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                                txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                                txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();

                                double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                                tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                                s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                                ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                                bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                                tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                                areaq = tf * bf;
                                ytq = 0.5 * d - 0.5 * tf;
                                q = areaq * ytq;
                                v = yDgCte[xdelyMtomayorABS];
                                v = Math.Abs(v);
                                sa = (yDgMtomayABS) / (s * 1000);
                                sb = sa * (0.5 * d - tf) / (0.5 * d);
                                cb = (v * q) / (ix * tw);
                                cb = cb / 1000;
                                spa = sa; // en megapascales
                            
                                spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));


                                string prefijo = "";

                                if (sa > 0 && sa < 0.001)
                                {
                                    sa = sa * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (sa >= 0.001 && sa < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (sa >= 1000)
                                {
                                    sa = sa / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                txtENena.Text = sa.ToString("0.000");
                                lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                txtECena.Text = "0";

                                if (sb > 0 && sb < 0.001)
                                {
                                    sb = sb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (sb >= 0.001 && sb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (sb >= 1000)
                                {
                                    sb = sb / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                txtENenb.Text = sb.ToString("0.000");

                                if (cb > 0 && cb < 0.001)
                                {
                                    cb = cb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (cb >= 0.001 && cb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (cb >= 1000)
                                {
                                    cb = cb / 1000;
                                    prefijo = "[GPa]";
                                }
                                lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                txtECenb.Text = cb.ToString("0.000");

                                if (spa > 0 && spa < 0.001)
                                {
                                    spa = spa * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (spa >= 0.001 && spa < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (spa >= 1000)
                                {
                                    spa = spa / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                txtspa.Text = spa.ToString();

                                if (spb > 0 && spb < 0.001)
                                {
                                    spb = spb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (spb >= 0.001 && spb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (spb >= 1000)
                                {
                                    spb = spb / 1000;
                                    prefijo = "[GPa]:";
                                }

                                txtspb.Text = spb.ToString();
                                lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                //dibujar perfil
                                pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                                pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                                pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                            }
                            else if (unidades == 1)
                            {
                                txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                                txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                                txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                                txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                                txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();

                                //cálculo del esfuerzo principal
                                double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                                tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                                s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                                ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                                bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                                tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                                areaq = tf * bf;
                                ytq = 0.5 * d - 0.5 * tf;
                                q = areaq * ytq;
                                v = yDgCte[xdelyMtomayorABS];
                                v = Math.Abs(v);
                                sa = (yDgMtomayABS * 12) / (s);
                                sb = sa * (0.5 * d - tf) / (0.5 * d);
                                cb = (v * q) / (ix * tw);
                                spa = sa;
                                spa = Math.Round(spa, 4);
                                spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                spb = Math.Round(spb, 4);


                                string prefijo = "";

                                if (sa > 0 && sa < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (sa >= 1000000 && sa < 1000000000)
                                {
                                    sa = sa / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (sa >= 1000000000)
                                {
                                    sa = sa / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                txtENena.Text = sa.ToString("0.000");
                                lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                txtECena.Text = "0";

                                if (sb > 0 && sb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (sb >= 1000000 && sb < 1000000000)
                                {
                                    sb = sb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (sb >= 1000000000)
                                {
                                    sb = sb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                txtENenb.Text = sb.ToString("0.000");

                                if (cb > 0 && cb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (cb >= 1000000 && cb < 1000000000)
                                {
                                    cb = cb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (cb >= 1000000000)
                                {
                                    cb = cb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                txtECenb.Text = cb.ToString("0.000");

                                if (spa > 0 && spa < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (spa >= 1000000 && spa < 1000000000)
                                {
                                    spa = spa / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (spa >= 1000000000)
                                {
                                    spa = spa / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                txtspa.Text = spa.ToString();

                                if (spb > 0 && spb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (spb >= 1000000 && spb < 1000000000)
                                {
                                    spb = spb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (spb >= 1000000000)
                                {
                                    spb = spb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }

                                txtspb.Text = spb.ToString();
                                lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                //dibujar perfil
                                pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                                pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                                pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                            }
                         

                            break;
                        }
                        else if (primerapalabra.ToString() == "S")
                        {
                            if (unidades == 0)
                            {
                                txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                                txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                                txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                                txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                                txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();


                                //cálculo del esfuerzo principal
                                double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                                tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                                s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                                ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                                bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                                tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                                areaq = tf * bf;
                                ytq = 0.5 * d - 0.5 * tf;
                                q = areaq * ytq;
                                v = yDgCte[xdelyMtomayorABS];
                                v = Math.Abs(v);
                                sa = (yDgMtomayABS) / (s * 1000);
                                sb = sa * (0.5 * d - tf) / (0.5 * d);
                                cb = (v * q) / (ix * tw);
                                cb = cb / 1000;
                                spa = sa; // en megapascales
                           
                                spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                                string prefijo = "";

                                if (sa > 0 && sa < 0.001)
                                {
                                    sa = sa * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (sa >= 0.001 && sa < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (sa >= 1000)
                                {
                                    sa = sa / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                txtENena.Text = sa.ToString("0.000");
                                lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                txtECena.Text = "0";

                                if (sb > 0 && sb < 0.001)
                                {
                                    sb = sb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (sb >= 0.001 && sb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (sb >= 1000)
                                {
                                    sb = sb / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                txtENenb.Text = sb.ToString("0.000");

                                if (cb > 0 && cb < 0.001)
                                {
                                    cb = cb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (cb >= 0.001 && cb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (cb >= 1000)
                                {
                                    cb = cb / 1000;
                                    prefijo = "[GPa]";
                                }
                                lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                txtECenb.Text = cb.ToString("0.000");

                                if (spa > 0 && spa < 0.001)
                                {
                                    spa = spa * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (spa >= 0.001 && spa < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (spa >= 1000)
                                {
                                    spa = spa / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                txtspa.Text = spa.ToString();

                                if (spb > 0 && spb < 0.001)
                                {
                                    spb = spb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (spb >= 0.001 && spb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (spb >= 1000)
                                {
                                    spb = spb / 1000;
                                    prefijo = "[GPa]:";
                                }

                                txtspb.Text = spb.ToString();
                                lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            }
                            else if (unidades == 1)
                            {
                                txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                                txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                                txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                                txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                                txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                                //cálculo del esfuerzo principal
                                double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                d = double.Parse(psus1.Rows[idvgsda - 1][3].ToString());
                                tf = double.Parse(psus1.Rows[idvgsda - 1][6].ToString());
                                s = double.Parse(psus1.Rows[idvgsda - 1][2].ToString());
                                ix = double.Parse(psus1.Rows[idvgsda - 1][8].ToString());
                                bf = double.Parse(psus1.Rows[idvgsda - 1][5].ToString());
                                tw = double.Parse(psus1.Rows[idvgsda - 1][7].ToString());

                                areaq = tf * bf;
                                ytq = 0.5 * d - 0.5 * tf;
                                q = areaq * ytq;
                                v = yDgCte[xdelyMtomayorABS];
                                v = Math.Abs(v);
                                sa = (yDgMtomayABS * 12) / (s);
                                sb = sa * (0.5 * d - tf) / (0.5 * d);
                                cb = (v * q) / (ix * tw);
                                spa = sa;
                                spa = Math.Round(spa, 4);
                                spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                spb = Math.Round(spb, 4);


                                string prefijo = "";

                                if (sa > 0 && sa < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (sa >= 1000000 && sa < 1000000000)
                                {
                                    sa = sa / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (sa >= 1000000000)
                                {
                                    sa = sa / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                txtENena.Text = sa.ToString("0.000");
                                lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                txtECena.Text = "0";

                                if (sb > 0 && sb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (sb >= 1000000 && sb < 1000000000)
                                {
                                    sb = sb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (sb >= 1000000000)
                                {
                                    sb = sb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                txtENenb.Text = sb.ToString("0.000");

                                if (cb > 0 && cb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (cb >= 1000000 && cb < 1000000000)
                                {
                                    cb = cb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (cb >= 1000000000)
                                {
                                    cb = cb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                txtECenb.Text = cb.ToString("0.000");

                                if (spa > 0 && spa < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (spa >= 1000000 && spa < 1000000000)
                                {
                                    spa = spa / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (spa >= 1000000000)
                                {
                                    spa = spa / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                txtspa.Text = spa.ToString();

                                if (spb > 0 && spb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (spb >= 1000000 && spb < 1000000000)
                                {
                                    spb = spb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (spb >= 1000000000)
                                {
                                    spb = spb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }

                                txtspb.Text = spb.ToString();
                                lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            }

                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";

                            break;
                        }

                        else if (primerapalabra.ToString() == "C")
                        {
                            if (unidades == 0)
                            {
                                txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                                txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                                txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                                txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                                txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();


                                //cálculo del esfuerzo principal
                                double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                                tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                                s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                                ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                                bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                                tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                                areaq = tf * bf;
                                ytq = 0.5 * d - 0.5 * tf;
                                q = areaq * ytq;
                                v = yDgCte[xdelyMtomayorABS];
                                v = Math.Abs(v);
                                sa = (yDgMtomayABS) / (s * 1000);
                                sb = sa * (0.5 * d - tf) / (0.5 * d);
                                cb = (v * q) / (ix * tw);
                                cb = cb / 1000;
                                spa = sa; // en megapascales

                                spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                                string prefijo = "";

                                if (sa > 0 && sa < 0.001)
                                {
                                    sa = sa * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (sa >= 0.001 && sa < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (sa >= 1000)
                                {
                                    sa = sa / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                txtENena.Text = sa.ToString("0.000");
                                lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                txtECena.Text = "0";

                                if (sb > 0 && sb < 0.001)
                                {
                                    sb = sb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (sb >= 0.001 && sb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (sb >= 1000)
                                {
                                    sb = sb / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                txtENenb.Text = sb.ToString("0.000");

                                if (cb > 0 && cb < 0.001)
                                {
                                    cb = cb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (cb >= 0.001 && cb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (cb >= 1000)
                                {
                                    cb = cb / 1000;
                                    prefijo = "[GPa]";
                                }
                                lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                txtECenb.Text = cb.ToString("0.000");

                                if (spa > 0 && spa < 0.001)
                                {
                                    spa = spa * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (spa >= 0.001 && spa < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (spa >= 1000)
                                {
                                    spa = spa / 1000;
                                    prefijo = "[GPa]:";
                                }
                                lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                txtspa.Text = spa.ToString();

                                if (spb > 0 && spb < 0.001)
                                {
                                    spb = spb * 1000;
                                    prefijo = "[kPa]:";
                                }
                                else if (spb >= 0.001 && spb < 1000)
                                {

                                    prefijo = "[MPa]:";
                                }
                                else if (spb >= 1000)
                                {
                                    spb = spb / 1000;
                                    prefijo = "[GPa]:";
                                }

                                txtspb.Text = spb.ToString();
                                lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            }
                            else if (unidades == 1)
                            {
                                txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                                txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                                txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                                txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                                txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();

                                //cálculo del esfuerzo principal
                                double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                                tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                                s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                                ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                                bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                                tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                                areaq = tf * bf;
                                ytq = 0.5 * d - 0.5 * tf;
                                q = areaq * ytq;
                                v = yDgCte[xdelyMtomayorABS];
                                v = Math.Abs(v);
                                sa = (yDgMtomayABS * 12) / (s);
                                sb = sa * (0.5 * d - tf) / (0.5 * d);
                                cb = (v * q) / (ix * tw);
                                spa = sa;
                                spa = Math.Round(spa, 4);
                                spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                spb = Math.Round(spb, 4);


                                string prefijo = "";

                                if (sa > 0 && sa < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (sa >= 1000000 && sa < 1000000000)
                                {
                                    sa = sa / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (sa >= 1000000000)
                                {
                                    sa = sa / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                txtENena.Text = sa.ToString("0.000");
                                lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                txtECena.Text = "0";

                                if (sb > 0 && sb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (sb >= 1000000 && sb < 1000000000)
                                {
                                    sb = sb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (sb >= 1000000000)
                                {
                                    sb = sb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                txtENenb.Text = sb.ToString("0.000");

                                if (cb > 0 && cb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (cb >= 1000000 && cb < 1000000000)
                                {
                                    cb = cb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (cb >= 1000000000)
                                {
                                    cb = cb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                txtECenb.Text = cb.ToString("0.000");

                                if (spa > 0 && spa < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (spa >= 1000000 && spa < 1000000000)
                                {
                                    spa = spa / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (spa >= 1000000000)
                                {
                                    spa = spa / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }
                                lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                txtspa.Text = spa.ToString();

                                if (spb > 0 && spb < 1000000)
                                {
                                    prefijo = "[ksi]:";
                                }
                                else if (spb >= 1000000 && spb < 1000000000)
                                {
                                    spb = spb / 1000000;
                                    prefijo = "[Mpsi]:";
                                }
                                else if (spb >= 1000000000)
                                {
                                    spb = spb / 1000000000;
                                    prefijo = "[Gpsi]:";
                                }

                                txtspb.Text = spb.ToString();
                                lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            }

                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
                            break;
                        }
                    }

                    pnlDibPerf.Invalidate();
                 
                }

                if (sind < lbperf.Items.Count - 1)
                {
                    btnSiguPerf.Enabled = true;
                }
            }
            else if (cbPfPP.SelectedIndex == 1)
            {
                if (sind == lbperf.Items.Count - 1)
                {
                    btnAntPerf.Enabled = false;
                }

                else
                {
                    lbperf.SelectedIndex = sind + 1;


                    idvgsda = (int)lbperf.SelectedItem;
                    if (unidades == 0)
                    {
                        txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();

                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa * 1000; // en megapascales
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = spb * 1000; // en megapascales
                        spb = Math.Round(spb, 4);

                        string prefijo = "";

                        if (sa > 0 && sa < 0.001)
                        {
                            sa = sa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sa >= 0.001 && sa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sa >= 1000)
                        {
                            sa = sa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 0.001)
                        {
                            sb = sb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sb >= 0.001 && sb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sb >= 1000)
                        {
                            sb = sb / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 0.001)
                        {
                            cb = cb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (cb >= 0.001 && cb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (cb >= 1000)
                        {
                            cb = cb / 1000;
                            prefijo = "[GPa]";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 0.001)
                        {
                            spa = spa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spa >= 0.001 && spa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spa >= 1000)
                        {
                            spa = spa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 0.001)
                        {
                            spb = spb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spb >= 0.001 && spb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spb >= 1000)
                        {
                            spb = spb / 1000;
                            prefijo = "[GPa]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;

                        //dibujar perfil
                        pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                        pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                        pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";

                    }
                    else if (unidades == 1)
                    {
                        txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();

                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS * 12) / (s);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa;
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = Math.Round(spb, 4);


                        string prefijo = "";

                        if (sa > 0 && sa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sa >= 1000000 && sa < 1000000000)
                        {
                            sa = sa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sa >= 1000000000)
                        {
                            sa = sa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sb >= 1000000 && sb < 1000000000)
                        {
                            sb = sb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sb >= 1000000000)
                        {
                            sb = sb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (cb >= 1000000 && cb < 1000000000)
                        {
                            cb = cb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (cb >= 1000000000)
                        {
                            cb = cb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spa >= 1000000 && spa < 1000000000)
                        {
                            spa = spa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spa >= 1000000000)
                        {
                            spa = spa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spb >= 1000000 && spb < 1000000000)
                        {
                            spb = spb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spb >= 1000000000)
                        {
                            spb = spb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;

                        //dibujar perfil
                        pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                        pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                        pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                    }
                 

                  
                }

                if (sind < lbperf.Items.Count - 1)
                {
                    btnSiguPerf.Enabled = true;
                }

            }
            else if (cbPfPP.SelectedIndex == 2)
            {
                if (sind == lbperf.Items.Count - 1)
                {
                    btnAntPerf.Enabled = false;
                }

                else
                {
                    lbperf.SelectedIndex = sind + 1;


                    idvgsda = (int)lbperf.SelectedItem;

                    if (unidades == 0)
                    {
                        txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();


                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa * 1000; // en megapascales
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = spb * 1000; // en megapascales
                        spb = Math.Round(spb, 4);

                        string prefijo = "";

                        if (sa > 0 && sa < 0.001)
                        {
                            sa = sa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sa >= 0.001 && sa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sa >= 1000)
                        {
                            sa = sa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 0.001)
                        {
                            sb = sb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sb >= 0.001 && sb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sb >= 1000)
                        {
                            sb = sb / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 0.001)
                        {
                            cb = cb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (cb >= 0.001 && cb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (cb >= 1000)
                        {
                            cb = cb / 1000;
                            prefijo = "[GPa]";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 0.001)
                        {
                            spa = spa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spa >= 0.001 && spa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spa >= 1000)
                        {
                            spa = spa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 0.001)
                        {
                            spb = spb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spb >= 0.001 && spb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spb >= 1000)
                        {
                            spb = spb / 1000;
                            prefijo = "[GPa]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }
                    else if (unidades == 1)
                    {
                        txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();

                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS*12) / (s);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa;
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                    
                        spb = Math.Round(spb, 4);


                        string prefijo = "";

                        if (sa > 0 && sa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sa >= 1000000 && sa < 1000000000)
                        {
                            sa = sa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sa >= 1000000000)
                        {
                            sa = sa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sb >= 1000000 && sb < 1000000000)
                        {
                            sb = sb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sb >= 1000000000)
                        {
                            sb = sb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (cb >= 1000000 && cb < 1000000000)
                        {
                            cb = cb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (cb >= 1000000000)
                        {
                            cb = cb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spa >= 1000000 && spa < 1000000000)
                        {
                            spa = spa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spa >= 1000000000)
                        {
                            spa = spa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spb >= 1000000 && spb < 1000000000)
                        {
                            spb = spb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spb >= 1000000000)
                        {
                            spb = spb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }


                    //dibujar perfil
                    pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";
                }

                if (sind < lbperf.Items.Count - 1)
                {
                    btnSiguPerf.Enabled = true;
                }
            }
            else if (cbPfPP.SelectedIndex == 3)
            {
                if (sind == lbperf.Items.Count - 1)
                {
                    btnAntPerf.Enabled = false;
                }

                else
                {
                    lbperf.SelectedIndex = sind + 1;


                    idvgsda = (int)lbperf.SelectedItem;

                    if (unidades == 0)
                    {
                        txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();


                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyCtemayorABS];
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa * 1000; // en megapascales
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = spb * 1000; // en megapascales
                        spb = Math.Round(spb, 4);

                        string prefijo = "";

                        if (sa > 0 && sa < 0.001)
                        {
                            sa = sa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sa >= 0.001 && sa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sa >= 1000)
                        {
                            sa = sa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 0.001)
                        {
                            sb = sb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sb >= 0.001 && sb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sb >= 1000)
                        {
                            sb = sb / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 0.001)
                        {
                            cb = cb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (cb >= 0.001 && cb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (cb >= 1000)
                        {
                            cb = cb / 1000;
                            prefijo = "[GPa]";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 0.001)
                        {
                            spa = spa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spa >= 0.001 && spa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spa >= 1000)
                        {
                            spa = spa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 0.001)
                        {
                            spb = spb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spb >= 0.001 && spb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spb >= 1000)
                        {
                            spb = spb / 1000;
                            prefijo = "[GPa]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }
                    else if (unidades == 1)
                    {
                        txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa * 1000; // en megapascales
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = spb * 1000; // en megapascales
                        spb = Math.Round(spb, 4);


                        string prefijo = "";

                        if (sa > 0 && sa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sa >= 1000000 && sa < 1000000000)
                        {
                            sa = sa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sa >= 1000000000)
                        {
                            sa = sa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sb >= 1000000 && sb < 1000000000)
                        {
                            sb = sb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sb >= 1000000000)
                        {
                            sb = sb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (cb >= 1000000 && cb < 1000000000)
                        {
                            cb = cb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (cb >= 1000000000)
                        {
                            cb = cb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spa >= 1000000 && spa < 1000000000)
                        {
                            spa = spa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spa >= 1000000000)
                        {
                            spa = spa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spb >= 1000000 && spb < 1000000000)
                        {
                            spb = spb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spb >= 1000000000)
                        {
                            spb = spb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }


                    //dibujar perfil
                    pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
                }

                if (sind < lbperf.Items.Count - 1)
                {
                    btnSiguPerf.Enabled = true;
                }
            }



        }

        private void btnSiguPerf_Click(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }

            int sind;
            sind = lbperf.SelectedIndex;
            int siname;
            siname = lbnameperf.SelectedIndex;

            if (cbPfPP.SelectedIndex == 0)
            {
                if (sind == lbperf.Items.Count - 1 )
                {
                    btnSiguPerf.Enabled = false;
                }

                else
                {

                    string name;

                    lbperf.SelectedIndex = sind - 1;
                    lbnameperf.SelectedIndex = siname - 1;

                    try
                    {
                        idvgsda = (int)lbperf.SelectedItem;
                        name = lbnameperf.SelectedItem.ToString();

                        foreach (char primerapalabra in name)
                        {
                            if (primerapalabra.ToString() == "W")
                            {
                                if (unidades == 0)
                                {
                                    txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                                    txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                                    txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                                    txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                                    txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();

                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                                    tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                                    s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                                    ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                                    bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                                    tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS) / (s * 1000);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    cb = cb / 1000;
                                    spa = sa; // en megapascales
                                
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));




                                    string prefijo = "";

                                    if (sa > 0 && sa < 0.001)
                                    {
                                        sa = sa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sa >= 0.001 && sa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sa >= 1000)
                                    {
                                        sa = sa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 0.001)
                                    {
                                        sb = sb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sb >= 0.001 && sb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sb >= 1000)
                                    {
                                        sb = sb / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 0.001)
                                    {
                                        cb = cb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (cb >= 0.001 && cb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (cb >= 1000)
                                    {
                                        cb = cb / 1000;
                                        prefijo = "[GPa]";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 0.001)
                                    {
                                        spa = spa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spa >= 0.001 && spa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spa >= 1000)
                                    {
                                        spa = spa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 0.001)
                                    {
                                        spb = spb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spb >= 0.001 && spb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spb >= 1000)
                                    {
                                        spb = spb / 1000;
                                        prefijo = "[GPa]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                                }
                                else if (unidades == 1)
                                {
                                    txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                                    txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                                    txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                                    txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                                    txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();

                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                                    tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                                    s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                                    ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                                    bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                                    tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS * 12) / (s);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    spa = sa;
                                    spa = Math.Round(spa, 4);
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                    spb = Math.Round(spb, 4);


                                    string prefijo = "";

                                    if (sa > 0 && sa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sa >= 1000000 && sa < 1000000000)
                                    {
                                        sa = sa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sa >= 1000000000)
                                    {
                                        sa = sa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sb >= 1000000 && sb < 1000000000)
                                    {
                                        sb = sb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sb >= 1000000000)
                                    {
                                        sb = sb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (cb >= 1000000 && cb < 1000000000)
                                    {
                                        cb = cb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (cb >= 1000000000)
                                    {
                                        cb = cb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spa >= 1000000 && spa < 1000000000)
                                    {
                                        spa = spa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spa >= 1000000000)
                                    {
                                        spa = spa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spb >= 1000000 && spb < 1000000000)
                                    {
                                        spb = spb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spb >= 1000000000)
                                    {
                                        spb = spb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                                }
                             

                                break;
                            }
                            else if (primerapalabra.ToString() == "S")
                            {
                                if (unidades == 0)
                                {
                                    txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                                    txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                                    txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                                    txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                                    txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();


                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                                    tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                                    s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                                    ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                                    bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                                    tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS) / (s * 1000);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    cb = cb / 1000;
                                    spa = sa; // en megapascales
                                  
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));


                                    string prefijo = "";

                                    if (sa > 0 && sa < 0.001)
                                    {
                                        sa = sa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sa >= 0.001 && sa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sa >= 1000)
                                    {
                                        sa = sa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 0.001)
                                    {
                                        sb = sb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sb >= 0.001 && sb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sb >= 1000)
                                    {
                                        sb = sb / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 0.001)
                                    {
                                        cb = cb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (cb >= 0.001 && cb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (cb >= 1000)
                                    {
                                        cb = cb / 1000;
                                        prefijo = "[GPa]";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 0.001)
                                    {
                                        spa = spa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spa >= 0.001 && spa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spa >= 1000)
                                    {
                                        spa = spa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 0.001)
                                    {
                                        spb = spb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spb >= 0.001 && spb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spb >= 1000)
                                    {
                                        spb = spb / 1000;
                                        prefijo = "[GPa]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                                }
                                else if (unidades == 1)
                                {
                                    txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                                    txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                                    txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                                    txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                                    txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(psus1.Rows[idvgsda - 1][3].ToString());
                                    tf = double.Parse(psus1.Rows[idvgsda - 1][6].ToString());
                                    s = double.Parse(psus1.Rows[idvgsda - 1][2].ToString());
                                    ix = double.Parse(psus1.Rows[idvgsda - 1][8].ToString());
                                    bf = double.Parse(psus1.Rows[idvgsda - 1][5].ToString());
                                    tw = double.Parse(psus1.Rows[idvgsda - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS * 12) / (s);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    spa = sa;
                                    spa = Math.Round(spa, 4);
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                    spb = Math.Round(spb, 4);


                                    string prefijo = "";

                                    if (sa > 0 && sa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sa >= 1000000 && sa < 1000000000)
                                    {
                                        sa = sa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sa >= 1000000000)
                                    {
                                        sa = sa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sb >= 1000000 && sb < 1000000000)
                                    {
                                        sb = sb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sb >= 1000000000)
                                    {
                                        sb = sb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (cb >= 1000000 && cb < 1000000000)
                                    {
                                        cb = cb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (cb >= 1000000000)
                                    {
                                        cb = cb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spa >= 1000000 && spa < 1000000000)
                                    {
                                        spa = spa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spa >= 1000000000)
                                    {
                                        spa = spa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spb >= 1000000 && spb < 1000000000)
                                    {
                                        spb = spb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spb >= 1000000000)
                                    {
                                        spb = spb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                                }
                                //dibujar perfil
                                pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                                pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                                pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";

                                break;
                            }

                            else if (primerapalabra.ToString() == "C")
                            {
                                if (unidades == 0)
                                {
                                    txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                                    txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                                    txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                                    txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                                    txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();


                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                                    tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                                    s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                                    ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                                    bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                                    tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS) / (s * 1000);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    cb = cb / 1000;
                                    spa = sa; // en megapascales

                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                                    string prefijo = "";

                                    if (sa > 0 && sa < 0.001)
                                    {
                                        sa = sa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sa >= 0.001 && sa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sa >= 1000)
                                    {
                                        sa = sa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 0.001)
                                    {
                                        sb = sb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sb >= 0.001 && sb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sb >= 1000)
                                    {
                                        sb = sb / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 0.001)
                                    {
                                        cb = cb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (cb >= 0.001 && cb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (cb >= 1000)
                                    {
                                        cb = cb / 1000;
                                        prefijo = "[GPa]";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 0.001)
                                    {
                                        spa = spa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spa >= 0.001 && spa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spa >= 1000)
                                    {
                                        spa = spa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 0.001)
                                    {
                                        spb = spb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spb >= 0.001 && spb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spb >= 1000)
                                    {
                                        spb = spb / 1000;
                                        prefijo = "[GPa]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                                }
                                else if (unidades == 1)
                                {
                                    txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                                    txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                                    txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                                    txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                                    txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();

                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                                    tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                                    s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                                    ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                                    bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                                    tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS * 12) / (s);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    spa = sa;
                                    spa = Math.Round(spa, 4);
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                    spb = Math.Round(spb, 4);


                                    string prefijo = "";

                                    if (sa > 0 && sa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sa >= 1000000 && sa < 1000000000)
                                    {
                                        sa = sa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sa >= 1000000000)
                                    {
                                        sa = sa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sb >= 1000000 && sb < 1000000000)
                                    {
                                        sb = sb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sb >= 1000000000)
                                    {
                                        sb = sb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (cb >= 1000000 && cb < 1000000000)
                                    {
                                        cb = cb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (cb >= 1000000000)
                                    {
                                        cb = cb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spa >= 1000000 && spa < 1000000000)
                                    {
                                        spa = spa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spa >= 1000000000)
                                    {
                                        spa = spa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spb >= 1000000 && spb < 1000000000)
                                    {
                                        spb = spb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spb >= 1000000000)
                                    {
                                        spb = spb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                                }

                                //dibujar perfil
                                pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                                pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                                pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";

                                break;
                            }




                        }

                        pnlDibPerf.Invalidate();

                    }
                    catch (Exception)
                    {

                        btnSiguPerf.Enabled = false;
                    }
                   
                   

             


                }

                if (sind > 0)
                {
                    btnAntPerf.Enabled = true;
                }
            }
            else if (cbPfPP.SelectedIndex == 1)
            {
                if (sind == 0)
                {
                    btnSiguPerf.Enabled = false;
                }

                else
                {
                    lbperf.SelectedIndex = sind - 1;


                    idvgsda = (int)lbperf.SelectedItem;

                    if (unidades == 0)
                    {
                        txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();

                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        cb = cb / 1000;
                        spa = sa ; // en megapascales
                    
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                        string prefijo = "";

                        if (sa > 0 && sa < 0.001)
                        {
                            sa = sa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sa >= 0.001 && sa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sa >= 1000)
                        {
                            sa = sa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 0.001)
                        {
                            sb = sb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sb >= 0.001 && sb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sb >= 1000)
                        {
                            sb = sb / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 0.001)
                        {
                            cb = cb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (cb >= 0.001 && cb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (cb >= 1000)
                        {
                            cb = cb / 1000;
                            prefijo = "[GPa]";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 0.001)
                        {
                            spa = spa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spa >= 0.001 && spa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spa >= 1000)
                        {
                            spa = spa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 0.001)
                        {
                            spb = spb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spb >= 0.001 && spb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spb >= 1000)
                        {
                            spb = spb / 1000;
                            prefijo = "[GPa]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;

                        //dibujar perfil
                        pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                        pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                        pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                    }
                    else if (unidades == 1)
                    {
                        txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();

                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS * 12) / (s);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa;
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = Math.Round(spb, 4);


                        string prefijo = "";

                        if (sa > 0 && sa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sa >= 1000000 && sa < 1000000000)
                        {
                            sa = sa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sa >= 1000000000)
                        {
                            sa = sa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sb >= 1000000 && sb < 1000000000)
                        {
                            sb = sb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sb >= 1000000000)
                        {
                            sb = sb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (cb >= 1000000 && cb < 1000000000)
                        {
                            cb = cb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (cb >= 1000000000)
                        {
                            cb = cb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spa >= 1000000 && spa < 1000000000)
                        {
                            spa = spa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spa >= 1000000000)
                        {
                            spa = spa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spb >= 1000000 && spb < 1000000000)
                        {
                            spb = spb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spb >= 1000000000)
                        {
                            spb = spb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;

                        //dibujar perfil
                        pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                        pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                        pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                    }
              

                    
                }

                if (sind > 0)
                {
                    btnAntPerf.Enabled = true;

                }
            }
            else if (cbPfPP.SelectedIndex == 2)
            {
                if (sind == 0)
                {
                    btnSiguPerf.Enabled = false;
                }

                else
                {
                    lbperf.SelectedIndex = sind - 1;


                    idvgsda = (int)lbperf.SelectedItem;

                    if (unidades == 0)
                    {
                        txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();


                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        cb = cb / 1000;
                        spa = sa; // en megapascales
                    
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                        string prefijo = "";

                        if (sa > 0 && sa < 0.001)
                        {
                            sa = sa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sa >= 0.001 && sa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sa >= 1000)
                        {
                            sa = sa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 0.001)
                        {
                            sb = sb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sb >= 0.001 && sb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sb >= 1000)
                        {
                            sb = sb / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 0.001)
                        {
                            cb = cb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (cb >= 0.001 && cb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (cb >= 1000)
                        {
                            cb = cb / 1000;
                            prefijo = "[GPa]";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 0.001)
                        {
                            spa = spa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spa >= 0.001 && spa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spa >= 1000)
                        {
                            spa = spa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 0.001)
                        {
                            spb = spb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spb >= 0.001 && spb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spb >= 1000)
                        {
                            spb = spb / 1000;
                            prefijo = "[GPa]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }
                    else if (unidades == 1)
                    {
                        txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(psus1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(psus1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(psus1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(psus1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(psus1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(psus1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS * 12) / (s);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa;
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                        spb = Math.Round(spb, 4);


                        string prefijo = "";

                        if (sa > 0 && sa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sa >= 1000000 && sa < 1000000000)
                        {
                            sa = sa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sa >= 1000000000)
                        {
                            sa = sa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sb >= 1000000 && sb < 1000000000)
                        {
                            sb = sb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sb >= 1000000000)
                        {
                            sb = sb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (cb >= 1000000 && cb < 1000000000)
                        {
                            cb = cb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (cb >= 1000000000)
                        {
                            cb = cb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spa >= 1000000 && spa < 1000000000)
                        {
                            spa = spa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spa >= 1000000000)
                        {
                            spa = spa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spb >= 1000000 && spb < 1000000000)
                        {
                            spb = spb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spb >= 1000000000)
                        {
                            spb = spb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }


                    //dibujar perfil
                    pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";
                }

                if (sind > 0)
                {
                    btnAntPerf.Enabled = true;

                }
            }
            else if (cbPfPP.SelectedIndex == 3)
            {
                if (sind == 0)
                {
                    btnSiguPerf.Enabled = false;
                }

                else
                {
                    lbperf.SelectedIndex = sind - 1;


                    idvgsda = (int)lbperf.SelectedItem;

                    if (unidades == 0)
                    {
                        txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();


                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS) / (s * 1000);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        cb = cb / 1000;
                        spa = sa ; // en megapascales
                      
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                        string prefijo = "";

                        if (sa > 0 && sa < 0.001)
                        {
                            sa = sa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sa >= 0.001 && sa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sa >= 1000)
                        {
                            sa = sa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 0.001)
                        {
                            sb = sb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (sb >= 0.001 && sb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (sb >= 1000)
                        {
                            sb = sb / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 0.001)
                        {
                            cb = cb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (cb >= 0.001 && cb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (cb >= 1000)
                        {
                            cb = cb / 1000;
                            prefijo = "[GPa]";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 0.001)
                        {
                            spa = spa * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spa >= 0.001 && spa < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spa >= 1000)
                        {
                            spa = spa / 1000;
                            prefijo = "[GPa]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 0.001)
                        {
                            spb = spb * 1000;
                            prefijo = "[kPa]:";
                        }
                        else if (spb >= 0.001 && spb < 1000)
                        {

                            prefijo = "[MPa]:";
                        }
                        else if (spb >= 1000)
                        {
                            spb = spb / 1000;
                            prefijo = "[GPa]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }
                    else if (unidades == 1)
                    {
                        txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                        txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                        txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                        txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                        txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();

                        //cálculo del esfuerzo principal
                        double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                        d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                        tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                        s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                        ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                        bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                        tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                        areaq = tf * bf;
                        ytq = 0.5 * d - 0.5 * tf;
                        q = areaq * ytq;
                        v = yDgCte[xdelyMtomayorABS];
                        v = Math.Abs(v);
                        sa = (yDgMtomayABS * 12) / (s);
                        sb = sa * (0.5 * d - tf) / (0.5 * d);
                        cb = (v * q) / (ix * tw);
                        spa = sa;
                        spa = Math.Round(spa, 4);
                        spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));

                        spb = Math.Round(spb, 4);


                        string prefijo = "";

                        if (sa > 0 && sa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sa >= 1000000 && sa < 1000000000)
                        {
                            sa = sa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sa >= 1000000000)
                        {
                            sa = sa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblENena.Text = "Esfuerzo normal en a " + prefijo;
                        txtENena.Text = sa.ToString("0.000");
                        lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                        txtECena.Text = "0";

                        if (sb > 0 && sb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (sb >= 1000000 && sb < 1000000000)
                        {
                            sb = sb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (sb >= 1000000000)
                        {
                            sb = sb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                        txtENenb.Text = sb.ToString("0.000");

                        if (cb > 0 && cb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (cb >= 1000000 && cb < 1000000000)
                        {
                            cb = cb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (cb >= 1000000000)
                        {
                            cb = cb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                        txtECenb.Text = cb.ToString("0.000");

                        if (spa > 0 && spa < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spa >= 1000000 && spa < 1000000000)
                        {
                            spa = spa / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spa >= 1000000000)
                        {
                            spa = spa / 1000000000;
                            prefijo = "[Gpsi]:";
                        }
                        lblspa.Text = "Esfuerzo principal en a " + prefijo;
                        txtspa.Text = spa.ToString();

                        if (spb > 0 && spb < 1000000)
                        {
                            prefijo = "[ksi]:";
                        }
                        else if (spb >= 1000000 && spb < 1000000000)
                        {
                            spb = spb / 1000000;
                            prefijo = "[Mpsi]:";
                        }
                        else if (spb >= 1000000000)
                        {
                            spb = spb / 1000000000;
                            prefijo = "[Gpsi]:";
                        }

                        txtspb.Text = spb.ToString();
                        lblspb.Text = "Esfuerzo principal en b " + prefijo;
                    }


                    //dibujar perfil
                    pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
                }

                if (sind > 0)
                {
                    btnAntPerf.Enabled = true;

                }
            }

        
        }

        private void chartPend_MouseMove(object sender, MouseEventArgs e)
        {
            if (indTipApoy == 0)
            {
                if (btnSegui.Checked == true)
                {
                    chartPend.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartPend.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartPend.ChartAreas[0].CursorY.SetCursorPosition(Ypsa(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartPend.Series[ns1 + 2].Points.Clear();
                            chartPend.Series[ns1 + 2].Points.AddXY(pX, Ypsa(pX));
                            chartPend.Series[ns1 + 2].MarkerSize = 8;
                            chartPend.Series[ns1 + 2].Color = Color.Blue;
                            chartPend.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartPend.Annotations.Clear();

                            anotacionp.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionp.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionp.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionp.LineColor = System.Drawing.Color.Empty;
                            anotacionp.Name = "ant";
                            anotacionp.Text = "x: " + pX.ToString() + "\r\n" + "tetha: " + Ypsa(pX).ToString();
                            anotacionp.AxisXName = "ChartArea1\\rX";
                            anotacionp.YAxisName = "ChartArea1\\rY";
                            anotacionp.X = pX;
                            anotacionp.Y = Ypsa(pX);
                            chartPend.Annotations.Add(anotacionp);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartPend.Series[ns1 + 2].Points.Clear();
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartPend.Annotations.Clear();

                }
            }
            else if (indTipApoy == 1)
            {
                if (btnSegui.Checked == true)
                {
                    chartPend.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartPend.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartPend.ChartAreas[0].CursorY.SetCursorPosition(Yptv(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartPend.Series[ns1 + 2].Points.Clear();
                            chartPend.Series[ns1 + 2].Points.AddXY(pX, Yptv(pX));
                            chartPend.Series[ns1 + 2].MarkerSize = 8;
                            chartPend.Series[ns1 + 2].Color = Color.Blue;
                            chartPend.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartPend.Annotations.Clear();

                            anotacionp.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionp.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionp.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionp.LineColor = System.Drawing.Color.Empty;
                            anotacionp.Name = "ant";
                            anotacionp.Text = "x: " + pX.ToString() + "\r\n" + "tetha: " + Yptv(pX).ToString();
                            anotacionp.AxisXName = "ChartArea1\\rX";
                            anotacionp.YAxisName = "ChartArea1\\rY";
                            anotacionp.X = pX;
                            anotacionp.Y = Yptv(pX);
                            chartPend.Annotations.Add(anotacionp);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartPend.Series[ns1 + 2].Points.Clear();
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartPend.Annotations.Clear();

                }
            }
            else if (indTipApoy == 2)
            {
                if (btnSegui.Checked == true)
                {
                    chartPend.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartPend.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartPend.ChartAreas[0].CursorY.SetCursorPosition(Ypei(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartPend.Series[ns1 + 2].Points.Clear();
                            chartPend.Series[ns1 + 2].Points.AddXY(pX, Ypei(pX));
                            chartPend.Series[ns1 + 2].MarkerSize = 8;
                            chartPend.Series[ns1 + 2].Color = Color.Blue;
                            chartPend.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartPend.Annotations.Clear();

                            anotacionp.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionp.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionp.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionp.LineColor = System.Drawing.Color.Empty;
                            anotacionp.Name = "ant";
                            anotacionp.Text = "x: " + pX.ToString() + "\r\n" + "tetha: " + Ypei(pX).ToString();
                            anotacionp.AxisXName = "ChartArea1\\rX";
                            anotacionp.YAxisName = "ChartArea1\\rY";
                            anotacionp.X = pX;
                            anotacionp.Y = Ypei(pX);
                            chartPend.Annotations.Add(anotacionp);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartPend.Series[ns1 + 2].Points.Clear();
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartPend.Annotations.Clear();

                }
            }
            else if (indTipApoy == 3)
            {
                if (btnSegui.Checked == true)
                {
                    chartPend.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartPend.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartPend.ChartAreas[0].CursorY.SetCursorPosition(Ypc(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartPend.Series[ns1 + 2].Points.Clear();
                            chartPend.Series[ns1 + 2].Points.AddXY(pX, Ypc(pX));
                            chartPend.Series[ns1 + 2].MarkerSize = 8;
                            chartPend.Series[ns1 + 2].Color = Color.Blue;
                            chartPend.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartPend.Annotations.Clear();

                            anotacionp.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionp.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionp.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionp.LineColor = System.Drawing.Color.Empty;
                            anotacionp.Name = "ant";
                            anotacionp.Text = "x: " + pX.ToString() + "\r\n" + "tetha: " + Ypc(pX).ToString();
                            anotacionp.AxisXName = "ChartArea1\\rX";
                            anotacionp.YAxisName = "ChartArea1\\rY";
                            anotacionp.X = pX;
                            anotacionp.Y = Ypc(pX);
                            chartPend.Annotations.Add(anotacionp);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartPend.Series[ns1 + 2].Points.Clear();
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartPend.Annotations.Clear();

                }
            }
            else if (indTipApoy == 4)
            {
                if (btnSegui.Checked == true)
                {
                    chartPend.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartPend.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartPend.ChartAreas[0].CursorY.SetCursorPosition(Yp5(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartPend.Series[ns1 + 2].Points.Clear();
                            chartPend.Series[ns1 + 2].Points.AddXY(pX, Yp5(pX));
                            chartPend.Series[ns1 + 2].MarkerSize = 8;
                            chartPend.Series[ns1 + 2].Color = Color.Blue;
                            chartPend.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartPend.Annotations.Clear();

                            anotacionp.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionp.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionp.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionp.LineColor = System.Drawing.Color.Empty;
                            anotacionp.Name = "ant";
                            anotacionp.Text = "x: " + pX.ToString() + "\r\n" + "tetha: " + Yp5(pX).ToString();
                            anotacionp.AxisXName = "ChartArea1\\rX";
                            anotacionp.YAxisName = "ChartArea1\\rY";
                            anotacionp.X = pX;
                            anotacionp.Y = Yp5(pX);
                            chartPend.Annotations.Add(anotacionp);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartPend.Series[ns1 + 2].Points.Clear();
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartPend.Annotations.Clear();

                }
            }
            else if (indTipApoy == 5)
            {
                if (btnSegui.Checked == true)
                {
                    chartPend.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartPend.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartPend.ChartAreas[0].CursorY.SetCursorPosition(Yp6(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartPend.Series[ns1 + 2].Points.Clear();
                            chartPend.Series[ns1 + 2].Points.AddXY(pX, Yp6(pX));
                            chartPend.Series[ns1 + 2].MarkerSize = 8;
                            chartPend.Series[ns1 + 2].Color = Color.Blue;
                            chartPend.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartPend.Annotations.Clear();

                            anotacionp.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotacionp.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotacionp.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotacionp.LineColor = System.Drawing.Color.Empty;
                            anotacionp.Name = "ant";
                            anotacionp.Text = "x: " + pX.ToString() + "\r\n" + "tetha: " + Yp6(pX).ToString();
                            anotacionp.AxisXName = "ChartArea1\\rX";
                            anotacionp.YAxisName = "ChartArea1\\rY";
                            anotacionp.X = pX;
                            anotacionp.Y = Yp6(pX);
                            chartPend.Annotations.Add(anotacionp);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartPend.Series[ns1 + 2].Points.Clear();
                    chartPend.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartPend.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartPend.Annotations.Clear();

                }
            }
        }

        private void chartDefl_MouseMove(object sender, MouseEventArgs e)
        {
            if (indTipApoy == 0)
            {
                if (btnSegui.Checked == true)
                {
                    chartDefl.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartDefl.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartDefl.ChartAreas[0].CursorY.SetCursorPosition(Ydsa(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartDefl.Series[ns1 + 2].Points.Clear();
                            chartDefl.Series[ns1 + 2].Points.AddXY(pX, Ydsa(pX));
                            chartDefl.Series[ns1 + 2].MarkerSize = 8;
                            chartDefl.Series[ns1 + 2].Color = Color.Blue;
                            chartDefl.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartDefl.Annotations.Clear();

                            anotaciond.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotaciond.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotaciond.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotaciond.LineColor = System.Drawing.Color.Empty;
                            anotaciond.Name = "ant";
                            anotaciond.Text = "x: " + pX.ToString() + "\r\n" + "Deflexión: " + Ydsa(pX).ToString();
                            anotaciond.AxisXName = "ChartArea1\\rX";
                            anotaciond.YAxisName = "ChartArea1\\rY";
                            anotaciond.X = pX;
                            anotaciond.Y = Ydsa(pX);
                            chartDefl.Annotations.Add(anotaciond);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartDefl.Series[ns1 + 2].Points.Clear();
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartDefl.Annotations.Clear();

                }
            }
            else if (indTipApoy == 1)
            {
                if (btnSegui.Checked == true)
                {
                    chartDefl.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartDefl.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartDefl.ChartAreas[0].CursorY.SetCursorPosition(Ydtv(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartDefl.Series[ns1 + 2].Points.Clear();
                            chartDefl.Series[ns1 + 2].Points.AddXY(pX, Ydtv(pX));
                            chartDefl.Series[ns1 + 2].MarkerSize = 8;
                            chartDefl.Series[ns1 + 2].Color = Color.Blue;
                            chartDefl.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartDefl.Annotations.Clear();

                            anotaciond.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotaciond.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotaciond.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotaciond.LineColor = System.Drawing.Color.Empty;
                            anotaciond.Name = "ant";
                            anotaciond.Text = "x: " + pX.ToString() + "\r\n" + "Deflexión: " + Ydtv(pX).ToString();
                            anotaciond.AxisXName = "ChartArea1\\rX";
                            anotaciond.YAxisName = "ChartArea1\\rY";
                            anotaciond.X = pX;
                            anotaciond.Y = Ydtv(pX);
                            chartDefl.Annotations.Add(anotaciond);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartDefl.Series[ns1 + 2].Points.Clear();
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartDefl.Annotations.Clear();

                }
            }
            else if (indTipApoy == 2)
            {
                if (btnSegui.Checked == true)
                {
                    chartDefl.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartDefl.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartDefl.ChartAreas[0].CursorY.SetCursorPosition(Ydei(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartDefl.Series[ns1 + 2].Points.Clear();
                            chartDefl.Series[ns1 + 2].Points.AddXY(pX, Ydei(pX));
                            chartDefl.Series[ns1 + 2].MarkerSize = 8;
                            chartDefl.Series[ns1 + 2].Color = Color.Blue;
                            chartDefl.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartDefl.Annotations.Clear();

                            anotaciond.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotaciond.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotaciond.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotaciond.LineColor = System.Drawing.Color.Empty;
                            anotaciond.Name = "ant";
                            anotaciond.Text = "x: " + pX.ToString() + "\r\n" + "Deflexión: " + Ydei(pX).ToString();
                            anotaciond.AxisXName = "ChartArea1\\rX";
                            anotaciond.YAxisName = "ChartArea1\\rY";
                            anotaciond.X = pX;
                            anotaciond.Y = Ydei(pX);
                            chartDefl.Annotations.Add(anotaciond);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartDefl.Series[ns1 + 2].Points.Clear();
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartDefl.Annotations.Clear();

                }
            }
            else if (indTipApoy == 3)
            {
                if (btnSegui.Checked == true)
                {
                    chartDefl.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartDefl.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartDefl.ChartAreas[0].CursorY.SetCursorPosition(Ydc(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartDefl.Series[ns1 + 2].Points.Clear();
                            chartDefl.Series[ns1 + 2].Points.AddXY(pX, Ydc(pX));
                            chartDefl.Series[ns1 + 2].MarkerSize = 8;
                            chartDefl.Series[ns1 + 2].Color = Color.Blue;
                            chartDefl.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartDefl.Annotations.Clear();

                            anotaciond.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotaciond.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotaciond.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotaciond.LineColor = System.Drawing.Color.Empty;
                            anotaciond.Name = "ant";
                            anotaciond.Text = "x: " + pX.ToString() + "\r\n" + "Deflexión: " + Ydc(pX).ToString();
                            anotaciond.AxisXName = "ChartArea1\\rX";
                            anotaciond.YAxisName = "ChartArea1\\rY";
                            anotaciond.X = pX;
                            anotaciond.Y = Ydc(pX);
                            chartDefl.Annotations.Add(anotaciond);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartDefl.Series[ns1 + 2].Points.Clear();
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartDefl.Annotations.Clear();

                }
            }
            else if (indTipApoy == 4)
            {
                if (btnSegui.Checked == true)
                {
                    chartDefl.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartDefl.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartDefl.ChartAreas[0].CursorY.SetCursorPosition(Yd5(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartDefl.Series[ns1 + 2].Points.Clear();
                            chartDefl.Series[ns1 + 2].Points.AddXY(pX, Yd5(pX));
                            chartDefl.Series[ns1 + 2].MarkerSize = 8;
                            chartDefl.Series[ns1 + 2].Color = Color.Blue;
                            chartDefl.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartDefl.Annotations.Clear();

                            anotaciond.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotaciond.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotaciond.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotaciond.LineColor = System.Drawing.Color.Empty;
                            anotaciond.Name = "ant";
                            anotaciond.Text = "x: " + pX.ToString() + "\r\n" + "Deflexión: " + Yd5(pX).ToString();
                            anotaciond.AxisXName = "ChartArea1\\rX";
                            anotaciond.YAxisName = "ChartArea1\\rY";
                            anotaciond.X = pX;
                            anotaciond.Y = Yd5(pX);
                            chartDefl.Annotations.Add(anotaciond);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartDefl.Series[ns1 + 2].Points.Clear();
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartDefl.Annotations.Clear();

                }
            }
            else if (indTipApoy == 5)
            {
                if (btnSegui.Checked == true)
                {
                    chartDefl.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
                    double pX = chartDefl.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Silver;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Silver;

                    chartDefl.ChartAreas[0].CursorY.SetCursorPosition(Yd6(pX));
                    if (pX > 0 && pX <= l)
                    {
                        try
                        {
                            chartDefl.Series[ns1 + 2].Points.Clear();
                            chartDefl.Series[ns1 + 2].Points.AddXY(pX, Yd6(pX));
                            chartDefl.Series[ns1 + 2].MarkerSize = 8;
                            chartDefl.Series[ns1 + 2].Color = Color.Blue;
                            chartDefl.Series[ns1 + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            chartDefl.Annotations.Clear();

                            anotaciond.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                            anotaciond.BorderSkin.PageColor = System.Drawing.Color.Transparent;
                            anotaciond.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
                            anotaciond.LineColor = System.Drawing.Color.Empty;
                            anotaciond.Name = "ant";
                            anotaciond.Text = "x: " + pX.ToString() + "\r\n" + "Deflexión: " + Yd6(pX).ToString();
                            anotaciond.AxisXName = "ChartArea1\\rX";
                            anotaciond.YAxisName = "ChartArea1\\rY";
                            anotaciond.X = pX;
                            anotaciond.Y = Yd6(pX);
                            chartDefl.Annotations.Add(anotaciond);




                        }
                        catch (Exception)
                        {
                            throw;

                        }
                    }
                }
                else
                {


                    chartDefl.Series[ns1 + 2].Points.Clear();
                    chartDefl.ChartAreas[0].CursorX.LineColor = Color.Transparent;
                    chartDefl.ChartAreas[0].CursorY.LineColor = Color.Transparent;
                    chartDefl.Annotations.Clear();

                }
            }
        }

        private void txtenx_Click(object sender, EventArgs e)
        {
            txtenx.SelectAll();
        }

        private void txtenx_KeyPress(object sender, KeyPressEventArgs e)
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

                txtenx.Focus();
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

                txtenx.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtenx.Focus();
                e.Handled = true;
            }
        }

        private void txtenx_TextChanged(object sender, EventArgs e)
        {
            if (indTipApoy == 0)
            {
                try
                {

                    xp = Convert.ToDouble(txtenx.Text);
                    penxigual = Ypsa(xp);

                    txtPenenxplot.Text = penxigual.ToString();

                }
                catch (FormatException) { txtenx.Text = ""; }

                if (xp > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtenx.Text = "0";
                    txtenx.Focus();
                }
            }

            else if (indTipApoy == 1)
            {
                try
                {

                    xp = Convert.ToDouble(txtenx.Text);
                    penxigual = Yptv(xp);

                    txtPenenxplot.Text = penxigual.ToString();

                }
                catch (FormatException) { txtenx.Text = ""; }

                if (xp > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtenx.Text = "0";
                    txtenx.Focus();
                }
            }

            else if (indTipApoy == 2)
            {
                try
                {

                    xp = Convert.ToDouble(txtenx.Text);
                    penxigual = Ypei(xp);

                    txtPenenxplot.Text = penxigual.ToString();

                }
                catch (FormatException) { txtenx.Text = ""; }

                if (xp > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtenx.Text = "0";
                    txtenx.Focus();
                }
            }
            else if (indTipApoy == 3)
            {
                try
                {

                    xp = Convert.ToDouble(txtenx.Text);
                    penxigual = Ypc(xp);

                    txtPenenxplot.Text = penxigual.ToString();

                }
                catch (FormatException) { txtenx.Text = ""; }

                if (xp > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtenx.Text = "0";
                    txtenx.Focus();
                }
            }
            else if (indTipApoy == 4)
            {
                try
                {

                    xp = Convert.ToDouble(txtenx.Text);
                    penxigual = Yp5(xp);

                    txtPenenxplot.Text = penxigual.ToString();

                }
                catch (FormatException) { txtenx.Text = ""; }

                if (xp > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtenx.Text = "0";
                    txtenx.Focus();
                }
            }
            else if (indTipApoy == 5)
            {
                try
                {

                    xp = Convert.ToDouble(txtenx.Text);
                    penxigual = Yp6(xp);

                    txtPenenxplot.Text = penxigual.ToString();

                }
                catch (FormatException) { txtenx.Text = ""; }

                if (xp > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtenx.Text = "0";
                    txtenx.Focus();
                }
            }
        }

        private void problemasResueltosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Ejercicios resueltos .pdf");
        }

        private void txtDefl_Click(object sender, EventArgs e)
        {
            txtDefl.SelectAll();
        }

        private void txtDefl_KeyPress(object sender, KeyPressEventArgs e)
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

                txtDefl.Focus();
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

                txtDefl.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtDefl.Focus();
                e.Handled = true;
            }
        }

        private void txtDefl_TextChanged(object sender, EventArgs e)
        {
            if (indTipApoy == 0)
            {
                try
                {

                    xd = Convert.ToDouble(txtDefl.Text);
                    denxigual = Ydsa(xd);

                    txtDeflenx.Text = denxigual.ToString();

                }
                catch (FormatException) { txtDefl.Text = ""; }

                if (xd > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtDefl.Text = "0";
                    txtDefl.Focus();
                }
            }

            else if (indTipApoy == 1)
            {
                try
                {

                    xd = Convert.ToDouble(txtDefl.Text);
                    denxigual = Ydtv(xd);

                    txtDeflenx.Text = denxigual.ToString();

                }
                catch (FormatException) { txtDefl.Text = ""; }

                if (xd > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtDefl.Text = "0";
                    txtDefl.Focus();
                }
            }

            else if (indTipApoy == 2)
            {
                try
                {

                    xd = Convert.ToDouble(txtDefl.Text);
                    denxigual = Ydei(xd);

                    txtDeflenx.Text = denxigual.ToString();

                }
                catch (FormatException) { txtDefl.Text = ""; }

                if (xd > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtDefl.Text = "0";
                    txtDefl.Focus();
                }
            }
            else if (indTipApoy == 3)
            {
                try
                {

                    xd = Convert.ToDouble(txtDefl.Text);
                    denxigual = Ydc(xd);

                    txtDeflenx.Text = denxigual.ToString();

                }
                catch (FormatException) { txtDefl.Text = ""; }

                if (xd > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtDefl.Text = "0";
                    txtDefl.Focus();
                }
            }
            else if (indTipApoy == 4)
            {
                try
                {

                    xd = Convert.ToDouble(txtDefl.Text);
                    denxigual = Yd5(xd);

                    txtDeflenx.Text = denxigual.ToString();

                }
                catch (FormatException) { txtDefl.Text = ""; }

                if (xd > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtDefl.Text = "0";
                    txtDefl.Focus();
                }
            }
            else if (indTipApoy == 5)
            {
                try
                {

                    xd = Convert.ToDouble(txtDefl.Text);
                    denxigual = Yd6(xd);

                    txtDeflenx.Text = denxigual.ToString();

                }
                catch (FormatException) { txtDefl.Text = ""; }

                if (xd > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtDefl.Text = "0";
                    txtDefl.Focus();
                }
            }
        }

        private void tabPenyDflx_SizeChanged(object sender, EventArgs e)
        {
            panel2.Width = Fn.NumEnt(tabPenyDflx.Width * 0.97);
            chartDefl.Width = Fn.NumEnt(tabPenyDflx.Width * 0.93);
            chartPend.Width = Fn.NumEnt(tabPenyDflx.Width * 0.93);
        }

        private void btnReesPerf_Click(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }

            if (cbPfPP.SelectedIndex == 0)
            {
                string name;
                lbperf.SelectedIndex = 0;
                lbnameperf.SelectedIndex = 0;
                idvgsda = (int)lbperf.SelectedItem;
                name = lbnameperf.SelectedItem.ToString();

                foreach (char primerapalabra in name)
                {
                    if (primerapalabra.ToString() == "W")
                    {
                        if (unidades == 0)
                        {
                            txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();

                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS) / (s * 1000);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            cb = cb / 1000;
                            spa = sa ; // en megapascales
                           
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                            string prefijo = "";

                            if (sa > 0 && sa < 0.001)
                            {
                                sa = sa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sa >= 0.001 && sa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sa >= 1000)
                            {
                                sa = sa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 0.001)
                            {
                                sb = sb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sb >= 0.001 && sb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sb >= 1000)
                            {
                                sb = sb / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 0.001)
                            {
                                cb = cb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (cb >= 0.001 && cb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (cb >= 1000)
                            {
                                cb = cb / 1000;
                                prefijo = "[GPa]";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 0.001)
                            {
                                spa = spa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spa >= 0.001 && spa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spa >= 1000)
                            {
                                spa = spa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 0.001)
                            {
                                spb = spb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spb >= 0.001 && spb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spb >= 1000)
                            {
                                spb = spb / 1000;
                                prefijo = "[GPa]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;

                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                        }
                        else if (unidades == 1)
                        {
                            txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();

                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS * 12) / (s);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            spa = sa;
                            spa = Math.Round(spa, 4);
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            spb = Math.Round(spb, 4);


                            string prefijo = "";

                            if (sa > 0 && sa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sa >= 1000000 && sa < 1000000000)
                            {
                                sa = sa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sa >= 1000000000)
                            {
                                sa = sa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sb >= 1000000 && sb < 1000000000)
                            {
                                sb = sb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sb >= 1000000000)
                            {
                                sb = sb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (cb >= 1000000 && cb < 1000000000)
                            {
                                cb = cb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (cb >= 1000000000)
                            {
                                cb = cb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spa >= 1000000 && spa < 1000000000)
                            {
                                spa = spa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spa >= 1000000000)
                            {
                                spa = spa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spb >= 1000000 && spb < 1000000000)
                            {
                                spb = spb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spb >= 1000000000)
                            {
                                spb = spb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;

                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                        }
                    

                     
                        break;
                    }
                    else if (primerapalabra.ToString() == "S")
                    {
                        if (unidades == 0)
                        {
                            txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();


                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS) / (s * 1000);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            cb = cb / 1000;
                            spa = sa ; // en megapascales
                           
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                            string prefijo = "";

                            if (sa > 0 && sa < 0.001)
                            {
                                sa = sa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sa >= 0.001 && sa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sa >= 1000)
                            {
                                sa = sa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 0.001)
                            {
                                sb = sb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sb >= 0.001 && sb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sb >= 1000)
                            {
                                sb = sb / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 0.001)
                            {
                                cb = cb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (cb >= 0.001 && cb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (cb >= 1000)
                            {
                                cb = cb / 1000;
                                prefijo = "[GPa]";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 0.001)
                            {
                                spa = spa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spa >= 0.001 && spa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spa >= 1000)
                            {
                                spa = spa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 0.001)
                            {
                                spb = spb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spb >= 0.001 && spb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spb >= 1000)
                            {
                                spb = spb / 1000;
                                prefijo = "[GPa]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                        }
                        else if (unidades == 1)
                        {
                            txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(psus1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(psus1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(psus1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(psus1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(psus1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(psus1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS * 12) / (s);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            spa = sa;
                            spa = Math.Round(spa, 4);
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            spb = Math.Round(spb, 4);


                            string prefijo = "";

                            if (sa > 0 && sa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sa >= 1000000 && sa < 1000000000)
                            {
                                sa = sa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sa >= 1000000000)
                            {
                                sa = sa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sb >= 1000000 && sb < 1000000000)
                            {
                                sb = sb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sb >= 1000000000)
                            {
                                sb = sb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (cb >= 1000000 && cb < 1000000000)
                            {
                                cb = cb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (cb >= 1000000000)
                            {
                                cb = cb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spa >= 1000000 && spa < 1000000000)
                            {
                                spa = spa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spa >= 1000000000)
                            {
                                spa = spa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spb >= 1000000 && spb < 1000000000)
                            {
                                spb = spb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spb >= 1000000000)
                            {
                                spb = spb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                        }


                        //dibujar perfil
                        pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                        pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                        pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";
                        break;
                    }

                    else if (primerapalabra.ToString() == "C")
                    {
                        if (unidades == 0)
                        {
                            txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();


                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS) / (s * 1000);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            cb = cb / 1000;
                            spa = sa; // en megapascales

                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));



                            string prefijo = "";

                            if (sa > 0 && sa < 0.001)
                            {
                                sa = sa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sa >= 0.001 && sa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sa >= 1000)
                            {
                                sa = sa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 0.001)
                            {
                                sb = sb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sb >= 0.001 && sb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sb >= 1000)
                            {
                                sb = sb / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 0.001)
                            {
                                cb = cb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (cb >= 0.001 && cb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (cb >= 1000)
                            {
                                cb = cb / 1000;
                                prefijo = "[GPa]";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 0.001)
                            {
                                spa = spa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spa >= 0.001 && spa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spa >= 1000)
                            {
                                spa = spa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 0.001)
                            {
                                spb = spb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spb >= 0.001 && spb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spb >= 1000)
                            {
                                spb = spb / 1000;
                                prefijo = "[GPa]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                        }
                        else if (unidades == 1)
                        {
                            txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();

                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS * 12) / (s);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            spa = sa;
                            spa = Math.Round(spa, 4);
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            spb = Math.Round(spb, 4);


                            string prefijo = "";

                            if (sa > 0 && sa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sa >= 1000000 && sa < 1000000000)
                            {
                                sa = sa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sa >= 1000000000)
                            {
                                sa = sa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sb >= 1000000 && sb < 1000000000)
                            {
                                sb = sb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sb >= 1000000000)
                            {
                                sb = sb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (cb >= 1000000 && cb < 1000000000)
                            {
                                cb = cb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (cb >= 1000000000)
                            {
                                cb = cb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spa >= 1000000 && spa < 1000000000)
                            {
                                spa = spa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spa >= 1000000000)
                            {
                                spa = spa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spb >= 1000000 && spb < 1000000000)
                            {
                                spb = spb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spb >= 1000000000)
                            {
                                spb = spb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                        }


                        //dibujar perfil
                        pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                        pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                        pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
                        break;
                    }

                }

             
            }
            else if (cbPfPP.SelectedIndex == 1)
            {
                lbperf.SelectedIndex = 0;
                idvgsda = (int)lbperf.SelectedItem;
                if (unidades == 0)
                {
                    txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                    txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                    txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                    txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                    txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();

                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                    d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                    tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                    s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                    ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                    bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                    tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                    areaq = tf * bf;
                    ytq = 0.5 * d - 0.5 * tf;
                    q = areaq * ytq;
                    v = yDgCte[xdelyMtomayorABS];
                    v = Math.Abs(v);
                    sa = (yDgMtomayABS) / (s * 1000);
                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                    cb = (v * q) / (ix * tw);
                    spa = sa * 1000; // en megapascales
                    spa = Math.Round(spa, 4);
                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                    spb = spb * 1000; // en megapascales
                    spb = Math.Round(spb, 4);


                    string prefijo = "";

                    if (sa > 0 && sa < 0.001)
                    {
                        sa = sa * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (sa >= 0.001 && sa < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (sa >= 1000)
                    {
                        sa = sa / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                    txtENena.Text = sa.ToString("0.000");
                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                    txtECena.Text = "0";

                    if (sb > 0 && sb < 0.001)
                    {
                        sb = sb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (sb >= 0.001 && sb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (sb >= 1000)
                    {
                        sb = sb / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                    txtENenb.Text = sb.ToString("0.000");

                    if (cb > 0 && cb < 0.001)
                    {
                        cb = cb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (cb >= 0.001 && cb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (cb >= 1000)
                    {
                        cb = cb / 1000;
                        prefijo = "[GPa]";
                    }
                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                    txtECenb.Text = cb.ToString("0.000");

                    if (spa > 0 && spa < 0.001)
                    {
                        spa = spa * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (spa >= 0.001 && spa < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (spa >= 1000)
                    {
                        spa = spa / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                    txtspa.Text = spa.ToString();

                    if (spb > 0 && spb < 0.001)
                    {
                        spb = spb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (spb >= 0.001 && spb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (spb >= 1000)
                    {
                        spb = spb / 1000;
                        prefijo = "[GPa]:";
                    }

                    txtspb.Text = spb.ToString();
                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                    //dibujar perfil
                    pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                }
                else if (unidades == 1)
                {
                    txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                    txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                    txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                    txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                    txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();

                    //cálculo del esfuerzo principal
                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                    d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                    tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                    s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                    ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                    bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                    tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                    areaq = tf * bf;
                    ytq = 0.5 * d - 0.5 * tf;
                    q = areaq * ytq;
                    v = yDgCte[xdelyMtomayorABS];
                    v = Math.Abs(v);
                    sa = (yDgMtomayABS * 12) / (s);
                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                    cb = (v * q) / (ix * tw);
                    spa = sa;
                    spa = Math.Round(spa, 4);
                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                    spb = Math.Round(spb, 4);


                    string prefijo = "";

                    if (sa > 0 && sa < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (sa >= 1000000 && sa < 1000000000)
                    {
                        sa = sa / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (sa >= 1000000000)
                    {
                        sa = sa / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                    txtENena.Text = sa.ToString("0.000");
                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                    txtECena.Text = "0";

                    if (sb > 0 && sb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (sb >= 1000000 && sb < 1000000000)
                    {
                        sb = sb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (sb >= 1000000000)
                    {
                        sb = sb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                    txtENenb.Text = sb.ToString("0.000");

                    if (cb > 0 && cb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (cb >= 1000000 && cb < 1000000000)
                    {
                        cb = cb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (cb >= 1000000000)
                    {
                        cb = cb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                    txtECenb.Text = cb.ToString("0.000");

                    if (spa > 0 && spa < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (spa >= 1000000 && spa < 1000000000)
                    {
                        spa = spa / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (spa >= 1000000000)
                    {
                        spa = spa / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                    txtspa.Text = spa.ToString();

                    if (spb > 0 && spb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (spb >= 1000000 && spb < 1000000000)
                    {
                        spb = spb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (spb >= 1000000000)
                    {
                        spb = spb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }

                    txtspb.Text = spb.ToString();
                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                    //dibujar perfil
                    pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                }
       

               
            }
            else if (cbPfPP.SelectedIndex == 2)
            {
                lbperf.SelectedIndex = 0;
                idvgsda = (int)lbperf.SelectedItem;
                if (unidades == 0)
                {
                    txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                    txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                    txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                    txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                    txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();


                    //cálculo del esfuerzo principal
                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                    d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                    tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                    s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                    ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                    bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                    tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                    areaq = tf * bf;
                    ytq = 0.5 * d - 0.5 * tf;
                    q = areaq * ytq;
                    v = yDgCte[xdelyMtomayorABS];
                    v = Math.Abs(v);
                    sa = (yDgMtomayABS) / (s * 1000);
                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                    cb = (v * q) / (ix * tw);
                    spa = sa * 1000; // en megapascales
                    spa = Math.Round(spa, 4);
                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                    spb = spb * 1000; // en megapascales
                    spb = Math.Round(spb, 4);


                    string prefijo = "";

                    if (sa > 0 && sa < 0.001)
                    {
                        sa = sa * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (sa >= 0.001 && sa < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (sa >= 1000)
                    {
                        sa = sa / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                    txtENena.Text = sa.ToString("0.000");
                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                    txtECena.Text = "0";

                    if (sb > 0 && sb < 0.001)
                    {
                        sb = sb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (sb >= 0.001 && sb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (sb >= 1000)
                    {
                        sb = sb / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                    txtENenb.Text = sb.ToString("0.000");

                    if (cb > 0 && cb < 0.001)
                    {
                        cb = cb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (cb >= 0.001 && cb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (cb >= 1000)
                    {
                        cb = cb / 1000;
                        prefijo = "[GPa]";
                    }
                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                    txtECenb.Text = cb.ToString("0.000");

                    if (spa > 0 && spa < 0.001)
                    {
                        spa = spa * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (spa >= 0.001 && spa < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (spa >= 1000)
                    {
                        spa = spa / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                    txtspa.Text = spa.ToString();

                    if (spb > 0 && spb < 0.001)
                    {
                        spb = spb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (spb >= 0.001 && spb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (spb >= 1000)
                    {
                        spb = spb / 1000;
                        prefijo = "[GPa]:";
                    }

                    txtspb.Text = spb.ToString();
                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                }
                else if (unidades == 1)
                {
                    txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                    txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                    txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                    txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                    txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                    //cálculo del esfuerzo principal
                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                    d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                    tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                    s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                    ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                    bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                    tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                    areaq = tf * bf;
                    ytq = 0.5 * d - 0.5 * tf;
                    q = areaq * ytq;
                    v = yDgCte[xdelyMtomayorABS];
                    v = Math.Abs(v);
                    sa = (yDgMtomayABS) / (s * 1000);
                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                    cb = (v * q) / (ix * tw);
                    spa = sa * 1000; // en megapascales
                    spa = Math.Round(spa, 4);
                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                    spb = spb * 1000; // en megapascales
                    spb = Math.Round(spb, 4);


                    string prefijo = "";

                    if (sa > 0 && sa < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (sa >= 1000000 && sa < 1000000000)
                    {
                        sa = sa / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (sa >= 1000000000)
                    {
                        sa = sa / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                    txtENena.Text = sa.ToString("0.000");
                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                    txtECena.Text = "0";

                    if (sb > 0 && sb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (sb >= 1000000 && sb < 1000000000)
                    {
                        sb = sb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (sb >= 1000000000)
                    {
                        sb = sb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                    txtENenb.Text = sb.ToString("0.000");

                    if (cb > 0 && cb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (cb >= 1000000 && cb < 1000000000)
                    {
                        cb = cb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (cb >= 1000000000)
                    {
                        cb = cb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                    txtECenb.Text = cb.ToString("0.000");

                    if (spa > 0 && spa < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (spa >= 1000000 && spa < 1000000000)
                    {
                        spa = spa / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (spa >= 1000000000)
                    {
                        spa = spa / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                    txtspa.Text = spa.ToString();

                    if (spb > 0 && spb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (spb >= 1000000 && spb < 1000000000)
                    {
                        spb = spb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (spb >= 1000000000)
                    {
                        spb = spb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }

                    txtspb.Text = spb.ToString();
                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                }


                //dibujar perfil
                pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";
            }
            else if (cbPfPP.SelectedIndex == 3)
            {

                lbperf.SelectedIndex = 0;
                idvgsda = (int)lbperf.SelectedItem;
                if (unidades == 0)
                {
                    txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                    txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                    txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                    txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                    txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();


                    //cálculo del esfuerzo principal
                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                    d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                    tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                    s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                    ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                    bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                    tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                    areaq = tf * bf;
                    ytq = 0.5 * d - 0.5 * tf;
                    q = areaq * ytq;
                    v = yDgCte[xdelyMtomayorABS];
                    v = Math.Abs(v);
                    sa = (yDgMtomayABS) / (s * 1000);
                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                    cb = (v * q) / (ix * tw);
                    spa = sa * 1000; // en megapascales
                    spa = Math.Round(spa, 4);
                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                    spb = spb * 1000; // en megapascales
                    spb = Math.Round(spb, 4);


                    string prefijo = "";

                    if (sa > 0 && sa < 0.001)
                    {
                        sa = sa * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (sa >= 0.001 && sa < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (sa >= 1000)
                    {
                        sa = sa / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                    txtENena.Text = sa.ToString("0.000");
                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                    txtECena.Text = "0";

                    if (sb > 0 && sb < 0.001)
                    {
                        sb = sb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (sb >= 0.001 && sb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (sb >= 1000)
                    {
                        sb = sb / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                    txtENenb.Text = sb.ToString("0.000");

                    if (cb > 0 && cb < 0.001)
                    {
                        cb = cb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (cb >= 0.001 && cb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (cb >= 1000)
                    {
                        cb = cb / 1000;
                        prefijo = "[GPa]";
                    }
                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                    txtECenb.Text = cb.ToString("0.000");

                    if (spa > 0 && spa < 0.001)
                    {
                        spa = spa * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (spa >= 0.001 && spa < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (spa >= 1000)
                    {
                        spa = spa / 1000;
                        prefijo = "[GPa]:";
                    }
                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                    txtspa.Text = spa.ToString();

                    if (spb > 0 && spb < 0.001)
                    {
                        spb = spb * 1000;
                        prefijo = "[kPa]:";
                    }
                    else if (spb >= 0.001 && spb < 1000)
                    {

                        prefijo = "[MPa]:";
                    }
                    else if (spb >= 1000)
                    {
                        spb = spb / 1000;
                        prefijo = "[GPa]:";
                    }

                    txtspb.Text = spb.ToString();
                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                }
                else if (unidades == 1)
                {
                    txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                    txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                    txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                    txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                    txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();

                    //cálculo del esfuerzo principal
                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                    d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                    tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                    s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                    ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                    bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                    tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                    areaq = tf * bf;
                    ytq = 0.5 * d - 0.5 * tf;
                    q = areaq * ytq;
                    v = yDgCte[xdelyMtomayorABS];
                    v = Math.Abs(v);
                    sa = (yDgMtomayABS) / (s * 1000);
                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                    cb = (v * q) / (ix * tw);
                    spa = sa; 
                    spa = Math.Round(spa, 4);
                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                 
                    spb = Math.Round(spb, 4);


                    string prefijo = "";

                    if (sa > 0 && sa < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (sa >= 1000000 && sa < 1000000000)
                    {
                        sa = sa / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (sa >= 1000000000)
                    {
                        sa = sa / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                    txtENena.Text = sa.ToString("0.000");
                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                    txtECena.Text = "0";

                    if (sb > 0 && sb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (sb >= 1000000 && sb < 1000000000)
                    {
                        sb = sb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (sb >= 1000000000)
                    {
                        sb = sb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                    txtENenb.Text = sb.ToString("0.000");

                    if (cb > 0 && cb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (cb >= 1000000 && cb < 1000000000)
                    {
                        cb = cb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (cb >= 1000000000)
                    {
                        cb = cb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                    txtECenb.Text = cb.ToString("0.000");

                    if (spa > 0 && spa < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (spa >= 1000000 && spa < 1000000000)
                    {
                        spa = spa / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (spa >= 1000000000)
                    {
                        spa = spa / 1000000000;
                        prefijo = "[Gpsi]:";
                    }
                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                    txtspa.Text = spa.ToString();

                    if (spb > 0 && spb < 1000000)
                    {
                        prefijo = "[ksi]:";
                    }
                    else if (spb >= 1000000 && spb < 1000000000)
                    {
                        spb = spb / 1000000;
                        prefijo = "[Mpsi]:";
                    }
                    else if (spb >= 1000000000)
                    {
                        spb = spb / 1000000000;
                        prefijo = "[Gpsi]:";
                    }

                    txtspb.Text = spb.ToString();
                    lblspb.Text = "Esfuerzo principal en b " + prefijo;
                }


                //dibujar perfil
                pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
            }
          
        }

        private void SItsitem_Click(object sender, EventArgs e)
        {
            if (SItsitem.Checked == false)
            {
                SItsitem.Checked = true;
                EUtsitem.Checked = false;
                haymaterial = 0;
                Mtst.Text = "Mt: NN";
                unidades = 0;
                lblLPP.Text = "                Longitud [m]";
                cx1.HeaderText = "Coordenada x1 [m]";
                cx2.HeaderText = "Coordenada x2 [m]";
                Fza.HeaderText = "Fuerza [kN]";
                Fza1.HeaderText = "Fuerza inicial [kN/m]";
                Fza2.HeaderText = "Fuerza final [kN/m]";
                Mto.HeaderText = "Momento [kN*m]";

                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.Controls.Remove(tabDiag);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.Controls.Remove(tabPerf);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }
                if (chkbSDPP.Checked == true)
                {
                    Mtst.Visible = false;
                    if (cbApyPP.SelectedIndex == 1)
                    {
                        ltvst.Visible = true;
                        if (Mtst.Visible == false && ltvst.Visible == false)
                        {
                            pyc.Visible = false;
                        }
                        else
                        {
                            pyc.Visible = true;
                        }

                    }
                    else
                    {
                        ltvst.Visible = false;
                        pyc.Visible = false;

                    }

                }
                else
                {
                    Mtst.Visible = true;
                }
                R1st.Visible = false;
                R2st.Visible = false;
                MRst.Visible = false;
                pyc2.Visible = false;
                pyc3.Visible = false;
                pyc4.Visible = false;

                tabCgVgPP.Invalidate();
            }
       
        }

        private void EUtsitem_Click(object sender, EventArgs e)
        {
            if (EUtsitem.Checked == false)
            {
                SItsitem.Checked = false;
                EUtsitem.Checked = true;
                haymaterial = 0;
                Mtst.Text = "Mt: NN";
                unidades = 1;
                lblLPP.Text = "                Longitud [ft]";
                cx1.HeaderText = "Coordenada x1 [ft]";
                cx2.HeaderText = "Coordenada x2 [ft]";
                Fza.HeaderText = "Fuerza [kip]";
                Fza1.HeaderText = "Fuerza inicial [kip/ft]";
                Fza2.HeaderText = "Fuerza final [kip/ft]";
                Mto.HeaderText = "Momento [kip*ft]";

                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.Controls.Remove(tabDiag);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.Controls.Remove(tabPerf);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }
                if (chkbSDPP.Checked == true)
                {
                    Mtst.Visible = false;
                    if (cbApyPP.SelectedIndex == 1)
                    {
                        ltvst.Visible = true;
                        if (Mtst.Visible == false && ltvst.Visible == false)
                        {
                            pyc.Visible = false;
                        }
                        else
                        {
                            pyc.Visible = true;
                        }
                      
                    }
                    else
                    {
                        ltvst.Visible = false;
                        pyc.Visible = false;
               
                    }

                }
                else
                {
                    Mtst.Visible = true;     
                }
                R1st.Visible = false;
                R2st.Visible = false;
                MRst.Visible = false;
                pyc2.Visible = false;
                pyc3.Visible = false;
                pyc4.Visible = false;

                tabCgVgPP.Invalidate();
            }
    
        }

        private void txtLPP_Leave(object sender, EventArgs e)
        {
            if (l == 0)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingrese valor diferente de 0");
                txtLPP.Text = "";

                txtLPP.Focus();
            }
            for (int i = 0; i < dtgFyM.Rows.Count; i++)
            {
                if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) > l || double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()) > l)
                {

                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Quedan cargas por fuera de la viga");
                    txtLPP.Text = "";

                    txtLPP.Focus();
                }
            }

            if (l != 0 && txtLPP.Text != "")
            {
                tabCgVgPP.Invalidate();
            }



        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("MANUAL DE USUARIO.pdf");
        }

        private void btnResolPP_MouseEnter(object sender, EventArgs e)
        {
            tabCgVgPP.Invalidate();
        }

        private void btnResolPP_MouseLeave(object sender, EventArgs e)
        {
            tabCgVgPP.Invalidate();
        }

   

        private void pbMaxPP_Click(object sender, EventArgs e)
        {
           
            if (maximizado == true)
            {
                this.Width = 1100;
                this.Height = 700;
                WindowState = FormWindowState.Normal;
                pbMaxPP.Image = Image.FromFile("ilustraciones/btnmax0.png");
                maximizado = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                pbMaxPP.Image = Image.FromFile("ilustraciones/btnmax1.png");
                maximizado = true;
            }
           
        }

        private void pbMaxPP_MouseEnter(object sender, EventArgs e)
        {
            pbMaxPP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(242)))));
        }

        private void pbMaxPP_MouseLeave(object sender, EventArgs e)
        {
            pbMaxPP.BackColor = Color.Transparent;
        }

 

        private void tabDiag_SizeChanged(object sender, EventArgs e)
        {
            panel1.Width = Fn.NumEnt(tabDiag.Width * 0.97);
            chartV.Width = Fn.NumEnt(tabDiag.Width * 0.93);
            chartM.Width = Fn.NumEnt(tabDiag.Width * 0.93);
        }

        private void tabCgVgPP_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void cbPfPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }

        }

   

        private void txtxMtoplot_Click(object sender, EventArgs e)
        {
            txtxMtoplot.SelectAll();
        }

        private void txtxMtoplot_TextChanged(object sender, EventArgs e)
        {
            if (indTipApoy == 0)
            {
                try
                {

                    x11M = Convert.ToDouble(txtxMtoplot.Text);
                    Mtoenxigual = YMxSA(x11M);

                    txtyMtoplot.Text = Mtoenxigual.ToString();

                }
                catch (FormatException) { txtxMtoplot.Text = ""; }

                if (x11M > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtxMtoplot.Text = "0";
                    txtxMtoplot.Focus();
                }
            }

            else if (indTipApoy == 1)
            {
                try
                {

                    x11M = Convert.ToDouble(txtxMtoplot.Text);
                    Mtoenxigual = YMxTV(x11M);

                    txtyMtoplot.Text = Mtoenxigual.ToString();

                }
                catch (FormatException) { txtxMtoplot.Text = ""; }

                if (x11M > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtxMtoplot.Text = "0";
                    txtxMtoplot.Focus();
                }
            }

            else if (indTipApoy == 2)
            {
                try
                {

                    x11M = Convert.ToDouble(txtxMtoplot.Text);
                    Mtoenxigual = YMxEI(x11M);

                    txtyMtoplot.Text = Mtoenxigual.ToString();

                }
                catch (FormatException) { txtxMtoplot.Text = ""; }

                if (x11M > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtxMtoplot.Text = "0";
                    txtxMtoplot.Focus();
                }
            }
            else if (indTipApoy == 3)
            {
                try
                {

                    x11M = Convert.ToDouble(txtxMtoplot.Text);
                    Mtoenxigual = YMxC(x11M);

                    txtyMtoplot.Text = Mtoenxigual.ToString();

                }
                catch (FormatException) { txtxMtoplot.Text = ""; }

                if (x11M > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtxMtoplot.Text = "0";
                    txtxMtoplot.Focus();
                }
            }
            else if (indTipApoy == 4)
            {
                try
                {

                    x11M = Convert.ToDouble(txtxMtoplot.Text);
                    Mtoenxigual = YMx5(x11M);

                    txtyMtoplot.Text = Mtoenxigual.ToString();

                }
                catch (FormatException) { txtxMtoplot.Text = ""; }

                if (x11M > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtxMtoplot.Text = "0";
                    txtxMtoplot.Focus();
                }
            }
            else if (indTipApoy == 5)
            {
                try
                {

                    x11M = Convert.ToDouble(txtxMtoplot.Text);
                    Mtoenxigual = YMx6(x11M);

                    txtyMtoplot.Text = Mtoenxigual.ToString();

                }
                catch (FormatException) { txtxMtoplot.Text = ""; }

                if (x11M > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtxMtoplot.Text = "0";
                    txtxMtoplot.Focus();
                }
            }

        }

        private void txtctexplot_Click(object sender, EventArgs e)
        {
            txtctexplot.SelectAll();
        }

        private void txtctexplot_TextChanged(object sender, EventArgs e)
        {
            if (indTipApoy == 0)
            {
                try
                {

                    x11 = Convert.ToDouble(txtctexplot.Text);
                    cteenxigual = YxSA(x11);

                    txtyctexplot.Text = cteenxigual.ToString();

                }
                catch (FormatException) { txtctexplot.Text = ""; }

                if (x11 > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtctexplot.Text = "0";
                    txtctexplot.Focus();
                }
            }

            else if (indTipApoy == 1)
            {
                try
                {

                    x11 = Convert.ToDouble(txtctexplot.Text);
                    cteenxigual = YxTV(x11);

                    txtyctexplot.Text = cteenxigual.ToString();

                }
                catch (FormatException) { txtctexplot.Text = ""; }

                if (x11 > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtctexplot.Text = "0";
                    txtctexplot.Focus();
                }
            }

            else if (indTipApoy == 2)
            {
                try
                {

                    x11 = Convert.ToDouble(txtctexplot.Text);
                    cteenxigual = YxEI(x11);

                    txtyctexplot.Text = cteenxigual.ToString();

                }
                catch (FormatException) { txtctexplot.Text = ""; }

                if (x11 > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtctexplot.Text = "0";
                    txtctexplot.Focus();
                }
            }
            else if (indTipApoy == 3)
            {
                try
                {

                    x11 = Convert.ToDouble(txtctexplot.Text);
                    cteenxigual = YxC(x11);

                    txtyctexplot.Text = cteenxigual.ToString();

                }
                catch (FormatException) { txtctexplot.Text = ""; }

                if (x11 > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtctexplot.Text = "0";
                    txtctexplot.Focus();
                }
            }
            else if (indTipApoy == 4)
            {
                try
                {

                    x11 = Convert.ToDouble(txtctexplot.Text);
                    cteenxigual = Yx5(x11);

                    txtyctexplot.Text = cteenxigual.ToString();

                }
                catch (FormatException) { txtctexplot.Text = ""; }

                if (x11 > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtctexplot.Text = "0";
                    txtctexplot.Focus();
                }
            }
            else if (indTipApoy == 5)
            {
                try
                {

                    x11 = Convert.ToDouble(txtctexplot.Text);
                    cteenxigual = Yx6(x11);

                    txtyctexplot.Text = cteenxigual.ToString();

                }
                catch (FormatException) { txtctexplot.Text = ""; }

                if (x11 > l)
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("x no debe exceder la longitud de la viga");
                    txtctexplot.Text = "0";
                    txtctexplot.Focus();
                }
            }

        }

        private void chkbDyPPP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDyPPP.Checked == false)
            {
                chkbSDPP.Checked = true;
                Mtst.Visible = false;

              
                R1st.Visible = false;
                R2st.Visible = false;
                MRst.Visible = false;
                pyc2.Visible = false;
                pyc3.Visible = false;
                pyc4.Visible = false;
                pyc.Visible = false;
                pyc5.Visible = false;
                pyc6.Visible = false;
                pyc7.Visible = false;
                pyc8.Visible = false;
                pyc9.Visible = false;
                pyc10.Visible = false;
                Rast.Visible = false;
                Rbst.Visible = false;
                Rcst.Visible = false;
                Mast.Visible = false;
                Mbst.Visible = false;
                if (cbApyPP.SelectedIndex == 1)
                {
                    ltvst.Visible = true;
                  
                }
                else
                {
                    ltvst.Visible = false;
                   
                }
                if (cbApyPP.SelectedIndex == 3)
                {
                    lconst.Visible = true;

                }
                else
                {
                    lconst.Visible = false;

                }

                btnAgMtPP.Hide();
                lblPfPP.Hide();
                cbPfPP.Hide();
                lblLPP.Location = new Point(0, 230);
                txtLPP.Location = new Point(200, 235);
                lblAp.Location = new Point(0, 270);
                cbApyPP.Location = new Point(150, 275);
                btnCgyMPP.Location = new Point(0, 310);
                pnlCyMPP.Location = new Point(0, 350);

                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }
            }
            else
            {
             
                chkbSDPP.Checked = false;
                Mtst.Visible = true;

                Mtst.Visible = true;
                R1st.Visible = false;
                R2st.Visible = false;
                MRst.Visible = false;
                pyc2.Visible = false;
                pyc3.Visible = false;
                pyc4.Visible = false;
                pyc5.Visible = false;
                pyc6.Visible = false;
                pyc7.Visible = false;
                pyc8.Visible = false;
             
                pyc10.Visible = false;
                Rast.Visible = false;
                Rbst.Visible = false;
                Rcst.Visible = false;
                Mast.Visible = false;
                Mbst.Visible = false;

                if (cbApyPP.SelectedIndex == 1)
                {
                    ltvst.Visible = true;
                    pyc.Visible = true;


                }
                else
                {
                    ltvst.Visible = false;
                    pyc.Visible = false;
                }

                if (cbApyPP.SelectedIndex == 3)
                {
                    lconst.Visible = true;
                    pyc9.Visible = true;


                }
                else
                {
                    lconst.Visible = false;
                    pyc9.Visible = false;
                }

                btnAgMtPP.Location = new Point(0, 230);
                btnAgMtPP.Show();
                lblFSPP.Location = new Point(0, 270);
                txtFSPP.Location = new Point(200, 275);
                lblPfPP.Location = new Point(0, 310);
                lblPfPP.Show();
                cbPfPP.Location = new Point(150, 318);
                cbPfPP.Show();
                lblLPP.Location = new Point(0, 350);
                txtLPP.Location = new Point(200, 355);
                lblAp.Location = new Point(0, 390);
                cbApyPP.Location = new Point(150, 395);
                btnCgyMPP.Location = new Point(0, 430);
                pnlCyMPP.Location = new Point(0, 470);

                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                }
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }
            }
        }

        private void btnCgyMPP_Click(object sender, EventArgs e)
        {
            if (pnlCyMPP.Visible)
            {
                pnlCyMPP.Hide();
            }
            else
            {
                pnlCyMPP.Show();
            }
        }

        private void txtFSPP_KeyPress(object sender, KeyPressEventArgs e)
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

                    txtFSPP.Focus();
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

                    txtFSPP.Focus();
                    e.Handled = true;
                }
                else
                {
                    MssBox mssBox = new MssBox();
                    mssBox.Muestra("Solo números");
                    txtFSPP.Focus();
                    e.Handled = true;
                }
            
         
        
        }

        private void txtFSPP_Click(object sender, EventArgs e)
        {
            txtFSPP.SelectAll();
        }


        //hacer la p+agina principal draggable
        private void pnlSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;


        }

        private void pnlSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void pnlSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;

            }
        }

        private void txtLPP_TextChanged(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }
            if (chkbSDPP.Checked == true)
            {
                Mtst.Visible = false;
                if (cbApyPP.SelectedIndex == 1)
                {
                    ltvst.Visible = true;
                    if ( ltvst.Visible == false)
                    {
                        pyc.Visible = false;
                    }
                    else
                    {
                        pyc.Visible = true;
                    }

                }
                else
                {
                    ltvst.Visible = false;
                    pyc.Visible = false;

                }

            }
            else
            {
                Mtst.Visible = true;
            }
            R1st.Visible = false;
            R2st.Visible = false;
            MRst.Visible = false;
            Rast.Visible = false;
            Rbst.Visible = false;
            Rcst.Visible = false;
            Mast.Visible = false;
            Mbst.Visible = false;
            pyc2.Visible = false;
            pyc3.Visible = false;
            pyc4.Visible = false;
            pyc5.Visible = false;
            pyc6.Visible = false;
            pyc7.Visible = false;
            pyc8.Visible = false;
            pyc9.Visible = false;
            pyc10.Visible = false;


            try
            {
                
                l = Convert.ToDouble(txtLPP.Text);
           
              

            }
            catch (FormatException) 
            { txtLPP.Text = ""; }

          
            

        }

        private void txtLPP_KeyPress(object sender, KeyPressEventArgs e)
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

                txtLPP.Focus();
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

                txtLPP.Focus();
                e.Handled = true;
            }
            else
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Solo números");
                txtLPP.Focus();
                e.Handled = true;
            }
        }

        private void txtLPP_Click(object sender, EventArgs e)
        {
            txtLPP.SelectAll();
        }

        private void btnCDPP_Click(object sender, EventArgs e)
        {
            if (txtLPP.Text == "0" || txtLPP.Text == "")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingresar longitud");
                txtLPP.Focus();
            }
            else
            {
                AgCD agCD = new AgCD();
                agCD.ShowDialog();
            }
        }

        private void dtgFyM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgFyM.CurrentCell.ColumnIndex == 7 && dtgFyM.CurrentRow.Cells[0].Value.ToString() == "CC")
            {
                var row = dtgFyM.CurrentRow;
                EditCC miEditar = new EditCC();
                var txt1 = miEditar.Controls["txtcxEditcC"];
                var txt2 = miEditar.Controls["txtFzEditCC"];

               
              
                  


                    txt1.Text = row.Cells[1].Value.ToString();
                    txt2.Text = row.Cells[3].Value.ToString();


                    if (miEditar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                       

                        row.Cells[1].Value = txt1.Text;
                        row.Cells[2].Value = txt1.Text;
                        row.Cells[3].Value = txt2.Text;
                        if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                        {
                            TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                        }
                        PagPrincipal.Pag.tabCgVgPP.Invalidate();

                    }
                
            
     
            }

            else if (dtgFyM.CurrentCell.ColumnIndex == 7 && dtgFyM.CurrentRow.Cells[0].Value.ToString() == "CD")
            {
                var row = dtgFyM.CurrentRow;
                EditCD miEditarCD = new EditCD();
                var txt1 = miEditarCD.Controls["txtcx1EditCD"];
                var txt2 = miEditarCD.Controls["txtcx2EditCD"];
                var txt3 = miEditarCD.Controls["txtFzInEditCD"];
                var txt4 = miEditarCD.Controls["txtFzFinEditCD"];
                txt1.Text = row.Cells[1].Value.ToString();
                txt2.Text = row.Cells[2].Value.ToString();
                txt3.Text = row.Cells[4].Value.ToString();
                txt4.Text = row.Cells[5].Value.ToString();

                if (miEditarCD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    row.Cells[1].Value = txt1.Text;
                    row.Cells[2].Value = txt2.Text;
                    row.Cells[4].Value = txt3.Text;
                    row.Cells[5].Value = txt4.Text;
                
                     if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                     {
                        TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                     }
                     else
                     {

                     }
                    PagPrincipal.Pag.tabCgVgPP.Invalidate();
                }

            }

            else if (dtgFyM.CurrentCell.ColumnIndex == 7 && dtgFyM.CurrentRow.Cells[0].Value.ToString() == "M")
            {
                var row = dtgFyM.CurrentRow;
                EditM miEditM = new EditM();
                var txt1 = miEditM.Controls["txtcxEditM"];
                var txt2 = miEditM.Controls["txtMeditM"];

                txt1.Text = row.Cells[1].Value.ToString();
                txt2.Text = row.Cells[6].Value.ToString();

                if (miEditM.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    row.Cells[1].Value = txt1.Text;
                    row.Cells[2].Value = txt1.Text;
                    row.Cells[6].Value = txt2.Text;


                    if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                    {
                        TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                    }
                    PagPrincipal.Pag.tabCgVgPP.Invalidate();
                }
            }

            else if (dtgFyM.CurrentCell.ColumnIndex == 8)
            {
                var row = dtgFyM.CurrentRow;
                dtgFyM.Rows.Remove(row);
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                }
                PagPrincipal.Pag.tabCgVgPP.Invalidate();
            }
        }



     

        private void btnMPP_Click(object sender, EventArgs e)
        {
            if (txtLPP.Text == "0" || txtLPP.Text == "")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingresar longitud");
                txtLPP.Focus();
            }
            else
            {
                AgM agM = new AgM();
                agM.ShowDialog();
            }
        }

        private void btnCPPP_Click(object sender, EventArgs e)
        {
            if (txtLPP.Text == "0" || txtLPP.Text == "")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingresar longitud");
                txtLPP.Focus();
            }
            else
            {
                AgCC agCC = new AgCC();
                agCC.ShowDialog();
            }
            
        }

        private void tabCgVgPP_Paint(object sender, PaintEventArgs e)
        {
            //ajustes
            int cd = 15; // ajustar altura de carga distribuida rectangular
            int t = 15; // ajustar triangulos
            int trm = 45; // trapecio linea menor
            int trM = 15; //trapecio linea mayor

            int p1x, p1y,lvg,anchovg,pttancho,pttalto,p2ctx,p1cty,altorayacota, pt1xlabelcx,fnlcotax, fnlcotay, lfincotax,puntact,iniciocgneg, ptrvEx, ptrvEy,anchoMto;
            p1x = Fn.NumEnt(tabCgVgPP.Width * 0.1);
            p1y = Fn.NumEnt(tabCgVgPP.Height * 0.20);
            lvg = Fn.NumEnt(tabCgVgPP.Width * 0.77);
            anchovg = Fn.NumEnt(tabCgVgPP.Height * 0.017);
            pttancho = Fn.NumEnt(tabCgVgPP.Width * 0.013);
            pttalto = Fn.NumEnt(tabCgVgPP.Height * 0.04);
            p1cty = Fn.NumEnt(tabCgVgPP.Height * 0.47);
            p2ctx = Fn.NumEnt(tabCgVgPP.Width * 0.89);
            altorayacota = Fn.NumEnt(tabCgVgPP.Height * 0.008);
            pt1xlabelcx = Fn.NumEnt(tabCgVgPP.Width * 0.097);
            fnlcotax = Fn.NumEnt(tabCgVgPP.Width * 0.91);// x[m]
            fnlcotay = Fn.NumEnt(tabCgVgPP.Height * 0.45);// x[m]
            lfincotax = Fn.NumEnt(tabCgVgPP.Width * 0.87);// x[m] la magnitud
            puntact = Fn.NumEnt(tabCgVgPP.Width * 0.91);

            iniciocgneg = Fn.NumEnt(tabCgVgPP.Height * 0.05);
            ptrvEx = Fn.NumEnt(tabCgVgPP.Width * 0.084);
            ptrvEy = Fn.NumEnt(tabCgVgPP.Height * 0.19);
            anchoMto = Fn.NumEnt(tabCgVgPP.Width * 0.020);

            MgCC.Clear();
            cxCC.Clear();
            locationxCC.Clear();
            cx1CD.Clear();
            cx2CD.Clear();
            M1CD.Clear();
            M2CD.Clear();
            locationx1CD.Clear();
            locationx2CD.Clear();
            MgM.Clear();
            cxM.Clear();
            locationxM.Clear();
            
            for (int i = 0; i < dtgFyM.Rows.Count; i++)
            {
                cxCC.Insert(i, 0);
                MgCC.Insert(i,0);
                locationxCC.Insert(i, 0);
                cx1CD.Insert(i, 0);
                cx2CD.Insert(i, 0);
                M1CD.Insert(i, 0);
                M2CD.Insert(i,0);
                locationx1CD.Insert(i, 0);
                locationx2CD.Insert(i, 0);
                MgM.Insert(i,0);
                cxM.Insert(i, 0);
                locationxM.Insert(i,0);
            }
            
            pluma.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pluma3.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            
            if (indTipApoy == 0)
            {    
                g3 = tabCgVgPP.CreateGraphics();
                g3.FillRectangle(bsuave, p1x, p1y, lvg, anchovg);
                g3.DrawRectangle(pluma1,p1x,p1y,lvg,anchovg);//viga
                Point[] pttri = { new Point(p1x,p1y + anchovg),new Point(p1x + pttancho, p1y + pttalto + anchovg),new Point(p1x - pttancho,p1y + pttalto+ anchovg) };
                g3.FillEllipse(bsuave, new Rectangle(p1x + lvg - pttancho,p1y + anchovg,2*pttancho,pttalto));//relleno del circulo
                g3.DrawEllipse(pluma1, new Rectangle(p1x + lvg - pttancho, p1y + anchovg,2*pttancho,pttalto));
                g3.FillPolygon(bsuave, pttri);
                g3.DrawPolygon(pluma1, pttri);
                g3.DrawLine(pluma1, new Point(p1x,p1cty),new Point(p2ctx,p1cty));
                g3.DrawLine(pluma1, new Point(p1x, p1cty - altorayacota), new Point(p1x, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x + lvg, p1cty - altorayacota), new Point(p1x + lvg, p1cty + altorayacota));
                g3.DrawString("0", fuente1, Brushes.Black, pt1xlabelcx, p1cty + altorayacota);
                if (unidades == 0)
                {
                    g3.DrawString("x [m]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
                else if (unidades == 1)
                {
                    g3.DrawString("x [ft]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
              
                g3.DrawString(txtLPP.Text,fuente1,Brushes.Black, lvg + pt1xlabelcx , p1cty + altorayacota);

                //cabeza de la cota
                Point[] ptcbct = {new Point(p2ctx,p1cty - altorayacota), new Point(p2ctx,p1cty + altorayacota), new Point(puntact,p1cty), new Point(p2ctx,p1cty - altorayacota) };
                g3.FillPolygon(bfuerte,ptcbct);

                //mostrar dibujos de las fuerzas resultantes
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    if (R1 != 0 && R1 < 0)
                    {

                        g3.DrawLine(pluma3, 0 + p1x, iniciocgneg, 0 + p1x, p1y);
                        g3.DrawString("R1", fuente1, Brushes.Red, 0 + pt1xlabelcx, anchovg);


                    }
                    else if (R1 != 0 && R1 > 0)
                    {
                        g3.DrawLine(pluma3, 0 + p1x, 2 * p1y + anchovg - iniciocgneg, 0 + p1x, p1y + anchovg);
                        g3.DrawString("R1", fuente1, Brushes.Red, 0 + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    if (R2 != 0 && R2 > 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, 2 * p1y + anchovg - iniciocgneg, lvg + p1x, p1y + anchovg);
                        g3.DrawString("R2", fuente1, Brushes.Red, lvg + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    else if (R2 != 0 && R2 < 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, iniciocgneg, lvg + p1x, p1y);
                        g3.DrawString("R2", fuente1, Brushes.Red, lvg + pt1xlabelcx, anchovg);
                    }
                }
            

                g3.Dispose();
            }
            else if (indTipApoy ==1)
            {
                
                int locationx;
                locationx = Fn.NumEnt(lvg * ltv / l);

                g3 = tabCgVgPP.CreateGraphics();
                g3.FillRectangle(bsuave, p1x, p1y, lvg, anchovg);
                g3.DrawRectangle(pluma1, p1x, p1y, lvg, anchovg);
                Point[] pttri = { new Point(p1x, p1y + anchovg), new Point(p1x + pttancho, p1y + pttalto + anchovg), new Point(p1x - pttancho, p1y + pttalto + anchovg) };
                //g3.FillEllipse(bsuave, new Rectangle(locationx+p1x-13,p1y + anchovg,26,26));
                //g3.DrawEllipse(pluma1, new Rectangle(locationx+p1x-13, p1y + anchovg, 26, 26));
                g3.FillEllipse(bsuave, new Rectangle(locationx + p1x - pttancho, p1y + anchovg, 2 * pttancho, pttalto));
                g3.DrawEllipse(pluma1, new Rectangle(locationx + p1x - pttancho, p1y + anchovg, 2 * pttancho, pttalto));
                g3.FillPolygon(bsuave, pttri);
                g3.DrawPolygon(pluma1, pttri);
                g3.DrawLine(pluma1, new Point(p1x, p1cty - altorayacota), new Point(p1x, p1cty + altorayacota)); //linea origen
                g3.DrawLine(pluma1, new Point(p1x + lvg, p1cty - altorayacota), new Point(p1x + lvg, p1cty + altorayacota));//linea final
                g3.DrawLine(pluma1, new Point(p1x, p1cty), new Point(p2ctx, p1cty));
                g3.DrawLine(pluma1,new Point(locationx +p1x,p1cty - altorayacota),new Point(locationx+p1x,p1cty + altorayacota));
                g3.DrawString("0", fuente1, Brushes.Black, pt1xlabelcx, p1cty + altorayacota);
                if (unidades == 0)
                {
                    g3.DrawString("x [m]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
                else if (unidades == 1)
                {
                    g3.DrawString("x [ft]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
              
                g3.DrawString(txtLPP.Text, fuente1, Brushes.Black, lvg + pt1xlabelcx, p1cty + altorayacota);
                g3.DrawString(ltv.ToString(), fuente1, Brushes.Black, locationx + pt1xlabelcx, p1cty + altorayacota);

                //cabeza de la cota
                Point[] ptcbct = { new Point(p2ctx, p1cty - altorayacota), new Point(p2ctx, p1cty + altorayacota), new Point(puntact, p1cty), new Point(p2ctx, p1cty - altorayacota) };
                
                g3.FillPolygon(bfuerte, ptcbct);

                //mostrar dibujos de las fuerzas resultantes
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    if (R1 != 0 && R1 < 0)
                    {

                        g3.DrawLine(pluma3, 0 + p1x, iniciocgneg, 0 + p1x, p1y);
                        g3.DrawString("R1", fuente1, Brushes.Red, 0 + pt1xlabelcx, anchovg);


                    }
                    else if (R1 != 0 && R1 > 0)
                    {
                        g3.DrawLine(pluma3, 0 + p1x, 2 * p1y + anchovg - iniciocgneg, 0 + p1x, p1y + anchovg);
                        g3.DrawString("R1", fuente1, Brushes.Red, 0 + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    if (R2 != 0 && R2 > 0)
                    {
                        g3.DrawLine(pluma3, locationx + p1x, 2 * p1y + anchovg - iniciocgneg, locationx + p1x, p1y + anchovg);
                        g3.DrawString("R2", fuente1, Brushes.Red,  locationx + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    else if (R2 != 0 && R2 < 0)
                    {
                        g3.DrawLine(pluma3, locationx + p1x, iniciocgneg, locationx + p1x, p1y);
                        g3.DrawString("R2", fuente1, Brushes.Red, locationx + pt1xlabelcx, anchovg);
                    }
                }


                g3.Dispose();
            }
            else if (indTipApoy ==2)
            {
                g3 = tabCgVgPP.CreateGraphics();
                g3.FillRectangle(bsuave, p1x, p1y, lvg, anchovg);
                g3.FillRectangle(bsuave, ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2*(p1y - ptrvEy));
                g3.DrawRectangle(pluma1, p1x, p1y, lvg, anchovg);
                g3.DrawRectangle(pluma1, ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));
                g3.DrawLine(pluma1, new Point(p1x, p1cty - altorayacota), new Point(p1x, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x + lvg, p1cty - altorayacota), new Point(p1x + lvg, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x, p1cty), new Point(p2ctx, p1cty));
                g3.DrawString("0", fuente1, Brushes.Black, pt1xlabelcx, p1cty + altorayacota);
                if (unidades == 0)
                {
                    g3.DrawString("x [m]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
                else if (unidades == 1)
                {
                    g3.DrawString("x [ft]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
               
                g3.DrawString(txtLPP.Text, fuente1, Brushes.Black, lvg + pt1xlabelcx, p1cty + altorayacota);

                //cabeza de la cota
                Point[] ptcbct = { new Point(p2ctx, p1cty - altorayacota), new Point(p2ctx, p1cty + altorayacota), new Point(puntact, p1cty), new Point(p2ctx, p1cty - altorayacota) };
                g3.FillPolygon(bfuerte, ptcbct);

                //mostrar dibujos de las fuerzas resultantes
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    if (R1 != 0 && R1 < 0)
                    {

                        g3.DrawLine(pluma3, 0 + p1x, iniciocgneg, 0 + p1x, p1y);
                        g3.DrawString("R1", fuente1, Brushes.Red, 0 + pt1xlabelcx, anchovg);


                    }
                    else if (R1 != 0 && R1 > 0)
                    {
                        g3.DrawLine(pluma3, 0 + p1x, 2 * p1y + anchovg - iniciocgneg, 0 + p1x, p1y + anchovg);
                        g3.DrawString("R1", fuente1, Brushes.Red, 0 + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    if (MR != 0 && MR > 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(p1x - anchoMto , Fn.NumEnt(tabCgVgPP.Height * 0.17), anchoMto * 2, anchoMto * 2), 0, -250 );
                        g3.DrawString("MR", fuente1, Brushes.Red, 0 + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }
                    else if (MR != 0 && MR < 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle( - anchoMto + p1x, Fn.NumEnt(tabCgVgPP.Height * 0.17), 2 * anchoMto, 2 * anchoMto), 180, 250);
                        g3.DrawString("MR", fuente1, Brushes.Red, 0 + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }
                }

                g3.Dispose();
            }
            else if (indTipApoy ==3)
            {
                int locationx;
                locationx = Fn.NumEnt(lvg * lcon / l);

                g3 = tabCgVgPP.CreateGraphics();
                g3.FillRectangle(bsuave, p1x, p1y, lvg, anchovg);
                g3.DrawRectangle(pluma1, p1x, p1y, lvg, anchovg);
                Point[] pttri = { new Point(p1x, p1y + anchovg), new Point(p1x + pttancho, p1y + pttalto + anchovg), new Point(p1x - pttancho, p1y + pttalto + anchovg) };
                //g3.FillEllipse(bsuave, new Rectangle(locationx + p1x - 13, p1y + anchovg, 26, 26));
                //g3.DrawEllipse(pluma1, new Rectangle(locationx + p1x - 13, p1y + anchovg, 26, 26));
                g3.FillEllipse(bsuave, new Rectangle(locationx + p1x - pttancho, p1y + anchovg, 2 * pttancho, pttalto));
                g3.DrawEllipse(pluma1, new Rectangle(locationx + p1x - pttancho, p1y + anchovg, 2 * pttancho, pttalto));
                g3.FillPolygon(bsuave, pttri);
                g3.DrawPolygon(pluma1, pttri);
                g3.DrawLine(pluma1, new Point(p1x, p1cty - altorayacota), new Point(p1x, p1cty + altorayacota)); //linea origen
                g3.DrawLine(pluma1, new Point(p1x + lvg, p1cty - altorayacota), new Point(p1x + lvg, p1cty + altorayacota));//linea final
                g3.DrawLine(pluma1, new Point(p1x, p1cty), new Point(p2ctx, p1cty));
                g3.DrawLine(pluma1, new Point(locationx + p1x, p1cty - altorayacota), new Point(locationx + p1x, p1cty + altorayacota));
                g3.DrawString("0", fuente1, Brushes.Black, pt1xlabelcx, p1cty + altorayacota);

                //circulo en c
                g3.FillEllipse(bsuave, new Rectangle(p1x + lvg - pttancho, p1y + anchovg, 2 * pttancho, pttalto));//relleno del circulo
                g3.DrawEllipse(pluma1, new Rectangle(p1x + lvg - pttancho, p1y + anchovg, 2 * pttancho, pttalto));
                //////////////////77
                if (unidades == 0)
                {
                    g3.DrawString("x [m]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
                else if (unidades == 1)
                {
                    g3.DrawString("x [ft]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }

                g3.DrawString(txtLPP.Text, fuente1, Brushes.Black, lvg + pt1xlabelcx, p1cty + altorayacota);
                g3.DrawString(lcon.ToString(), fuente1, Brushes.Black, locationx + pt1xlabelcx, p1cty + altorayacota);

                //cabeza de la cota
                Point[] ptcbct = { new Point(p2ctx, p1cty - altorayacota), new Point(p2ctx, p1cty + altorayacota), new Point(puntact, p1cty), new Point(p2ctx, p1cty - altorayacota) };

                g3.FillPolygon(bfuerte, ptcbct);

                //mostrar dibujos de las fuerzas resultantes
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    if (Ra != 0 && Ra < 0)
                    {

                        g3.DrawLine(pluma3, 0 + p1x, iniciocgneg, 0 + p1x, p1y);
                        g3.DrawString("Ra", fuente1, Brushes.Red, 0 + pt1xlabelcx, anchovg);


                    }
                    else if (Ra != 0 && Ra > 0)
                    {
                        g3.DrawLine(pluma3, 0 + p1x, 2 * p1y + anchovg - iniciocgneg, 0 + p1x, p1y + anchovg);
                        g3.DrawString("Ra", fuente1, Brushes.Red, 0 + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    if (Rc != 0 && Rc > 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, 2 * p1y + anchovg - iniciocgneg, lvg + p1x, p1y + anchovg);
                        g3.DrawString("Rc", fuente1, Brushes.Red, lvg + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    else if (Rc != 0 && Rc < 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, iniciocgneg, lvg + p1x, p1y);
                        g3.DrawString("Rc", fuente1, Brushes.Red, lvg + pt1xlabelcx, anchovg);
                    }
                    if (Rb != 0 && Rb > 0)
                    {
                        g3.DrawLine(pluma3, locationx + p1x, 2 * p1y + anchovg - iniciocgneg, locationx + p1x, p1y + anchovg);
                        g3.DrawString("Rb", fuente1, Brushes.Red, locationx + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    else if (Rb != 0 && Rb < 0)
                    {
                        g3.DrawLine(pluma3, locationx + p1x, iniciocgneg, locationx + p1x, p1y);
                        g3.DrawString("Rb", fuente1, Brushes.Red, lvg + pt1xlabelcx, anchovg);
                    }
                }

                g3.Dispose();
            }
            else if (indTipApoy == 4)
            {
                g3 = tabCgVgPP.CreateGraphics();
                g3.FillRectangle(bsuave, p1x, p1y, lvg, anchovg);
                g3.FillRectangle(bsuave, ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));
                g3.DrawRectangle(pluma1, p1x, p1y, lvg, anchovg);
                g3.DrawRectangle(pluma1, ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));
                g3.DrawLine(pluma1, new Point(p1x, p1cty - altorayacota), new Point(p1x, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x + lvg, p1cty - altorayacota), new Point(p1x + lvg, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x, p1cty), new Point(p2ctx, p1cty));
                g3.DrawString("0", fuente1, Brushes.Black, pt1xlabelcx, p1cty + altorayacota);

                //circulo en b
                g3.FillEllipse(bsuave, new Rectangle(p1x + lvg - pttancho, p1y + anchovg, 2 * pttancho, pttalto));//relleno del circulo
                g3.DrawEllipse(pluma1, new Rectangle(p1x + lvg - pttancho, p1y + anchovg, 2 * pttancho, pttalto));
                //

                if (unidades == 0)
                {
                    g3.DrawString("x [m]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
                else if (unidades == 1)
                {
                    g3.DrawString("x [ft]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }

                g3.DrawString(txtLPP.Text, fuente1, Brushes.Black, lvg + pt1xlabelcx, p1cty + altorayacota);

                //cabeza de la cota
                Point[] ptcbct = { new Point(p2ctx, p1cty - altorayacota), new Point(p2ctx, p1cty + altorayacota), new Point(puntact, p1cty), new Point(p2ctx, p1cty - altorayacota) };
                g3.FillPolygon(bfuerte, ptcbct);

                //mostrar dibujos de las fuerzas resultantes
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    if (Ra != 0 && Ra < 0)
                    {

                        g3.DrawLine(pluma3, 0 + p1x, iniciocgneg, 0 + p1x, p1y);
                        g3.DrawString("Ra", fuente1, Brushes.Red, 0 + pt1xlabelcx, anchovg);


                    }
                    else if (Ra != 0 && Ra > 0)
                    {
                        g3.DrawLine(pluma3, 0 + p1x, 2 * p1y + anchovg - iniciocgneg, 0 + p1x, p1y + anchovg);
                        g3.DrawString("Ra", fuente1, Brushes.Red, 0 + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    if (Rb != 0 && Rb > 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, 2 * p1y + anchovg - iniciocgneg, lvg + p1x, p1y + anchovg);
                        g3.DrawString("Rb", fuente1, Brushes.Red, lvg + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    else if (Rb != 0 && Rb < 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, iniciocgneg, lvg + p1x, p1y);
                        g3.DrawString("Rb", fuente1, Brushes.Red, lvg + pt1xlabelcx, anchovg);
                    }
                    if (Ma != 0 && Ma > 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(p1x - anchoMto, Fn.NumEnt(tabCgVgPP.Height * 0.17), anchoMto * 2, anchoMto * 2), 0, -250);
                        g3.DrawString("Ma", fuente1, Brushes.Red, 0 + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }
                    else if (Ma != 0 && Ma < 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(-anchoMto + p1x, Fn.NumEnt(tabCgVgPP.Height * 0.17), 2 * anchoMto, 2 * anchoMto), 180, 250);
                        g3.DrawString("Ma", fuente1, Brushes.Red, 0 + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }

                }

                g3.Dispose();
            }

            else if (indTipApoy == 5)
            {
                g3 = tabCgVgPP.CreateGraphics();
                g3.FillRectangle(bsuave, p1x, p1y, lvg, anchovg);
                g3.FillRectangle(bsuave, ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));

                g3.FillRectangle(bsuave, ptrvEx + lvg + p1x - ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));

                g3.DrawRectangle(pluma1, p1x, p1y, lvg, anchovg);
                g3.DrawRectangle(pluma1, ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));

                g3.DrawRectangle(pluma1, ptrvEx + lvg + p1x - ptrvEx, ptrvEy, p1x - ptrvEx, anchovg + 2 * (p1y - ptrvEy));

                g3.DrawLine(pluma1, new Point(p1x, p1cty - altorayacota), new Point(p1x, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x + lvg, p1cty - altorayacota), new Point(p1x + lvg, p1cty + altorayacota));
                g3.DrawLine(pluma1, new Point(p1x, p1cty), new Point(p2ctx, p1cty));
                g3.DrawString("0", fuente1, Brushes.Black, pt1xlabelcx, p1cty + altorayacota);
                if (unidades == 0)
                {
                    g3.DrawString("x [m]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }
                else if (unidades == 1)
                {
                    g3.DrawString("x [ft]", fuente1, Brushes.Black, fnlcotax, fnlcotay);
                }

                g3.DrawString(txtLPP.Text, fuente1, Brushes.Black, lvg + pt1xlabelcx, p1cty + altorayacota);

                //cabeza de la cota
                Point[] ptcbct = { new Point(p2ctx, p1cty - altorayacota), new Point(p2ctx, p1cty + altorayacota), new Point(puntact, p1cty), new Point(p2ctx, p1cty - altorayacota) };
                g3.FillPolygon(bfuerte, ptcbct);

                //mostrar dibujos de las fuerzas resultantes
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    if (Ra != 0 && Ra < 0)
                    {

                        g3.DrawLine(pluma3, 0 + p1x, iniciocgneg, 0 + p1x, p1y);
                        g3.DrawString("Ra", fuente1, Brushes.Red, 0 + pt1xlabelcx, anchovg);


                    }
                    else if (Ra != 0 && Ra > 0)
                    {
                        g3.DrawLine(pluma3, 0 + p1x, 2 * p1y + anchovg - iniciocgneg, 0 + p1x, p1y + anchovg);
                        g3.DrawString("Ra", fuente1, Brushes.Red, 0 + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    if (Rb != 0 && Rb > 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, 2 * p1y + anchovg - iniciocgneg, lvg + p1x, p1y + anchovg);
                        g3.DrawString("Rb", fuente1, Brushes.Red, lvg + pt1xlabelcx, 2 * p1y + anchovg - iniciocgneg);
                    }
                    else if (Rb != 0 && Rb < 0)
                    {
                        g3.DrawLine(pluma3, lvg + p1x, iniciocgneg, lvg + p1x, p1y);
                        g3.DrawString("Rb", fuente1, Brushes.Red, lvg + pt1xlabelcx, anchovg);
                    }
                    if (-Ma != 0 && -Ma > 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(p1x - anchoMto, Fn.NumEnt(tabCgVgPP.Height * 0.17), anchoMto * 2, anchoMto * 2), 0, -250);
                        g3.DrawString("Ma", fuente1, Brushes.Red, 0 + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }
                    else if (-Ma != 0 && -Ma < 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(-anchoMto + p1x, Fn.NumEnt(tabCgVgPP.Height * 0.17), 2 * anchoMto, 2 * anchoMto), 180, 250);
                        g3.DrawString("Ma", fuente1, Brushes.Red, 0 + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }
                    if (Mb != 0 && Mb > 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(p1x - anchoMto + lvg, Fn.NumEnt(tabCgVgPP.Height * 0.17), anchoMto * 2, anchoMto * 2), 0, -250);
                        g3.DrawString("Mb", fuente1, Brushes.Red, lvg + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }
                    else if (Mb != 0 && Mb < 0)
                    {
                        g3.DrawArc(pluma3, new Rectangle(-anchoMto + p1x + lvg, Fn.NumEnt(tabCgVgPP.Height * 0.17), 2 * anchoMto, 2 * anchoMto), 180, 250);
                        g3.DrawString("Mb", fuente1, Brushes.Red, lvg + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                    }

                }

                g3.Dispose();
            }


            for (int i = 0; i < dtgFyM.Rows.Count ; i++)
            {
                
                //cargas puntuales
                if (dtgFyM.Rows[i].Cells[0].Value.ToString() == "CC")
                {
                    cxCC[i] = double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString());
                    MgCC[i] = double.Parse(dtgFyM.Rows[i].Cells[3].Value.ToString());
                    locationxCC[i] = Fn.NumEnt(lvg * cxCC[i] / l);
 
                    if (MgCC[i] < 0 )
                    {
                        g1 = tabCgVgPP.CreateGraphics();
                        
                        g1.DrawLine(pluma, locationxCC[i] + p1x, iniciocgneg, locationxCC[i] + p1x, p1y);
                        g1.DrawString((Math.Abs(MgCC[i])).ToString(), fuente1, Brushes.Black, locationxCC[i] + pt1xlabelcx, anchovg);
                        g1.DrawLine(pluma1, new Point(locationxCC[i] + p1x, p1cty - altorayacota), new Point(locationxCC[i] + p1x, p1cty + altorayacota));
                      
                        g1.DrawString((Math.Abs(cxCC[i])).ToString(), fuente1, Brushes.Black, locationxCC[i] + pt1xlabelcx, p1cty + altorayacota);
                        g1.Dispose();
                       
                    }
                    else
                    {
                        g1 = tabCgVgPP.CreateGraphics();
                        g1.DrawLine(pluma1, new Point(locationxCC[i] + p1x, p1cty - altorayacota), new Point(locationxCC[i] + p1x, p1cty + altorayacota));
                        g1.DrawLine(pluma, locationxCC[i] + p1x, 2*p1y + anchovg - iniciocgneg, locationxCC[i] + p1x, p1y + anchovg);
                        g1.DrawString((Math.Abs(MgCC[i])).ToString(), fuente1, Brushes.Black, locationxCC[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg);
                       
                        g1.DrawString((Math.Abs(cxCC[i])).ToString(), fuente1, Brushes.Black, locationxCC[i] + pt1xlabelcx, p1cty + altorayacota);
                        g1.Dispose();
                       
                    }
                

                }
                
             


            }
            //cargas dsitribuidas
            for (int i = 0; i < dtgFyM.Rows.Count; i++)
            {
          
                if (dtgFyM.Rows[i].Cells[0].Value.ToString() == "CD")
                {
                    cx1CD[i] = double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString());
                    cx2CD[i] = double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString());
                    M1CD[i] = double.Parse(dtgFyM.Rows[i].Cells[4].Value.ToString());
                    M2CD[i] = double.Parse(dtgFyM.Rows[i].Cells[5].Value.ToString());
                    
                    locationx1CD[i]= Fn.NumEnt(lvg * cx1CD[i] / l);
                    locationx2CD[i]= Fn.NumEnt(lvg * cx2CD[i] / l);

                    if (M1CD[i] < 0 && M1CD[i] == M2CD[i])
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, iniciocgneg + cd, locationx1CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, anchovg + cd);
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma, locationx2CD[i] + p1x, iniciocgneg + cd, locationx2CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, anchovg+cd);
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, iniciocgneg + cd, locationx2CD[i] + p1x, iniciocgneg + cd);

                        g2.Dispose();



                    }
                    else if (M1CD[i] > 0 && M1CD[i] == M2CD[i])
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, 2*p1y + anchovg - iniciocgneg-cd, locationx1CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg -cd);
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx2CD[i] + p1x, 2*p1y + anchovg - iniciocgneg-cd, locationx2CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg -cd);
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, 2*p1y + anchovg - iniciocgneg -cd, locationx2CD[i] + p1x, 2*p1y + anchovg - iniciocgneg-cd);

                        g2.Dispose();

                    }
                    else if (M1CD[i] == 0 && M2CD[i] < 0)
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx2CD[i] + p1x, iniciocgneg + t, locationx2CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, anchovg + t);
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx2CD[i] + p1x, iniciocgneg + t, locationx1CD[i] + p1x, p1y);

                        g2.Dispose();
                    }
                    else if (M1CD[i] == 0 && M2CD[i] > 0)
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx2CD[i] + p1x, 2*p1y + anchovg - iniciocgneg-t, locationx2CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg-t);
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx2CD[i] + p1x, 2*p1y + anchovg - iniciocgneg-t, locationx1CD[i] + p1x, p1y + anchovg);

                        g2.Dispose();
                    }
                    else if (M2CD[i] == 0 && M1CD[i] < 0)
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, iniciocgneg + t, locationx1CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, anchovg+t);
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, iniciocgneg+t, locationx2CD[i] + p1x, p1y);

                        g2.Dispose();
                    }
                    else if (M2CD[i] == 0 && M1CD[i] > 0)
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, 2*p1y + anchovg - iniciocgneg - t, locationx1CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg - t);
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, 2*p1y + anchovg - iniciocgneg - t, locationx2CD[i] + p1x, p1y + anchovg);

                        g2.Dispose();
                    }
                    else if (M1CD[i] != 0 && M2CD[i] != 0 && M1CD[i]<0 && Math.Abs(M1CD[i]) < Math.Abs(M2CD[i]))
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, iniciocgneg + trm, locationx1CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, iniciocgneg + trm - Fn.NumEnt(tabCgVgPP.Height * 0.04));////
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma, locationx2CD[i] + p1x, iniciocgneg + trM, locationx2CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, anchovg + trM);
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, iniciocgneg + trm, locationx2CD[i] + p1x, iniciocgneg+ trM);

                        g2.Dispose();
                    }
                    else if (M1CD[i] != 0 && M2CD[i] != 0 && M1CD[i] > 0 && Math.Abs(M1CD[i]) < Math.Abs(M2CD[i]))
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota ), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, 2*p1y - trm + anchovg - iniciocgneg, locationx1CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, 2 * p1y - trm + anchovg - iniciocgneg + Fn.NumEnt(tabCgVgPP.Height * 0.01));
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx2CD[i] + p1x, 2*p1y + anchovg - iniciocgneg - trM, locationx2CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg - trM);
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, 2 * p1y - trm + anchovg - iniciocgneg, locationx2CD[i] + p1x, 2*p1y + anchovg - iniciocgneg - trM);

                        g2.Dispose();
                    }
                    else if (M1CD[i] != 0 && M2CD[i] != 0 && M1CD[i] < 0 && Math.Abs(M2CD[i]) < Math.Abs(M1CD[i]))
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, iniciocgneg + trM, locationx1CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, anchovg + trM);
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma, locationx2CD[i] + p1x, iniciocgneg + trm, locationx2CD[i] + p1x, p1y);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, iniciocgneg + trm - Fn.NumEnt(tabCgVgPP.Height * 0.04));
                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, iniciocgneg + trM, locationx2CD[i] + p1x, iniciocgneg + trm);

                        g2.Dispose();
                    }
                    else if (M1CD[i] != 0 && M2CD[i] != 0 && M1CD[i] > 0 && Math.Abs(M1CD[i]) > Math.Abs(M2CD[i]))
                    {
                        g2 = tabCgVgPP.CreateGraphics();
                        g2.DrawLine(pluma1, new Point(locationx1CD[i] + p1x, p1cty - altorayacota ), new Point(locationx1CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx1CD[i] + p1x, 2*p1y + anchovg - iniciocgneg - trM, locationx1CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, 2*p1y + anchovg - iniciocgneg -trM);
                        g2.DrawString((Math.Abs(cx1CD[i])).ToString(), fuente1, Brushes.Black, locationx1CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma1, new Point(locationx2CD[i] + p1x, p1cty - altorayacota ), new Point(locationx2CD[i] + p1x, p1cty + altorayacota));
                        g2.DrawLine(pluma, locationx2CD[i] + p1x, 2 * p1y - trm + anchovg - iniciocgneg, locationx2CD[i] + p1x, p1y + anchovg);
                        g2.DrawString((Math.Abs(M2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, 2 * p1y - trm + anchovg - iniciocgneg + Fn.NumEnt(tabCgVgPP.Height * 0.01));
                        g2.DrawString((Math.Abs(cx2CD[i])).ToString(), fuente1, Brushes.Black, locationx2CD[i] + pt1xlabelcx, p1cty + altorayacota);

                        g2.DrawLine(pluma2, locationx1CD[i] + p1x, 2*p1y + anchovg - iniciocgneg - trM, locationx2CD[i] + p1x, 2 * p1y - trm + anchovg - iniciocgneg);

                        g2.Dispose();
                    }

                }
            }
            //Momento
            for (int i = 0; i < dtgFyM.Rows.Count; i++)
            {

               
                if (dtgFyM.Rows[i].Cells[0].Value.ToString() == "M")
                {

                    cxM[i] = double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString());

                    MgM[i] =  double.Parse(dtgFyM.Rows[i].Cells[6].Value.ToString());

                    locationxM[i] =  Fn.NumEnt(lvg * cxM[i] / l);



                    if (MgM[i] < 0)
                    {
                        g4 = tabCgVgPP.CreateGraphics();

                        g4.DrawArc(pluma, new Rectangle(locationxM[i]- anchoMto + p1x, Fn.NumEnt(tabCgVgPP.Height * 0.17), 2*anchoMto, 2*anchoMto),180,p1cty - altorayacota);
                        g4.DrawString((Math.Abs(MgM[i])).ToString(), fuente1, Brushes.Black, locationxM[i] + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));
                        g4.DrawLine(pluma1, new Point(locationxM[i] + p1x, p1cty - altorayacota), new Point(locationxM[i] + p1x, p1cty + altorayacota));

                        g4.DrawString((Math.Abs(cxM[i])).ToString(), fuente1, Brushes.Black, locationxM[i] + pt1xlabelcx, p1cty + altorayacota);
                        g4.Dispose();

                    }
                    else
                    {
                        g4 = tabCgVgPP.CreateGraphics();
                        g4.DrawLine(pluma1, new Point(locationxM[i] + p1x, p1cty - altorayacota), new Point(locationxM[i] + p1x, p1cty + altorayacota));
                        g4.DrawArc(pluma, new Rectangle(locationxM[i]-anchoMto+p1x, Fn.NumEnt(tabCgVgPP.Height * 0.17), anchoMto*2,anchoMto*2),0,-p1cty - altorayacota);
                        g4.DrawString((Math.Abs(MgM[i])).ToString(), fuente1, Brushes.Black, locationxM[i] + pt1xlabelcx, Fn.NumEnt(tabCgVgPP.Height * 0.144));

                        g4.DrawString((Math.Abs(cxM[i])).ToString(), fuente1, Brushes.Black, locationxM[i] + pt1xlabelcx, p1cty + altorayacota);
                        g4.Dispose();

                    }


                }




            }


        }

        //boton resolver
        private void btnResolPP_Click(object sender, EventArgs e)
        {
            int aux20 = 0;
            for (int i = 0; i < dtgFyM.Rows.Count; i++)
            {
                if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) > l || double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()) > l)
                {

                    aux20 = 1;
                }
            }

            //Advertencias antes de empezar a resolver
            if (txtFSPP.Text == "" || txtFSPP.Text == "0")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Factor de seguridad no puede ser cero ni nulo");
                txtFSPP.Focus();
            }
            else if (txtLPP.Text == "" || txtLPP.Text == "0")
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Ingrese longitud válida");
                txtLPP.Focus();
            }
            else if (haymaterial == 0 && chkbDyPPP.Checked == true)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Por favor, seleccione marerial");
                btnAgMtPP.Focus();
            }
            else if (dtgFyM.Rows.Count == 0)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("No se han agregado cargas a la viga");
                btnAgMtPP.Focus();
            }
            else if (aux20 == 1)
            {
               
                   

                        MssBox mssBox = new MssBox();
                        mssBox.Muestra("Quedan cargas por fuera de la viga");
                        txtLPP.Text = "";
                       
                        txtLPP.Focus();
                    
                
            }
            else if (indTipApoy == 1 && ltv == 0)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("valor de ltv inválido, vuelva a digitarlo correctamente");
                txtFSPP.Focus();
            }
            else if (l < ltv && indTipApoy == 1)
            {
                MssBox mssBox = new MssBox();
                mssBox.Muestra("Tramo en voladizo queda por fuera de la viga");
                txtLPP.Focus();
            }
            else
            {
                //llenar vectores con 0
                MgCC.Clear();
                cxCC.Clear();
                cx1CD.Clear();
                cx2CD.Clear();
                M1CD.Clear();
                M2CD.Clear();
                MgM.Clear();
                yDgCte.Clear();
                yDgMto.Clear();
                xlabel.Clear();
                cxM.Clear();
                a1c.Clear();
                a2c.Clear();
                f1c.Clear();
                a1tp.Clear();
                a2tp.Clear();
                f1tp.Clear();
                a1tn.Clear();
                a2tn.Clear();
                f1tn.Clear();
                f1trp.Clear();
                f2trp.Clear();
                a1trp.Clear();
                a2trp.Clear();
                f1trn.Clear();
                f2trn.Clear();
                a1trn.Clear();
                a2trn.Clear();
                xaux.Clear();
                x1.Clear();
                x2.Clear();
                yaux.Clear();
                y1.Clear();
                y2.Clear();
                yauxM.Clear();
                y1M.Clear();
                y2M.Clear();
                SmenSminpeso.Clear();
                SmenSminpesoPS.Clear();
                SmenSminpesoPSname.Clear();
                SmenSminpesoname1.Clear();
                SmenSminpesoname.Clear();
                autom.Rows.Clear();
                autom.Columns.Clear();
                namevg.Clear();
                idvgautm.Clear();
                SmenSminpesoPSname1.Clear();
                SmenSminpesoid.Clear();
                pesoidPW.Clear();
                SmenSminpesoPSid.Clear();
                pesoidPS.Clear();
                lbperf.Items.Clear();
                lbnameperf.Items.Clear();
                SmenSminpesoPC.Clear();
                SmenSminpesoPCid.Clear();
                pesoidPC.Clear();
                SmenSminpesoPCname.Clear();
                chartV.ChartAreas[0].AxisX.CustomLabels.Clear();
                chartV.ChartAreas[0].AxisY.CustomLabels.Clear();
                chartM.ChartAreas[0].AxisX.CustomLabels.Clear();
                chartM.ChartAreas[0].AxisY.CustomLabels.Clear();

                for (int i = 0; i < dtgFyM.Rows.Count; i++)
                {
                    cxCC.Insert(i, 0);
                    MgCC.Insert(i, 0);
                    cx1CD.Insert(i, 1);
                    cx2CD.Insert(i, 2);
                    M1CD.Insert(i, 0);
                    M2CD.Insert(i, 0);
                    cxM.Insert(i, 0);
                    MgM.Insert(i, 0);
                    a1c.Insert(i, 1);
                    a2c.Insert(i, 2);
                    f1c.Insert(i, 0);
                    a1tp.Insert(i, 1);
                    a2tp.Insert(i, 2);
                    f1tp.Insert(i, 0);
                    a1tn.Insert(i, 1);
                    a2tn.Insert(i, 2);
                    f1tn.Insert(i, 0);
                    f1trp.Insert(i, 0);
                    f2trp.Insert(i, 0);
                    a1trp.Insert(i, 1);
                    a2trp.Insert(i, 2);
                    f1trn.Insert(i, 0);
                    f2trn.Insert(i, 0);
                    a1trn.Insert(i, 1);
                    a2trn.Insert(i, 2);



                }
                //vectores para dibujos(digramas)
                for (int i = 0; i <= 1000; i++)
                {
                    yDgCte.Insert(i, 0);
                    yDgMto.Insert(i, 0);
                  
                    xlabel.Insert(i, 0);
                }
                //llenar xlabel
                for (int i = 0; i <= 1000; i++)
                { xlabel[i] = (l * i) / (1000); }

                //extraer datos de cargas puntuales
                for (int i = 0; i < dtgFyM.Rows.Count; i++)
                {
                    if (dtgFyM.Rows[i].Cells[0].Value.ToString() == "CC")
                    {
                        MgCC[i] = double.Parse(dtgFyM.Rows[i].Cells[3].Value.ToString());
                        cxCC[i] = double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString());

                    }


                }
                //extraer datos de momento
                for (int i = 0; i < dtgFyM.Rows.Count; i++)
                {
                    if (dtgFyM.Rows[i].Cells[0].Value.ToString() == "M")
                    {
                        cxM[i] = double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString());
                        MgM[i] = double.Parse(dtgFyM.Rows[i].Cells[6].Value.ToString());

                    }

                }
                //extraer datos carga distribuida
                for (int i = 0; i < dtgFyM.Rows.Count; i++)
                {
                    if (dtgFyM.Rows[i].Cells[0].Value.ToString() == "CD")
                    {
                        cx1CD[i] = double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString());
                        cx2CD[i] = double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString());
                        M1CD[i] = double.Parse(dtgFyM.Rows[i].Cells[4].Value.ToString());
                        M2CD[i] = double.Parse(dtgFyM.Rows[i].Cells[5].Value.ToString());


                        if (M1CD[i] == M2CD[i]) //carga rectangular
                        {
                            a1c[i] = cx1CD[i];
                            a2c[i] = cx2CD[i];
                            f1c[i] = M1CD[i];

                        }
                        else if (M1CD[i] == 0 && M2CD[i] != 0) //triangulo con pendiente positiva
                        {
                            a1tp[i] = cx1CD[i];
                            a2tp[i] = cx2CD[i];
                            f1tp[i] = M2CD[i];

                        }
                        else if (M1CD[i] != 0 && M2CD[i] == 0) //tringulo con pendiente negativa
                        {
                            a1tn[i] = cx1CD[i];
                            a2tn[i] = cx2CD[i];
                            f1tn[i] = M1CD[i];

                        }
                        else if (M1CD[i] != 0 && Math.Abs(M1CD[i]) < Math.Abs(M2CD[i])) //trapecio pendiente positiva
                        {
                            f1trp[i] = M1CD[i];
                            f2trp[i] = M2CD[i];
                            a1trp[i] = cx1CD[i];
                            a2trp[i] = cx2CD[i];

                        }
                        else if (M1CD[i] != 0 && Math.Abs(M1CD[i]) > Math.Abs(M2CD[i])) //trapecio pendiente negativa
                        {
                            f1trn[i] = M1CD[i];
                            f2trn[i] = M2CD[i];
                            a1trn[i] = cx1CD[i];
                            a2trn[i] = cx2CD[i];

                        }
                    }
                }



                //Reacciondes y vectores pra graficar dependiento el tipo de apoyo
                if (indTipApoy == 0)
                {
                    // hallar reacción R2 VIGA SIMPL. APOYADA
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        SumaMomentos +=
                         MgCC[i] * cxCC[i] + f1c[i] * (a2c[i] - a1c[i]) * (((a2c[i] - a1c[i]) / 2) + a1c[i]) + MgM[i]
                                      + f1tp[i] * (a2tp[i] - a1tp[i]) / 2 * (a1tp[i] + 2 * (a2tp[i] - a1tp[i]) / 3)
                                      + f1tn[i] * (a2tn[i] - a1tn[i]) / 2 * (a1tn[i] + (a2tn[i] - a1tn[i]) / 3)
                         + ((f1trp[i] * (a2trp[i] - a1trp[i]) * (a1trp[i] + ((a2trp[i] - a1trp[i]) / 2))) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2) * (a1trp[i] + (2 * (a2trp[i] - a1trp[i]) / 3))))
                         + ((f2trn[i] * (a2trn[i] - a1trn[i]) * (a1trn[i] + ((a2trn[i] - a1trn[i]) / 2))) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2) * (a1trn[i] + (1 * (a2trn[i] - a1trn[i]) / 3))));
                    }
                    R2 = -SumaMomentos / l;
                    SumaMomentos = 0;

                    //R2 en barra sde estados

                    R2st.Visible = true;
                    pyc3.Visible = true;
                    R2st.Text = "R2 = " + R2.ToString("0.000");
                    R2st.ToolTipText = "Reacción 2: " + R2.ToString() + "\r" + "Coordenada x: " + l.ToString();
                    
             
                   

                    //hallar reacción R1 VIGA SIMPL.APOYADA
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    { SumaFuerzas += ((MgCC[i]) + (f1c[i] * (a2c[i] - a1c[i])) + (f1tp[i] * ((a2tp[i] - a1tp[i]) / 2)) + (f1tn[i] * ((a2tn[i] - a1tn[i]) / 2)) + (f1trp[i] * (a2trp[i] - a1trp[i])) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2)) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2)) + (f2trn[i] * (a2trn[i] - a1trn[i]))); }
                    R1 = -(SumaFuerzas + R2);
                    SumaFuerzas = 0;

                    //R1 en barra sde estados
                    if (Mtst.Visible == false && ltvst.Visible == false)
                    {
                        pyc2.Visible = false;
                        pyc4.Visible = false;
                        pyc5.Visible = false;
                        pyc6.Visible = false;
                        pyc7.Visible = false;
                        pyc8.Visible = false;
                        pyc9.Visible = false;
                        Rast.Visible = false;
                        Rbst.Visible = false;
                        Rcst.Visible = false;
                        MRst.Visible = false;
                        Mbst.Visible = false;
                        lconst.Visible = false;
                        Mast.Visible = false;
                        pyc10.Visible = false;

                        R1st.Visible = true;
                        R1st.Text = "R1 = " + R1.ToString("0.000");
                        R1st.ToolTipText = "Reacción 1: " + R1.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    else
                    {
                        pyc4.Visible = false;
                        pyc5.Visible = false;
                        pyc6.Visible = false;
                        pyc7.Visible = false;
                        pyc8.Visible = false;
                        pyc9.Visible = false;
                        Rast.Visible = false;
                        Rbst.Visible = false;
                        Rcst.Visible = false;
                        MRst.Visible = false;
                        Mbst.Visible = false;
                        lconst.Visible = false;
                        Mast.Visible = false;
                        pyc10.Visible = false;

                        pyc2.Visible = true;
                        R1st.Visible = true;
                        R1st.Text = "R1 = " + R1.ToString();
                        R1st.ToolTipText = "Reacción 1: " + R1.ToString() + "\r" + "Coordenada x: " + "0";


                    }

                    //hallar función de singularidad
                    for (int i = 0; i < MgCC.Count; i++)
                    {
                        fsincc += MgCC[i].ToString() + "<x-" + cxCC[i].ToString() + ">^0";
                    }
                    for (int i = 0; i < f1c.Count; i++)
                    {
                        fsinr += f1c[i].ToString() + "<x-" + a1c[i].ToString() + ">^1 " + Convert.ToString(-f1c[i]) + "<x-" + a2c[i].ToString() + ">^1 ";
                    }

                    //hacer el vector y(cortante) 
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgCte[i] += MgCC[j] * Fn.FsingCP(cxCC[j], xlabel[i]) //cargas puntuales
                            + f1c[j] * Fn.FSingMCP(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCP(a2c[j], xlabel[i]) //carga rectangular
                            + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) // triangulo pendiente positiva
                            + (f1tn[j]) * Fn.FSingMCP(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], xlabel[i]) //triandulo pendiente negativa
                            + f1trp[j] * Fn.FSingMCP(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCP(a2trp[j], xlabel[i]) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], xlabel[i]) //trapecio pendiente positiva
                            + f2trn[j] * Fn.FSingMCP(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCP(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], xlabel[i]); //trapecio pendiente negativa

                        }


                        yDgCte[i] = yDgCte[i] + R1 * Fn.FsingCP(0, xlabel[i]) + R2 * Fn.FsingCP(l, xlabel[i]);

                        yDgCte[i] = Math.Round(yDgCte[i], 4);
                    }


                    // hacer el vector y (Momento) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgMto[i] += MgCC[j] * Fn.FSingMCP(cxCC[j], xlabel[i]) +
                            +f1c[j] * Fn.FSingMCDR(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCDR(a2c[j], xlabel[i]) + //
                            +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                            +f1tn[j] * Fn.FSingMCDR(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], xlabel[i]) +
                            +f1trp[j] * Fn.FSingMCDR(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCDR(a2trp[j], xlabel[i]) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], xlabel[i]) +
                            +f2trn[j] * Fn.FSingMCDR(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCDR(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], xlabel[i]) +
                            -MgM[j] * Fn.FsingCP(cxM[j], xlabel[i]);


                        }
                        yDgMto[i] = yDgMto[i] + R1 * Fn.FSingMCP(0, xlabel[i]) + R2 * Fn.FSingMCP(l, xlabel[i]);
                        yDgMto[i] = Math.Round(yDgMto[i], 4);
                    }


                    //elemento del yvalue mayor y menor
                    yDgCtemay = yDgCte[0];
                    yDgCtemen = yDgCte[0];
                    yDgCtemayABS = Math.Abs(yDgCte[0]);
                    yDgCtemenABS = Math.Abs(yDgCte[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgCte[i]) > yDgCtemayABS)
                        {
                            yDgCtemayABS = Math.Abs(yDgCte[i]);
                            xdelyCtemayorABS = i;
                        }
                        else if (Math.Abs(yDgCte[i]) < yDgCtemenABS) { yDgCtemenABS = Math.Abs(yDgCte[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgCte[i] > yDgCtemay)
                        {
                            yDgCtemay = yDgCte[i];


                        }
                        else if (yDgCte[i] < yDgCtemen) { yDgCtemen = yDgCte[i]; }
                    }



                    //elemento mayor y menor de momento
                    yDgMtomay = yDgMto[0];
                    yDgMtomen = yDgMto[0];
                    yDgMtomayABS = Math.Abs(yDgMto[0]);
                    yDgMtomenABS = Math.Abs(yDgMto[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgMto[i] > yDgMtomay)
                        {
                            yDgMtomay = yDgMto[i];
                        }
                        else if (yDgMto[i] < yDgMtomen) { yDgMtomen = yDgMto[i]; }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgMto[i]) > yDgMtomayABS)
                        {
                            yDgMtomayABS = Math.Abs(yDgMto[i]);
                            xdelyMtomayorABS = i;

                        }
                        else if (Math.Abs(yDgMto[i]) < yDgMtomenABS) { yDgMtomenABS = Math.Abs(yDgMto[i]); }
                    }


                    



                    //if (chkDyP.Checked == true)
                    //{
                    //    btnSelPf.Enabled = true;
                    //}

                }

                //resolver reacciones y diagramas de viga con tramo en voladizo
                else if (indTipApoy == 1)
                {

                    for (int j = 0; j < dtgFyM.Rows.Count; j++)
                    {
                        SumaMomentos += MgCC[j] * cxCC[j] + f1c[j] * (a2c[j] - a1c[j]) * (((a2c[j] - a1c[j]) / 2) + a1c[j]) + MgM[j]
                                         + (f1tp[j] * (a2tp[j] - a1tp[j]) / 2) * (a1tp[j] + (2 * (a2tp[j] - a1tp[j])) / 3)
                                         + (f1tn[j] * (a2tn[j] - a1tn[j]) / 2) * (a1tn[j] + (a2tn[j] - a1tn[j]) / 3)
                         + (f1trp[j] * (a2trp[j] - a1trp[j]) * (a1trp[j] + (a2trp[j] - a1trp[j]) / 2)) + (((a2trp[j] - a1trp[j]) * (f2trp[j] - f1trp[j]) / 2) * (a1trp[j] + (2 * (a2trp[j] - a1trp[j]) / 3)))
                        + f2trn[j] * (a2trn[j] - a1trn[j]) * (a1trn[j] + (a2trn[j] - a1trn[j]) / 2) + (a2trn[j] - a1trn[j]) * (f1trn[j] - f2trn[j]) / 2 * (a1c[j] + (a2trn[j] - a1trn[j]) * 1 / 3);
                    }
                    R2 = -SumaMomentos / ltv;
                    SumaMomentos = 0;

                    //R2 en barra sde estados
                   
                        pyc4.Visible = false;
                        pyc5.Visible = false;
                        pyc6.Visible = false;
                        pyc7.Visible = false;
                        pyc8.Visible = false;
                        pyc9.Visible = false;
                        pyc10.Visible = false;
                        Rast.Visible = false;
                        Rbst.Visible = false;
                        Rcst.Visible = false;
                        MRst.Visible = false;
                        Mbst.Visible = false;
                        lconst.Visible = false;
                        Mast.Visible = false;
                       

                        pyc3.Visible = true;
                        R2st.Visible = true;
                        R2st.Text = "R2 = " + R2.ToString("0.000");
                        R2st.ToolTipText = "Reacción 2: " + R2.ToString() + "\r" + "Coordenada x: " + ltv.ToString();
                    
            

                    // hallar reacción R1 VIGA TRAMO EN VOLADIZO
                    for (int j = 0; j < dtgFyM.Rows.Count; j++)
                    { SumaFuerzas += MgCC[j] + f1c[j] * (a2c[j] - a1c[j]) + f1tp[j] * ((a2tp[j] - a1tp[j]) / 2) + (f1tn[j] * (a2tn[j] - a1tn[j]) / 2) + f1trp[j] * (a2trp[j] - a1trp[j]) + (a2trp[j] - a1trp[j]) * (f2trp[j] - f1trp[j]) / 2 + (a2trn[j] - a1trn[j]) * (f1trn[j] - f2trn[j]) / 2 + f2trn[j] * (a2trn[j] - a1trn[j]); }
                    R1 = -(SumaFuerzas + R2);
                    SumaFuerzas = 0;

                    //R1 en barra sde estados
                    if (Mtst.Visible == false && ltvst.Visible == false){
                 

                        pyc2.Visible = false;
                        R1st.Visible = true;
                        R1st.Text = "R1 = " + R1.ToString("0.000");
                        R1st.ToolTipText = "Reacción 1: " + R1.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    else
                    {
                      

                        pyc2.Visible = true;
                        R1st.Visible = true;
                        R1st.Text = "R1 = " + R1.ToString("0.000");
                        R1st.ToolTipText = "Reacción 1: " + R1.ToString() + "\r" + "Coordenada x: " + "0";


                    }

                    //hacer el vector y(cortante) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgCte[i] += MgCC[j] * Fn.FsingCP(cxCC[j], xlabel[i]) +
                                +f1c[j] * Fn.FSingMCP(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCP(a2c[j], xlabel[i]) //carga rectangular
                                + f1tp[j] * Fn.FSingMCP(a1tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) +
                                +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) +
                                +(f1tn[j]) * Fn.FSingMCP(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], xlabel[i]) +
                                +f1trp[j] * Fn.FSingMCP(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCP(a2trp[j], xlabel[i]) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], xlabel[i]) +
                                +f2trn[j] * Fn.FSingMCP(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCP(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], xlabel[i]);

                        }

                        yDgCte[i] = yDgCte[i] + R1 * Fn.FsingCP(0, xlabel[i]) + R2 * Fn.FsingCP(ltv, xlabel[i]);
                        yDgCte[i] = Math.Round(yDgCte[i], 4);
                    }


                    // hacer el vector y(Momento) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgMto[i] += MgCC[j] * Fn.FSingMCP(cxCC[j], xlabel[i])
                                 + f1c[j] * Fn.FSingMCDR(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCDR(a2c[j], xlabel[i])
                                            + f1tp[j] * Fn.FSingMCDR(a1tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                                            +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                                            +f1tn[j] * Fn.FSingMCDR(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], xlabel[i]) +
                                            +f1trp[j] * Fn.FSingMCDR(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCDR(a2trp[j], xlabel[i]) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], xlabel[i]) +
                                            +f2trn[j] * Fn.FSingMCDR(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCDR(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], xlabel[i]) +
                                            -MgM[j] * Fn.FsingCP(cxM[j], xlabel[i]);

                        }
                        yDgMto[i] = yDgMto[i] + R1 * Fn.FSingMCP(0, xlabel[i]) + R2 * Fn.FSingMCP(ltv, xlabel[i]);
                        yDgMto[i] = Math.Round(yDgMto[i], 4);
                    }


                    // elemento del yvalue mayor y menor
                    yDgCtemay = yDgCte[0];
                    yDgCtemen = yDgCte[0];
                    yDgCtemayABS = Math.Abs(yDgCte[0]);
                    yDgCtemenABS = Math.Abs(yDgCte[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgCte[i]) > yDgCtemayABS)
                        {
                            yDgCtemayABS = Math.Abs(yDgCte[i]);
                            xdelyCtemayorABS = i;
                        }
                        else if (Math.Abs(yDgCte[i]) < yDgCtemenABS) { yDgCtemenABS = Math.Abs(yDgCte[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgCte[i] > yDgCtemay)
                        {
                            yDgCtemay = yDgCte[i];

                        }
                        else if (yDgCte[i] < yDgCtemen) { yDgCtemen = yDgCte[i]; }
                    }



                    //elemento mayor y menor de yyvalue
                    yDgMtomay = yDgMto[0];
                    yDgMtomen = yDgMto[0];
                    yDgMtomayABS = Math.Abs(yDgMto[0]);
                    yDgMtomenABS = Math.Abs(yDgMto[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgMto[i]) > yDgMtomayABS)
                        {
                            yDgMtomayABS = Math.Abs(yDgMto[i]);
                            xdelyMtomayorABS = i;
                        }
                        else if (Math.Abs(yDgMto[i]) < yDgMtomenABS) { yDgMtomenABS = Math.Abs(yDgMto[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgMto[i] > yDgMtomay)
                        {
                            yDgMtomay = yDgMto[i];
                        }
                        else if (yDgMto[i] < yDgMtomen) { yDgMtomen = yDgMto[i]; }
                    }



                }

                //resolver reacciones y diagramas de viga empotrada
                else if (indTipApoy == 2)
                {
                    //hallar MR(momento reactor) con un tramo en voladizo
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        SumaMomentos +=
                         MgCC[i] * cxCC[i] + f1c[i] * (a2c[i] - a1c[i]) * (((a2c[i] - a1c[i]) / 2) + a1c[i]) + MgM[i]
                                      + f1tp[i] * (a2tp[i] - a1tp[i]) / 2 * (a1tp[i] + 2 * (a2tp[i] - a1tp[i]) / 3)
                                      + f1tn[i] * (a2tn[i] - a1tn[i]) / 2 * (a1tn[i] + (a2tn[i] - a1tn[i]) / 3)
                         + ((f1trp[i] * (a2trp[i] - a1trp[i]) * (a1trp[i] + ((a2trp[i] - a1trp[i]) / 2))) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2) * (a1trp[i] + (2 * (a2trp[i] - a1trp[i]) / 3))))
                         + ((f2trn[i] * (a2trn[i] - a1trn[i]) * (a1trn[i] + ((a2trn[i] - a1trn[i]) / 2))) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2) * (a1trn[i] + (1 * (a2trn[i] - a1trn[i]) / 3))));
                    }
                    MR = -SumaMomentos;
                    SumaMomentos = 0;

                    //mr en la barra de estado
                 

                        pyc4.Visible = true;
                        MRst.Visible = true;
                        MRst.Text = "Mr = " + MR.ToString("0.000");
                        MRst.ToolTipText = "Momento reactivo : " + MR.ToString() + "\r" + "Coordenada x: " + "0";





                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    { SumaFuerzas += ((MgCC[i]) + (f1c[i] * (a2c[i] - a1c[i])) + (f1tp[i] * ((a2tp[i] - a1tp[i]) / 2)) + (f1tn[i] * ((a2tn[i] - a1tn[i]) / 2)) + (f1trp[i] * (a2trp[i] - a1trp[i])) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2)) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2)) + (f2trn[i] * (a2trn[i] - a1trn[i]))); }
                    R1 = -SumaFuerzas;
                    SumaFuerzas = 0;

                    //R1 en barra sde estados
                    if (Mtst.Visible == false )
                    {
                        pyc3.Visible = false;
                      
                        pyc5.Visible = false;
                        pyc6.Visible = false;
                        pyc7.Visible = false;
                        pyc8.Visible = false;
                        pyc9.Visible = false;
                        Rast.Visible = false;
                        Rbst.Visible = false;
                        Rcst.Visible = false;
                  
                        Mbst.Visible = false;
                        lconst.Visible = false;
                        Mast.Visible = false;
                        pyc10.Visible = false;
                        ltvst.Visible = false;
                        pyc.Visible = false;

                        pyc2.Visible = false;
                        R1st.Visible = true;
                        R1st.Text = "R = " + R1.ToString("0.000");
                        R1st.ToolTipText = "Reacción: " + R1.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    else
                    {
                        pyc3.Visible = false;
                       
                        pyc5.Visible = false;
                        pyc6.Visible = false;
                        pyc7.Visible = false;
                        pyc8.Visible = false;
                        pyc9.Visible = false;
                        Rast.Visible = false;
                        Rbst.Visible = false;
                        Rcst.Visible = false;
                  
                        Mbst.Visible = false;
                        lconst.Visible = false;
                        Mast.Visible = false;
                        pyc10.Visible = false;
                        ltvst.Visible = false;
                        pyc.Visible = false;

                        pyc2.Visible = true;
                        R1st.Visible = true;
                        R1st.Text = "R = " + R1.ToString("0.000");
                        R1st.ToolTipText = "Magnitud: " + R1.ToString() + "\r" + "Coordenada x: " + "0";


                    }

                    //    //hacer el vector y(cortante) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgCte[i] += MgCC[j] * Fn.FsingCP(cxCC[j], xlabel[i]) //cargas puntuales
                           + f1c[j] * Fn.FSingMCP(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCP(a2c[j], xlabel[i]) //carga rectangular
                           + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) // triangulo pendiente positiva
                           + (f1tn[j]) * Fn.FSingMCP(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], xlabel[i]) //triandulo pendiente negativa
                           + f1trp[j] * Fn.FSingMCP(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCP(a2trp[j], xlabel[i]) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], xlabel[i]) //trapecio pendiente positiva
                           + f2trn[j] * Fn.FSingMCP(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCP(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], xlabel[i]); //trapecio pendiente negativa

                        }
                        yDgCte[i] = yDgCte[i] + R1 * Fn.FsingCP(0, xlabel[i]);
                        yDgCte[i] = Math.Round(yDgCte[i], 4);
                    }


                    //    // hacer el vector y (Momento) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgMto[i] += MgCC[j] * Fn.FSingMCP(cxCC[j], xlabel[i]) +
                             +f1c[j] * Fn.FSingMCDR(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCDR(a2c[j], xlabel[i]) + //
                             +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                             +f1tn[j] * Fn.FSingMCDR(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], xlabel[i]) +
                             +f1trp[j] * Fn.FSingMCDR(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCDR(a2trp[j], xlabel[i]) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], xlabel[i]) +
                             +f2trn[j] * Fn.FSingMCDR(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCDR(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], xlabel[i]) +
                             -MgM[j] * Fn.FsingCP(cxM[j], xlabel[i]);


                        }
                        yDgMto[i] = yDgMto[i] + R1 * Fn.FSingMCP(0, xlabel[i]) - MR * Fn.FsingCP(0, xlabel[i]);
                        yDgMto[i] = Math.Round(yDgMto[i], 4);
                    }


                    //elemento del yvalue mayor y menor
                    yDgCtemay = yDgCte[0];
                    yDgCtemen = yDgCte[0];
                    yDgCtemayABS = Math.Abs(yDgCte[0]);
                    yDgCtemenABS = Math.Abs(yDgCte[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgCte[i]) > yDgCtemayABS)
                        {
                            yDgCtemayABS = Math.Abs(yDgCte[i]);
                            xdelyCtemayorABS = i;
                        }
                        else if (Math.Abs(yDgCte[i]) < yDgCtemenABS) { yDgCtemenABS = Math.Abs(yDgCte[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgCte[i] > yDgCtemay)
                        {
                            yDgCtemay = yDgCte[i];

                        }
                        else if (yDgCte[i] < yDgCtemen) { yDgCtemen = yDgCte[i]; }
                    }



                    //elemento mayor y menor de yyvalue
                    yDgMtomay = yDgMto[0];
                    yDgMtomen = yDgMto[0];
                    yDgMtomayABS = Math.Abs(yDgMto[0]);
                    yDgMtomenABS = Math.Abs(yDgMto[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgMto[i] > yDgMtomay)
                        {
                            yDgMtomay = yDgMto[i];
                        }
                        else if (yDgMto[i] < yDgMtomen) { yDgMtomen = yDgMto[i]; }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgMto[i]) > yDgMtomayABS)
                        {
                            yDgMtomayABS = Math.Abs(yDgMto[i]);
                            xdelyMtomayorABS = i;
                        }
                        else if (Math.Abs(yDgMto[i]) < yDgMtomenABS) { yDgMtomenABS = Math.Abs(yDgMto[i]); }
                    }



                }

                //resolver reacciones y diagrammas para viga continua
                else if (indTipApoy == 3)
                {
                    double E = 1, I = 1, vCC=0,vCC1=0,vCR=0,vCR1=0,vCR2=0,vTP=0,vTP1=0,vTP2=0,xbb,vTRP=0,vTRP1=0,vTRP2=0,vTN=0,vTN1=0,vTN2=0,vTRN=0,vTRN1=0,vTRN2=0,vM=0,vM1=0;
                    double C,D,J; // variables para almacenar
                    //reacción redundadante
                    xbb = l - lcon;
                    D = (xbb * lcon) / (6 * l * E * I);
                    J = Math.Pow(l, 2) - Math.Pow(xbb, 2) - Math.Pow(lcon, 2);
                    C = D * J;

                    //carga concentrada
                    for (int i = 0; i < MgCC.Count; i++)
                    {
                        if (cxCC[i] > lcon)
                        {
                            double b,A,B;
                        
                            b = l - cxCC[i];
                            A = (-MgCC[i]*b*lcon)/(6*l*E*I);
                            B = Math.Pow(l, 2) - Math.Pow(b, 2) - Math.Pow(lcon, 2);
                            vCC += A * B;
                        }
                        else if (cxCC[i] < lcon)
                        {
                            double b, A, B, H;
                            b = l - cxCC[i];
                            A = (-MgCC[i] * b * lcon) / (6 * l * E * I);
                            B = Math.Pow(l, 2) - Math.Pow(b, 2) - Math.Pow(lcon, 2);
                            H = (-MgCC[i] * Math.Pow(lcon - cxCC[i], 3)) / (6);
                            vCC1 += A * B + H;
                        }
                    }


                    //carga rectángular
                    for (int i = 0; i < f1c.Count; i++)
                    {
                        double RaCC,b,C2=0,C3,C6;
                        
                        b = a2c[i] - a1c[i];
                        RaCC = (-b*f1c[i]*(l-a2c[i]+0.5*b))/(l);
                        C3 = (-b * f1c[i] * Math.Pow(l - a2c[i] + 0.5 * b, 3)) / (6*l) -  RaCC * Math.Pow(l, 2) / 6 +  Math.Pow(b, 3) * f1c[i] * a2c[i] / (24*l) -  Math.Pow(b, 4) * f1c[i] / (48*l);
                        C2 = C3 - ((f1c[i] * Math.Pow(b, 3)) / 24);
                        C6 = -C3 * l - (b * f1c[i] * Math.Pow(l - a2c[i] + 0.5 * b, 3) / 6) - RaCC * Math.Pow(l, 3) / 6; 
                        if (lcon < a1c[i] && lcon < a2c[i])
                        {
                            vCR1 = RaCC * Math.Pow(lcon, 3) / 6 + C2 * lcon; /// c2=c1
                        }
                        else if (lcon >= a1c[i] && lcon <= a2c[i])
                        {
                            vCR +=  RaCC * Math.Pow(lcon, 3) / 6 + f1c[i] * Math.Pow(lcon - a1c[i], 4) / 24 + C2 * lcon;
                        }
                        else if (lcon >= a1c[i] && lcon >= a2c[i])
                        {
                            vCR2 += RaCC * Math.Pow(lcon, 3) / 6 + b * f1c[i] * Math.Pow(lcon - a2c[i] + 0.5*b,3) / 6 + C3*lcon + C6;
                        }
                    }

                    //carga triangular con pendiente positiva
                    for (int i = 0; i < f1tp.Count; i++)
                    {
                        double RaTP, b,h,m, C2 = 0, C3, C6,C5;
                        h = f1tp[i];
                        b = a2tp[i] - a1tp[i];
                        RaTP = (-b * h * (l - a2tp[i] + b/3)) / (2*l);
                        m = h / b;

                        C3 = -RaTP * Math.Pow(l, 2) / 6 - b * h * Math.Pow(l - a2tp[i] + b / 3, 3) / (12 * l) - Math.Pow(b, 3) * h * a1tp[i] / (36 * l) + m * Math.Pow(b, 4) * a1tp[i]/(24*l);
                        C5 = -Math.Pow(b, 3) * h * a2tp[i] / 36 + m * Math.Pow(b, 4) * a2tp[i] / 24 - C3 * l - b * h * Math.Pow(l - a2tp[i] + b / 3, 3) / 12 - m * Math.Pow(b, 5) / 120 - h * Math.Pow(b, 4) / 324 - RaTP * Math.Pow(l, 3) / 6;
                        C2 = C3 + Math.Pow(b, 3) * h / 36 - m * Math.Pow(b, 4)/24;
                        C6 = -C2 * a1tp[i] - C3 * a1tp[i] - b * h * Math.Pow(a1tp[i] - a2tp[i], 3) / 12;
                      
                      
                        if (lcon < a1tp[i] && lcon <= a2tp[i])
                        {
                            vTP1 += RaTP * Math.Pow(lcon, 3) / 6 + C2 * lcon;
                        }
                        else if (lcon >= a1tp[i] && lcon <= a2tp[i])
                        {
                            vTP += RaTP * Math.Pow(lcon, 3) / (6) + m * Math.Pow(lcon - a1tp[i], 5) / (120) + C2 * lcon + C5;
                        }
                        else if (lcon >= a1tp[i] && lcon >= a2tp[i])
                        {
                            vTP2 += RaTP * Math.Pow(lcon, 3) / 6 + b * h * Math.Pow(lcon - a2tp[i] + b / 3, 3) + C3 * lcon + C6;
                        }
                    }

                    //trapecio de pendiente positiva
                    for (int i = 0; i < f1trp.Count; i++)
                    {
                        double RaTP, b, h, m, C2 = 0, C3, C6, C5;
                        h = f2trp[i] - f1trp[i];
                        b = a2trp[i] - a1trp[i];
                        RaTP = (-b * h * (l - a2trp[i] + b / 3)) / (2 * l);
                        m = h / b;

                        C3 = -RaTP * Math.Pow(l, 2) / 6 - b * h * Math.Pow(l - a2trp[i] + b / 3, 3) / (12 * l) - Math.Pow(b, 3) * h * a1trp[i] / (36 * l) + m * Math.Pow(b, 4) * a1trp[i] / (24 * l);
                        C5 = -Math.Pow(b, 3) * h * a2trp[i] / 36 + m * Math.Pow(b, 4) * a2trp[i] / 24 - C3 * l - b * h * Math.Pow(l - a2trp[i] + b / 3, 3) / 12 - m * Math.Pow(b, 5) / 120 - h * Math.Pow(b, 4) / 324 - RaTP * Math.Pow(l, 3) / 6;
                        C2 = C3 + Math.Pow(b, 3) * h / 36 - m * Math.Pow(b, 4) / 24;
                        C6 = -C2 * a1trp[i] - C3 * a1trp[i] - b * h * Math.Pow(a1trp[i] - a2trp[i], 3) / 12;


                        double RaCC, bR, C22 = 0, C33, C66;

                        bR = a2trp[i] - a1trp[i];
                        RaCC = (-bR * f1trp[i] * (l - a2trp[i] + 0.5 * bR)) / (l);
                        C33 = (-bR * f1trp[i] * Math.Pow(l - a2trp[i] + 0.5 * bR, 3)) / (6 * l) - RaCC * Math.Pow(l, 2) / 6 + Math.Pow(bR, 3) * f1trp[i] * a2trp[i] / (24 * l) - Math.Pow(bR, 4) * f1trp[i] / (48 * l);
                        C22 = C33 - ((f1trp[i] * Math.Pow(bR, 3)) / 24);
                        C66 = -C33 * l - (bR * f1trp[i] * Math.Pow(l - a2trp[i] + 0.5 * bR, 3) / 6) - RaCC * Math.Pow(l, 3) / 6;
              



                        if (lcon < a1trp[i] && lcon <= a2trp[i])
                        {
                            vTRP1 += RaTP * Math.Pow(lcon, 3) / 6 + C2 * lcon    +    RaCC * Math.Pow(lcon, 3) / 6 + C22 * lcon;
                        }
                        else if (lcon >= a1trp[i] && lcon <= a2trp[i])
                        {
                            vTRP += RaTP * Math.Pow(lcon, 3) / (6) + m * Math.Pow(lcon - a1trp[i], 5) / (120) + C2 * lcon + C5    +    RaCC * Math.Pow(lcon, 3) / 6 + f1trp[i] * Math.Pow(lcon - a1trp[i], 4) / 24 + C22 * lcon;
                        }
                        else if (lcon >= a1trp[i] && lcon >= a2trp[i])
                        {
                            vTRP2 += RaTP * Math.Pow(lcon, 3) / 6 + b * h * Math.Pow(lcon - a2trp[i] + b / 3, 3) + C3 * lcon + C6     + RaCC * Math.Pow(lcon, 3) / 6 + bR * f1trp[i] * Math.Pow(lcon - a2trp[i] + 0.5 * bR, 3) / 6 + C33 * lcon + C66;
                        }
                    }

                    //carga triangular con pendiente negativa

                    for (int i = 0; i < f1tn.Count; i++)
                    {
                        double RaTN, b, h, m, C2 = 0, C3, C6, C5=0, A, B, CC, DD, C1;
                        h = f1tn[i];
                        b = a2tn[i] - a1tn[i];
                        RaTN = (-b * h * (l - a2tn[i] + 2 * b / 3)) / (2 * l);
                        m = -h / b;

                        A = m / 24;
                        B = h / 9 - a2tn[i] * m / 18 - a1tn[i] * m / 9;
                        CC = Math.Pow(a1tn[i], 2) * m / 12 + a1tn[i] * a2tn[i] * m / 6 - a1tn[i] * h / 3;
                        DD = Math.Pow(a1tn[i], 2) * h / 3 - Math.Pow(a1tn[i], 2) * a2tn[i] * m / 6;

                        C3 = 4 * A * Math.Pow(a2tn[i], 5) / 5 + 3 * B * Math.Pow(a2tn[i], 4) / 4 + 2 * CC * Math.Pow(a2tn[i], 3) / 3 + DD * Math.Pow(a2tn[i], 2) / 2
                           - 4 * A * Math.Pow(a1tn[i], 5) / 5 - 3 * B * Math.Pow(a1tn[i], 4) / 4 - 2 * CC * Math.Pow(a1tn[i], 3) / 3 - DD * Math.Pow(a1tn[i], 2) / 2
                           - Math.Pow(b, 3) * h * a2tn[i] / 9 + 2 * Math.Pow(b, 4) * h / 81 - RaTN * Math.Pow(l, 3) / 6 - b * h * Math.Pow(l - a2tn[i] + 2 * b / 3, 3) / 12;
                        C3 = C3 / l;
                        C6 = -RaTN * Math.Pow(l, 3) / 6 - b * h * Math.Pow(l - a2tn[i] + 2 * b / 3, 3) / 12 - C3 * l;
                        C2 = C3 + Math.Pow(b, 3) * h / 9 - Math.Pow(a2tn[i], 4) * A - Math.Pow(a2tn[i], 3) * B - Math.Pow(a2tn[i], 2) * CC - a2tn[i] * DD;
                        C1 = C2 + Math.Pow(a1tn[i],4)*A + Math.Pow(a1tn[i],3)*B + Math.Pow(a1tn[i],2)*CC + a1tn[i]*DD;
                        C5 = C1 * a1tn[i] - C2 * a1tn[i] - Math.Pow(a1tn[i], 5) * A / 5 - Math.Pow(a1tn[i], 4) * B / 4 - Math.Pow(a1tn[i], 3) * CC / 3 - Math.Pow(a1tn[i], 2) * DD / 2;


                        if (lcon < a1tn[i] && lcon <= a2tn[i])
                        {
                            vTN1 += RaTN * Math.Pow(lcon, 3) / 6 + C1*lcon;
                        }
                        else if (lcon >= a1tn[i] && lcon <= a2tn[i])
                        {
                            vTN += RaTN * Math.Pow(lcon, 3) / 6 + A * Math.Pow(lcon, 5) / 5 + B * Math.Pow(lcon, 4) / 4 + CC * Math.Pow(lcon, 3) / 3 + DD * Math.Pow(lcon, 2) / 2 + C2 * lcon + C5;
                        }
                        else if (lcon >= a1tn[i] && lcon >= a2tn[i])
                        {
                            vTN2 += RaTN * Math.Pow(lcon, 3) / 6 + b*h*Math.Pow(lcon-a2tn[i]+2*b/3,3)/12 + C3*lcon + C6;
                        }
                    }

                    //carga trapecio con pendiente negativa
                    for (int i = 0; i < f1trn.Count; i++)
                    {
                        double RaTN, b, h, m, C2 = 0, C3, C6, C5 = 0, A, B, CC, DD, C1;
                        h = f1tn[i];
                        b = a2trn[i] - a1trn[i];
                        RaTN = (-b * h * (l - a2trn[i] + 2 * b / 3)) / (2 * l);
                        m = -h / b;

                        A = m / 24;
                        B = h / 9 - a2trn[i] * m / 18 - a1trn[i] * m / 9;
                        CC = Math.Pow(a1trn[i], 2) * m / 12 + a1trn[i] * a2trn[i] * m / 6 - a1trn[i] * h / 3;
                        DD = Math.Pow(a1trn[i], 2) * h / 3 - Math.Pow(a1trn[i], 2) * a2trn[i] * m / 6;

                        C3 = 4 * A * Math.Pow(a2trn[i], 5) / 5 + 3 * B * Math.Pow(a2trn[i], 4) / 4 + 2 * CC * Math.Pow(a2trn[i], 3) / 3 + DD * Math.Pow(a2trn[i], 2) / 2
                           - 4 * A * Math.Pow(a1trn[i], 5) / 5 - 3 * B * Math.Pow(a1trn[i], 4) / 4 - 2 * CC * Math.Pow(a1trn[i], 3) / 3 - DD * Math.Pow(a1trn[i], 2) / 2
                           - Math.Pow(b, 3) * h * a2trn[i] / 9 + 2 * Math.Pow(b, 4) * h / 81 - RaTN * Math.Pow(l, 3) / 6 - b * h * Math.Pow(l - a2trn[i] + 2 * b / 3, 3) / 12;
                        C3 = C3 / l;
                        C6 = -RaTN * Math.Pow(l, 3) / 6 - b * h * Math.Pow(l - a2trn[i] + 2 * b / 3, 3) / 12 - C3 * l;
                        C2 = C3 + Math.Pow(b, 3) * h / 9 - Math.Pow(a2trn[i], 4) * A - Math.Pow(a2trn[i], 3) * B - Math.Pow(a2trn[i], 2) * CC - a2trn[i] * DD;
                        C1 = C2 + Math.Pow(a1trn[i], 4) * A + Math.Pow(a1trn[i], 3) * B + Math.Pow(a1trn[i], 2) * CC + a1trn[i] * DD;
                        C5 = C1 * a1trn[i] - C2 * a1trn[i] - Math.Pow(a1trn[i], 5) * A / 5 - Math.Pow(a1trn[i], 4) * B / 4 - Math.Pow(a1trn[i], 3) * CC / 3 - Math.Pow(a1trn[i], 2) * DD / 2;

                        double RaCC, bR, C22 = 0, C33, C66;

                        bR = a2trn[i] - a1trn[i];
                        RaCC = (-bR * m * (lcon - a2trn[i]) * (l - a2trn[i] + 0.5 * bR)) / (l);
                        C33 = (-bR * h * Math.Pow(l - a2trn[i] + 0.5 * bR, 3)) / (6 * l) - RaCC * Math.Pow(l, 2) / 6 + Math.Pow(bR, 3) * h * a2trn[i] / (24 * l) - Math.Pow(bR, 4) * h / (48 * l);
                        C22 = C3 - ((h * Math.Pow(bR, 3)) / 24);
                        C66 = -C3 * l - (bR * h * Math.Pow(l - a2trn[i] + 0.5 * bR, 3) / 6) - RaCC * Math.Pow(l, 3) / 6;

                        if (lcon < a1trn[i] && lcon <= a2trn[i])
                        {
                            vTRN1 += RaTN * Math.Pow(lcon, 3) / 6 + C1 * lcon + RaCC* Math.Pow(lcon, 3) / 6 + C22 * lcon;
                        }
                        else if (lcon >= a1trn[i] && lcon <= a2trn[i])
                        {
                            vTRN += RaTN * Math.Pow(lcon, 3) / 6 + A * Math.Pow(lcon, 5) / 5 + B * Math.Pow(lcon, 4) / 4 + CC * Math.Pow(lcon, 3) / 3 + DD * Math.Pow(lcon, 2) / 2 + C2 * lcon + C5  + RaCC * Math.Pow(lcon, 3) / 6 + m * (lcon - a2trn[i]) * Math.Pow(lcon - a1trn[i], 4) / 24 + C22 * lcon;
                        }
                        else if (lcon >= a1trn[i] && lcon >= a2trn[i])
                        {
                            vTRN2 += RaTN * Math.Pow(lcon, 3) / 6 + b * h * Math.Pow(lcon - a2trn[i] + 2 * b / 3, 3) / 12 + C3 * lcon + C6  +  RaCC* Math.Pow(lcon, 3) / 6 + bR * m * (lcon - a2trn[i]) * Math.Pow(lcon - a2trn[i] + 0.5 * bR, 3) / 6 + C33 * lcon + C66;
                        }
                    }

                    //momento
                    for (int i = 0; i < MgM.Count; i++)
                    {
                        if (cxM[i] > lcon)
                        {
                            double A,B;
                            A = MgM[i] * lcon;
                            B = Math.Pow(lcon, 2) + 2 * Math.Pow(l, 2) + 3 * Math.Pow(cxM[i], 2) - 6 * cxM[i] * l;
                    
                            vM += (A * B)/(6*l);
                        }
                        else if (cxCC[i] < lcon)
                        {
                            double C2,C4;
                            C2 = MgM[i] * l / 2 - MgM[i] * l / 6 + MgM[i] * Math.Pow(cxM[i], 2) / l;
                            C4 = MgM[i] * Math.Pow(l, 2) / 2 - MgM[i] * Math.Pow(l, 2) - C2 * l;

                            vM1 += (MgM[i]*Math.Pow(lcon,3))/(6*l) - MgM[i]*Math.Pow(l,2)/2 + C2*lcon + C4;
                        }
                    }

                    //reacción Rb
                    double sumav;
                    sumav = vCC + vCC1 - vCR - vCR1 - vCR2 - vTP - vTP1 - vTP2 - vTRP - vTRP1 - vTRP2 - vTN - vTN1 - vTN2 - vTRN - vTRN1 - vTRN2 - vM - vM1;
                    Rb =  sumav / C;





                    //rb en la barra de estados



                    pyc6.Visible = true;
                        Rbst.Visible = true;
                        Rbst.Text = "Rb = " + Math.Round(Rb,3).ToString();
                        Rbst.ToolTipText = "Rb : " + Rb.ToString() + "\r" + "Coordenada x: " + lcon.ToString();
                    
                

                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        SumaMomentos +=
                         MgCC[i] * cxCC[i] + f1c[i] * (a2c[i] - a1c[i]) * (((a2c[i] - a1c[i]) / 2) + a1c[i]) + MgM[i]
                                      + f1tp[i] * (a2tp[i] - a1tp[i]) / 2 * (a1tp[i] + 2 * (a2tp[i] - a1tp[i]) / 3)
                                      + f1tn[i] * (a2tn[i] - a1tn[i]) / 2 * (a1tn[i] + (a2tn[i] - a1tn[i]) / 3)
                         + ((f1trp[i] * (a2trp[i] - a1trp[i]) * (a1trp[i] + ((a2trp[i] - a1trp[i]) / 2))) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2) * (a1trp[i] + (2 * (a2trp[i] - a1trp[i]) / 3))))
                         + ((f2trn[i] * (a2trn[i] - a1trn[i]) * (a1trn[i] + ((a2trn[i] - a1trn[i]) / 2))) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2) * (a1trn[i] + (1 * (a2trn[i] - a1trn[i]) / 3))));
                    }
                    Rc = (-SumaMomentos - Rb*lcon) / l;
                    SumaMomentos = 0;

                    //rc en la barra de estados
                   
                       

                        pyc7.Visible = true;
                        Rcst.Visible = true;
                        Rcst.Text = "Rc = " + Math.Round(Rc,3).ToString();
                        Rcst.ToolTipText = "Rc : " + Rc.ToString() + "\r" + "Coordenada x: " + l.ToString();
                    
               

                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    { SumaFuerzas += ((MgCC[i]) + (f1c[i] * (a2c[i] - a1c[i])) + (f1tp[i] * ((a2tp[i] - a1tp[i]) / 2)) + (f1tn[i] * ((a2tn[i] - a1tn[i]) / 2)) + (f1trp[i] * (a2trp[i] - a1trp[i])) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2)) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2)) + (f2trn[i] * (a2trn[i] - a1trn[i]))); }
                    Ra = -(SumaFuerzas + Rb + Rc);
                    SumaFuerzas = 0;

                    //ra en barra de estados
                    if (Mtst.Visible == false )
                    {
                        pyc2.Visible = false;
                        pyc3.Visible = false;
                        pyc4.Visible = false;
                        pyc9.Visible = true;
                    
                      
                        pyc8.Visible = false;
                     
                        Rast.Visible = false;
                       
                        MRst.Visible = false;
                        Mbst.Visible = false;
                        lconst.Visible = true;
                        Mast.Visible = false;
                        pyc10.Visible = false;
                        ltvst.Visible = false;
                        pyc.Visible = false;

                        pyc5.Visible = false;
                        Rast.Visible = true;
                        Rast.Text = "Ra = " + Math.Round(Ra,3).ToString();
                        Rast.ToolTipText = "Ra : " + Ra.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    else
                    {
                        pyc2.Visible = false;
                        pyc3.Visible = false;
                        pyc4.Visible = false;
                        pyc9.Visible = true;


                        pyc8.Visible = false;

                        Rast.Visible = false;
                 
                        MRst.Visible = false;
                        Mbst.Visible = false;
                        lconst.Visible = true;
                        Mast.Visible = false;
                        pyc10.Visible = false;
                        ltvst.Visible = false;
                        pyc.Visible = false;

                        pyc5.Visible = true;
                        Rast.Visible = true;
                        Rast.Text = "Ra = " + Math.Round(Ra, 3).ToString();
                        Rast.ToolTipText = "Ra : " + Ra.ToString() + "\r" + "Coordenada x: " + "0";


                    }

                    //hacer el vector y(cortante) 
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgCte[i] += MgCC[j] * Fn.FsingCP(cxCC[j], xlabel[i]) //cargas puntuales
                            + f1c[j] * Fn.FSingMCP(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCP(a2c[j], xlabel[i]) //carga rectangular
                            + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) // triangulo pendiente positiva
                            + (f1tn[j]) * Fn.FSingMCP(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], xlabel[i]) //triandulo pendiente negativa
                            + f1trp[j] * Fn.FSingMCP(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCP(a2trp[j], xlabel[i]) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], xlabel[i]) //trapecio pendiente positiva
                            + f2trn[j] * Fn.FSingMCP(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCP(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], xlabel[i]); //trapecio pendiente negativa

                        }


                        yDgCte[i] = yDgCte[i] + Ra * Fn.FsingCP(0, xlabel[i]) + Rc * Fn.FsingCP(l, xlabel[i]) + Rb*Fn.FsingCP(lcon,xlabel[i]);

                        yDgCte[i] = Math.Round(yDgCte[i], 4);
                    }


                    // hacer el vector y (Momento) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgMto[i] += MgCC[j] * Fn.FSingMCP(cxCC[j], xlabel[i]) +
                            +f1c[j] * Fn.FSingMCDR(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCDR(a2c[j], xlabel[i]) + //
                            +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                            +f1tn[j] * Fn.FSingMCDR(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], xlabel[i]) +
                            +f1trp[j] * Fn.FSingMCDR(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCDR(a2trp[j], xlabel[i]) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], xlabel[i]) +
                            +f2trn[j] * Fn.FSingMCDR(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCDR(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], xlabel[i]) +
                            -MgM[j] * Fn.FsingCP(cxM[j], xlabel[i]);


                        }
                        yDgMto[i] = yDgMto[i] + Ra * Fn.FSingMCP(0, xlabel[i]) + Rc * Fn.FSingMCP(l, xlabel[i]) + Rb*Fn.FSingMCP(lcon,xlabel[i]);
                        yDgMto[i] = Math.Round(yDgMto[i], 4);
                    }


                    //elemento del yvalue mayor y menor
                    yDgCtemay = yDgCte[0];
                    yDgCtemen = yDgCte[0];
                    yDgCtemayABS = Math.Abs(yDgCte[0]);
                    yDgCtemenABS = Math.Abs(yDgCte[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgCte[i]) > yDgCtemayABS)
                        {
                            yDgCtemayABS = Math.Abs(yDgCte[i]);
                            xdelyCtemayorABS = i;
                        }
                        else if (Math.Abs(yDgCte[i]) < yDgCtemenABS) { yDgCtemenABS = Math.Abs(yDgCte[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgCte[i] > yDgCtemay)
                        {
                            yDgCtemay = yDgCte[i];


                        }
                        else if (yDgCte[i] < yDgCtemen) { yDgCtemen = yDgCte[i]; }
                    }



                    //elemento mayor y menor de momento
                    yDgMtomay = yDgMto[0];
                    yDgMtomen = yDgMto[0];
                    yDgMtomayABS = Math.Abs(yDgMto[0]);
                    yDgMtomenABS = Math.Abs(yDgMto[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgMto[i] > yDgMtomay)
                        {
                            yDgMtomay = yDgMto[i];
                        }
                        else if (yDgMto[i] < yDgMtomen) { yDgMtomen = yDgMto[i]; }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgMto[i]) > yDgMtomayABS)
                        {
                            yDgMtomayABS = Math.Abs(yDgMto[i]);
                            xdelyMtomayorABS = i;

                        }
                        else if (Math.Abs(yDgMto[i]) < yDgMtomenABS) { yDgMtomenABS = Math.Abs(yDgMto[i]); }
                    }










                }

                //resolver reacciones y diagramas de viga empotradad en un extremo y simplemente apoyada en el otro
                else if (indTipApoy == 4)
                {
                    double C1, C2;
                    //hallar momento a
                    C1 = -fsin3(0);
                    C2 = -fsin4(0);
                    double x = fsin4(l);
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        SumaMomentos +=
                         MgCC[i] * cxCC[i] + f1c[i] * (a2c[i] - a1c[i]) * (((a2c[i] - a1c[i]) / 2) + a1c[i]) + MgM[i]
                                      + f1tp[i] * (a2tp[i] - a1tp[i]) / 2 * (a1tp[i] + 2 * (a2tp[i] - a1tp[i]) / 3)
                                      + f1tn[i] * (a2tn[i] - a1tn[i]) / 2 * (a1tn[i] + (a2tn[i] - a1tn[i]) / 3)
                         + ((f1trp[i] * (a2trp[i] - a1trp[i]) * (a1trp[i] + ((a2trp[i] - a1trp[i]) / 2))) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2) * (a1trp[i] + (2 * (a2trp[i] - a1trp[i]) / 3))))
                         + ((f2trn[i] * (a2trn[i] - a1trn[i]) * (a1trn[i] + ((a2trn[i] - a1trn[i]) / 2))) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2) * (a1trn[i] + (1 * (a2trn[i] - a1trn[i]) / 3))));
                    }

                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        SumaFuerzas += ((MgCC[i]) + (f1c[i] * (a2c[i] - a1c[i])) + (f1tp[i] * ((a2tp[i] - a1tp[i]) / 2)) + (f1tn[i] * ((a2tn[i] - a1tn[i]) / 2)) + (f1trp[i] * (a2trp[i] - a1trp[i])) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2)) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2)) + (f2trn[i] * (a2trn[i] - a1trn[i])));
                    }
                    Ma = -SumaMomentos / 2 + SumaFuerzas * l / 2 - (3 * fsin4(l)) / (Math.Pow(l, 2)) - (3 * C1) / (l) - (3 * C2) / (Math.Pow(l, 2));
                    Rb = -SumaMomentos / l + Ma / l;
                    Ra = -Rb - SumaFuerzas;
                        SumaFuerzas = 0;
                        SumaMomentos = 0;
                    // ma en barra de estados
                    Ma = -Ma;

                        pyc10.Visible = true;
                        Mast.Visible = true;
                        Mast.Text = "Ma = " + Ma.ToString("0.000");
                        Mast.ToolTipText = "Ma : " + Ma.ToString() + "\r" + "Coordenada x: " + "0";




                
                    // ra en barra de estados;
                    if (Mtst.Visible == false)
                    {
                        pyc5.Visible = false;
                        Rast.Visible = true;
                        Rast.Text = "Ra = " + Ra.ToString("0.000");
                        Rast.ToolTipText = "Ra : " + Ra.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    else
                    {
                        pyc5.Visible = true;
                        Rast.Visible = true;
                        Rast.Text = "Ra = " + Ra.ToString("0.000");
                        Rast.ToolTipText = "Ra : " + Ra.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                  
                    // rb en barra de estado
                    Rbst.Visible = true;
                    pyc6.Visible = true;
                    Rbst.Text = "Rb = " + Rb.ToString("0.000");
                    Rbst.ToolTipText = "Rb : " + Rb.ToString() + "\r" + "Coordenada x: " + l.ToString();

                    pyc.Visible = false;
                    pyc2.Visible = false;
                    pyc3.Visible = false;
                    pyc4.Visible = false;
                 
                    pyc7.Visible = false;
                    pyc8.Visible = false;
                    pyc9.Visible = false;
                    MRst.Visible = false;
                    Mbst.Visible = false;
                    lconst.Visible = false;
                  
                   








                   

                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgCte[i] += MgCC[j] * Fn.FsingCP(cxCC[j], xlabel[i]) //cargas puntuales
                            + f1c[j] * Fn.FSingMCP(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCP(a2c[j], xlabel[i]) //carga rectangular
                            + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) // triangulo pendiente positiva
                            + (f1tn[j]) * Fn.FSingMCP(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], xlabel[i]) //triandulo pendiente negativa
                            + f1trp[j] * Fn.FSingMCP(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCP(a2trp[j], xlabel[i]) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], xlabel[i]) //trapecio pendiente positiva
                            + f2trn[j] * Fn.FSingMCP(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCP(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], xlabel[i]); //trapecio pendiente negativa

                        }


                        yDgCte[i] = yDgCte[i] + Ra * Fn.FsingCP(0, xlabel[i]) + Rb * Fn.FsingCP(l, xlabel[i]);

                        yDgCte[i] = Math.Round(yDgCte[i], 4);
                    }

                 
                    // hacer el vector y (Momento) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgMto[i] += MgCC[j] * Fn.FSingMCP(cxCC[j], xlabel[i]) +
                            +f1c[j] * Fn.FSingMCDR(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCDR(a2c[j], xlabel[i]) + //
                            +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                            +f1tn[j] * Fn.FSingMCDR(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], xlabel[i]) +
                            +f1trp[j] * Fn.FSingMCDR(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCDR(a2trp[j], xlabel[i]) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], xlabel[i]) +
                            +f2trn[j] * Fn.FSingMCDR(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCDR(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], xlabel[i]) +
                            -MgM[j] * Fn.FsingCP(cxM[j], xlabel[i]);


                        }
                        yDgMto[i] = yDgMto[i] + Ra * Fn.FSingMCP(0, xlabel[i]) - Ma*Fn.FsingCP(0, xlabel[i]) + Rb * Fn.FSingMCP(l, xlabel[i]);
                        yDgMto[i] = Math.Round(yDgMto[i], 4);
                    }


                    //elemento del yvalue mayor y menor
                    yDgCtemay = yDgCte[0];
                    yDgCtemen = yDgCte[0];
                    yDgCtemayABS = Math.Abs(yDgCte[0]);
                    yDgCtemenABS = Math.Abs(yDgCte[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgCte[i]) > yDgCtemayABS)
                        {
                            yDgCtemayABS = Math.Abs(yDgCte[i]);
                            xdelyCtemayorABS = i;
                        }
                        else if (Math.Abs(yDgCte[i]) < yDgCtemenABS) { yDgCtemenABS = Math.Abs(yDgCte[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgCte[i] > yDgCtemay)
                        {
                            yDgCtemay = yDgCte[i];


                        }
                        else if (yDgCte[i] < yDgCtemen) { yDgCtemen = yDgCte[i]; }
                    }



                    //elemento mayor y menor de momento
                    yDgMtomay = yDgMto[0];
                    yDgMtomen = yDgMto[0];
                    yDgMtomayABS = Math.Abs(yDgMto[0]);
                    yDgMtomenABS = Math.Abs(yDgMto[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgMto[i] > yDgMtomay)
                        {
                            yDgMtomay = yDgMto[i];
                        }
                        else if (yDgMto[i] < yDgMtomen) { yDgMtomen = yDgMto[i]; }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgMto[i]) > yDgMtomayABS)
                        {
                            yDgMtomayABS = Math.Abs(yDgMto[i]);
                            xdelyMtomayorABS = i;

                        }
                        else if (Math.Abs(yDgMto[i]) < yDgMtomenABS) { yDgMtomenABS = Math.Abs(yDgMto[i]); }
                    }




                }

                //resolver reacciones y diagramas par aviga doblemente empotrada
                else if (indTipApoy == 5)
                {
                    double C1, C2,Maaux;
                    //hallar momento a
                    C1 = -fsin3(0);
                    C2 = -fsin4(0);

                    Ma = -(4 * C1 / l) - (6 * C2) / (Math.Pow(l, 2)) - (6 * fsin4(l)) / (Math.Pow(l, 2)) + 2 * fsin3(l) / l;
                    Maaux = -Ma;
                    //mostrar ma en barra de estados
                    Mast.Visible = true;
                    pyc10.Visible = true;
                    Mast.Text = "Ma = " + Maaux.ToString("0.000");
                    Mast.ToolTipText = "Ma : " + Maaux.ToString() + "\r" + "Coordenada x: " + "0";

                    Ra = -2 * Ma / l - 2 * C1 / Math.Pow(l, 2) - 2 * fsin3(l) / Math.Pow(l, 2);

                    //mostra ra en barra de estados
                    if (Mtst.Visible == false )
                    {
                        pyc5.Visible = false;
                        Rast.Visible = true;
                        Rast.Text = "Ra = " + Ra.ToString("0.000");
                        Rast.ToolTipText = "Ra : " + Ra.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    else
                    {
                        pyc5.Visible = true;
                        Rast.Visible = true;
                        Rast.Text = "Ra = " + Ra.ToString("0.000");
                        Rast.ToolTipText = "Ra : " + Ra.ToString() + "\r" + "Coordenada x: " + "0";
                    }
                    //hallar reacción Ra VIGA doblmente empotrada
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    { SumaFuerzas += ((MgCC[i]) + (f1c[i] * (a2c[i] - a1c[i])) + (f1tp[i] * ((a2tp[i] - a1tp[i]) / 2)) + (f1tn[i] * ((a2tn[i] - a1tn[i]) / 2)) + (f1trp[i] * (a2trp[i] - a1trp[i])) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2)) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2)) + (f2trn[i] * (a2trn[i] - a1trn[i]))); }
                    Rb = -(SumaFuerzas + Ra);
                    SumaFuerzas = 0;

                    //mostra rb en barra de estados
                    Rbst.Visible = true;
                    pyc6.Visible = true;
                    Rbst.Text = "Rb = " + Rb.ToString("0.000");
                    Rbst.ToolTipText = "Rb : " + Rb.ToString() + "\r" + "Coordenada x: " + l.ToString();

                    // hallar Mb VIGA doblemente empotrada
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        SumaMomentos +=
                         MgCC[i] * cxCC[i] + f1c[i] * (a2c[i] - a1c[i]) * (((a2c[i] - a1c[i]) / 2) + a1c[i]) + MgM[i]
                                      + f1tp[i] * (a2tp[i] - a1tp[i]) / 2 * (a1tp[i] + 2 * (a2tp[i] - a1tp[i]) / 3)
                                      + f1tn[i] * (a2tn[i] - a1tn[i]) / 2 * (a1tn[i] + (a2tn[i] - a1tn[i]) / 3)
                         + ((f1trp[i] * (a2trp[i] - a1trp[i]) * (a1trp[i] + ((a2trp[i] - a1trp[i]) / 2))) + ((a2trp[i] - a1trp[i]) * ((f2trp[i] - f1trp[i]) / 2) * (a1trp[i] + (2 * (a2trp[i] - a1trp[i]) / 3))))
                         + ((f2trn[i] * (a2trn[i] - a1trn[i]) * (a1trn[i] + ((a2trn[i] - a1trn[i]) / 2))) + ((a2trn[i] - a1trn[i]) * ((f1trn[i] - f2trn[i]) / 2) * (a1trn[i] + (1 * (a2trn[i] - a1trn[i]) / 3))));
                    }
                    Mb = -SumaMomentos + Ma - Rb*l;
                    SumaMomentos = 0;

                    //mostrar mb en barra de estados
                    Mbst.Visible = true;
                    pyc8.Visible = true;
                    Mbst.Text = "Mb = " + Mb.ToString("0.000");
                    Mbst.ToolTipText = "Mb : " + Mb.ToString() + "\r" + "Coordenada x: " + l.ToString();

                    pyc.Visible = false;
                    ltvst.Visible = false;
                    lconst.Visible = false;
                    Rcst.Visible = false;
                    R1st.Visible = false;
                    R2st.Visible = false;
                    MRst.Visible = false;
                    pyc2.Visible = false;
                    pyc3.Visible = false;
                    pyc4.Visible = false;
                    pyc7.Visible = false;
                    pyc9.Visible = false;
                  

                    //hacer el vector y(cortante) 
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgCte[i] += MgCC[j] * Fn.FsingCP(cxCC[j], xlabel[i]) //cargas puntuales
                            + f1c[j] * Fn.FSingMCP(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCP(a2c[j], xlabel[i]) //carga rectangular
                            + (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDR(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCP(a2tp[j], xlabel[i]) // triangulo pendiente positiva
                            + (f1tn[j]) * Fn.FSingMCP(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDR(a2tn[j], xlabel[i]) //triandulo pendiente negativa
                            + f1trp[j] * Fn.FSingMCP(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCP(a2trp[j], xlabel[i]) + ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDR(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCP(a2trp[j], xlabel[i]) //trapecio pendiente positiva
                            + f2trn[j] * Fn.FSingMCP(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCP(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCP(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDR(a2trn[j], xlabel[i]); //trapecio pendiente negativa

                        }


                        yDgCte[i] = yDgCte[i] + Ra * Fn.FsingCP(0, xlabel[i]) + Rb * Fn.FsingCP(l, xlabel[i]);

                        yDgCte[i] = Math.Round(yDgCte[i], 4);
                    }


                    // hacer el vector y (Momento) CARGA PUNTUAL
                    for (int i = 0; i <= 1000; i++)
                    {
                        for (int j = 0; j < dtgFyM.Rows.Count; j++)
                        {
                            yDgMto[i] += MgCC[j] * Fn.FSingMCP(cxCC[j], xlabel[i]) +
                            +f1c[j] * Fn.FSingMCDR(a1c[j], xlabel[i]) - f1c[j] * Fn.FSingMCDR(a2c[j], xlabel[i]) + //
                            +(f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a1tp[j], xlabel[i]) - (f1tp[j] / (a2tp[j] - a1tp[j])) * Fn.FSingMCDTPP(a2tp[j], xlabel[i]) - f1tp[j] * Fn.FSingMCDR(a2tp[j], xlabel[i]) +
                            +f1tn[j] * Fn.FSingMCDR(a1tn[j], xlabel[i]) - (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a1tn[j], xlabel[i]) + (f1tn[j] / (a2tn[j] - a1tn[j])) * Fn.FSingMCDTPP(a2tn[j], xlabel[i]) +
                            +f1trp[j] * Fn.FSingMCDR(a1trp[j], xlabel[i]) - f1trp[j] * Fn.FSingMCDR(a2trp[j], xlabel[i]) + (f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j]) * Fn.FSingMCDTPP(a1trp[j], xlabel[i]) - ((f2trp[j] - f1trp[j]) / (a2trp[j] - a1trp[j])) * Fn.FSingMCDTPP(a2trp[j], xlabel[i]) - (f2trp[j] - f1trp[j]) * Fn.FSingMCDR(a2trp[j], xlabel[i]) +
                            +f2trn[j] * Fn.FSingMCDR(a1trn[j], xlabel[i]) - f2trn[j] * Fn.FSingMCDR(a2trn[j], xlabel[i]) + (f1trn[j] - f2trn[j]) * Fn.FSingMCDR(a1trn[j], xlabel[i]) - ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a1trn[j], xlabel[i]) + ((f1trn[j] - f2trn[j]) / (a2trn[j] - a1trn[j])) * Fn.FSingMCDTPP(a2trn[j], xlabel[i]) +
                            -MgM[j] * Fn.FsingCP(cxM[j], xlabel[i]);


                        }
                        yDgMto[i] = yDgMto[i] + Ra * Fn.FSingMCP(0, xlabel[i]) + Rb * Fn.FSingMCP(l, xlabel[i]) + Ma*Fn.FsingCP(0,xlabel[i]) - Mb*Fn.FsingCP(l,xlabel[i]);
                        yDgMto[i] = Math.Round(yDgMto[i], 4);
                    }

                    //elemento del yvalue mayor y menor
                    yDgCtemay = yDgCte[0];
                    yDgCtemen = yDgCte[0];
                    yDgCtemayABS = Math.Abs(yDgCte[0]);
                    yDgCtemenABS = Math.Abs(yDgCte[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgCte[i]) > yDgCtemayABS)
                        {
                            yDgCtemayABS = Math.Abs(yDgCte[i]);
                            xdelyCtemayorABS = i;
                        }
                        else if (Math.Abs(yDgCte[i]) < yDgCtemenABS) { yDgCtemenABS = Math.Abs(yDgCte[i]); }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgCte[i] > yDgCtemay)
                        {
                            yDgCtemay = yDgCte[i];


                        }
                        else if (yDgCte[i] < yDgCtemen) { yDgCtemen = yDgCte[i]; }
                    }



                    //elemento mayor y menor de momento
                    yDgMtomay = yDgMto[0];
                    yDgMtomen = yDgMto[0];
                    yDgMtomayABS = Math.Abs(yDgMto[0]);
                    yDgMtomenABS = Math.Abs(yDgMto[0]);
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (yDgMto[i] > yDgMtomay)
                        {
                            yDgMtomay = yDgMto[i];
                        }
                        else if (yDgMto[i] < yDgMtomen) { yDgMtomen = yDgMto[i]; }
                    }
                    for (int i = 0; i <= 1000; i++)
                    {
                        if (Math.Abs(yDgMto[i]) > yDgMtomayABS)
                        {
                            yDgMtomayABS = Math.Abs(yDgMto[i]);
                            xdelyMtomayorABS = i;

                        }
                        else if (Math.Abs(yDgMto[i]) < yDgMtomenABS) { yDgMtomenABS = Math.Abs(yDgMto[i]); }
                    }






                   
                }

                //eliminar pestaña de diagramas
                if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
                }
                //eliminar pestaña de pendiente y delfexión
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
                }
                //Habilitar grafico de diagrama cortante
                TabCtrlPanelPrincipal.Controls.Add(tabDiag);
                // dibujar Diagrama Cortante
                chartV.Series.Clear();
                chartV.Series.Add("Diagrama Cortante"); //[0]
                chartV.Series.Add("Linea 0"); //[1]
                chartV.Series.Add("Linea abrir diagrama cortante"); //[2]
                chartV.Series.Add("Linea Cerrar diagrama cortante"); //[3]
                chartV.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartV.Series[0].Color = Color.Blue;
                chartV.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chartV.Series[1].Color = Color.Red;
                chartV.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartV.Series[2].Color = Color.Blue;
                chartV.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartV.Series[3].Color = Color.Blue;
                if (unidades == 0)
                {
                    chartV.ChartAreas[0].AxisX.Title = "x [m]";
                    chartV.ChartAreas[0].AxisY.Title = "V [kN]";
                }
                else if (unidades == 1)
                {
                    chartV.ChartAreas[0].AxisX.Title = "x [ft]";
                    chartV.ChartAreas[0].AxisY.Title = "V [kip]";
                }
              
                chartV.ChartAreas[0].AxisX.Minimum = 0 - 0.05 * l;
                chartV.ChartAreas[0].AxisX.Maximum = l + 0.05 * l;
                chartV.ChartAreas[0].AxisY.Minimum = yDgCtemen - Math.Abs(yDgCtemen) * 0.15;
                chartV.ChartAreas[0].AxisY.Maximum = yDgCtemay + Math.Abs(yDgCtemay) * 0.15;
                chartV.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
                chartV.ChartAreas[0].AxisY.LabelStyle.Format = "{0.0}";
                chartV.Series[0].BorderWidth = 2;
                chartV.Series[1].BorderWidth = 2;
                chartV.Series[2].BorderWidth = 2;
                chartV.Series[3].BorderWidth = 2;
                chartV.Legends.Clear();

                //asignarle un valor a ns para organizar series
                ns = 3;
                //label ys en x=0 

                System.Windows.Forms.DataVisualization.Charting.CustomLabel Yx0 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                Yx0.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel Xltv = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                Xltv.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel Yltv = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                Yltv.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel Xlcon = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                Xlcon.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel Ylcon = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                Ylcon.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel X0 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                X0.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel Xl = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                Xl.ForeColor = System.Drawing.Color.Black;

                if (indTipApoy == 0)
                {
                    Yx0.FromPosition = YxSA(0) - YxSA(0) * 0.1;
                    Yx0.ToPosition = YxSA(0) + YxSA(0) * 0.1;
                    Yx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yx0.Text = YxSA(0).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yx0);

                    X0.FromPosition = 0 - 0.1 * l;
                    X0.ToPosition = 0 + 0.1 * l;
                    X0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    X0.Text = "0";
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(X0);

                    Xl.FromPosition = l - l * 0.1;
                    Xl.ToPosition = l + l * 0.1;
                    Xl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xl.Text = l.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xl);

                    //labels para el eje x de diagrama cortante
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                        {
                            x1igualx2++;

                            xaux.Insert(x1igualx2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            yaux.Insert(x1igualx2 - 1, YxSA(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            yauxM.Insert(x1igualx2 - 1, YMxSA(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));

                        }
                        else
                        {
                            x1diferentex2++;
                            x1.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            x2.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()));
                            y1.Insert(x1diferentex2 - 1, YxSA(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2.Insert(x1diferentex2 - 1, YxSA(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));
                            y1M.Insert(x1diferentex2 - 1, YMxSA(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2M.Insert(x1diferentex2 - 1, YMxSA(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));

                        }
                    }
                }

                else if (indTipApoy == 1)
                {
                    Yx0.FromPosition = YxTV(0) - YxTV(0) * 0.1;
                    Yx0.ToPosition = YxTV(0) + YxTV(0) * 0.1;
                    Yx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yx0.Text = YxTV(0).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yx0);

                    X0.FromPosition = 0 - 0.1 * l;
                    X0.ToPosition = 0 + 0.1 * l;
                    X0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    X0.Text = "0";
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(X0);

                    Xl.FromPosition = l - l * 0.1;
                    Xl.ToPosition = l + l * 0.1;
                    Xl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xl.Text = l.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xl);

                    Xltv.FromPosition = ltv - ltv * 0.1;
                    Xltv.ToPosition = ltv + ltv * 0.1;
                    Xltv.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xltv.Text = ltv.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xltv);


                    Yltv.FromPosition = YxTV(ltv) - YxTV(ltv) * 0.1;
                    Yltv.ToPosition = YxTV(ltv) + YxTV(ltv) * 0.1;
                    Yltv.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yltv.Text = YxTV(ltv).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yltv);

                    //labels para el eje x de diagrama cortante
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                        {
                            x1igualx2++;

                            xaux.Insert(x1igualx2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            yaux.Insert(x1igualx2 - 1, YxTV(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            yauxM.Insert(x1igualx2 - 1, YMxTV(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));

                        }
                        else
                        {
                            x1diferentex2++;
                            x1.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            x2.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()));
                            y1.Insert(x1diferentex2 - 1, YxTV(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2.Insert(x1diferentex2 - 1, YxTV(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));
                            y1M.Insert(x1diferentex2 - 1, YMxTV(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2M.Insert(x1diferentex2 - 1, YMxTV(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));

                        }
                    }
                }

                else if (indTipApoy == 2)
                {
                    Yx0.FromPosition = YxEI(0) - YxEI(0) * 0.01 * l;
                    Yx0.ToPosition = YxEI(0) + YxEI(0) * 0.01 * l;
                    Yx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yx0.Text = YxEI(0).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yx0);

                    X0.FromPosition = 0 - 0.1 * l;
                    X0.ToPosition = 0 + 0.1 * l;
                    X0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    X0.Text = "0";
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(X0);

                    Xl.FromPosition = l - l * 0.1;
                    Xl.ToPosition = l + l * 0.1;
                    Xl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xl.Text = l.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xl);

                    //labels para el eje x de diagrama cortante
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                        {
                            x1igualx2++;

                            xaux.Insert(x1igualx2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            yaux.Insert(x1igualx2 - 1, YxEI(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            yauxM.Insert(x1igualx2 - 1, YMxEI(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));

                        }
                        else
                        {
                            x1diferentex2++;
                            x1.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            x2.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()));
                            y1.Insert(x1diferentex2 - 1, YxEI(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2.Insert(x1diferentex2 - 1, YxEI(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));
                            y1M.Insert(x1diferentex2 - 1, YMxEI(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2M.Insert(x1diferentex2 - 1, YMxEI(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));

                        }
                    }
                }

                else if (indTipApoy == 3)
                {
                    Yx0.FromPosition = YxC(0) - YxC(0) * 0.01 * l;
                    Yx0.ToPosition = YxC(0) + YxC(0) * 0.01 * l;
                    Yx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yx0.Text = YxC(0).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yx0);

                    X0.FromPosition = 0 - 0.1 * l;
                    X0.ToPosition = 0 + 0.1 * l;
                    X0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    X0.Text = "0";
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(X0);

                    Xl.FromPosition = l - l * 0.1;
                    Xl.ToPosition = l + l * 0.1;
                    Xl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xl.Text = l.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xl);

                    Xlcon.FromPosition = lcon - lcon * 0.1;
                    Xlcon.ToPosition = lcon + lcon * 0.1;
                    Xlcon.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xlcon.Text = lcon.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xlcon);

                    Ylcon.FromPosition = YxC(lcon) - YxC(lcon) * 0.1;
                    Ylcon.ToPosition = YxC(lcon) + YxC(lcon) * 0.1;
                    Ylcon.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Ylcon.Text = YxC(lcon).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Ylcon);

                    //labels para el eje x de diagrama cortante
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                        {
                            x1igualx2++;

                            xaux.Insert(x1igualx2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            yaux.Insert(x1igualx2 - 1, YxC(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            yauxM.Insert(x1igualx2 - 1, YMxC(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));

                        }
                        else
                        {
                            x1diferentex2++;
                            x1.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            x2.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()));
                            y1.Insert(x1diferentex2 - 1, YxC(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2.Insert(x1diferentex2 - 1, YxC(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));
                            y1M.Insert(x1diferentex2 - 1, YMxC(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2M.Insert(x1diferentex2 - 1, YMxC(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));

                        }
                    }
                }

                else if (indTipApoy == 4)
                {
                    Yx0.FromPosition = Yx5(0) - Yx5(0) * 0.1;
                    Yx0.ToPosition = Yx5(0) + Yx5(0) * 0.1;
                    Yx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yx0.Text = Yx5(0).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yx0);

                    X0.FromPosition = 0 - 0.1 * l;
                    X0.ToPosition = 0 + 0.1 * l;
                    X0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    X0.Text = "0";
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(X0);

                    Xl.FromPosition = l - l * 0.1;
                    Xl.ToPosition = l + l * 0.1;
                    Xl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xl.Text = l.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xl);

                    //labels para el eje x de diagrama cortante
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                        {
                            x1igualx2++;

                            xaux.Insert(x1igualx2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            yaux.Insert(x1igualx2 - 1, Yx5(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            yauxM.Insert(x1igualx2 - 1, YMx5(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));

                        }
                        else
                        {
                            x1diferentex2++;
                            x1.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            x2.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()));
                            y1.Insert(x1diferentex2 - 1, Yx5(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2.Insert(x1diferentex2 - 1, Yx5(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));
                            y1M.Insert(x1diferentex2 - 1, YMx5(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2M.Insert(x1diferentex2 - 1, YMx5(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));

                        }
                    }
                }

                else if (indTipApoy == 5)
                {
                    Yx0.FromPosition = Yx6(0) - Yx6(0) * 0.1;
                    Yx0.ToPosition = Yx6(0) + Yx6(0) * 0.1;
                    Yx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Yx0.Text = Yx6(0).ToString();
                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(Yx0);

                    X0.FromPosition = 0 - 0.1 * l;
                    X0.ToPosition = 0 + 0.1 * l;
                    X0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    X0.Text = "0";
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(X0);

                    Xl.FromPosition = l - l * 0.1;
                    Xl.ToPosition = l + l * 0.1;
                    Xl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    Xl.Text = l.ToString();
                    chartV.ChartAreas[0].AxisX.CustomLabels.Add(Xl);

                    //labels para el eje x de diagrama cortante
                    for (int i = 0; i < dtgFyM.Rows.Count; i++)
                    {
                        if (double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                        {
                            x1igualx2++;

                            xaux.Insert(x1igualx2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            yaux.Insert(x1igualx2 - 1, Yx6(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            yauxM.Insert(x1igualx2 - 1, YMx6(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));

                        }
                        else
                        {
                            x1diferentex2++;
                            x1.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()));
                            x2.Insert(x1diferentex2 - 1, double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()));
                            y1.Insert(x1diferentex2 - 1, Yx6(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2.Insert(x1diferentex2 - 1, Yx6(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));
                            y1M.Insert(x1diferentex2 - 1, YMx6(double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString())));
                            y2M.Insert(x1diferentex2 - 1, YMx6(double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString())));

                        }
                    }
                }

                //escoger etiqueta a mostrar del momento mayor
                double xmmac = xlabel[xdelyCtemayorABS]; // x del nuevo momento mayor absoluto
                double ymayor = yDgCte[xdelyCtemayorABS];
                for (int i = 0; i < yaux.Count; i++)
                {
                    if (Math.Abs(yaux[i]) > yDgCtemayABS)
                    {
                        yDgCtemayABS = Math.Abs(yaux[i]);
                        ymayor = yaux[i];
                        xmmac = xaux[i];

                    }
                }
                for (int i = 0; i < y1.Count; i++)
                {
                    if (Math.Abs(y1[i]) > yDgCtemayABS)
                    {
                        yDgCtemayABS = Math.Abs(y1[i]);
                        ymayor = y1[i];
                        xmmac = xaux[i];

                    }
                }
                for (int i = 0; i < y2.Count; i++)
                {
                    if (Math.Abs(y2[i]) > yDgCtemayABS)
                    {
                        yDgCtemayABS = Math.Abs(y2[i]);
                        ymayor = y2[i];
                        xmmac = xaux[i];

                    }
                }

                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsx = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1igualx2];
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsy = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1igualx2];

                for (byte i = 0; i < x1igualx2; i++)
                {
                    labelsx[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                for (byte i = 0; i < x1igualx2; i++)
                {
                    labelsy[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }

                if (x1igualx2 >= 1)
                {
                    if (xaux[0] != 0 && xaux[0] != l && xaux[0] != ltv && xaux[0] != lcon && xaux[0] != xmmac)
                    {
                        labelsx[0].ForeColor = System.Drawing.Color.Black;
                        labelsx[0].FromPosition = xaux[0] - xaux[0] * 0.1;
                        labelsx[0].ToPosition = xaux[0] + xaux[0] * 0.1;
                        labelsx[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsx[0].Text = xaux[0].ToString();
                        chartV.ChartAreas[0].AxisX.CustomLabels.Add(labelsx[0]);

                    }


                    if (yaux[0] != yDgCte[0] && yaux[0] != yDgCtemayABS)
                    {
                        labelsy[0].ForeColor = System.Drawing.Color.Black;
                        labelsy[0].FromPosition = yaux[0] - yaux[0] * 0.1;
                        labelsy[0].ToPosition = yaux[0] + yaux[0] * 0.1;
                        labelsy[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsy[0].Text = yaux[0].ToString();
                        chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy[0]);
                    }
                }





                for (int i = 0; i < x1igualx2; i++)
                {
                    int a1 = 0, a2 = 0;
                    for (int j = 0; j < x1igualx2; j++)
                    {

                        if (x1igualx2 > 1 && i < x1igualx2 - 1)
                        {
                            for (int k = 0; k < x1igualx2; k++)
                            {
                                if (xaux[i + 1] != xaux[k])
                                {
                                    a1++;
                                }
                                if (yaux[i + 1] != yaux[k])
                                {
                                    a2++;
                                }
                            }
                            if (a1 == x1igualx2 - 1 && xaux[i + 1] != l && xaux[i + 1] != ltv && xaux[i + 1] != 0 && xaux[i + 1] != 0 && xaux[i + 1] != xmmac && xaux[i + 1] != lcon)
                            {
                                labelsx[i + 1].ForeColor = System.Drawing.Color.Black;
                                labelsx[i + 1].FromPosition = xaux[i + 1] - xaux[i + 1] * 0.1;
                                labelsx[i + 1].ToPosition = xaux[i + 1] + xaux[i + 1] * 0.1;
                                labelsx[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                labelsx[i + 1].Text = xaux[i + 1].ToString();
                                chartV.ChartAreas[0].AxisX.CustomLabels.Add(labelsx[i + 1]);
                            }

                            if (indTipApoy == 0)
                            {
                                if (a2 == x1igualx2 - 1 && yaux[i + 1] != YxSA(l) && yaux[i + 1] != yDgCte[0] && yaux[i + 1] != yDgCtemayABS)
                                {
                                    labelsy[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy[i + 1].FromPosition = yaux[i + 1] - yaux[i + 1] * 0.1;
                                    labelsy[i + 1].ToPosition = yaux[i + 1] + yaux[i + 1] * 0.1;
                                    labelsy[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy[i + 1].Text = yaux[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy[i + 1]);
                                }
                            }
                            else if (indTipApoy == 1)
                            {
                                if (a2 == x1igualx2 - 1 && yaux[i + 1] != YxTV(l) && yaux[i + 1] != yDgCte[0] && yaux[i + 1] != YxTV(ltv) && yaux[i + 1] != yDgCtemayABS)
                                {
                                    labelsy[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy[i + 1].FromPosition = yaux[i + 1] - yaux[i + 1] * 0.1;
                                    labelsy[i + 1].ToPosition = yaux[i + 1] + yaux[i + 1] * 0.1;
                                    labelsy[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy[i + 1].Text = yaux[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy[i + 1]);
                                }
                            }
                            else if (indTipApoy == 2)
                            {
                                if (a2 == x1igualx2 - 1 && yaux[i + 1] != YxEI(l) && yaux[i + 1] != yDgCte[0] && yaux[i + 1] != yDgCtemayABS)
                                {
                                    labelsy[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy[i + 1].FromPosition = yaux[i + 1] - yaux[i + 1] * 0.1;
                                    labelsy[i + 1].ToPosition = yaux[i + 1] + yaux[i + 1] * 0.1;
                                    labelsy[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy[i + 1].Text = yaux[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy[i + 1]);
                                }
                            }
                            else if (indTipApoy == 3)
                            {
                                if (a2 == x1igualx2 - 1 && yaux[i + 1] != YxC(l) && yaux[i + 1] != yDgCte[0] && yaux[i + 1] != yDgCtemayABS)
                                {
                                    labelsy[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy[i + 1].FromPosition = yaux[i + 1] - yaux[i + 1] * 0.1;
                                    labelsy[i + 1].ToPosition = yaux[i + 1] + yaux[i + 1] * 0.1;
                                    labelsy[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy[i + 1].Text = yaux[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy[i + 1]);
                                }
                            }
                            else if (indTipApoy == 4)
                            {
                                if (a2 == x1igualx2 - 1 && yaux[i + 1] != Yx5(l) && yaux[i + 1] != yDgCte[0] && yaux[i + 1] != yDgCtemayABS)
                                {
                                    labelsy[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy[i + 1].FromPosition = yaux[i + 1] - yaux[i + 1] * 0.1;
                                    labelsy[i + 1].ToPosition = yaux[i + 1] + yaux[i + 1] * 0.1;
                                    labelsy[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy[i + 1].Text = yaux[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy[i + 1]);
                                }
                            }


                        }



                    }



                }


                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsx1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsx1[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsx2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsx2[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsy1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsy1[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsy2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsy2[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }

                if (x1diferentex2 >= 1)
                {
                    if (x1[0] != 0 && x1[0] != l && x1[0] != ltv && x1[0] != xmmac && x1[0] != lcon)
                    {
                        labelsx1[0].ForeColor = System.Drawing.Color.Black;
                        labelsx1[0].FromPosition = x1[0] - x1[0] * 0.1;
                        labelsx1[0].ToPosition = x1[0] + x1[0] * 0.1;
                        labelsx1[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsx1[0].Text = x1[0].ToString();
                        chartV.ChartAreas[0].AxisX.CustomLabels.Add(labelsx1[0]);

                    }
                    if (x2[0] != 0 && x2[0] != l && x2[0] != ltv && x2[0] != xmmac && x2[0] != lcon)
                    {
                        labelsx2[0].ForeColor = System.Drawing.Color.Black;
                        labelsx2[0].FromPosition = x2[0] - x2[0] * 0.1;
                        labelsx2[0].ToPosition = x2[0] + x2[0] * 0.1;
                        labelsx2[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsx2[0].Text = x2[0].ToString();
                        chartV.ChartAreas[0].AxisX.CustomLabels.Add(labelsx2[0]);

                    }



                    if (y1[0] != yDgCte[0] && y1[0] != yDgCtemayABS)
                    {
                        labelsy1[0].ForeColor = System.Drawing.Color.Black;
                        labelsy1[0].FromPosition = y1[0] - y1[0] * 0.1;
                        labelsy1[0].ToPosition = y1[0] + y1[0] * 0.1;
                        labelsy1[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsy1[0].Text = y1[0].ToString();
                        chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[0]);
                    }

                    if (y2[0] != yDgCte[0] && y2[0] != yDgCtemayABS)
                    {
                        labelsy2[0].ForeColor = System.Drawing.Color.Black;
                        labelsy2[0].FromPosition = y2[0] - y2[0] * 0.1;
                        labelsy2[0].ToPosition = y2[0] + y2[0] * 0.1;
                        labelsy2[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsy2[0].Text = y2[0].ToString();
                        chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[0]);

                    }


                }



                for (int i = 0; i < x1diferentex2; i++)
                {
                    int a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0;
                    for (int j = 0; j < x1diferentex2; j++)
                    {

                        if (x1diferentex2 > 1 && i < x1diferentex2 - 1)
                        {
                            for (int k = 0; k < x1diferentex2; k++)
                            {
                                if (x1[i + 1] != x1[k])
                                {
                                    a1++;
                                }
                                if (x1[i + 1] != x2[k])
                                {
                                    a2++;
                                }
                                if (x2[i + 1] != x1[k])
                                {
                                    a3++;
                                }
                                if (x2[i + 1] != x2[k])
                                {
                                    a4++;
                                }


                                if (y1[i + 1] != y1[k])
                                {
                                    a5++;
                                }
                                if (y1[i + 1] != y2[k])
                                {
                                    a6++;
                                }
                                if (y2[i + 1] != y1[k])
                                {
                                    a7++;
                                }
                                if (y2[i + 1] != y2[k])
                                {
                                    a8++;
                                }

                            }
                            if (a1 == x1diferentex2 - 1 && a2 == x1diferentex2 && x1[i + 1] != l && x1[i + 1] != ltv && x1[i + 1] != 0  && x1[i + 1] != xmmac && x1[i + 1] != lcon)
                            {
                                labelsx1[i + 1].ForeColor = System.Drawing.Color.Black;
                                labelsx1[i + 1].FromPosition = x1[i + 1] - x1[i + 1] * 0.1;
                                labelsx1[i + 1].ToPosition = x1[i + 1] + x1[i + 1] * 0.1;
                                labelsx1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                labelsx1[i + 1].Text = x1[i + 1].ToString();
                                chartV.ChartAreas[0].AxisX.CustomLabels.Add(labelsx1[i + 1]);
                            }
                            if (a3 == x1diferentex2 && a4 == x1diferentex2 - 1 && x2[i + 1] != l && x2[i + 1] != ltv && x2[i + 1] != 0 && x2[i + 1] != xmmac && x2[i + 1] != lcon)
                            {
                                labelsx2[i + 1].ForeColor = System.Drawing.Color.Black;
                                labelsx2[i + 1].FromPosition = x2[i + 1] - x2[i + 1] * 0.1;
                                labelsx2[i + 1].ToPosition = x2[i + 1] + x2[i + 1] * 0.1;
                                labelsx2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                labelsx2[i + 1].Text = x2[i + 1].ToString();
                                chartV.ChartAreas[0].AxisX.CustomLabels.Add(labelsx2[i + 1]);
                            }
                            if (indTipApoy == 0)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1[i + 1] != YxSA(l) && y1[i + 1] != yDgCte[0] && y1[i + 1] != yDgCtemayABS)
                                {
                                    labelsy1[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1[i + 1].FromPosition = y1[i + 1] - y1[i + 1] * 0.1;
                                    labelsy1[i + 1].ToPosition = y1[i + 1] + y1[i + 1] * 0.1;
                                    labelsy1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1[i + 1].Text = y1[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[i + 1]);
                                }
                            }
                            else if (indTipApoy == 1)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && yaux[i + 1] != YxTV(l) && yaux[i + 1] != yDgCte[0] && yaux[i + 1] != YxTV(ltv) && y1[i + 1] != yDgCtemayABS)
                                {
                                    labelsy1[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1[i + 1].FromPosition = y1[i + 1] - y1[i + 1] * 0.1;
                                    labelsy1[i + 1].ToPosition = y1[i + 1] + y1[i + 1] * 0.1;
                                    labelsy1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1[i + 1].Text = y1[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[i + 1]);
                                }
                            }
                            else if (indTipApoy == 2)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1[i + 1] != YxEI(l) && y1[i + 1] != yDgCte[0] && y1[i + 1] != yDgCtemayABS)
                                {
                                    labelsy1[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1[i + 1].FromPosition = y1[i + 1] - y1[i + 1] * 0.1;
                                    labelsy1[i + 1].ToPosition = y1[i + 1] + y1[i + 1] * 0.1;
                                    labelsy1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1[i + 1].Text = y1[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[i + 1]);
                                }
                            }
                            else if (indTipApoy == 3)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1[i + 1] != YxC(l) && y1[i + 1] != yDgCte[0] && y1[i + 1] != yDgCtemayABS)
                                {
                                    labelsy1[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1[i + 1].FromPosition = y1[i + 1] - y1[i + 1] * 0.1;
                                    labelsy1[i + 1].ToPosition = y1[i + 1] + y1[i + 1] * 0.1;
                                    labelsy1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1[i + 1].Text = y1[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[i + 1]);
                                }
                            }
                            else if (indTipApoy == 4)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1[i + 1] != Yx5(l) && y1[i + 1] != yDgCte[0] && y1[i + 1] != yDgCtemayABS)
                                {
                                    labelsy1[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1[i + 1].FromPosition = y1[i + 1] - y1[i + 1] * 0.1;
                                    labelsy1[i + 1].ToPosition = y1[i + 1] + y1[i + 1] * 0.1;
                                    labelsy1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1[i + 1].Text = y1[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[i + 1]);
                                }
                            }
                            else if (indTipApoy == 5)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1[i + 1] != Yx6(l) && y1[i + 1] != yDgCte[0] && y1[i + 1] != yDgCtemayABS)
                                {
                                    labelsy1[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1[i + 1].FromPosition = y1[i + 1] - y1[i + 1] * 0.1;
                                    labelsy1[i + 1].ToPosition = y1[i + 1] + y1[i + 1] * 0.1;
                                    labelsy1[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1[i + 1].Text = y1[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1[i + 1]);
                                }
                            }



                            if (indTipApoy == 0)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2[i + 1] != YxSA(l) && y2[i + 1] != yDgCte[0] && y2[i + 1] != yDgCtemayABS)
                                {
                                    labelsy2[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2[i + 1].FromPosition = y2[i + 1] - y2[i + 1] * 0.1;
                                    labelsy2[i + 1].ToPosition = y2[i + 1] + y2[i + 1] * 0.1;
                                    labelsy2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2[i + 1].Text = y2[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[i + 1]);
                                }
                            }
                            else if (indTipApoy == 1)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2[i + 1] != YxTV(l) && y2[i + 1] != yDgCte[0] && y2[i + 1] != YxTV(ltv) && y2[i + 1] != yDgCtemayABS)
                                {
                                    labelsy2[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2[i + 1].FromPosition = y2[i + 1] - y2[i + 1] * 0.1;
                                    labelsy2[i + 1].ToPosition = y2[i + 1] + y2[i + 1] * 0.1;
                                    labelsy2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2[i + 1].Text = y2[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[i + 1]);
                                }
                            }
                            else if (indTipApoy == 2)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2[i + 1] != YxEI(l) && y2[i + 1] != yDgCte[0] && y2[i + 1] != yDgCtemayABS)
                                {
                                    labelsy2[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2[i + 1].FromPosition = y2[i + 1] - y2[i + 1] * 0.1;
                                    labelsy2[i + 1].ToPosition = y2[i + 1] + y2[i + 1] * 0.1;
                                    labelsy2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2[i + 1].Text = y2[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[i + 1]);
                                }
                            }
                            else if (indTipApoy == 3)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2[i + 1] != YxC(l) && y2[i + 1] != yDgCte[0] && y2[i + 1] != yDgCtemayABS)
                                {
                                    labelsy2[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2[i + 1].FromPosition = y2[i + 1] - y2[i + 1] * 0.1;
                                    labelsy2[i + 1].ToPosition = y2[i + 1] + y2[i + 1] * 0.1;
                                    labelsy2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2[i + 1].Text = y2[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[i + 1]);
                                }
                            }
                            else if (indTipApoy == 4)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2[i + 1] != Yx5(l) && y2[i + 1] != yDgCte[0] && y2[i + 1] != yDgCtemayABS)
                                {
                                    labelsy2[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2[i + 1].FromPosition = y2[i + 1] - y2[i + 1] * 0.1;
                                    labelsy2[i + 1].ToPosition = y2[i + 1] + y2[i + 1] * 0.1;
                                    labelsy2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2[i + 1].Text = y2[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[i + 1]);
                                }
                            }
                            else if (indTipApoy == 5)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2[i + 1] != Yx6(l) && y2[i + 1] != yDgCte[0] && y2[i + 1] != yDgCtemayABS)
                                {
                                    labelsy2[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2[i + 1].FromPosition = y2[i + 1] - y2[i + 1] * 0.1;
                                    labelsy2[i + 1].ToPosition = y2[i + 1] + y2[i + 1] * 0.1;
                                    labelsy2[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2[i + 1].Text = y2[i + 1].ToString();
                                    chartV.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2[i + 1]);
                                }
                            }

                        }



                    }












                }





                for (int i = 0; i <= 1000; i++)
                {
                    chartV.Series[0].Points.AddXY(xlabel[i], yDgCte[i]);
                }

                for (int z = 0; z <= 1000; z++)
                {
                    chartV.Series[1].Points.AddXY(xlabel[z], 0);
                }

                //abrir el comienzo del diagrama cortante

                yDgCteOpen[0] = 0;
                yDgCteOpen[1] = yDgCte[0];
                for (int i = 0; i < 2; i++)
                {
                    chartV.Series[2].Points.AddXY(0, yDgCteOpen[i]);
                }
                //cerrar diagrama cortante
                yDgCteClose[0] = 0;
                yDgCteClose[1] = yDgCte[1000];
                for (int i = 0; i < 2; i++)
                {
                    chartV.Series[3].Points.AddXY(l, yDgCteClose[i]);
                }



                //etiqueta a puntos en diagrama cortante
                if (yDgCte[0] != 0)
                {
                    chartV.Series[0].Points[0].Label = yDgCte[0].ToString(); //etiqueta en 0
                }

                chartV.Series[0].Points[1000].Label = yDgCte[1000].ToString(); //eqtiqueta en l


                if (indTipApoy == 1)
                {
                    ns = 4;
                    chartV.Series.Add("labeldelltv");
                    chartV.Series[ns].Points.AddXY(ltv + 0.02 * l, YxTV(ltv));
                    chartV.Series[ns].MarkerSize = 0;
                    chartV.Series[ns].Points[0].Label = YxTV(ltv).ToString();
                    chartV.Series[ns].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }
                else if (indTipApoy == 3)
                {
                    ns = 4;
                    chartV.Series.Add("labeldelltv");
                    chartV.Series[ns].Points.AddXY(lcon + 0.02 * l, YxC(lcon));
                    chartV.Series[ns].MarkerSize = 0;
                    chartV.Series[ns].Points[0].Label = YxC(lcon).ToString();
                    chartV.Series[ns].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }



                chartV.Series.Add("labeldcte"); //[4]
                if (x1igualx2 >= 1 && yaux[0] != yDgCte[0] && yaux[0] != yDgCte[1000] && yaux[0] != yDgCtemayABS && xaux[0] != ltv && xaux[0] != lcon)
                {
                    chartV.Series[ns + 1].Points.AddXY(xaux[0] + 0.02 * l, yaux[0]); //
                    chartV.Series[ns + 1].MarkerSize = 0;
                    chartV.Series[ns + 1].Points[0].Label = yaux[0].ToString();
                    chartV.Series[ns + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

                }


                for (int i = 0; i < x1igualx2; i++)
                {
                    int a1 = 0;
                    for (int j = 0; j < x1igualx2; j++)
                    {
                        if (x1igualx2 > 1 && i < x1igualx2 - 1)
                        {
                            for (int k = 0; k < x1igualx2; k++)
                            {
                                if (xaux[i + 1] != xaux[k])
                                {
                                    a1++;
                                }
                            }

                            if (a1 == x1igualx2 - 1 && xaux[i + 1] != 0 && xaux[i + 1] != l && xaux[i + 1] != ltv && xaux[i + 1] != xmmac && xaux[i + 1] != lcon)
                            {
                                chartV.Series[ns + 1].Points.AddXY(xaux[i + 1] + 0.02 * l, yaux[i + 1]);
                                chartV.Series[ns + 1].MarkerSize = 0;
                                chartV.Series[ns + 1].Points[chartV.Series[ns + 1].Points.Count - 1].Label = yaux[i + 1].ToString();
                                chartV.Series[ns + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            }


                        }


                    }



                }
                chartV.Series.Add("labelcte1");
                chartV.Series.Add("labelcte2");

                if (x1diferentex2 >= 1)
                {
                    if (y1[0] != yDgCte[0] && y1[0] != yDgCte[1000] && x1[0] != lcon && x1[0] != xmmac && x1[0] != ltv)
                    {
                        chartV.Series[ns + 2].Points.AddXY(x1[0] + 0.02 * l, y1[0]);
                        chartV.Series[ns + 2].MarkerSize = 0;
                        chartV.Series[ns + 2].Points[0].Label = y1[0].ToString();
                        chartV.Series[ns + 2].Points[0].Label.PadLeft(1);
                        chartV.Series[ns + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    }
                    if (y2[0] != yDgCte[0] && y2[0] != yDgCte[1000] && x2[0] != lcon && x2[0] != xmmac && x1[0] != ltv)
                    {
                        chartV.Series[ns + 3].Points.AddXY(x2[0] + 0.02 * l, y2[0]);
                        chartV.Series[ns + 3].MarkerSize = 0;
                        chartV.Series[ns + 3].Points[0].Label = y2[0].ToString();
                        chartV.Series[ns + 3].Points[0].Label.PadLeft(1);
                        chartV.Series[ns + 3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    }



                }


                for (int i = 0; i < x1diferentex2; i++)
                {
                    int a1 = 0, a2 = 0, a3 = 0, a4 = 0;
                    for (int j = 0; j < x1diferentex2; j++)
                    {
                        if (x1diferentex2 > 1 && i < x1diferentex2 - 1)
                        {
                            for (int k = 0; k < x1diferentex2; k++)
                            {
                                if (x1[i + 1] != x1[k])
                                {
                                    a1++;
                                }
                                if (x1[i + 1] != x2[k])
                                {
                                    a2++;
                                }
                                if (x2[i + 1] != x1[k])
                                {
                                    a3++;
                                }
                                if (x2[i + 1] != x2[k])
                                {
                                    a4++;
                                }
                            }
                            if (a1 == x1diferentex2 - 1 && a2 == x1diferentex2 && x1[i + 1] != 0 && x1[i + 1] != l && x1[i + 1] != ltv && x1[i + 1] != lcon && x1[i + 1] != xmmac)
                            {
                                chartV.Series[ns + 2].Points.AddXY(x1[i + 1] + 0.02 * l, y1[i + 1]);
                                chartV.Series[ns + 2].MarkerSize = 0;
                                chartV.Series[ns + 2].Points[chartV.Series[ns + 2].Points.Count - 1].Label = y1[i + 1].ToString();

                                chartV.Series[ns + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            }
                            if (a3 == x1diferentex2 && a4 == x1diferentex2 - 1 && x2[i + 1] != 0 && x2[i + 1] != l && x2[i + 1] != ltv && x2[i + 1] != lcon && x2[i + 1] != xmmac)
                            {
                                chartV.Series[ns + 3].Points.AddXY(x2[i + 1] + 0.02 * l, y2[i + 1]);
                                chartV.Series[ns + 3].MarkerSize = 0;
                                chartV.Series[ns + 3].Points[chartV.Series[ns + 3].Points.Count - 1].Label = y2[i + 1].ToString();

                                chartV.Series[ns + 3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            }


                        }


                    }



                }

                chartV.Series.Add("ymayor");
                //int t = 0;
                //for (int i = 0; i < dtgFyM.Rows.Count; i++)
                //{

                //    if (xlabel[xdelyCtemayorABS] == double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) || xlabel[xdelyCtemayorABS] == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                //    {

                //        t = 1;

                //    }


                //}

                if (/*t == 0*/ xmmac != 0 && xmmac != l && xmmac != ltv && xmmac != lcon)
                {

                    chartV.Series[ns + 4].Points.AddXY(xmmac + 0.02 * l, ymayor);
                    chartV.Series[ns + 4].MarkerSize = 0;
                    chartV.Series[ns + 4].Points[0].Label = yDgCtemayABS.ToString();
                    chartV.Series[ns + 4].Points[0].Label.PadLeft(1);
                    chartV.Series[ns + 4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;



                    System.Windows.Forms.DataVisualization.Charting.CustomLabel XVM = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                    XVM.ForeColor = System.Drawing.Color.Black;
                    System.Windows.Forms.DataVisualization.Charting.CustomLabel YVM = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                    YVM.ForeColor = System.Drawing.Color.Black;



                    if (xmmac != 0 && xmmac != l && xmmac != ltv && xmmac != lcon)
                    {
                        XVM.FromPosition = xmmac - xmmac * 0.1;
                        XVM.ToPosition = xmmac + xmmac * 0.1;
                        XVM.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        XVM.Text = xmmac.ToString();
                        chartV.ChartAreas[0].AxisX.CustomLabels.Add(XVM);
                    }
                    if (yDgCtemayABS != 0)
                    {
                        YVM.FromPosition = ymayor - ymayor * 0.1;
                        YVM.ToPosition = ymayor + ymayor * 0.1;
                        YVM.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        YVM.Text = yDgCtemayABS.ToString();
                        chartV.ChartAreas[0].AxisY.CustomLabels.Add(YVM);
                    }



                }

                chartV.Series.Add("puntoseguidor");





                // dibujar Diagrama Momento
                chartM.Series.Clear();
                chartM.Series.Add("Diagrama Momento"); //[0]
                chartM.Series.Add("Linea 0"); //[1]
                chartM.Series.Add("Linea abrir diagrama momento"); //[2]
                chartM.Series.Add("Linea cerrar diagrama momento"); //[3]
                chartM.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartM.Series[0].Color = Color.Blue;
                chartM.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chartM.Series[1].Color = Color.Red;
                chartM.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartM.Series[2].Color = Color.Blue;
                chartM.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartM.Series[3].Color = Color.Blue;
                if (unidades == 0)
                {
                    chartM.ChartAreas[0].AxisX.Title = "x [m]";
                    chartM.ChartAreas[0].AxisY.Title = "M [kN*m]";
                }
                else if (unidades == 1)
                {
                    chartM.ChartAreas[0].AxisX.Title = "x [ft]";
                    chartM.ChartAreas[0].AxisY.Title = "M [kip*ft]";
                }
              
                chartM.ChartAreas[0].AxisX.Minimum = 0 - 0.05 * l;
                chartM.ChartAreas[0].AxisX.Maximum = l + 0.05 * l;
                chartM.ChartAreas[0].AxisY.Minimum = yDgMtomen - Math.Abs(yDgMtomen) * 0.15;
                chartM.ChartAreas[0].AxisY.Maximum = yDgMtomay + Math.Abs(yDgMtomay) * 0.15;
                chartM.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
                chartM.ChartAreas[0].AxisY.LabelStyle.Format = "{0.0}";
                chartM.Series[0].BorderWidth = 2;
                chartM.Series[1].BorderWidth = 2;
                chartM.Series[2].BorderWidth = 2;
                chartM.Series[3].BorderWidth = 2;
                chartM.Legends.Clear();




                System.Windows.Forms.DataVisualization.Charting.CustomLabel YMx0 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                YMx0.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel XMltv = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                XMltv.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel YMltv = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                YMltv.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel XMlcon = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                XMlcon.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel YMlcon = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                YMlcon.ForeColor = System.Drawing.Color.Black;

                System.Windows.Forms.DataVisualization.Charting.CustomLabel XM0 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                XM0.ForeColor = System.Drawing.Color.Black;
                System.Windows.Forms.DataVisualization.Charting.CustomLabel XMl = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                XMl.ForeColor = System.Drawing.Color.Black;

                YMx0.ForeColor = System.Drawing.Color.Black;
                YMx0.FromPosition = yDgMto[0] - yDgMto[0] * 0.1;
                YMx0.ToPosition = yDgMto[0] + yDgMto[0] * 0.1;
                YMx0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                YMx0.Text = yDgMto[0].ToString();
                chartM.ChartAreas[0].AxisY.CustomLabels.Add(YMx0);

                if (indTipApoy == 0)
                {
                    XM0.FromPosition = 0 - 0.1 * l;
                    XM0.ToPosition = 0 + 0.1 * l;
                    XM0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XM0.Text = "0";
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XM0);

                    XMl.FromPosition = l - l * 0.1;
                    XMl.ToPosition = l + l * 0.1;
                    XMl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMl.Text = l.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMl);
                }
                else if (indTipApoy == 1)
                {
                    XM0.FromPosition = 0 - 0.1 * l;
                    XM0.ToPosition = 0 + 0.1 * l;
                    XM0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XM0.Text = "0";
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XM0);

                    XMl.FromPosition = l - l * 0.1;
                    XMl.ToPosition = l + l * 0.1;
                    XMl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMl.Text = l.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMl);

                    XMltv.FromPosition = ltv - ltv * 0.1;
                    XMltv.ToPosition = ltv + ltv * 0.1;
                    XMltv.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMltv.Text = ltv.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMltv);

                    YMltv.FromPosition = YMxTV(ltv) - YMxTV(ltv) * 0.1;
                    YMltv.ToPosition = YMxTV(ltv) + YMxTV(ltv) * 0.1;
                    YMltv.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    YMltv.Text = YMxTV(ltv).ToString();
                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(YMltv);
                }
                else if (indTipApoy == 2)
                {
                    XM0.FromPosition = 0 - 0.1 * l;
                    XM0.ToPosition = 0 + 0.1 * l;
                    XM0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XM0.Text = "0";
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XM0);

                    XMl.FromPosition = l - l * 0.1;
                    XMl.ToPosition = l + l * 0.1;
                    XMl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMl.Text = l.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMl);
                }
                else if (indTipApoy == 3)
                {
                    XM0.FromPosition = 0 - 0.1 * l;
                    XM0.ToPosition = 0 + 0.1 * l;
                    XM0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XM0.Text = "0";
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XM0);

                    XMl.FromPosition = l - l * 0.1;
                    XMl.ToPosition = l + l * 0.1;
                    XMl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMl.Text = l.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMl);

                    XMlcon.FromPosition = lcon - lcon * 0.1;
                    XMlcon.ToPosition = lcon + lcon * 0.1;
                    XMlcon.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMlcon.Text = lcon.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMlcon);

                    YMlcon.FromPosition = YMxC(lcon) - YMxC(lcon) * 0.1;
                    YMlcon.ToPosition = YMxC(lcon) + YMxC(lcon) * 0.1;
                    YMlcon.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    YMlcon.Text = YMxC(lcon).ToString();
                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(YMlcon);
                }
                else if (indTipApoy == 4)
                {
                    XM0.FromPosition = 0 - 0.1 * l;
                    XM0.ToPosition = 0 + 0.1 * l;
                    XM0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XM0.Text = "0";
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XM0);

                    XMl.FromPosition = l - l * 0.1;
                    XMl.ToPosition = l + l * 0.1;
                    XMl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMl.Text = l.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMl);
                }
                else if (indTipApoy == 5)
                {
                    XM0.FromPosition = 0 - 0.1 * l;
                    XM0.ToPosition = 0 + 0.1 * l;
                    XM0.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XM0.Text = "0";
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XM0);

                    XMl.FromPosition = l - l * 0.1;
                    XMl.ToPosition = l + l * 0.1;
                    XMl.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                    XMl.Text = l.ToString();
                    chartM.ChartAreas[0].AxisX.CustomLabels.Add(XMl);
                }


                //escoger etiqueta a mostrar del momento mayor
                double xmma = xlabel[xdelyMtomayorABS]; // x del nuevo momento mayor absoluto
                double yMmayor = yDgMto[xdelyMtomayorABS];

                for (int i = 0; i < yauxM.Count; i++)
                {
                    if (Math.Abs(yauxM[i]) > yDgMtomayABS)
                    {
                        yDgMtomayABS = Math.Abs(yauxM[i]);
                        yMmayor = yauxM[i];
                        xmma = xaux[i];
                        
                    }
                }
                for (int i = 0; i < y1M.Count; i++)
                {
                    if (Math.Abs(y1M[i]) > yDgMtomayABS)
                    {
                        yDgMtomayABS = Math.Abs(y1M[i]);
                        yMmayor = y1M[i];
                        xmma = xaux[i];

                    }
                }
                for (int i = 0; i < y2M.Count; i++)
                {
                    if (Math.Abs(y2M[i]) > yDgMtomayABS)
                    {
                        yDgMtomayABS = Math.Abs(y2M[i]);
                        yMmayor = y2M[i];
                        xmma = xaux[i];

                    }
                }




                //labels para el eje x de diagrama momento

                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsxM = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1igualx2];
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsyM = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1igualx2];

                for (byte i = 0; i < x1igualx2; i++)
                {
                    labelsxM[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                for (byte i = 0; i < x1igualx2; i++)
                {
                    labelsyM[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }

                if (x1igualx2 >= 1)
                {
                    if (x1igualx2 >= 1)
                    {
                        if (xaux[0] != 0 && xaux[0] != l && xaux[0] != ltv && xaux[0] != xmma && xaux[0] != lcon)
                        {
                            labelsxM[0].ForeColor = System.Drawing.Color.Black;
                            labelsxM[0].FromPosition = xaux[0] - xaux[0] * 0.1;
                            labelsxM[0].ToPosition = xaux[0] + xaux[0] * 0.1;
                            labelsxM[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                            labelsxM[0].Text = xaux[0].ToString();
                            chartM.ChartAreas[0].AxisX.CustomLabels.Add(labelsxM[0]);

                        }


                        if (yauxM[0] != yDgMto[0] && yauxM[0] != yDgMtomayABS )
                        {
                            labelsyM[0].ForeColor = System.Drawing.Color.Black;
                            labelsyM[0].FromPosition = yauxM[0] - yauxM[0] * 0.1;
                            labelsyM[0].ToPosition = yauxM[0] + yauxM[0] * 0.1;
                            labelsyM[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                            labelsyM[0].Text = yauxM[0].ToString();
                            chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[0]);
                        }



                    }

                }


                for (int i = 0; i < x1igualx2; i++)
                {
                    int a1 = 0, a2 = 0;
                    for (int j = 0; j < x1igualx2; j++)
                    {

                        if (x1igualx2 > 1 && i < x1igualx2 - 1)
                        {
                            for (int k = 0; k < x1igualx2; k++)
                            {
                                if (xaux[i + 1] != xaux[k])
                                {
                                    a1++;
                                }
                                if (yauxM[i + 1] != yauxM[k])
                                {
                                    a2++;
                                }
                            }
                            if (a1 == x1igualx2 - 1 && xaux[i + 1] != l && xaux[i + 1] != ltv && xaux[i + 1] != 0 && xaux[i + 1] != xmma && xaux[i + 1] != lcon)
                            {
                                labelsxM[i + 1].ForeColor = System.Drawing.Color.Black;
                                labelsxM[i + 1].FromPosition = xaux[i + 1] - xaux[i + 1] * 0.1;
                                labelsxM[i + 1].ToPosition = xaux[i + 1] + xaux[i + 1] * 0.1;
                                labelsxM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                labelsxM[i + 1].Text = xaux[i + 1].ToString();
                                chartM.ChartAreas[0].AxisX.CustomLabels.Add(labelsxM[i + 1]);
                            }

                            if (indTipApoy == 0)
                            {
                                if (a2 == x1igualx2 - 1 && yauxM[i + 1] != YMxSA(l) && yauxM[i + 1] != yDgMto[0] && yauxM[i + 1] != yDgMtomayABS)
                                {
                                    labelsyM[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsyM[i + 1].FromPosition = yauxM[i + 1] - yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].ToPosition = yauxM[i + 1] + yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsyM[i + 1].Text = yauxM[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[i + 1]);
                                }
                            }
                            else if (indTipApoy == 1)
                            {
                                if (a2 == x1igualx2 - 1 && yauxM[i + 1] != YMxTV(l) && yauxM[i + 1] != yDgMto[0] && yauxM[i + 1] != YMxTV(ltv) && yauxM[i + 1] != yDgMtomayABS)
                                {
                                    labelsyM[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsyM[i + 1].FromPosition = yauxM[i + 1] - yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].ToPosition = yauxM[i + 1] + yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsyM[i + 1].Text = yauxM[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[i + 1]);
                                }
                            }
                            else if (indTipApoy == 2)
                            {
                                if (a2 == x1igualx2 - 1 && yauxM[i + 1] != YMxEI(l) && yauxM[i + 1] != yDgMto[0] && yauxM[i + 1] != yDgMtomayABS)
                                {
                                    labelsyM[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsyM[i + 1].FromPosition = yauxM[i + 1] - yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].ToPosition = yauxM[i + 1] + yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsyM[i + 1].Text = yauxM[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[i + 1]);
                                }
                            }
                            else if (indTipApoy == 3)
                            {
                                if (a2 == x1igualx2 - 1 && yauxM[i + 1] != YMxC(l) && yauxM[i + 1] != yDgMto[0] && yauxM[i + 1] != yDgMtomayABS)
                                {
                                    labelsyM[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsyM[i + 1].FromPosition = yauxM[i + 1] - yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].ToPosition = yauxM[i + 1] + yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsyM[i + 1].Text = yauxM[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[i + 1]);
                                }
                            }
                            else if (indTipApoy == 4)
                            {
                                if (a2 == x1igualx2 - 1 && yauxM[i + 1] != YMx5(l) && yauxM[i + 1] != yDgMto[0] && yauxM[i + 1] != yDgMtomayABS)
                                {
                                    labelsyM[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsyM[i + 1].FromPosition = yauxM[i + 1] - yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].ToPosition = yauxM[i + 1] + yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsyM[i + 1].Text = yauxM[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[i + 1]);
                                }
                            }
                            else if (indTipApoy == 5)
                            {
                                if (a2 == x1igualx2 - 1 && yauxM[i + 1] != YMx6(l) && yauxM[i + 1] != yDgMto[0] && yauxM[i + 1] != yDgMtomayABS)
                                {
                                    labelsyM[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsyM[i + 1].FromPosition = yauxM[i + 1] - yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].ToPosition = yauxM[i + 1] + yauxM[i + 1] * 0.1;
                                    labelsyM[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsyM[i + 1].Text = yauxM[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsyM[i + 1]);
                                }
                            }




                        }



                    }







                }


                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsx1M = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsx1M[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsx2M = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsx2M[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsy1M = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsy1M[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }
                System.Windows.Forms.DataVisualization.Charting.CustomLabel[] labelsy2M = new System.Windows.Forms.DataVisualization.Charting.CustomLabel[x1diferentex2];
                for (byte i = 0; i < x1diferentex2; i++)
                {
                    labelsy2M[i] = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                }


                if (x1diferentex2 >= 1)
                {
                    if (x1[0] != 0 && x1[0] != l && x1[0] != ltv && x1[0] != xmma && x1[0] != lcon)
                    {
                        labelsx1M[0].ForeColor = System.Drawing.Color.Black;
                        labelsx1M[0].FromPosition = x1[0] - x1[0] * 0.1;
                        labelsx1M[0].ToPosition = x1[0] + x1[0] * 0.1;
                        labelsx1M[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsx1M[0].Text = x1[0].ToString();
                        chartM.ChartAreas[0].AxisX.CustomLabels.Add(labelsx1M[0]);

                    }
                    if (x2[0] != 0 && x2[0] != l && x2[0] != ltv && x2[0] != xmma && x2[0] != lcon)
                    {
                        labelsx2M[0].ForeColor = System.Drawing.Color.Black;
                        labelsx2M[0].FromPosition = x2[0] - x2[0] * 0.1;
                        labelsx2M[0].ToPosition = x2[0] + x2[0] * 0.1;
                        labelsx2M[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsx2M[0].Text = x2[0].ToString();
                        chartM.ChartAreas[0].AxisX.CustomLabels.Add(labelsx2M[0]);

                    }



                    if (y1M[0] != yDgMto[0] && y1M[0] != yDgMtomayABS)
                    {
                        labelsy1M[0].ForeColor = System.Drawing.Color.Black;
                        labelsy1M[0].FromPosition = y1M[0] - y1M[0] * 0.1;
                        labelsy1M[0].ToPosition = y1M[0] + y1M[0] * 0.1;
                        labelsy1M[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsy1M[0].Text = y1M[0].ToString();
                        chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[0]);
                    }

                    if (y2M[0] != yDgMto[0] && y2M[0] != yDgMtomayABS)
                    {
                        labelsy2M[0].ForeColor = System.Drawing.Color.Black;
                        labelsy2M[0].FromPosition = y2M[0] - y2M[0] * 0.1;
                        labelsy2M[0].ToPosition = y2M[0] + y2M[0] * 0.1;
                        labelsy2M[0].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        labelsy2M[0].Text = y2M[0].ToString();
                        chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[0]);

                    }












                }

                for (int i = 0; i < x1diferentex2; i++)
                {
                    int a1 = 0;
                    int a2 = 0;
                    int a3 = 0;
                    int a4 = 0;
                    int a5 = 0, a6 = 0, a7 = 0, a8 = 0;
                    for (int j = 0; j < x1diferentex2; j++)
                    {

                        if (x1diferentex2 > 1 && i < x1diferentex2 - 1)
                        {
                            for (int k = 0; k < x1diferentex2; k++)
                            {
                                if (x1[i + 1] != x1[k])
                                {
                                    a1++;
                                }
                                if (x1[i + 1] != x2[k])
                                {
                                    a2++;
                                }
                                if (x2[i + 1] != x1[k])
                                {
                                    a3++;
                                }
                                if (x2[i + 1] != x2[k])
                                {
                                    a4++;
                                }
                                if (y1M[i + 1] != y1M[k])
                                {
                                    a5++;
                                }
                                if (y1M[i + 1] != y2M[k])
                                {
                                    a6++;
                                }
                                if (y2M[i + 1] != y1M[k])
                                {
                                    a7++;
                                }
                                if (y2M[i + 1] != y2M[k])
                                {
                                    a8++;
                                }
                            }
                            if (a1 == x1diferentex2 - 1 && a2 == x1diferentex2 && x1[i + 1] != l && x1[i + 1] != ltv && x1[i + 1] != 0 && x1[i + 1] != xmma && x1[i + 1] != lcon)
                            {
                                labelsx1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                labelsx1M[i + 1].FromPosition = x1[i + 1] - x1[i + 1] * 0.1;
                                labelsx1M[i + 1].ToPosition = x1[i + 1] + x1[i + 1] * 0.1;
                                labelsx1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                labelsx1M[i + 1].Text = x1[i + 1].ToString();
                                chartM.ChartAreas[0].AxisX.CustomLabels.Add(labelsx1M[i + 1]);
                            }
                            if (a3 == x1diferentex2 && a4 == x1diferentex2 - 1 && x2[i + 1] != l && x2[i + 1] != ltv && x2[i + 1] != 0 && x2[i + 1] != xmma && x2[i + 1] != lcon)
                            {
                                labelsx2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                labelsx2M[i + 1].FromPosition = x2[i + 1] - x2[i + 1] * 0.1;
                                labelsx2M[i + 1].ToPosition = x2[i + 1] + x2[i + 1] * 0.1;
                                labelsx2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                labelsx2M[i + 1].Text = x2[i + 1].ToString();
                                chartM.ChartAreas[0].AxisX.CustomLabels.Add(labelsx2M[i + 1]);
                            }
                            if (indTipApoy == 0)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1M[i + 1] != YMxSA(l) && y1M[i + 1] != yDgMto[0] && y1M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1M[i + 1].FromPosition = y1M[i + 1] - y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].ToPosition = y1M[i + 1] + y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1M[i + 1].Text = y1M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 1)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1M[i + 1] != YMxTV(l) && y1M[i + 1] != yDgMto[0] && y1M[i + 1] != YMxTV(ltv) && y1M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1M[i + 1].FromPosition = y1M[i + 1] - y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].ToPosition = y1M[i + 1] + y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1M[i + 1].Text = y1M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 2)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1M[i + 1] != YMxEI(l) && y1M[i + 1] != yDgMto[0] && y1M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1M[i + 1].FromPosition = y1M[i + 1] - y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].ToPosition = y1M[i + 1] + y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1M[i + 1].Text = y1M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 3)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1M[i + 1] != YMxC(l) && y1M[i + 1] != yDgMto[0] && y1M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1M[i + 1].FromPosition = y1M[i + 1] - y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].ToPosition = y1M[i + 1] + y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1M[i + 1].Text = y1M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 4)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1M[i + 1] != YMx5(l) && y1M[i + 1] != yDgMto[0] && y1M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1M[i + 1].FromPosition = y1M[i + 1] - y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].ToPosition = y1M[i + 1] + y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1M[i + 1].Text = y1M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 5)
                            {
                                if (a5 == x1diferentex2 - 1 && a6 == x1diferentex2 && y1M[i + 1] != YMx6(l) && y1M[i + 1] != yDgMto[0] && y1M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy1M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy1M[i + 1].FromPosition = y1M[i + 1] - y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].ToPosition = y1M[i + 1] + y1M[i + 1] * 0.1;
                                    labelsy1M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy1M[i + 1].Text = y1M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy1M[i + 1]);
                                }
                            }




                            if (indTipApoy == 0)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2M[i + 1] != YMxSA(l) && y2M[i + 1] != yDgMto[0] && y2M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2M[i + 1].FromPosition = y2M[i + 1] - y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].ToPosition = y2M[i + 1] + y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2M[i + 1].Text = y2M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 1)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2M[i + 1] != YMxTV(l) && y2M[i + 1] != yDgMto[0] && y2M[i + 1] != YMxTV(ltv) && y2M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2M[i + 1].FromPosition = y2M[i + 1] - y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].ToPosition = y2M[i + 1] + y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2M[i + 1].Text = y2M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 2)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2M[i + 1] != YMxEI(l) && y2M[i + 1] != yDgMto[0] && y2M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2M[i + 1].FromPosition = y2M[i + 1] - y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].ToPosition = y2M[i + 1] + y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2M[i + 1].Text = y2M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 3)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2M[i + 1] != YMxC(l) && y2M[i + 1] != yDgMto[0] && y2M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2M[i + 1].FromPosition = y2M[i + 1] - y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].ToPosition = y2M[i + 1] + y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2M[i + 1].Text = y2M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 4)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2M[i + 1] != YMx5(l) && y2M[i + 1] != yDgMto[0] && y2M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2M[i + 1].FromPosition = y2M[i + 1] - y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].ToPosition = y2M[i + 1] + y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2M[i + 1].Text = y2M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[i + 1]);
                                }
                            }
                            else if (indTipApoy == 5)
                            {
                                if (a7 == x1diferentex2 && a8 == x1diferentex2 - 1 && y2M[i + 1] != YMx6(l) && y2M[i + 1] != yDgMto[0] && y2M[i + 1] != yDgMtomayABS)
                                {
                                    labelsy2M[i + 1].ForeColor = System.Drawing.Color.Black;
                                    labelsy2M[i + 1].FromPosition = y2M[i + 1] - y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].ToPosition = y2M[i + 1] + y2M[i + 1] * 0.1;
                                    labelsy2M[i + 1].GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                                    labelsy2M[i + 1].Text = y2M[i + 1].ToString();
                                    chartM.ChartAreas[0].AxisY.CustomLabels.Add(labelsy2M[i + 1]);
                                }
                            }





                        }



                    }












                }

                for (int i = 0; i <= 1000; i++)
                {
                    chartM.Series[0].Points.AddXY(xlabel[i], yDgMto[i]);
                }

                for (int z = 0; z <= 1000; z++)
                {
                    chartM.Series[1].Points.AddXY(xlabel[z], 0);
                }

                //abrir el comienzo del diagrama cortante

                yDgMtoOpen[0] = 0;
                yDgMtoOpen[1] = yDgMto[0];
                for (int i = 0; i < 2; i++)
                {
                    chartM.Series[2].Points.AddXY(0, yDgMtoOpen[i]);
                }
                //cerrar diagrama cortante
                yDgMtoClose[0] = 0;
                yDgMtoClose[1] = yDgMto[1000];
                for (int i = 0; i < 2; i++)
                {
                    chartM.Series[3].Points.AddXY(0, yDgMtoClose[i]);
                }


                //etiqueta a digrama momento 



                //etiqueta a puntos en diagrama momento
                if (yDgMto[0] != 0)
                {
                    chartM.Series[0].Points[0].Label = yDgMto[0].ToString(); //etiqueta en 0
                }

                chartM.Series[0].Points[1000].Label = yDgMto[1000].ToString(); //eqtiqueta en l

                if (indTipApoy == 1)
                {
                    ns = 4;
                    chartM.Series.Add("labeldelltvM");

                    chartM.Series[ns].Points.AddXY(ltv + 0.02 * l, YMxTV(ltv));
                    chartM.Series[ns].MarkerSize = 0;
                    chartM.Series[ns].Points[0].Label = YMxTV(ltv).ToString();
                    chartM.Series[ns].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }
                else if (indTipApoy == 3)
                {
                    ns = 4;
                    chartM.Series.Add("labeldelltvM");
                    chartM.Series[ns].Points.AddXY(ltv + 0.02 * l, YMxC(ltv));
                    chartM.Series[ns].MarkerSize = 0;
                    chartM.Series[ns].Points[0].Label = YMxC(ltv).ToString();
                    chartM.Series[ns].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }

                chartM.Series.Add("labeldctMe"); //[4]

                if ( x1igualx2 >= 1 && yauxM[0] != yDgMto[0] && yauxM[0] != yDgMto[1000] && yauxM[0] != yDgMtomayABS && xaux[0] != ltv && xaux[0] != lcon)
                {
                        chartM.Series[ns + 1].Points.AddXY(xaux[0] + 0.02 * l, yauxM[0]);
                        chartM.Series[ns + 1].MarkerSize = 0;
                        chartM.Series[ns + 1].Points[0].Label = yauxM[0].ToString();
                        chartM.Series[ns + 1].Points[0].Label.PadLeft(1);
                        chartM.Series[ns + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }


                for (int i = 0; i < x1igualx2; i++)
                {
                    int flM = 0;
                    for (int j = 0; j < x1igualx2; j++)
                    {
                        if (x1igualx2 > 1 && i < x1igualx2 - 1)
                        {
                            for (int k = 0; k < x1igualx2; k++)
                            {
                                if (xaux[i + 1] != xaux[k])
                                {
                                    flM++;
                                }
                            }


                            if (flM == x1igualx2 - 1 && xaux[i + 1] != 0 && xaux[i + 1] != l && xaux[i + 1] != ltv && xaux[i + 1] != xmma && xaux[i + 1] != lcon)
                            {
                              
                                chartM.Series[ns + 1].Points.AddXY(xaux[i + 1] + 0.02 * l, yauxM[i + 1]);
                                chartM.Series[ns + 1].MarkerSize = 0;
                                chartM.Series[ns + 1].Points[chartM.Series[ns + 1].Points.Count - 1].Label = yauxM[i + 1].ToString();

                                chartM.Series[ns + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

                            }




                        }


                    }


                }

                chartM.Series.Add("labelcte1"); //[5]
                chartM.Series.Add("labelcte2"); //[6]

                if (x1diferentex2 >= 1)
                {
                    if (y1M[0] != yDgMto[0] && y1M[0] != yDgMto[1000] && x1[0] != ltv && x1[0] != lcon && x1[0] != xmma)
                    {
                        chartM.Series[ns + 2].Points.AddXY(x1[0] + 0.02 * l, y1M[0]);
                        chartM.Series[ns + 2].MarkerSize = 0;
                        chartM.Series[ns + 2].Points[0].Label = y1M[0].ToString();
                        chartM.Series[ns + 2].Points[0].Label.PadLeft(1);
                        chartM.Series[ns + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    }
                    if (y2M[0] != yDgMto[0] && y2M[0] != yDgMto[1000] && x2[0] != ltv && x2[0] != lcon && x2[0] != xmma)
                    {
                        chartM.Series[ns + 3].Points.AddXY(x2[0] + 0.02 * l, y2M[0]);
                        chartM.Series[ns + 3].MarkerSize = 0;
                        chartM.Series[ns + 3].Points[0].Label = y2M[0].ToString();
                        chartM.Series[ns + 3].Points[0].Label.PadLeft(1);
                        chartM.Series[ns + 3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    }






                }

                for (int i = 0; i < x1diferentex2; i++)
                {
                    int f1M = 0;
                    int f2M = 0;
                    int f3M = 0;
                    int f4M = 0;
                    for (int j = 0; j < x1diferentex2; j++)
                    {
                        if (x1diferentex2 > 1 && i < x1diferentex2 - 1)
                        {
                            for (int k = 0; k < x1diferentex2; k++)
                            {
                                if (x1[i + 1] != x1[k])
                                {
                                    f1M++;
                                }
                                if (x1[i + 1] != x2[k])
                                {
                                    f2M++;
                                }
                                if (x2[i + 1] != x1[k])
                                {
                                    f3M++;
                                }
                                if (x2[i + 1] != x2[k])
                                {
                                    f4M++;
                                }
                            }

                            if (f1M == x1diferentex2 - 1 && f2M == x1diferentex2 && x1[i + 1] != 0 && x1[i + 1] != l && x1[i + 1] != ltv  && x1[ i+1] != lcon && x1[i+1] != xmma)
                            {
                                chartM.Series[ns + 2].Points.AddXY(x1[i + 1] + 0.02 * l, y1M[i + 1]);
                                chartM.Series[ns + 2].MarkerSize = 0;
                                chartM.Series[ns + 2].Points[chartM.Series[ns + 2].Points.Count - 1].Label = y1M[i + 1].ToString();

                                chartM.Series[ns + 2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            }
                            if (f3M == x1diferentex2 && f4M == x1diferentex2 - 1 && x2[i + 1] != 0 && x1[i + 1] != l && x1[i + 1] != ltv && x1[i + 1] != lcon && x1[i + 1] != xmma)
                            {
                                chartM.Series[ns + 3].Points.AddXY(x2[i + 1], y2M[i + 1]);
                                chartM.Series[ns + 3].MarkerSize = 0;
                                chartM.Series[ns + 3].Points[chartM.Series[ns + 3].Points.Count - 1].Label = y2M[i + 1].ToString();

                                chartM.Series[ns + 3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            }






                        }


                    }







                }

                chartM.Series.Add("ymayor"); //[7]

                //int tM = 0;
                //for (int i = 0; i < dtgFyM.Rows.Count; i++)
                //{

                //    //if (xmma == double.Parse(dtgFyM.Rows[i].Cells[1].Value.ToString()) || xmma == double.Parse(dtgFyM.Rows[i].Cells[2].Value.ToString()))
                //    //{

                //    //    tM = 1;

                //    //}


                //}
                if (/*tM == 0*/  xmma != 0 && xmma != l && xmma != ltv && xmma != lcon)
                {

                    chartM.Series[ns + 4].Points.AddXY(xmma, yMmayor);
                    chartM.Series[ns + 4].MarkerSize = 0;
                    chartM.Series[ns + 4].Points[0].Label = yDgMtomayABS.ToString();

                    chartM.Series[ns + 4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

                    System.Windows.Forms.DataVisualization.Charting.CustomLabel XVMM = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                    XVMM.ForeColor = System.Drawing.Color.Black;
                    System.Windows.Forms.DataVisualization.Charting.CustomLabel YVMM = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                    YVMM.ForeColor = System.Drawing.Color.Black;

                    if (xmma != 0 && xmma != l && xmma != ltv && xmma != lcon)
                    {
                        XVMM.FromPosition = xmma - xmma * 0.1;
                        XVMM.ToPosition = xmma + xmma * 0.1;
                        XVMM.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        XVMM.Text = xmma.ToString();
                        chartM.ChartAreas[0].AxisX.CustomLabels.Add(XVMM);
                    }
                    if (yDgMtomayABS != 0)
                    {
                        YVMM.FromPosition = yMmayor - yMmayor * 0.1;
                        YVMM.ToPosition = yMmayor + yMmayor * 0.1;
                        YVMM.GridTicks = System.Windows.Forms.DataVisualization.Charting.GridTickTypes.TickMark;
                        YVMM.Text = yDgMtomayABS.ToString();
                        chartM.ChartAreas[0].AxisY.CustomLabels.Add(YVMM);
                    }

                }


                chartM.Series.Add("puntoseguidor"); //[6]

      





                x1igualx2 = 0; //reiniciar contador
                x1diferentex2 = 0; //reiniciar contador

                //barra de herramientas
                btncxV.Image = Image.FromFile("ilustraciones/btnCxV.png");
                //anotaciones debajo del chart
                if (unidades == 0)
                {
                    lblCtemayplot.Text = "Cortante mayor absoluto [kN] ";
                    lblMtomayplot.Text = "Momento mayor absoluto [kN*m]";
                  
                }
                else if (unidades == 1)
                {
                    lblCtemayplot.Text = "Cortante mayor absoluto [kip] ";
                    lblMtomayplot.Text = "Momento mayor absoluto [kip*ft]";
                }
                txtCtemayplot.Text = yDgCtemayABS.ToString();
                txtyctexplot.Text = yDgCte[0].ToString();
                txtMtomayplot.Text = yDgMtomayABS.ToString();
                txtyMtoplot.Text = yDgMto[0].ToString();

                //elminar pestaña de viga seleccionada
                if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
                {
                    TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
                }

                if (chkbDyPPP.Checked == true && haymaterial == 1)
                {
                    //Habilitar gráfico perfil
                    TabCtrlPanelPrincipal.Controls.Add(tabPerf);


                    //smin si unidades están en pies
            

                   
                        if (unidades == 0)
                        {

                        
                            Smin = (yDgMtomayABS) / (ETP*1000); //smin queda en 10E3 mm3
                        }
                        else if (unidades == 1)
                        {

                       
                            Smin = yDgMtomayABS * 12 / ETP; //smin queda en in^3

                        }

                    
          




                    //matris para s mayores que smin con su ID y PESO
                    if (cbPfPP.SelectedIndex == 0 && unidades == 0) ////////////////////////////////////////
                    {
                        for (int i = 0; i < pwis1.Rows.Count; i++)
                        {

                            if (double.Parse(pwis1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpeso.Add(double.Parse(pwis1.Rows[i][2].ToString()));
                                SmenSminpesoname.Add(pwis1.Rows[i][1].ToString());
                                SmenSminpesoid.Add(int.Parse(pwis1.Rows[i][0].ToString()));
                                pesoidPW.Add(double.Parse(pwis1.Rows[i][4].ToString()));
                            }

                        }

               

                        if (SmenSminpeso.Count >= 1)
                        {
                            autom.Columns.Add("nombre", typeof(string));
                            autom.Columns.Add("S", typeof(double));
                            autom.Columns.Add("id",typeof(int));
                            autom.Columns.Add("peso", typeof(double));

                            for (int i = 0; i < SmenSminpeso.Count; i++)
                            {
                                autom.Rows.Add(SmenSminpesoname[i],SmenSminpeso[i],SmenSminpesoid[i],pesoidPW[i]);
                            }

                        }


                        ////////////////////////////////////////////////
                        for (int i = 0; i < psis1.Rows.Count; i++)
                        {

                            if (double.Parse(psis1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPS.Add(double.Parse(psis1.Rows[i][2].ToString()));
                                SmenSminpesoPSname.Add(psis1.Rows[i][1].ToString());
                                SmenSminpesoPSid.Add(int.Parse(psis1.Rows[i][0].ToString()));
                                pesoidPS.Add(double.Parse(psis1.Rows[i][4].ToString()));
                            }

                        }

     

                        if (SmenSminpesoPS.Count >= 1)
                        {

                            for (int i = SmenSminpeso.Count; i < SmenSminpeso.Count + SmenSminpesoPS.Count; i++)
                            {
                                autom.Rows.Add(SmenSminpesoPSname[i - SmenSminpeso.Count], SmenSminpesoPS[i - SmenSminpeso.Count],SmenSminpesoPSid[i - SmenSminpeso.Count],pesoidPS[i - SmenSminpeso.Count]);
                            }



                        }




                        ///////////////////////////////
                        for (int i = 0; i < pcis1.Rows.Count; i++)
                        {

                            if (double.Parse(pcis1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPC.Add(double.Parse(pcis1.Rows[i][2].ToString()));
                                SmenSminpesoPCname.Add(pcis1.Rows[i][1].ToString());
                                SmenSminpesoPCid.Add(int.Parse(pcis1.Rows[i][0].ToString()));
                                pesoidPC.Add(double.Parse(pcis1.Rows[i][4].ToString()));
                            }

                        }



                        if (SmenSminpesoPC.Count >= 1)
                        {

                            for (int i = SmenSminpesoPS.Count; i < SmenSminpesoPS.Count + SmenSminpesoPC.Count; i++)
                            {
                                autom.Rows.Add(SmenSminpesoPCname[i - SmenSminpesoPS.Count], SmenSminpesoPC[i - SmenSminpesoPS.Count], SmenSminpesoPCid[i - SmenSminpesoPS.Count], pesoidPC[i - SmenSminpesoPS.Count]);
                            }



                        }



                        ////////////////////////

                        for (int k = 0; k < autom.Rows.Count - 1; k++)
                        {
                            for (int f = 0; f < autom.Rows.Count - 1 - k; f++)
                            {
                                if (double.Parse(autom.Rows[f][3].ToString()) > double.Parse(autom.Rows[f + 1][3].ToString()))
                                {
                                    double aux, aux3;
                                    string aux1;
                                    int aux2;
                                    aux = double.Parse(autom.Rows[f][1].ToString());
                                    autom.Rows[f][1] = double.Parse(autom.Rows[f + 1][1].ToString());
                                    autom.Rows[f + 1][1] = aux;
                                    
                                    aux1 = autom.Rows[f][0].ToString();
                                    autom.Rows[f][0] = autom.Rows[f + 1][0].ToString();
                                    autom.Rows[f + 1][0] = aux1;

                                    aux2 = int.Parse(autom.Rows[f][2].ToString());
                                    autom.Rows[f][2] = int.Parse(autom.Rows[f + 1][2].ToString());
                                    autom.Rows[f + 1][2] = aux2;
                                   

                                    aux3 = double.Parse(autom.Rows[f][3].ToString());
                                    autom.Rows[f][3] = double.Parse(autom.Rows[f + 1][3].ToString());
                                    autom.Rows[f + 1][3] = aux3;
                                   



                                }
                            }
                        }

                        for (int i = 0; i < autom.Rows.Count; i++)
                        {
                            lbperf.Items.Add(int.Parse(autom.Rows[i][2].ToString()));
                            lbnameperf.Items.Add(autom.Rows[i][0].ToString());
                        }

              


                        if (autom.Rows.Count > 0)
                        {
                            string aux;
                            aux = autom.Rows[0][0].ToString();

                            foreach (char primeraletra in aux)
                            {
                                if (primeraletra.ToString() == "W")
                                {
                                    lbperf.SelectedIndex = 0;
                                    lbnameperf.SelectedIndex = 0;

                                    int idviga;
                                    idviga = int.Parse(autom.Rows[0][2].ToString());

                                    txtVgsda.Text = pwis1.Rows[idviga - 1][1].ToString();
                                    txtdPerf.Text = pwis1.Rows[idviga - 1][3].ToString();
                                    txtbfPerf.Text = pwis1.Rows[idviga - 1][5].ToString();
                                    txttfPerf.Text = pwis1.Rows[idviga - 1][6].ToString();
                                    txttwPerf.Text = pwis1.Rows[idviga - 1][7].ToString();

                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pwis1.Rows[idviga - 1][3].ToString());
                                    tf = double.Parse(pwis1.Rows[idviga - 1][6].ToString());
                                    s = double.Parse(pwis1.Rows[idviga - 1][2].ToString());
                                    ix = double.Parse(pwis1.Rows[idviga - 1][8].ToString());
                                    bf = double.Parse(pwis1.Rows[idviga - 1][5].ToString());
                                    tw = double.Parse(pwis1.Rows[idviga - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS) / (s * 1000);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    cb = cb / 1000;
                                    spa = sa;
                                    
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));





                                    string prefijo = "";

                                    if (sa > 0 && sa < 0.001)
                                    {
                                        sa = sa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sa >= 0.001 && sa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sa >= 1000)
                                    {
                                        sa = sa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 0.001)
                                    {
                                        sb = sb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sb >= 0.001 && sb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sb >= 1000)
                                    {
                                        sb = sb / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 0.001)
                                    {
                                        cb = cb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (cb >= 0.001 && cb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (cb >= 1000)
                                    {
                                        cb = cb / 1000;
                                        prefijo = "[GPa]";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 0.001)
                                    {
                                        spa = spa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spa >= 0.001 && spa < 0.001)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spa >= 1000)
                                    {
                                        spa = spa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 0.001)
                                    {
                                        spb = spb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spb >= 0.001 && spb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spb >= 1000)
                                    {
                                        spb = spb / 1000;
                                        prefijo = "[GPa]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";

                                    break;
                                }
                                if (primeraletra.ToString() == "S")
                                {
                                    lbperf.SelectedIndex = 0;
                                    lbnameperf.SelectedIndex = 0;

                                    int idviga;
                                    idviga = int.Parse(autom.Rows[0][2].ToString());

                                    txtVgsda.Text = psis1.Rows[idviga - 1][1].ToString();
                                    txtdPerf.Text = psis1.Rows[idviga - 1][3].ToString();
                                    txtbfPerf.Text = psis1.Rows[idviga - 1][5].ToString();
                                    txttfPerf.Text = psis1.Rows[idviga - 1][6].ToString();
                                    txttwPerf.Text = psis1.Rows[idviga - 1][7].ToString();

                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(psis1.Rows[idviga - 1][3].ToString());
                                    tf = double.Parse(psis1.Rows[idviga - 1][6].ToString());
                                    s = double.Parse(psis1.Rows[idviga - 1][2].ToString());
                                    ix = double.Parse(psis1.Rows[idviga - 1][8].ToString());
                                    bf = double.Parse(psis1.Rows[idviga - 1][5].ToString());
                                    tw = double.Parse(psis1.Rows[idviga - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS) / (s * 1000);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    cb = cb / 1000;
                                    spa = sa ; // en megapascales
                                 
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));





                                    string prefijo = "";

                                    if (sa > 0 && sa < 0.001)
                                    {
                                        sa = sa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sa >= 0.001 && sa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sa >= 1000)
                                    {
                                        sa = sa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 0.001)
                                    {
                                        sb = sb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sb >= 0.001 && sb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sb >= 1000)
                                    {
                                        sb = sb / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 0.001)
                                    {
                                        cb = cb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (cb >= 0.001 && cb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (cb >= 1000)
                                    {
                                        cb = cb / 1000;
                                        prefijo = "[GPa]";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 0.001)
                                    {
                                        spa = spa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spa >= 0.001 && spa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spa >= 1000)
                                    {
                                        spa = spa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 0.001)
                                    {
                                        spb = spb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spb >= 0.001 && spb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spb >= 1000)
                                    {
                                        spb = spb / 1000;
                                        prefijo = "[GPa]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";

                                    break;
                                }
                                if (primeraletra.ToString() == "C")
                                {
                                    lbperf.SelectedIndex = 0;
                                    lbnameperf.SelectedIndex = 0;

                                    int idviga;
                                    idviga = int.Parse(autom.Rows[0][2].ToString());

                                    txtVgsda.Text = pcis1.Rows[idviga - 1][1].ToString();
                                    txtdPerf.Text = pcis1.Rows[idviga - 1][3].ToString();
                                    txtbfPerf.Text = pcis1.Rows[idviga - 1][5].ToString();
                                    txttfPerf.Text = pcis1.Rows[idviga - 1][6].ToString();
                                    txttwPerf.Text = pcis1.Rows[idviga - 1][7].ToString();

                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pcis1.Rows[idviga - 1][3].ToString());
                                    tf = double.Parse(pcis1.Rows[idviga - 1][6].ToString());
                                    s = double.Parse(pcis1.Rows[idviga - 1][2].ToString());
                                    ix = double.Parse(pcis1.Rows[idviga - 1][8].ToString());
                                    bf = double.Parse(pcis1.Rows[idviga - 1][5].ToString());
                                    tw = double.Parse(pcis1.Rows[idviga - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS) / (s * 1000);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    cb = cb / 1000;
                                    spa = sa; // en megapascales
                                   
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));




                                    string prefijo = "";

                                    if (sa > 0 && sa < 0.001)
                                    {
                                        sa = sa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sa >= 0.001 && sa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sa >= 1000)
                                    {
                                        sa = sa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 0.001)
                                    {
                                        sb = sb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (sb >= 0.001 && sb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (sb >= 1000)
                                    {
                                        sb = sb / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 0.001)
                                    {
                                        cb = cb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (cb >= 0.001 && cb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (cb >= 1000)
                                    {
                                        cb = cb / 1000;
                                        prefijo = "[GPa]";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 0.001)
                                    {
                                        spa = spa * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spa >= 0.001 && spa < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spa >= 1000)
                                    {
                                        spa = spa / 1000;
                                        prefijo = "[GPa]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 0.001)
                                    {
                                        spb = spb * 1000;
                                        prefijo = "[kPa]:";
                                    }
                                    else if (spb >= 0.001 && spb < 1000)
                                    {

                                        prefijo = "[MPa]:";
                                    }
                                    else if (spb >= 1000)
                                    {
                                        spb = spb / 1000;
                                        prefijo = "[GPa]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";

                                    break;
                                }
                            }





                            //dibujar perfil
                            //lbldPerf.Text = "d [mm]:";
                            //lblbfPerf.Text = "bf [mm]:";
                            //lbltfPerf.Text = "tf [mm]:";
                            //lbltwPerf.Text = "tw [mm]:";

                            //lblspa.Text = "Esfuerzo principal en a [MPa]:";
                            //lblspb.Text = "Esfuerzo principal en b [MPa]:";


                    
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil en la base de datos se adapta a la configuración de la viga");
                        }









                    }
                    else if (cbPfPP.SelectedIndex == 0 && unidades == 1)
                    {
                        for (int i = 0; i < pwus1.Rows.Count; i++)
                        {

                            if (double.Parse(pwus1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpeso.Add(double.Parse(pwus1.Rows[i][2].ToString()));
                                SmenSminpesoname.Add(pwus1.Rows[i][1].ToString());
                                SmenSminpesoid.Add(int.Parse(pwus1.Rows[i][0].ToString()));
                                pesoidPW.Add(double.Parse(pwus1.Rows[i][4].ToString()));
                            }

                        }



                        if (SmenSminpeso.Count >= 1)
                        {
                            autom.Columns.Add("nombre", typeof(string));
                            autom.Columns.Add("S", typeof(double));
                            autom.Columns.Add("id", typeof(int));
                            autom.Columns.Add("peso", typeof(double));

                            for (int i = 0; i < SmenSminpeso.Count; i++)
                            {
                                autom.Rows.Add(SmenSminpesoname[i], SmenSminpeso[i], SmenSminpesoid[i], pesoidPW[i]);
                            }

                        }


                        ////////////////////////////////////////////////
                        for (int i = 0; i < psus1.Rows.Count; i++)
                        {

                            if (double.Parse(psus1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPS.Add(double.Parse(psus1.Rows[i][2].ToString()));
                                SmenSminpesoPSname.Add(psus1.Rows[i][1].ToString());
                                SmenSminpesoPSid.Add(int.Parse(psus1.Rows[i][0].ToString()));
                                pesoidPS.Add(double.Parse(psus1.Rows[i][4].ToString()));
                            }

                        }



                        if (SmenSminpesoPS.Count >= 1)
                        {

                            for (int i = SmenSminpeso.Count; i < SmenSminpeso.Count + SmenSminpesoPS.Count; i++)
                            {
                                autom.Rows.Add(SmenSminpesoPSname[i - SmenSminpeso.Count], SmenSminpesoPS[i - SmenSminpeso.Count], SmenSminpesoPSid[i - SmenSminpeso.Count], pesoidPS[i - SmenSminpeso.Count]);
                            }



                        }

                        ////////////////////////

                        for (int i = 0; i < pcus1.Rows.Count; i++)
                        {

                            if (double.Parse(pcus1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPC.Add(double.Parse(pcus1.Rows[i][2].ToString()));
                                SmenSminpesoPCname.Add(pcus1.Rows[i][1].ToString());
                                SmenSminpesoPCid.Add(int.Parse(pcus1.Rows[i][0].ToString()));
                                pesoidPC.Add(double.Parse(pcus1.Rows[i][4].ToString()));
                            }

                        }



                        if (SmenSminpesoPS.Count >= 1)
                        {

                            for (int i = SmenSminpesoPS.Count; i < SmenSminpesoPS.Count + SmenSminpesoPC.Count; i++)
                            {
                                autom.Rows.Add(SmenSminpesoPCname[i - SmenSminpesoPS.Count], SmenSminpesoPC[i - SmenSminpesoPS.Count], SmenSminpesoPCid[i - SmenSminpesoPS.Count], pesoidPC[i - SmenSminpesoPS.Count]);
                            }



                        }
                        //////////////

                        for (int k = 0; k < autom.Rows.Count - 1; k++)
                        {
                            for (int f = 0; f < autom.Rows.Count - 1 - k; f++)
                            {
                                if (double.Parse(autom.Rows[f][3].ToString()) > double.Parse(autom.Rows[f + 1][3].ToString()))
                                {
                                    double aux, aux3;
                                    string aux1;
                                    int aux2;
                                    aux = double.Parse(autom.Rows[f][1].ToString());
                                    autom.Rows[f][1] = double.Parse(autom.Rows[f + 1][1].ToString());
                                    autom.Rows[f + 1][1] = aux;

                                    aux1 = autom.Rows[f][0].ToString();
                                    autom.Rows[f][0] = autom.Rows[f + 1][0].ToString();
                                    autom.Rows[f + 1][0] = aux1;

                                    aux2 = int.Parse(autom.Rows[f][2].ToString());
                                    autom.Rows[f][2] = int.Parse(autom.Rows[f + 1][2].ToString());
                                    autom.Rows[f + 1][2] = aux2;


                                    aux3 = double.Parse(autom.Rows[f][3].ToString());
                                    autom.Rows[f][3] = double.Parse(autom.Rows[f + 1][3].ToString());
                                    autom.Rows[f + 1][3] = aux3;




                                }
                            }
                        }

                        for (int i = 0; i < autom.Rows.Count; i++)
                        {
                            lbperf.Items.Add(int.Parse(autom.Rows[i][2].ToString()));
                            lbnameperf.Items.Add(autom.Rows[i][0].ToString());
                        }




                        if (autom.Rows.Count > 0)
                        {
                            string aux;
                            aux = autom.Rows[0][0].ToString();

                            foreach (char primeraletra in aux)
                            {
                                if (primeraletra.ToString() == "W")
                                {
                                    lbperf.SelectedIndex = 0;
                                    lbnameperf.SelectedIndex = 0;

                                    int idviga;
                                    idviga = int.Parse(autom.Rows[0][2].ToString());

                                    txtVgsda.Text = pwus1.Rows[idviga - 1][1].ToString();
                                    txtdPerf.Text = pwus1.Rows[idviga - 1][3].ToString();
                                    txtbfPerf.Text = pwus1.Rows[idviga - 1][5].ToString();
                                    txttfPerf.Text = pwus1.Rows[idviga - 1][6].ToString();
                                    txttwPerf.Text = pwus1.Rows[idviga - 1][7].ToString();

                          
                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pwus1.Rows[idviga - 1][3].ToString());
                                    tf = double.Parse(pwus1.Rows[idviga - 1][6].ToString());
                                    s = double.Parse(pwus1.Rows[idviga - 1][2].ToString());
                                    ix = double.Parse(pwus1.Rows[idviga - 1][8].ToString());
                                    bf = double.Parse(pwus1.Rows[idviga - 1][5].ToString());
                                    tw = double.Parse(pwus1.Rows[idviga - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS * 12) / (s);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    spa = sa;
                                    spa = Math.Round(spa, 4);
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                    spb = Math.Round(spb, 4);



                                    string prefijo = "";

                                    if (sa > 0 && sa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sa >= 1000000 && sa < 1000000000)
                                    {
                                        sa = sa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sa >= 1000000000)
                                    {
                                        sa = sa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sb >= 1000000 && sb < 1000000000)
                                    {
                                        sb = sb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sb >= 1000000000)
                                    {
                                        sb = sb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (cb >= 1000000 && cb < 1000000000)
                                    {
                                        cb = cb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (cb >= 1000000000)
                                    {
                                        cb = cb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spa >= 1000000 && spa < 1000000000)
                                    {
                                        spa = spa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spa >= 1000000000)
                                    {
                                        spa = spa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spb >= 1000000 && spb < 1000000000)
                                    {
                                        spb = spb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spb >= 1000000000)
                                    {
                                        spb = spb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";

                                    break;
                                }
                                if (primeraletra.ToString() == "S")
                                {
                                    lbperf.SelectedIndex = 0;
                                    lbnameperf.SelectedIndex = 0;

                                    int idviga;
                                    idviga = int.Parse(autom.Rows[0][2].ToString());

                                    txtVgsda.Text = psus1.Rows[idviga - 1][1].ToString();
                                    txtdPerf.Text = psus1.Rows[idviga - 1][3].ToString();
                                    txtbfPerf.Text = psus1.Rows[idviga - 1][5].ToString();
                                    txttfPerf.Text = psus1.Rows[idviga - 1][6].ToString();
                                    txttwPerf.Text = psus1.Rows[idviga - 1][7].ToString();

                                 
                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(psus1.Rows[idviga - 1][3].ToString());
                                    tf = double.Parse(psus1.Rows[idviga - 1][6].ToString());
                                    s = double.Parse(psus1.Rows[idviga - 1][2].ToString());
                                    ix = double.Parse(psus1.Rows[idviga - 1][8].ToString());
                                    bf = double.Parse(psus1.Rows[idviga - 1][5].ToString());
                                    tw = double.Parse(psus1.Rows[idviga - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS * 12) / (s);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    spa = sa;
                                    spa = Math.Round(spa, 4);
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                    spb = Math.Round(spb, 4);


                                    string prefijo = "";

                                    if (sa > 0 && sa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sa >= 1000000 && sa < 1000000000)
                                    {
                                        sa = sa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sa >= 1000000000)
                                    {
                                        sa = sa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sb >= 1000000 && sb < 1000000000)
                                    {
                                        sb = sb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sb >= 1000000000)
                                    {
                                        sb = sb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (cb >= 1000000 && cb < 1000000000)
                                    {
                                        cb = cb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (cb >= 1000000000)
                                    {
                                        cb = cb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spa >= 1000000 && spa < 1000000000)
                                    {
                                        spa = spa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spa >= 1000000000)
                                    {
                                        spa = spa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spb >= 1000000 && spb < 1000000000)
                                    {
                                        spb = spb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spb >= 1000000000)
                                    {
                                        spb = spb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";

                                    break;
                                }
                                if (primeraletra.ToString() == "C")
                                {
                                    lbperf.SelectedIndex = 0;
                                    lbnameperf.SelectedIndex = 0;

                                    int idviga;
                                    idviga = int.Parse(autom.Rows[0][2].ToString());

                                    txtVgsda.Text = pcus1.Rows[idviga - 1][1].ToString();
                                    txtdPerf.Text = pcus1.Rows[idviga - 1][3].ToString();
                                    txtbfPerf.Text = pcus1.Rows[idviga - 1][5].ToString();
                                    txttfPerf.Text = pcus1.Rows[idviga - 1][6].ToString();
                                    txttwPerf.Text = pcus1.Rows[idviga - 1][7].ToString();


                                    //cálculo del esfuerzo principal
                                    double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                                    d = double.Parse(pcus1.Rows[idviga - 1][3].ToString());
                                    tf = double.Parse(pcus1.Rows[idviga - 1][6].ToString());
                                    s = double.Parse(pcus1.Rows[idviga - 1][2].ToString());
                                    ix = double.Parse(pcus1.Rows[idviga - 1][8].ToString());
                                    bf = double.Parse(pcus1.Rows[idviga - 1][5].ToString());
                                    tw = double.Parse(pcus1.Rows[idviga - 1][7].ToString());

                                    areaq = tf * bf;
                                    ytq = 0.5 * d - 0.5 * tf;
                                    q = areaq * ytq;
                                    v = yDgCte[xdelyMtomayorABS];
                                    v = Math.Abs(v);
                                    sa = (yDgMtomayABS * 12) / (s);
                                    sb = sa * (0.5 * d - tf) / (0.5 * d);
                                    cb = (v * q) / (ix * tw);
                                    spa = sa;
                                    spa = Math.Round(spa, 4);
                                    spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                                    spb = Math.Round(spb, 4);

                                    string prefijo = "";

                                    if (sa > 0 && sa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sa >= 1000000 && sa < 1000000000)
                                    {
                                        sa = sa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sa >= 1000000000)
                                    {
                                        sa = sa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblENena.Text = "Esfuerzo normal en a " + prefijo;
                                    txtENena.Text = sa.ToString("0.000");
                                    lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                                    txtECena.Text = "0";

                                    if (sb > 0 && sb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (sb >= 1000000 && sb < 1000000000)
                                    {
                                        sb = sb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (sb >= 1000000000)
                                    {
                                        sb = sb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                                    txtENenb.Text = sb.ToString("0.000");

                                    if (cb > 0 && cb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (cb >= 1000000 && cb < 1000000000)
                                    {
                                        cb = cb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (cb >= 1000000000)
                                    {
                                        cb = cb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                                    txtECenb.Text = cb.ToString("0.000");

                                    if (spa > 0 && spa < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spa >= 1000000 && spa < 1000000000)
                                    {
                                        spa = spa / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spa >= 1000000000)
                                    {
                                        spa = spa / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }
                                    lblspa.Text = "Esfuerzo principal en a " + prefijo;
                                    txtspa.Text = spa.ToString();

                                    if (spb > 0 && spb < 1000000)
                                    {
                                        prefijo = "[ksi]:";
                                    }
                                    else if (spb >= 1000000 && spb < 1000000000)
                                    {
                                        spb = spb / 1000000;
                                        prefijo = "[Mpsi]:";
                                    }
                                    else if (spb >= 1000000000)
                                    {
                                        spb = spb / 1000000000;
                                        prefijo = "[Gpsi]:";
                                    }

                                    txtspb.Text = spb.ToString();
                                    lblspb.Text = "Esfuerzo principal en b " + prefijo;

                                    //dibujar perfil
                                    pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                                    pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                                    pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                    lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";

                                    break;
                                }
                            }





                            //dibujar perfil
                            //lbldPerf.Text = "d [in]:";
                            //lblbfPerf.Text = "bf [in]:";
                            //lbltfPerf.Text = "tf [in]:";
                            //lbltwPerf.Text = "tw [in]:";

                            //lblspa.Text = "Esfuerzo principal en a [ksi]:";
                            //lblspb.Text = "Esfuerzo principal en b [ksi]:";
                       
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil en la base de datos se adapta a la configuración de la viga");
                        }
                    }
                    else if (cbPfPP.SelectedIndex == 1 && unidades == 0)
                    {


                        for (int i = 0; i < pwis1.Rows.Count; i++)
                        {

                            if (double.Parse(pwis1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpeso.Add(double.Parse(pwis1.Rows[i][2].ToString()));
                                SmenSminpesoid.Add(int.Parse(pwis1.Rows[i][0].ToString()));
                                pesoidPW.Add(double.Parse(pwis1.Rows[i][4].ToString()));
                            }

                        }




                        for (int k = 0; k < SmenSminpeso.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpeso.Count - 1 - k; f++)
                            {
                                if (SmenSminpeso[f] > SmenSminpeso[f + 1])
                                {
                                    double aux, aux2;
                                    int aux1;
                                    aux = SmenSminpeso[f];
                                    SmenSminpeso[f] = SmenSminpeso[f + 1];
                                    SmenSminpeso[f + 1] = aux;
                                    aux1 = SmenSminpesoid[f];
                                    SmenSminpesoid[f] = SmenSminpesoid[f + 1];
                                    SmenSminpesoid[f + 1] = aux1;
                                    aux2 = pesoidPW[f];
                                    pesoidPW[f] = pesoidPW[f + 1];
                                    pesoidPW[f + 1] = aux2;



                                }
                            }
                        }

                        for (int k = 0; k < SmenSminpeso.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpeso.Count - 1 - k; f++)
                            {
                                if (pesoidPW[f] > pesoidPW[f + 1])
                                {
                                    double aux;
                                    int aux1;
                                    aux = pesoidPW[f];
                                    pesoidPW[f] = pesoidPW[f + 1];
                                    pesoidPW[f + 1] = aux;
                                    aux1 = SmenSminpesoid[f];
                                    SmenSminpesoid[f] = SmenSminpesoid[f + 1];
                                    SmenSminpesoid[f + 1] = aux1;

                                }
                            }
                        }

                        for (int i = 0; i < SmenSminpesoid.Count; i++)
                        {
                            lbperf.Items.Add(SmenSminpesoid[i]);
                        }

                        if (SmenSminpeso.Count >= 1)
                        {

                            lbperf.SelectedIndex = 0;
                            idvgsda = SmenSminpesoid[0];
                            //mostrar el nombre de la viga
                            txtVgsda.Text = pwis1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pwis1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pwis1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pwis1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pwis1.Rows[idvgsda - 1][7].ToString();
                            lbldPerf.Text = "d [mm]:";
                            lblbfPerf.Text = "bf [mm]:";
                            lbltfPerf.Text = "tf [mm]:";
                            lbltwPerf.Text = "tw [mm]:";
                       
                            //cálculo del esfuerzo principal
                            double sa,s,sb,d,tf,bf,tw,ix,cb,v,areaq,ytq,q,spa, spb;
                            d = double.Parse(pwis1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pwis1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pwis1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pwis1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pwis1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pwis1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf; //mm2
                            ytq = 0.5* d - 0.5*tf; //mm
                            q = areaq * ytq; //mm3
                            v = yDgCte[xdelyMtomayorABS]; //kN
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS) / (s*1000); //MPa
                            sb = (sa*(0.5*d - tf))/(0.5*d); //MPa
                        
                            cb = (v*q)/(ix*tw); //GPa
                            cb = cb / 1000; //Mpa
                            spa = sa; // en megapascales
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            
                            





                            string prefijo = "";

                            if (sa > 0 && sa < 0.001)
                            {
                                sa = sa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sa >= 0.001 && sa < 1000)
                            {
                                
                                prefijo = "[MPa]:";
                            }
                            else if (sa >= 1000)
                            {
                                sa = sa/1000;
                                prefijo = "[GPa]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 0.001)
                            {
                                sb = sb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sb >= 0.001 && sb < 1000)
                            {
                               
                                prefijo = "[MPa]:";
                            }
                            else if (sb >= 1000)
                            {
                                sb = sb/1000;
                                prefijo = "[GPa]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 0.001)
                            {
                                cb = cb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (cb >= 0.001 && cb < 1000)
                            {
                              
                                prefijo = "[MPa]:";
                            }
                            else if (cb >= 1000)
                            {
                                cb = cb / 1000;
                                prefijo = "[GPa]";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 0.001)
                            {
                                spa = spa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spa >= 0.001 && spa < 1000)
                            {
                              
                                prefijo = "[MPa]:";
                            }
                            else if (spa >= 1000)
                            {
                                spa = spa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 0.001)
                            {
                                spb = spb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spb >= 0.001 && spb < 1000)
                            {
                               
                                prefijo = "[MPa]:";
                            }
                            else if (spb >= 1000)
                            {
                                spb = spb / 1000;
                                prefijo = "[GPa]:";
                            }
                         
                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            //dibujar perfil
                            //pnlDibPerf.Invalidate();

                            pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil se adapta a la configuración de la viga");
                        }


                    }
                    else if (cbPfPP.SelectedIndex == 1 && unidades == 1)
                    {
                        for (int i = 0; i < pwus1.Rows.Count; i++)
                        {

                            if (double.Parse(pwus1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpeso.Add(double.Parse(pwus1.Rows[i][2].ToString()));
                                SmenSminpesoid.Add(int.Parse(pwus1.Rows[i][0].ToString()));
                                pesoidPW.Add(double.Parse(pwus1.Rows[i][4].ToString()));
                            }

                        }




                        for (int k = 0; k < SmenSminpeso.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpeso.Count - 1 - k; f++)
                            {
                                if (SmenSminpeso[f] > SmenSminpeso[f + 1])
                                {
                                    double aux, aux2;
                                    int aux1;
                                    aux = SmenSminpeso[f];
                                    SmenSminpeso[f] = SmenSminpeso[f + 1];
                                    SmenSminpeso[f + 1] = aux;
                                    aux1 = SmenSminpesoid[f];
                                    SmenSminpesoid[f] = SmenSminpesoid[f + 1];
                                    SmenSminpesoid[f + 1] = aux1;
                                    aux2 = pesoidPW[f];
                                    pesoidPW[f] = pesoidPW[f + 1];
                                    pesoidPW[f + 1] = aux2;



                                }
                            }
                        }

                        for (int k = 0; k < SmenSminpeso.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpeso.Count - 1 - k; f++)
                            {
                                if (pesoidPW[f] > pesoidPW[f + 1])
                                {
                                    double aux;
                                    int aux1;
                                    aux = pesoidPW[f];
                                    pesoidPW[f] = pesoidPW[f + 1];
                                    pesoidPW[f + 1] = aux;
                                    aux1 = SmenSminpesoid[f];
                                    SmenSminpesoid[f] = SmenSminpesoid[f + 1];
                                    SmenSminpesoid[f + 1] = aux1;

                                }
                            }
                        }

                        for (int i = 0; i < SmenSminpesoid.Count; i++)
                        {
                            lbperf.Items.Add(SmenSminpesoid[i]);
                        }

                        if (SmenSminpeso.Count >= 1)
                        {

                            lbperf.SelectedIndex = 0;
                            idvgsda = SmenSminpesoid[0];
                            //mostrar el nombre de la viga
                            txtVgsda.Text = pwus1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pwus1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pwus1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pwus1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pwus1.Rows[idvgsda - 1][7].ToString();
                            lbldPerf.Text = "d [in]:";
                            lblbfPerf.Text = "bf [in]:";
                            lbltfPerf.Text = "tf [in]:";
                            lbltwPerf.Text = "tw [in]:";

                       
                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pwus1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pwus1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pwus1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pwus1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pwus1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pwus1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS*12) / (s);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            spa = sa; 
                            spa = Math.Round(spa, 4);
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            spb = Math.Round(spb, 4);

                         

                            string prefijo = "";
                           
                            if (sa > 0 && sa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sa >= 1000000 && sa < 1000000000)
                            {
                                sa = sa / 1000000;
                                prefijo = "[Mpsi]:";
                            }else if (sa >= 1000000000)
                            {
                                sa = sa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sb >= 1000000 && sb < 1000000000)
                            {
                                sb = sb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sb >= 1000000000)
                            {
                                sb = sb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (cb >= 1000000 && cb < 1000000000)
                            {
                                cb = cb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (cb >= 1000000000)
                            {
                                cb = cb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spa >= 1000000 && spa < 1000000000)
                            {
                                spa = spa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spa >= 1000000000)
                            {
                                spa = spa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spb >= 1000000 && spb < 1000000000)
                            {
                                spb = spb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spb >= 1000000000)
                            {
                                spb = spb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                        
                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfilw.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagew.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.canam-construction.com";
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil se adapta a la configuración de la viga");
                        }
                    }
                    else if (cbPfPP.SelectedIndex == 2 && unidades == 0)
                    {
                        for (int i = 0; i < psis1.Rows.Count; i++)
                        {

                            if (double.Parse(psis1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPS.Add(double.Parse(psis1.Rows[i][2].ToString()));
                                SmenSminpesoPSid.Add(int.Parse(psis1.Rows[i][0].ToString()));
                                pesoidPS.Add(double.Parse(psis1.Rows[i][4].ToString()));
                            }

                        }



                        for (int k = 0; k < SmenSminpesoPS.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPS.Count - 1 - k; f++)
                            {
                                if (SmenSminpesoPS[f] > SmenSminpesoPS[f + 1])
                                {
                                    double aux, aux2;
                                    int aux1;
                                    aux = SmenSminpesoPS[f];
                                    SmenSminpesoPS[f] = SmenSminpesoPS[f + 1];
                                    SmenSminpesoPS[f + 1] = aux;

                                    aux1 = SmenSminpesoPSid[f];
                                    SmenSminpesoPSid[f] = SmenSminpesoPSid[f + 1];
                                    SmenSminpesoPSid[f + 1] = aux1;
                                    aux2 = pesoidPS[f];
                                    pesoidPS[f] = pesoidPS[f + 1];
                                    pesoidPS[f + 1] = aux2;
                                }
                            }
                        }

                        for (int k = 0; k < SmenSminpesoPS.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPS.Count - 1 - k; f++)
                            {
                                if (pesoidPS[f] > pesoidPS[f + 1])
                                {
                                    double aux;
                                    int aux1;
                                    aux = pesoidPS[f];
                                    pesoidPS[f] = pesoidPS[f + 1];
                                    pesoidPS[f + 1] = aux;
                                    aux1 = SmenSminpesoPSid[f];
                                    SmenSminpesoPSid[f] = SmenSminpesoPSid[f + 1];
                                    SmenSminpesoPSid[f + 1] = aux1;

                                }
                            }
                        }

                        for (int i = 0; i < SmenSminpesoPSid.Count; i++)
                        {
                            lbperf.Items.Add(SmenSminpesoPSid[i]);
                        }

                        if (SmenSminpesoPS.Count >= 1)
                        {
                            idvgsda = SmenSminpesoPSid[0];
                            //mostrar el nombre de la viga
                            txtVgsda.Text = psis1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = psis1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = psis1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = psis1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = psis1.Rows[idvgsda - 1][7].ToString();
                            lbldPerf.Text = "d [mm]";
                            lblbfPerf.Text = "bf [mm]";
                            lbltfPerf.Text = "tf [mm]";
                            lbltwPerf.Text = "tw [mm]";

                          
                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(psis1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(psis1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(psis1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(psis1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(psis1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(psis1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS) / (s * 1000);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            cb = cb / 1000;
                            spa = sa; // en megapascales
                       
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));




                            string prefijo = "";

                            if (sa > 0 && sa < 0.001)
                            {
                                sa = sa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sa >= 0.001 && sa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sa >= 1000)
                            {
                                sa = sa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 0.001)
                            {
                                sb = sb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sb >= 0.001 && sb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sb >= 1000)
                            {
                                sb = sb / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 0.001)
                            {
                                cb = cb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (cb >= 0.001 && cb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (cb >= 1000)
                            {
                                cb = cb / 1000;
                                prefijo = "[GPa]";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 0.001)
                            {
                                spa = spa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spa >= 0.001 && spa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spa >= 1000)
                            {
                                spa = spa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 0.001)
                            {
                                spb = spb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spb >= 0.001 && spb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spb >= 1000)
                            {
                                spb = spb / 1000;
                                prefijo = "[GPa]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;
                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil se adapta a la configuración de la viga");
                        }
                    }
                    else if (cbPfPP.SelectedIndex == 2 && unidades == 1)
                    {
                        for (int i = 0; i < psus1.Rows.Count; i++)
                        {

                            if (double.Parse(psus1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPS.Add(double.Parse(psus1.Rows[i][2].ToString()));
                                SmenSminpesoPSid.Add(int.Parse(psus1.Rows[i][0].ToString()));
                                pesoidPS.Add(double.Parse(psus1.Rows[i][4].ToString()));
                            }

                        }



                        for (int k = 0; k < SmenSminpesoPS.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPS.Count - 1 - k; f++)
                            {
                                if (SmenSminpesoPS[f] > SmenSminpesoPS[f + 1])
                                {
                                    double aux, aux2;
                                    int aux1;
                                    aux = SmenSminpesoPS[f];
                                    SmenSminpesoPS[f] = SmenSminpesoPS[f + 1];
                                    SmenSminpesoPS[f + 1] = aux;

                                    aux1 = SmenSminpesoPSid[f];
                                    SmenSminpesoPSid[f] = SmenSminpesoPSid[f + 1];
                                    SmenSminpesoPSid[f + 1] = aux1;
                                    aux2 = pesoidPS[f];
                                    pesoidPS[f] = pesoidPS[f + 1];
                                    pesoidPS[f + 1] = aux2;
                                }
                            }
                        }

                        for (int k = 0; k < SmenSminpesoPS.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPS.Count - 1 - k; f++)
                            {
                                if (pesoidPS[f] > pesoidPS[f + 1])
                                {
                                    double aux;
                                    int aux1;
                                    aux = pesoidPS[f];
                                    pesoidPS[f] = pesoidPS[f + 1];
                                    pesoidPS[f + 1] = aux;
                                    aux1 = SmenSminpesoPSid[f];
                                    SmenSminpesoPSid[f] = SmenSminpesoPSid[f + 1];
                                    SmenSminpesoPSid[f + 1] = aux1;

                                }
                            }
                        }

                        for (int i = 0; i < SmenSminpesoPSid.Count; i++)
                        {
                            lbperf.Items.Add(SmenSminpesoPSid[i]);
                        }

                        if (SmenSminpesoPS.Count >= 1)
                        {
                            idvgsda = SmenSminpesoPSid[0];
                            //mostrar el nombre de la viga
                            txtVgsda.Text = psus1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = psus1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = psus1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = psus1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = psus1.Rows[idvgsda - 1][7].ToString();

                            lbldPerf.Text = "d [in]";
                            lblbfPerf.Text = "bf [in]";
                            lbltfPerf.Text = "tf [in]";
                            lbltwPerf.Text = "tw [in]";

                            lblspa.Text = "Esfuerzo principal en a [ksi]:";
                            lblspb.Text = "Esfuerzo principal en b [ksi]:";
                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(psus1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(psus1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(psus1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(psus1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(psus1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(psus1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS * 12) / (s);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            spa = sa;
                            spa = Math.Round(spa, 4);
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            spb = Math.Round(spb, 4);

                            txtspa.Text = spa.ToString();
                            txtspb.Text = spb.ToString();

                            string prefijo = "";

                            if (sa > 0 && sa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sa >= 1000000 && sa < 1000000000)
                            {
                                sa = sa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sa >= 1000000000)
                            {
                                sa = sa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sb >= 1000000 && sb < 1000000000)
                            {
                                sb = sb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sb >= 1000000000)
                            {
                                sb = sb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (cb >= 1000000 && cb < 1000000000)
                            {
                                cb = cb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (cb >= 1000000000)
                            {
                                cb = cb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spa >= 1000000 && spa < 1000000000)
                            {
                                spa = spa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spa >= 1000000000)
                            {
                                spa = spa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spb >= 1000000 && spb < 1000000000)
                            {
                                spb = spb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spb >= 1000000000)
                            {
                                spb = spb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;

                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfils.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/images.png");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://store.buymetal.com";
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil se adapta a la configuración de la viga");
                        }
                    }
                    else if (cbPfPP.SelectedIndex == 3 && unidades == 0)
                    {
                        for (int i = 0; i < pcis1.Rows.Count; i++)
                        {

                            if (double.Parse(pcis1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPC.Add(double.Parse(pcis1.Rows[i][2].ToString()));
                                SmenSminpesoPCid.Add(int.Parse(pcis1.Rows[i][0].ToString()));
                                pesoidPC.Add(double.Parse(pcis1.Rows[i][4].ToString()));
                            }

                        }



                        for (int k = 0; k < SmenSminpesoPC.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPC.Count - 1 - k; f++)
                            {
                                if (SmenSminpesoPC[f] > SmenSminpesoPC[f + 1])
                                {
                                    double aux, aux2;
                                    int aux1;
                                    aux = SmenSminpesoPC[f];
                                    SmenSminpesoPC[f] = SmenSminpesoPC[f + 1];
                                    SmenSminpesoPC[f + 1] = aux;

                                    aux1 = SmenSminpesoPCid[f];
                                    SmenSminpesoPCid[f] = SmenSminpesoPCid[f + 1];
                                    SmenSminpesoPCid[f + 1] = aux1;
                                    aux2 = pesoidPC[f];
                                    pesoidPC[f] = pesoidPC[f + 1];
                                    pesoidPC[f + 1] = aux2;
                                }
                            }
                        }

                        for (int k = 0; k < SmenSminpesoPC.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPC.Count - 1 - k; f++)
                            {
                                if (pesoidPC[f] > pesoidPC[f + 1])
                                {
                                    double aux;
                                    int aux1;
                                    aux = pesoidPC[f];
                                    pesoidPC[f] = pesoidPC[f + 1];
                                    pesoidPC[f + 1] = aux;
                                    aux1 = SmenSminpesoPCid[f];
                                    SmenSminpesoPCid[f] = SmenSminpesoPCid[f + 1];
                                    SmenSminpesoPCid[f + 1] = aux1;

                                }
                            }
                        }

                        for (int i = 0; i < SmenSminpesoPCid.Count; i++)
                        {
                            lbperf.Items.Add(SmenSminpesoPCid[i]);
                        }

                        if (SmenSminpesoPC.Count >= 1)
                        {
                            idvgsda = SmenSminpesoPCid[0];
                            //mostrar el nombre de la viga
                            txtVgsda.Text = pcis1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pcis1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pcis1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pcis1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pcis1.Rows[idvgsda - 1][7].ToString();
                            lbldPerf.Text = "d [mm]";
                            lblbfPerf.Text = "bf [mm]";
                            lbltfPerf.Text = "tf [mm]";
                            lbltwPerf.Text = "tw [mm]";

                         
                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pcis1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pcis1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pcis1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pcis1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pcis1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pcis1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS) / (s * 1000);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            cb = cb / 1000;
                            spa = sa; // en megapascales
                   
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));






                            string prefijo = "";

                            if (sa > 0 && sa < 0.001)
                            {
                                sa = sa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sa >= 0.001 && sa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sa >= 1000)
                            {
                                sa = sa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 0.001)
                            {
                                sb = sb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (sb >= 0.001 && sb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (sb >= 1000)
                            {
                                sb = sb / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 0.001)
                            {
                                cb = cb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (cb >= 0.001 && cb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (cb >= 1000)
                            {
                                cb = cb / 1000;
                                prefijo = "[GPa]";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 0.001)
                            {
                                spa = spa * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spa >= 0.001 && spa < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spa >= 1000)
                            {
                                spa = spa / 1000;
                                prefijo = "[GPa]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 0.001)
                            {
                                spb = spb * 1000;
                                prefijo = "[kPa]:";
                            }
                            else if (spb >= 0.001 && spb < 1000)
                            {

                                prefijo = "[MPa]:";
                            }
                            else if (spb >= 1000)
                            {
                                spb = spb / 1000;
                                prefijo = "[GPa]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;

                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil se adapta a la configuración de la viga");
                        }
                    }
                    else if (cbPfPP.SelectedIndex == 3 && unidades == 1)
                    {
                        for (int i = 0; i < pcus1.Rows.Count; i++)
                        {

                            if (double.Parse(pcus1.Rows[i][2].ToString()) >= Smin)
                            {

                                SmenSminpesoPC.Add(double.Parse(pcus1.Rows[i][2].ToString()));
                                SmenSminpesoPCid.Add(int.Parse(pcus1.Rows[i][0].ToString()));
                                pesoidPC.Add(double.Parse(pcus1.Rows[i][4].ToString()));
                            }

                        }



                        for (int k = 0; k < SmenSminpesoPC.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPC.Count - 1 - k; f++)
                            {
                                if (SmenSminpesoPC[f] > SmenSminpesoPC[f + 1])
                                {
                                    double aux, aux2;
                                    int aux1;
                                    aux = SmenSminpesoPC[f];
                                    SmenSminpesoPC[f] = SmenSminpesoPC[f + 1];
                                    SmenSminpesoPC[f + 1] = aux;

                                    aux1 = SmenSminpesoPCid[f];
                                    SmenSminpesoPCid[f] = SmenSminpesoPCid[f + 1];
                                    SmenSminpesoPCid[f + 1] = aux1;
                                    aux2 = pesoidPC[f];
                                    pesoidPC[f] = pesoidPC[f + 1];
                                    pesoidPC[f + 1] = aux2;
                                }
                            }
                        }

                        for (int k = 0; k < SmenSminpesoPC.Count - 1; k++)
                        {
                            for (int f = 0; f < SmenSminpesoPC.Count - 1 - k; f++)
                            {
                                if (pesoidPC[f] > pesoidPC[f + 1])
                                {
                                    double aux;
                                    int aux1;
                                    aux = pesoidPC[f];
                                    pesoidPC[f] = pesoidPC[f + 1];
                                    pesoidPC[f + 1] = aux;
                                    aux1 = SmenSminpesoPCid[f];
                                    SmenSminpesoPCid[f] = SmenSminpesoPCid[f + 1];
                                    SmenSminpesoPCid[f + 1] = aux1;

                                }
                            }
                        }

                        for (int i = 0; i < SmenSminpesoPCid.Count; i++)
                        {
                            lbperf.Items.Add(SmenSminpesoPCid[i]);
                        }

                        if (SmenSminpesoPC.Count >= 1)
                        {
                            idvgsda = SmenSminpesoPCid[0];
                            //mostrar el nombre de la viga
                            txtVgsda.Text = pcus1.Rows[idvgsda - 1][1].ToString();
                            txtdPerf.Text = pcus1.Rows[idvgsda - 1][3].ToString();
                            txtbfPerf.Text = pcus1.Rows[idvgsda - 1][5].ToString();
                            txttfPerf.Text = pcus1.Rows[idvgsda - 1][6].ToString();
                            txttwPerf.Text = pcus1.Rows[idvgsda - 1][7].ToString();
                            lbldPerf.Text = "d [in]";
                            lblbfPerf.Text = "bf [in]";
                            lbltfPerf.Text = "tf [in]";
                            lbltwPerf.Text = "tw [in]";

                            lblspa.Text = "Esfuerzo principal en a [ksi]:";
                            lblspb.Text = "Esfuerzo principal en b [ksi]:";
                            //cálculo del esfuerzo principal
                            double sa, s, sb, d, tf, bf, tw, ix, cb, v, areaq, ytq, q, spa, spb;
                            d = double.Parse(pcus1.Rows[idvgsda - 1][3].ToString());
                            tf = double.Parse(pcus1.Rows[idvgsda - 1][6].ToString());
                            s = double.Parse(pcus1.Rows[idvgsda - 1][2].ToString());
                            ix = double.Parse(pcus1.Rows[idvgsda - 1][8].ToString());
                            bf = double.Parse(pcus1.Rows[idvgsda - 1][5].ToString());
                            tw = double.Parse(pcus1.Rows[idvgsda - 1][7].ToString());

                            areaq = tf * bf;
                            ytq = 0.5 * d - 0.5 * tf;
                            q = areaq * ytq;
                            v = yDgCte[xdelyMtomayorABS];
                            v = Math.Abs(v);
                            sa = (yDgMtomayABS * 12) / (s);
                            sb = sa * (0.5 * d - tf) / (0.5 * d);
                            cb = (v * q) / (ix * tw);
                            spa = sa; 
                            spa = Math.Round(spa, 4);
                            spb = 0.5 * sb + Math.Sqrt(Math.Pow(0.5 * sb, 2) + Math.Pow(cb, 2));
                            spb = Math.Round(spb, 4);

                            txtspa.Text = spa.ToString();
                            txtspb.Text = spb.ToString();

                            string prefijo = "";

                            if (sa > 0 && sa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sa >= 1000000 && sa < 1000000000)
                            {
                                sa = sa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sa >= 1000000000)
                            {
                                sa = sa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblENena.Text = "Esfuerzo normal en a " + prefijo;
                            txtENena.Text = sa.ToString("0.000");
                            lblECena.Text = "Esfuerzo cortante en a " + prefijo;
                            txtECena.Text = "0";

                            if (sb > 0 && sb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (sb >= 1000000 && sb < 1000000000)
                            {
                                sb = sb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (sb >= 1000000000)
                            {
                                sb = sb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblEnenb.Text = "Esfuerzo normal en b " + prefijo;
                            txtENenb.Text = sb.ToString("0.000");

                            if (cb > 0 && cb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (cb >= 1000000 && cb < 1000000000)
                            {
                                cb = cb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (cb >= 1000000000)
                            {
                                cb = cb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblECenb.Text = "Esfuerzo cortante en b " + prefijo;
                            txtECenb.Text = cb.ToString("0.000");

                            if (spa > 0 && spa < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spa >= 1000000 && spa < 1000000000)
                            {
                                spa = spa / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spa >= 1000000000)
                            {
                                spa = spa / 1000000000;
                                prefijo = "[Gpsi]:";
                            }
                            lblspa.Text = "Esfuerzo principal en a " + prefijo;
                            txtspa.Text = spa.ToString();

                            if (spb > 0 && spb < 1000000)
                            {
                                prefijo = "[ksi]:";
                            }
                            else if (spb >= 1000000 && spb < 1000000000)
                            {
                                spb = spb / 1000000;
                                prefijo = "[Mpsi]:";
                            }
                            else if (spb >= 1000000000)
                            {
                                spb = spb / 1000000000;
                                prefijo = "[Gpsi]:";
                            }

                            txtspb.Text = spb.ToString();
                            lblspb.Text = "Esfuerzo principal en b " + prefijo;

                           
                            //dibujar perfil
                            pbPerf.Image = Image.FromFile("ilustraciones/perfilc.png");
                            pbPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            pbImaPerf.Image = Image.FromFile("ilustraciones/imagec.jpg");
                            pbImaPerf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            lblImgPerf.Text = "Tomado de: " + "https://www.coremarkmetals.com";
                        }
                        else
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ningún perfil se adapta a la configuración de la viga");
                        }
                    }


                }

                tabCgVgPP.Invalidate();



            }


        }

        private void btnPenyDflx_Click(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.Controls.Remove(tabPenyDflx);
            }
            TabCtrlPanelPrincipal.Controls.Add(tabPenyDflx);
            yDgPend.Clear();
            yDgDflx.Clear();
            chartPend.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartPend.ChartAreas[0].AxisY.CustomLabels.Clear();
            chartDefl.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartDefl.ChartAreas[0].AxisY.CustomLabels.Clear();
            //vectores para dibujos(digramas)
            for (int i = 0; i <= 1000; i++)
            {
                yDgPend.Insert(i, 0);
                yDgDflx.Insert(i, 0);
            }
            //diagrama de deflexion

            if (indPesñMat == 0 && unidades == 0)
            {
                ME = 200; //gigapasscales
            }
            else if (indPesñMat == 0 && unidades == 1)
            {
                ME = 29; //mega psi
            }
        
       
          
            foreach (char pletra in txtVgsda.Text)
            {

                if (pletra.ToString() == "W" && unidades == 0)
                {
                    string name;
                    name = txtVgsda.Text;
                    for (int i = 0; i < pwis1.Rows.Count; i++)
                    {
                        if (name == pwis1.Rows[i][1].ToString())
                        {
                            In = Convert.ToDouble(pwis1.Rows[i][8].ToString());

                        }
                        
                    }
                    break;

                }
                else if (pletra.ToString() == "S" && unidades == 0)
                {
                    string name;
                    name = txtVgsda.Text;
                    for (int i = 0; i < psis1.Rows.Count; i++)
                    {
                        if (name == psis1.Rows[i][1].ToString())
                        {
                            In = Convert.ToDouble(psis1.Rows[i][8].ToString());

                        }

                    }
                    break;

                }
                else if (pletra.ToString() == "C" && unidades == 0)
                {
                    string name;
                    name = txtVgsda.Text;
                    for (int i = 0; i < pcis1.Rows.Count; i++)
                    {
                        if (name == pcis1.Rows[i][1].ToString())
                        {
                            In = Convert.ToDouble(pcis1.Rows[i][8].ToString());

                        }

                    }
                    break;
                }
                else if (pletra.ToString() == "W" && unidades == 1)
                {
                    string name;
                    name = txtVgsda.Text;
                    for (int i = 0; i < pwus1.Rows.Count; i++)
                    {
                        if (name == pwus1.Rows[i][1].ToString())
                        {
                            In = Convert.ToDouble(pwus1.Rows[i][8].ToString());

                        }
                        
                    }
                    break;
                }
                else if (pletra.ToString() == "S" && unidades == 1)
                {
                    string name;
                    name = txtVgsda.Text;
                    for (int i = 0; i < psus1.Rows.Count; i++)
                    {
                        if (name == psus1.Rows[i][1].ToString())
                        {
                            In = Convert.ToDouble(psus1.Rows[i][8].ToString());

                        }

                    }
                    break;
                }
                else if (pletra.ToString() == "C" && unidades == 1)
                {
                    string name;
                    name = txtVgsda.Text;
                    for (int i = 0; i < pcus1.Rows.Count; i++)
                    {
                        if (name == pcus1.Rows[i][1].ToString())
                        {
                            In = Convert.ToDouble(pcus1.Rows[i][8].ToString());

                        }

                    }
                    break;
                }


            }

            
        

            if (indTipApoy == 0)
            {
                    double C1, C2;

                    C2 = -fsin4(0);
                    C1 = -R1 * Math.Pow(l, 2) / 6 - fsin4(l) / l - C2 / l;
                ei = ME * In;
                if (unidades == 0)
                {
                    ei = ei / 1000000;
                }
                else if (unidades == 1)
                {
                    ei = ei * 1000;
                    ei = ei / 144;
                }
               

                for (int i = 0; i <= 1000; i++)
                {
                    yDgPend[i] = R1 * Math.Pow(xlabel[i], 2) / 2 + fsin3(xlabel[i]) + C1;
                    yDgPend[i] = (yDgPend[i]) / (ei);
                    yDgDflx[i] = R1 * Math.Pow(xlabel[i], 3) / 6 + fsin4(xlabel[i]) + C1 * xlabel[i] + C2;
                    yDgDflx[i] = (yDgDflx[i]) / (ei);
                    yDgDflx[i] = (yDgDflx[i]) * 1000;


                }

                //elemento mayor y menor de la pendiete
                yDgpenmay = yDgPend[0];
                yDgpenmen = yDgPend[0];
                yDgpenmayABS = Math.Abs(yDgPend[0]);
                yDgpenmenABS = Math.Abs(yDgPend[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgPend[i] > yDgpenmay)
                    {
                        yDgpenmay = yDgPend[i];
                    }
                    else if (yDgPend[i] < yDgpenmen) { yDgpenmen = yDgPend[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgPend[i]) > yDgpenmayABS)
                    {
                        yDgpenmayABS = Math.Abs(yDgPend[i]);
                        xdePenmayABS = i;

                    }
                    else if (Math.Abs(yDgPend[i]) < yDgpenmenABS) { yDgpenmenABS = Math.Abs(yDgPend[i]); }
                }

                //elemento mayor y menor de la delflexión
                yDgdflxmay = yDgDflx[0];
                yDgdflxmen = yDgDflx[0];
                yDgdflxmayABS = Math.Abs(yDgDflx[0]);
                yDgdflxmenABS = Math.Abs(yDgDflx[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgDflx[i] > yDgdflxmay)
                    {
                        yDgdflxmay = yDgDflx[i];
                    }
                    else if (yDgDflx[i] < yDgdflxmen) { yDgdflxmen = yDgDflx[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgDflx[i]) > yDgdflxmayABS)
                    {
                        yDgdflxmayABS = Math.Abs(yDgDflx[i]);
                        xdeDflxABS = i;

                    }
                    else if (Math.Abs(yDgDflx[i]) < yDgdflxmenABS) { yDgdflxmenABS = Math.Abs(yDgDflx[i]); }
                }


            }
            else if (indTipApoy == 1)
            {
                double C1, C2;

                C2 = -fsin4(0);
                C1 = -R1 * Math.Pow(ltv, 2) / 6 - fsin4(ltv) / ltv - C2 / ltv;

                ei = ME * In;
                if (unidades == 0)
                {
                    ei = ei / 1000000;
                }
                else if (unidades == 1)
                {
                    ei = ei * 1000;
                    ei = ei / 144;
                }

                for (int i = 0; i <= 1000; i++)
                {
                    yDgPend[i] = R1 * Math.Pow(xlabel[i], 2) / 2 + fsin3(xlabel[i]) + C1 + R2*Fn.FSingMCDR(ltv,xlabel[i]);
                    yDgPend[i] = (yDgPend[i]) / (ei);
                    yDgDflx[i] = R1 * Math.Pow(xlabel[i], 3) / 6 + fsin4(xlabel[i]) + C1 * xlabel[i] + C2 + R2 * Fn.FSingMCDTPP(ltv, xlabel[i]);
                    yDgDflx[i] = (yDgDflx[i]) / (ei);
                    yDgDflx[i] = (yDgDflx[i]) * 1000;
                }

                //elemento mayor y menor de la pendiete
                yDgpenmay = yDgPend[0];
                yDgpenmen = yDgPend[0];
                yDgpenmayABS = Math.Abs(yDgPend[0]);
                yDgpenmenABS = Math.Abs(yDgPend[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgPend[i] > yDgpenmay)
                    {
                        yDgpenmay = yDgPend[i];
                    }
                    else if (yDgPend[i] < yDgpenmen) { yDgpenmen = yDgPend[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgPend[i]) > yDgpenmayABS)
                    {
                        yDgpenmayABS = Math.Abs(yDgPend[i]);
                        xdePenmayABS = i;

                    }
                    else if (Math.Abs(yDgPend[i]) < yDgpenmenABS) { yDgpenmenABS = Math.Abs(yDgPend[i]); }
                }

                //elemento mayor y menor de la delflexión
                yDgdflxmay = yDgDflx[0];
                yDgdflxmen = yDgDflx[0];
                yDgdflxmayABS = Math.Abs(yDgDflx[0]);
                yDgdflxmenABS = Math.Abs(yDgDflx[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgDflx[i] > yDgdflxmay)
                    {
                        yDgdflxmay = yDgDflx[i];
                    }
                    else if (yDgDflx[i] < yDgdflxmen) { yDgdflxmen = yDgDflx[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgDflx[i]) > yDgdflxmayABS)
                    {
                        yDgdflxmayABS = Math.Abs(yDgDflx[i]);
                        xdeDflxABS = i;

                    }
                    else if (Math.Abs(yDgDflx[i]) < yDgdflxmenABS) { yDgdflxmenABS = Math.Abs(yDgDflx[i]); }
                }
            }
            else if (indTipApoy == 2)
            {
                double C1, C2;

                C2 = -fsin4(0);
                C1 = -fsin3(0);

                ei = ME * In;
                if (unidades == 0)
                {
                    ei = ei / 1000000;
                }
                else if (unidades == 1)
                {
                    ei = ei * 1000;
                    ei = ei / 144;
                }

                for (int i = 0; i <= 1000; i++)
                {
                    yDgPend[i] = R1 * Math.Pow(xlabel[i], 2) / 2 + fsin3(xlabel[i]) + C1 - MR * xlabel[i];
                    yDgPend[i] = (yDgPend[i]) / (ei);
                    yDgDflx[i] = R1 * Math.Pow(xlabel[i], 3) / 6 + fsin4(xlabel[i]) + C1 * xlabel[i] + C2 - MR * Fn.FSingMCDR(0, xlabel[i]);
                    yDgDflx[i] = (yDgDflx[i]) / (ei);
                    yDgDflx[i] = (yDgDflx[i]) * 1000;
                }

                //elemento mayor y menor de la pendiete
                yDgpenmay = yDgPend[0];
                yDgpenmen = yDgPend[0];
                yDgpenmayABS = Math.Abs(yDgPend[0]);
                yDgpenmenABS = Math.Abs(yDgPend[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgPend[i] > yDgpenmay)
                    {
                        yDgpenmay = yDgPend[i];
                    }
                    else if (yDgPend[i] < yDgpenmen) { yDgpenmen = yDgPend[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgPend[i]) > yDgpenmayABS)
                    {
                        yDgpenmayABS = Math.Abs(yDgPend[i]);
                        xdePenmayABS = i;

                    }
                    else if (Math.Abs(yDgPend[i]) < yDgpenmenABS) { yDgpenmenABS = Math.Abs(yDgPend[i]); }
                }

                //elemento mayor y menor de la delflexión
                yDgdflxmay = yDgDflx[0];
                yDgdflxmen = yDgDflx[0];
                yDgdflxmayABS = Math.Abs(yDgDflx[0]);
                yDgdflxmenABS = Math.Abs(yDgDflx[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgDflx[i] > yDgdflxmay)
                    {
                        yDgdflxmay = yDgDflx[i];
                    }
                    else if (yDgDflx[i] < yDgdflxmen) { yDgdflxmen = yDgDflx[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgDflx[i]) > yDgdflxmayABS)
                    {
                        yDgdflxmayABS = Math.Abs(yDgDflx[i]);
                        xdeDflxABS = i;

                    }
                    else if (Math.Abs(yDgDflx[i]) < yDgdflxmenABS) { yDgdflxmenABS = Math.Abs(yDgDflx[i]); }
                }
            }
            else if (indTipApoy == 3)
            {
                double C1, C2;

                C2 = -fsin4(0);
                C1 = -Ra * Math.Pow(lcon, 2) / 6  - fsin4(lcon) / lcon - C2 / l;

                ei = ME * In;
                if (unidades == 0)
                {
                    ei = ei / 1000000;
                }
                else if (unidades == 1)
                {
                    ei = ei * 1000;
                    ei = ei / 144;
                }

                for (int i = 0; i <= 1000; i++)
                {
                    yDgPend[i] = Ra * Math.Pow(xlabel[i], 2) / 2 + Rb*Fn.FSingMCDR(lcon,xlabel[i]) + fsin3(xlabel[i]) + C1;
                    yDgPend[i] = (yDgPend[i]) / (ei);
                    yDgDflx[i] = Ra * Math.Pow(xlabel[i], 3) / 6 + Rb*Fn.FSingMCDTPP(lcon,xlabel[i]) + fsin4(xlabel[i]) + C1 * xlabel[i] + C2 ;
                    yDgDflx[i] = (yDgDflx[i]) / (ei);
                    yDgDflx[i] = (yDgDflx[i]) * 1000;
                }

                //elemento mayor y menor de la pendiete
                yDgpenmay = yDgPend[0];
                yDgpenmen = yDgPend[0];
                yDgpenmayABS = Math.Abs(yDgPend[0]);
                yDgpenmenABS = Math.Abs(yDgPend[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgPend[i] > yDgpenmay)
                    {
                        yDgpenmay = yDgPend[i];
                    }
                    else if (yDgPend[i] < yDgpenmen) { yDgpenmen = yDgPend[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgPend[i]) > yDgpenmayABS)
                    {
                        yDgpenmayABS = Math.Abs(yDgPend[i]);
                        xdePenmayABS = i;

                    }
                    else if (Math.Abs(yDgPend[i]) < yDgpenmenABS) { yDgpenmenABS = Math.Abs(yDgPend[i]); }
                }

                //elemento mayor y menor de la delflexión
                yDgdflxmay = yDgDflx[0];
                yDgdflxmen = yDgDflx[0];
                yDgdflxmayABS = Math.Abs(yDgDflx[0]);
                yDgdflxmenABS = Math.Abs(yDgDflx[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgDflx[i] > yDgdflxmay)
                    {
                        yDgdflxmay = yDgDflx[i];
                    }
                    else if (yDgDflx[i] < yDgdflxmen) { yDgdflxmen = yDgDflx[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgDflx[i]) > yDgdflxmayABS)
                    {
                        yDgdflxmayABS = Math.Abs(yDgDflx[i]);
                        xdeDflxABS = i;

                    }
                    else if (Math.Abs(yDgDflx[i]) < yDgdflxmenABS) { yDgdflxmenABS = Math.Abs(yDgDflx[i]); }
                }
            }
            else if (indTipApoy == 4)
            {
                double C1, C2;

                C2 = -fsin4(0);
                C1 = -fsin3(0);

                ei = ME * In;
                if (unidades == 0)
                {
                    ei = ei / 1000000;
                }
                else if (unidades == 1)
                {
                    ei = ei * 1000;
                    ei = ei / 144;
                }

                for (int i = 0; i <= 1000; i++)
                {
                    yDgPend[i] = Ra * Math.Pow(xlabel[i], 2) / 2 - Ma * xlabel[i] + fsin3(xlabel[i]) + C1;
                    yDgPend[i] = (yDgPend[i]) / (ei);
                    yDgDflx[i] = Ra * Math.Pow(xlabel[i], 3) / 6 - Ma * Math.Pow(xlabel[i],2) / 2 + fsin4(xlabel[i]) + C1 * xlabel[i] + C2;
                    yDgDflx[i] = (yDgDflx[i]) / (ei);
                    yDgDflx[i] = (yDgDflx[i]) * 1000;
                }

                //elemento mayor y menor de la pendiete
                yDgpenmay = yDgPend[0];
                yDgpenmen = yDgPend[0];
                yDgpenmayABS = Math.Abs(yDgPend[0]);
                yDgpenmenABS = Math.Abs(yDgPend[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgPend[i] > yDgpenmay)
                    {
                        yDgpenmay = yDgPend[i];
                    }
                    else if (yDgPend[i] < yDgpenmen) { yDgpenmen = yDgPend[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgPend[i]) > yDgpenmayABS)
                    {
                        yDgpenmayABS = Math.Abs(yDgPend[i]);
                        xdePenmayABS = i;

                    }
                    else if (Math.Abs(yDgPend[i]) < yDgpenmenABS) { yDgpenmenABS = Math.Abs(yDgPend[i]); }
                }

                //elemento mayor y menor de la delflexión
                yDgdflxmay = yDgDflx[0];
                yDgdflxmen = yDgDflx[0];
                yDgdflxmayABS = Math.Abs(yDgDflx[0]);
                yDgdflxmenABS = Math.Abs(yDgDflx[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgDflx[i] > yDgdflxmay)
                    {
                        yDgdflxmay = yDgDflx[i];
                    }
                    else if (yDgDflx[i] < yDgdflxmen) { yDgdflxmen = yDgDflx[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgDflx[i]) > yDgdflxmayABS)
                    {
                        yDgdflxmayABS = Math.Abs(yDgDflx[i]);
                        xdeDflxABS = i;

                    }
                    else if (Math.Abs(yDgDflx[i]) < yDgdflxmenABS) { yDgdflxmenABS = Math.Abs(yDgDflx[i]); }
                }
            }
            else if (indTipApoy == 5)
            {
                double C1, C2;

                C2 = -fsin4(0);
                C1 = -fsin3(0);

                ei = ME * In;
                if (unidades == 0)
                {
                    ei = ei / 1000000;
                }
                else if (unidades == 1)
                {
                    ei = ei * 1000;
                    ei = ei / 144;
                }

                for (int i = 0; i <= 1000; i++)
                {
                    yDgPend[i] = Ra * Math.Pow(xlabel[i], 2) / 2 + Ma * xlabel[i] + fsin3(xlabel[i]) + C1;
                    yDgPend[i] = (yDgPend[i]) / (ei);
                    yDgDflx[i] = Ra * Math.Pow(xlabel[i], 3) / 6 + Ma * Math.Pow(xlabel[i], 2) / 2 + fsin4(xlabel[i]) + C1 * xlabel[i] + C2;
                    yDgDflx[i] = (yDgDflx[i]) / (ei);
                    yDgDflx[i] = (yDgDflx[i]) * 1000;
                }

                //elemento mayor y menor de la pendiete
                yDgpenmay = yDgPend[0];
                yDgpenmen = yDgPend[0];
                yDgpenmayABS = Math.Abs(yDgPend[0]);
                yDgpenmenABS = Math.Abs(yDgPend[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgPend[i] > yDgpenmay)
                    {
                        yDgpenmay = yDgPend[i];
                    }
                    else if (yDgPend[i] < yDgpenmen) { yDgpenmen = yDgPend[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgPend[i]) > yDgpenmayABS)
                    {
                        yDgpenmayABS = Math.Abs(yDgPend[i]);
                        xdePenmayABS = i;

                    }
                    else if (Math.Abs(yDgPend[i]) < yDgpenmenABS) { yDgpenmenABS = Math.Abs(yDgPend[i]); }
                }

                //elemento mayor y menor de la delflexión
                yDgdflxmay = yDgDflx[0];
                yDgdflxmen = yDgDflx[0];
                yDgdflxmayABS = Math.Abs(yDgDflx[0]);
                yDgdflxmenABS = Math.Abs(yDgDflx[0]);
                for (int i = 0; i <= 1000; i++)
                {
                    if (yDgDflx[i] > yDgdflxmay)
                    {
                        yDgdflxmay = yDgDflx[i];
                    }
                    else if (yDgDflx[i] < yDgdflxmen) { yDgdflxmen = yDgDflx[i]; }
                }
                for (int i = 0; i <= 1000; i++)
                {
                    if (Math.Abs(yDgDflx[i]) > yDgdflxmayABS)
                    {
                        yDgdflxmayABS = Math.Abs(yDgDflx[i]);
                        xdeDflxABS = i;

                    }
                    else if (Math.Abs(yDgDflx[i]) < yDgdflxmenABS) { yDgdflxmenABS = Math.Abs(yDgDflx[i]); }
                }
            }
            //dibujar
            chartPend.Series.Clear();
            chartPend.Series.Add("Diagrama pendiente"); //[0]
            chartPend.Series.Add("Linea 0"); //[1]
            chartPend.Series.Add("Linea abrir diagrama pendiente"); //[2]
            chartPend.Series.Add("Linea Cerrar diagrama pendiente"); //[3]
            chartPend.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartPend.Series[0].Color = Color.Blue;
            chartPend.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chartPend.Series[1].Color = Color.Red;
            chartPend.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartPend.Series[2].Color = Color.Blue;
            chartPend.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartPend.Series[3].Color = Color.Blue;
            if (unidades == 0)
            {
                chartPend.ChartAreas[0].AxisX.Title = "x [m]";
                chartPend.ChartAreas[0].AxisY.Title = "tetha [rad]";
            }
            else if (unidades == 1)
            {
                chartPend.ChartAreas[0].AxisX.Title = "x [ft]";
                chartPend.ChartAreas[0].AxisY.Title = "tetha [rad]";
            }

            chartPend.ChartAreas[0].AxisX.Minimum = 0 - 0.05 * l;
            chartPend.ChartAreas[0].AxisX.Maximum = l + 0.05 * l;
            chartPend.ChartAreas[0].AxisY.Minimum = yDgpenmen - Math.Abs(yDgpenmen) * 0.15;
            chartPend.ChartAreas[0].AxisY.Maximum = yDgpenmay + Math.Abs(yDgpenmay) * 0.15;
            chartPend.ChartAreas[0].AxisX.LabelStyle.Format = "{0.00}";
            chartPend.ChartAreas[0].AxisY.LabelStyle.Format = "{0.000e+0}";
            chartPend.Series[0].BorderWidth = 2;
            chartPend.Series[1].BorderWidth = 2;
            chartPend.Series[2].BorderWidth = 2;
            chartPend.Series[3].BorderWidth = 2;
            chartPend.Legends.Clear();

            for (int i = 0; i <= 1000; i++)
            {
                chartPend.Series[0].Points.AddXY(xlabel[i], yDgPend[i]);
            }

            for (int z = 0; z <= 1000; z++)
            {
                chartPend.Series[1].Points.AddXY(xlabel[z], 0);
            }

            //asignarle un valor a ns para organizar series
            ns1 = 3;

            //abrir el comienzo del diagrama pendiente

            yDgPOpen[0] = 0;
            yDgPOpen[1] = yDgPend[0];
            for (int i = 0; i < 2; i++)
            {
                chartPend.Series[2].Points.AddXY(0, yDgPOpen[i]);
            }
            //cerrar diagrama cortante
            yDgPClose[0] = 0;
            yDgPClose[1] = yDgPend[1000];
            for (int i = 0; i < 2; i++)
            {
                chartPend.Series[3].Points.AddXY(l, yDgPClose[i]);
            }

            //etiqueta a puntos en diagrama cortante
            if (yDgPend[0] != 0)
            {
                chartPend.Series[0].Points[0].Label = yDgPend[0].ToString(); //etiqueta en 0
            }

            chartPend.Series[0].Points[1000].Label = yDgPend[1000].ToString(); //eqtiqueta en l


            if (indTipApoy == 1)
            {
                ns1 = 4; //[4]
                chartPend.Series.Add("labeldelltv");
                chartPend.Series[ns1].Points.AddXY(ltv + 0.02 * l, Yptv(ltv));
                chartPend.Series[ns1].MarkerSize = 0;
                chartPend.Series[ns1].Points[0].Label = Yptv(ltv).ToString();
                chartPend.Series[ns1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
            else if (indTipApoy == 3)
            {
                ns1 = 4; //[4]
                chartPend.Series.Add("labeldelltv");
                chartPend.Series[ns1].Points.AddXY(lcon + 0.02 * l, Ypc(lcon));
                chartPend.Series[ns1].MarkerSize = 0;
                chartPend.Series[ns1].Points[0].Label = Ypc(lcon).ToString();
                chartPend.Series[ns1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }


            chartPend.Series.Add("ymayor"); //[4] o [5] 



            if (xlabel[xdePenmayABS] !=0 && xlabel[xdePenmayABS] != l)
            {
                chartPend.Series[ns1 + 1].Points.AddXY(xlabel[xdePenmayABS] + 0.02 * l, yDgPend[xdePenmayABS]);
                chartPend.Series[ns1 + 1].MarkerSize = 0;
                chartPend.Series[ns1 + 1].Points[0].Label = yDgPend[xdePenmayABS].ToString();
                chartPend.Series[ns1 + 1].Points[0].Label.PadLeft(1);
                chartPend.Series[ns1 + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
        

    
                


            

            chartPend.Series.Add("puntoseguidor"); //[5] o [6]


            // diagrama de delflexión
            chartDefl.Series.Clear();
            chartDefl.Series.Add("Diagrama delfexion"); //[0]
            chartDefl.Series.Add("Linea 0"); //[1]
            chartDefl.Series.Add("Linea abrir diagrama delfexion"); //[2]
            chartDefl.Series.Add("Linea Cerrar diagrama deflexion"); //[3]
            chartDefl.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartDefl.Series[0].Color = Color.Blue;
            chartDefl.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chartDefl.Series[1].Color = Color.Red;
            chartDefl.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartDefl.Series[2].Color = Color.Blue;
            chartDefl.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartDefl.Series[3].Color = Color.Blue;
            if (unidades == 0)
            {
                chartDefl.ChartAreas[0].AxisX.Title = "x [m]";
                chartDefl.ChartAreas[0].AxisY.Title = "Deflexión [mm]";
            }
            else if (unidades == 1)
            {
                chartDefl.ChartAreas[0].AxisX.Title = "x [ft]";
                chartDefl.ChartAreas[0].AxisY.Title = "Deflexión [in]";
            }

            chartDefl.ChartAreas[0].AxisX.Minimum = 0 - 0.05 * l;
            chartDefl.ChartAreas[0].AxisX.Maximum = l + 0.05 * l;
            chartDefl.ChartAreas[0].AxisY.Minimum = yDgdflxmen - Math.Abs(yDgdflxmen) * 0.15;
            chartDefl.ChartAreas[0].AxisY.Maximum = yDgdflxmay + Math.Abs(yDgdflxmay) * 0.15;
            chartDefl.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
            chartDefl.ChartAreas[0].AxisY.LabelStyle.Format = "{0.000e+0}";
            chartDefl.Series[0].BorderWidth = 2;
            chartDefl.Series[1].BorderWidth = 2;
            chartDefl.Series[2].BorderWidth = 2;
            chartDefl.Series[3].BorderWidth = 2;
            chartDefl.Legends.Clear();

            for (int i = 0; i <= 1000; i++)
            {
                chartDefl.Series[0].Points.AddXY(xlabel[i], yDgDflx[i]);
            }

            for (int z = 0; z <= 1000; z++)
            {
                chartDefl.Series[1].Points.AddXY(xlabel[z], 0);
            }

            //asignarle un valor a ns para organizar series
            ns1 = 3;

            //abrir el comienzo del diagrama pendiente

            yDgDOpen[0] = 0;
            yDgDOpen[1] = yDgDflx[0];
            for (int i = 0; i < 2; i++)
            {
                chartDefl.Series[2].Points.AddXY(0, yDgDOpen[i]);
            }
            //cerrar diagrama cortante
            yDgDClose[0] = 0;
            yDgDClose[1] = yDgDflx[1000];
            for (int i = 0; i < 2; i++)
            {
                chartDefl.Series[3].Points.AddXY(l, yDgDClose[i]);
            }

            //etiqueta a puntos en diagrama cortante
            if (yDgDflx[0] != 0)
            {
                chartDefl.Series[0].Points[0].Label = yDgDflx[0].ToString(); //etiqueta en 0
            }

            chartDefl.Series[0].Points[1000].Label = yDgDflx[1000].ToString(); //eqtiqueta en l


            if (indTipApoy == 1)
            {
                ns1 = 4; //[4]
                chartDefl.Series.Add("labeldelltv");
                chartDefl.Series[ns1].Points.AddXY(ltv + 0.02 * l, Ydtv(ltv));
                chartDefl.Series[ns1].MarkerSize = 0;
                chartDefl.Series[ns1].Points[0].Label = Ydtv(ltv).ToString();
                chartDefl.Series[ns1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
            else if (indTipApoy == 3)
            {
                ns1 = 4; //[4]
                chartDefl.Series.Add("labeldelltv");
                chartDefl.Series[ns1].Points.AddXY(lcon + 0.02 * l, Ydc(lcon));
                chartDefl.Series[ns1].MarkerSize = 0;
                chartDefl.Series[ns1].Points[0].Label = Ydc(lcon).ToString();
                chartDefl.Series[ns1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }


            chartDefl.Series.Add("ymayor"); //[4] o [5] 



            if (xlabel[xdeDflxABS] != 0 && xlabel[xdeDflxABS] != l)
            {
                chartDefl.Series[ns1 + 1].Points.AddXY(xlabel[xdeDflxABS] + 0.02 * l, yDgDflx[xdeDflxABS]);
                chartDefl.Series[ns1 + 1].MarkerSize = 0;
                chartDefl.Series[ns1 + 1].Points[0].Label = yDgDflx[xdeDflxABS].ToString();
                chartDefl.Series[ns1 + 1].Points[0].Label.PadLeft(1);
                chartDefl.Series[ns1 + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }








            chartDefl.Series.Add("puntoseguidor"); //[5] o [6]








            //barrra de herramientas
            btnSegui.Image = Image.FromFile("ilustraciones/btnCxV.png");
            //anotaciones debajo del chart
            if (unidades == 0)
            {
                lblPendMay.Text = "tetha (mayor absoluto) en x = " + xlabel[xdePenmayABS].ToString() + " [rad]";
                lblDeflmayAbs.Text = "Deflexión (mayor absoluta) en x = " + xlabel[xdeDflxABS].ToString() + " [mm]";

            }
            else if (unidades == 1)
            {
                lblPendMay.Text = "tetha (mayor absoluto) en x = " + xlabel[xdePenmayABS].ToString() + " [rad]";
                lblDeflmayAbs.Text = "Deflexión (mayor absoluta) en x = " + xlabel[xdeDflxABS].ToString() + " [in]";
            }
            txtPenMay.Text = yDgpenmayABS.ToString("0.00e+0");
            txtPenenxplot.Text = yDgPend[0].ToString("0.00e+0");
            txtDeflmayAbs.Text = yDgdflxmayABS.ToString("0.00e+0");
            txtDeflenx.Text = yDgDflx[0].ToString("0.00e+0");

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabCtrlPanelPrincipal.Controls.Contains(tabDiag) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabDiag);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPerf) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPerf);
            }
            if (TabCtrlPanelPrincipal.Controls.Contains(tabPenyDflx) == true)
            {
                TabCtrlPanelPrincipal.TabPages.Remove(tabPenyDflx);
            }
            indTipApoy = cbApyPP.SelectedIndex;

            if (indTipApoy != 1)
            {
                pyc.Visible = false;
                ltvst.Visible = false;
            }
            else if (indTipApoy != 3)
            {
                pyc9.Visible = false;
                lconst.Visible = false;
            }
          
            //mostrar viga simplemente apoyada

            switch (indTipApoy)
            {
                case 0:
                    lcon = 0;
                    ltv = 0;
                       ltvst.Visible = false;
                    pyc.Visible = false;
                    lconst.Visible = false;
                    pyc9.Visible = false;
                    pyc2.Visible = false;
                    pyc3.Visible = false;
                    pyc4.Visible = false;
                    pyc5.Visible = false;
                    pyc6.Visible = false;
                    pyc7.Visible = false;
                    pyc8.Visible = false;
                    R1st.Visible = false;
                    R2st.Visible = false;
                    Rast.Visible = false;
                    Rbst.Visible = false;
                    Rcst.Visible = false;
                    MRst.Visible = false;
                    Mbst.Visible = false;

                    tabCgVgPP.Invalidate();
                       break;

                case 1:
                    if (txtLPP.Text == "" | txtLPP.Text == "0")
                    {
                        MssBox mssBox = new MssBox();
                        mssBox.Muestra("Ingrese primero longitud de la viga");
                        cbApyPP.SelectedIndex = 0;
                        txtLPP.Focus();
                    }
                    else
                    {
                        if (tv == 0)
                        {
                            tabCgVgPP.Invalidate();
                            PagVgTV tV = new PagVgTV();
                            if (Mtst.Visible == true)
                            {
                                pyc.Visible = true;
                                ltvst.Visible = true;
                                ltvst.Text = "ltv = " + ltv.ToString("0.000");
                            }
                            else
                            {
                                pyc.Visible = false;
                                ltvst.Visible = true;
                                ltvst.Text = "ltv = " + ltv.ToString("0.000");
                            }
                            pyc2.Visible = false;
                            pyc3.Visible = false;
                            pyc4.Visible = false;
                            pyc5.Visible = false;
                            pyc6.Visible = false;
                            pyc7.Visible = false;
                            pyc8.Visible = false;
                            pyc9.Visible = false;
                            R1st.Visible = false;
                            R2st.Visible = false;
                            Rast.Visible = false;
                            Rbst.Visible = false;
                            Rcst.Visible = false;
                            MRst.Visible = false;
                            Mbst.Visible = false;
                            lconst.Visible = false;



                            if (tV.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                            {
                                if (cbApyPP.SelectedIndex != 0)
                                {
                                    cbApyPP.SelectedIndex = 0;
                                }

                            }
                         
                            
                        }
                  


                       
                    }
                    tabCgVgPP.Invalidate();

                    break;

                case 2:
                    lcon = 0;
                    ltv = 0;
                    ltvst.Visible = false;
                    pyc2.Visible = false;
                    pyc3.Visible = false;
                    pyc4.Visible = false;
                    pyc5.Visible = false;
                    pyc6.Visible = false;
                    pyc7.Visible = false;
                    pyc8.Visible = false;
                    pyc9.Visible = false;
                    R1st.Visible = false;
                    R2st.Visible = false;
                    Rast.Visible = false;
                    Rbst.Visible = false;
                    Rcst.Visible = false;
                    MRst.Visible = false;
                    Mbst.Visible = false;
                    lconst.Visible = false;

                    tabCgVgPP.Invalidate();
                    break;

                case 3:
               
                    //agregar opcion cuando sea desde abrir txt o drop
                    if (tc == 0)
                    {
                        if (txtLPP.Text == "" | txtLPP.Text == "0")
                        {
                            MssBox mssBox = new MssBox();
                            mssBox.Muestra("Ingrese primero longitud de la viga");
                            cbApyPP.SelectedIndex = 0;
                            txtLPP.Focus();
                        }
                        else
                        {
                            tabCgVgPP.Invalidate();
                            PagVgCon pagVgCon = new PagVgCon();
                            //agregar lo de la barra de estado
                            if (Mtst.Visible == true)
                            {
                                pyc9.Visible = true;
                                lconst.Visible = true;
                                lconst.Text = "lcon = " + lcon.ToString("0.000");
                            }
                            else
                            {
                                pyc9.Visible = false;
                                lconst.Visible = true;
                                lconst.Text = "lcon =  " + lcon.ToString("0.000");
                            }
                            ltvst.Visible = false;
                            pyc2.Visible = false;
                            pyc3.Visible = false;
                            pyc4.Visible = false;
                            pyc5.Visible = false;
                            pyc6.Visible = false;
                            pyc7.Visible = false;
                            pyc8.Visible = false;
                       
                            R1st.Visible = false;
                            R2st.Visible = false;
                            Rast.Visible = false;
                            Rbst.Visible = false;
                            Rcst.Visible = false;
                            MRst.Visible = false;
                            Mbst.Visible = false;
                           
                            if (pagVgCon.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                            {
                                if (cbApyPP.SelectedIndex != 0)
                                {
                                    cbApyPP.SelectedIndex = 0;
                                }

                            }
                        }

                      
                    }
                    tabCgVgPP.Invalidate();
                    break;

                case 4:
                    lcon = 0;
                    ltv = 0;
                    ltvst.Visible = false;
                    pyc2.Visible = false;
                    pyc3.Visible = false;
                    pyc4.Visible = false;
                    pyc5.Visible = false;
                    pyc6.Visible = false;
                    pyc7.Visible = false;
                    pyc8.Visible = false;
                    pyc9.Visible = false;
                    R1st.Visible = false;
                    R2st.Visible = false;
                    Rast.Visible = false;
                    Rbst.Visible = false;
                    Rcst.Visible = false;
                    MRst.Visible = false;
                    Mbst.Visible = false;
                    lconst.Visible = false;



                    tabCgVgPP.Invalidate();
                    break;

                case 5:
                    lcon = 0;
                    ltv = 0;
                    ltvst.Visible = false;
                    pyc2.Visible = false;
                    pyc3.Visible = false;
                    pyc4.Visible = false;
                    pyc5.Visible = false;
                    pyc6.Visible = false;
                    pyc7.Visible = false;
                    pyc8.Visible = false;
                    pyc9.Visible = false;
                    R1st.Visible = false;
                    R2st.Visible = false;
                    Rast.Visible = false;
                    Rbst.Visible = false;
                    Rcst.Visible = false;
                    MRst.Visible = false;
                    Mbst.Visible = false;
                    lconst.Visible = false;

                    tabCgVgPP.Invalidate();
                    break;
            }

         
        }
    }
}
