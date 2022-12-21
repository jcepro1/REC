using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    class Matriz
    {
        const int MAXF = 100;
        const int MAXC = 100;
        private int[,] x;
        private int f, c;


        public Matriz()
        {
            x = new int[MAXF, MAXC];
            f = 0; c = 0;
        }

        public void cargar(int nf, int nc, int a, int b)
        {
            f = nf; c = nc;
            int f1, c1;
            Random r = new Random();
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = r.Next(a, b);
                }
            }
        }
        public string descargar()
        {
            string s = "";
            int f1, c1;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    s = s + x[f1, c1] + "\x09";
                }
                s = s + "\x0d" + "\x0a";
            }
            return s;
        }
      
       
         int frecuenciaFil(int f1, int ele)
         {
             int fr = 0;
             for (int c1 = 1; c1 <= c; c1++)
             {
                 if (x[f1, c1] == ele)
                 {
                     fr++;
                 }
             }
             return fr;
         }
        
         void cargarcol(int ele)
         {
             c++;
             x[1, c] = ele;
         }
         void ordenarCol()
         {
             for (int c1 = 1; c1 <= c-1; c1++)
             {
                 for (int c2 = c1+1; c2 <= c; c2++)
                 {
                     if (frecuenciaFil(1, x[1, c1]) < frecuenciaFil(1, x[1, c2]) && (x[1, c1] != x[1, c2]))
                     {
                         int aux = x[1, c1];
                         x[1, c1] = x[1, c2];
                         x[1, c2] = aux;
                     }
                 }
             }
         }
         public void pregunta2(int fi, int ff, int ci, int cf)
         {
            Matriz mpares = new Matriz();

            for (int c1 = ci; c1<=cf; c1++)
             {
                for (int f1 = ff; f1 >= fi; f1--)
                 {
                    int ele = x[f1, c1];
                    mpares.cargarcol(ele);
                 }
             }

            mpares.ordenarCol();
            int i1 = 1;
            for (int c1 = ci; c1 <= cf; c1++)
            {
                for (int f1 = ff; f1 >= fi; f1--)
                {
                        x[f1, c1] = mpares.x[1, i1];
                        i1++;
                   }
             }
         }
         public void intercambiarfilas(int f1, int f2)
         {
             for (int c1 = 1; c1 <= c; c1++)
             {
                 int aux = x[f1, c1];
                 x[f1, c1] = x[f2, c1];
                 x[f2, c1] =aux;
             }
         }
         public void examen1(int nc)
         {
             for (int f1 = 1; f1 < f; f1++)
             {
                 for (int f2 = f1+1; f2 <= f; f2++)
                 {
                     if (x[f1, nc] > x[f2, nc])
                     {
                         intercambiarfilas(f1, f2);
                     }
                 }
             }
         }



    }
}
