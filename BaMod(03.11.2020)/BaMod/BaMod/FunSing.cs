using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaMod
{
    public static class Fn
    {

        public static double FsingCP(double a, double x)
        {
            if (x >= a) { return 1; }
            else { return 0; }

        }

        public static double FsingCP1(double a, double x)
        {
            if (x > a) { return 1; }
            else { return 0; }

        }
        public static double FSingMCP(double pa, double px)
        {
            double a, x;
            a = pa; x = px;
            if (px < pa)
            {
                return 0;
            }
            else
            {
                return x - a;
            }
        }

        public static double FSingMCDR(double pa, double px)
        {
            double a, x, r;
            a = pa; x = px;
            r = x - a;
            if (px < pa)
            {
                return 0;
            }
            else
            {
                return ((0.5) * Math.Pow(r, 2));
            }
        }

        public static double FSingMCDTPP(double pa, double px)
        {
            double a, x, r;
            a = pa; x = px;
            r = x - a;
            if (px < pa)
            {
                return 0;
            }
            else
            {
                return (1 * Math.Pow(r, 3)) / 6;

            }
        }

        public static double FSing4(double pa, double px)
        {
            double a, x, r;
            a = pa; x = px;
            r = x - a;
            if (px < pa)
            {
                return 0;
            }
            else
            {
                return (1 * Math.Pow(r, 4)) / 24;

            }
        }

        public static double FSing5(double pa, double px)
        {
            double a, x, r;
            a = pa; x = px;
            r = x - a;
            if (px < pa)
            {
                return 0;
            }
            else
            {
                return (1 * Math.Pow(r, 5)) / 120;

            }
        }


        public static int NumEnt(double num)
        {
            double partedecimal;
           
            partedecimal = num - Math.Floor(num);
            
            if (partedecimal<=5)
            {
                return Convert.ToInt32(Math.Floor(num)); 
            }
            else
            {
              
                
                    return (Convert.ToInt32(Math.Floor(num)) + 1);
                  
                
               
            }

        }


    }
}
