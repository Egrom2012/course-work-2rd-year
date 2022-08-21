using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kursachchchch
{
     class terminal1
    {
        public int tipezav;

        public void prixod_zav(int data_type_zav)
        {
            tipezav = data_type_zav;
            NMD1.zavkas.Enqueue(new zavka(tipezav));
        }
        public string zav()
        {
            string str = "";
            str = Convert.ToString(tipezav);
            tipezav = 0;
            return str;
        }
    }

    class terminal2
    {
       public int tipezav;
        public void prixod_zav2(int data_type_zav)
        {
            tipezav = data_type_zav;
            NMD1.zavkas.Enqueue(new zavka(tipezav));
        }
        public string zav()
        {
            string str2 = "";
            str2 = Convert.ToString(tipezav);
            tipezav = 0;
            return str2;
        }
    }

    class terminal3
    {
        public int tipezav;
        public void prixod_zav3(int data_type_zav)
        {
            tipezav = data_type_zav;
            NMD1.zavkas.Enqueue(new zavka(tipezav));
        }
        public string zav()
        {
            string str3 = "";
            str3 = Convert.ToString(tipezav);
            tipezav = 0;
            return str3;
        }
    }
}
