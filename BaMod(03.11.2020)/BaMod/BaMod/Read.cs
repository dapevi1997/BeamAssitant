using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaMod
{
    class Read
    {
        private string chkbpregunta;
        private string indpstMt, indlb,et,ec,fs,cbPf,l,apy,ltv,nfilas,tadiag,tabperf,stabprin,haymaterial,unidades,lcon,me;
        private DataTable dtaux = new DataTable("Datatable_auxiliar"); 
        public Read(Stream myStream)
        {
            string aux,a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15;
            string aux1;
            string[] pieces;
            StreamReader sr = new StreamReader(myStream);

            aux = sr.ReadLine();
            unidades = aux;
            aux = sr.ReadLine();
            chkbpregunta = aux;
            a1 = sr.ReadLine();
            indpstMt = a1;
            a2 = sr.ReadLine();
            indlb = a2;
            a3 = sr.ReadLine();
            et = a3;
            a4 = sr.ReadLine();
            ec = a4;
            a5 = sr.ReadLine();
            fs = a5;
            a6 = sr.ReadLine();
            cbPf = a6;
            a7 = sr.ReadLine();
            l = a7;
            a8 = sr.ReadLine();
            apy = a8;
            a9 = sr.ReadLine();
            ltv = a9;
            a10 = sr.ReadLine();
            ////////
            nfilas = a10;
            dtaux.Columns.Add("tipo", typeof(string));
            dtaux.Columns.Add("cx1", typeof(string));
            dtaux.Columns.Add("cx2", typeof(string));
            dtaux.Columns.Add("fz", typeof(string));
            dtaux.Columns.Add("fz1", typeof(string));
            dtaux.Columns.Add("fz2", typeof(string));
            dtaux.Columns.Add("mto", typeof(string));

            for (int i = 0; i < Convert.ToInt32(nfilas); i++)
            {
                aux1 = sr.ReadLine();
                pieces = aux1.Split(';');

                dtaux.Rows.Add(pieces[0],pieces[1],pieces[2],pieces[3],pieces[4],pieces[5],pieces[6]);
            }

            a11 = sr.ReadLine();
            tadiag = a11;
            a12 = sr.ReadLine();
            tabperf = a12;
            a13 = sr.ReadLine();
            stabprin = a13;
            a14 = sr.ReadLine();
            haymaterial = a14;
            a15 = sr.ReadLine();
            lcon = a15;
            a15 = sr.ReadLine();
            me = a15;

            sr.Close();


        }

        public string get_Chkbpregunta()
        {
            return chkbpregunta;
        }
        public string get_indpstMt()
        {
            return indpstMt;
        }
        public string get_indlb()
        {
            return indlb;
        }
        public string get_et()
        {
            return et;
        }
        public string get_ec()
        {
            return ec;
        }
        public string get_fs()
        {
            return fs;
        }
        public string get_cbPf()
        {
            return cbPf;
        }
        public string get_l()
        {
            return l;
        }
        public string get_apy()
        {
            return apy;
        }
        public string get_ltv()
        {
            return ltv;
        }
        public string get_nfilas()
        {
            return nfilas;
        }
        public DataTable get_dtaux()
        {
            return dtaux;
        }
        public string get_tabdiag()
        {
            return tadiag;
        }
        public string get_tabperf()
        {
            return tabperf;
        }
        public string get_stabprin()
        {
            return stabprin;
        }
        public string get_haymaterial()
        {
            return haymaterial;
        }
        public string get_unidades()
        {
            return unidades;
        }

        public string get_lcon()
        {
            return lcon;
        }

        public string get_me()
        {
            return me;
        }


    }
}
