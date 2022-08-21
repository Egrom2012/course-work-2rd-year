using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kursachchchch
{
     class OP
    {
       private int type_zavki;
       private int type_instruc;
       private int i = 0;

       public static int vrema_zapis = 1;
       public static int vrema_NMD = 2;

        public void op_funct()
        {
            if (i < vrema_zapis)
                i++;
            else
            if (NMD1.zavkas.Count >0)
            {
               type_zavki = NMD1.zavkas.Peek().type;
               type_instruc = NMD2.inst(type_zavki);
               Processor.obrabotka(type_zavki, type_instruc);
                i = 0;
            }
        }


        public void nastroi_OP(int zapis, int NMD)
        {
            vrema_zapis = zapis;
            vrema_NMD = NMD;
        }
    }
}
