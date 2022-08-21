using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kursachchchch
{
    class Processor
    {
      static private int i = 0;
      static private int type_zav;
      static private int type_instruct;

      static public int time_obrabotka = 2;
      static public int pogresh = 1;

      static public int kol_vo_obrabotan_zav;
      static public int timer;

        static public void obrabotka(int data_type_zav,int data_type_instruct)
        {
            type_zav = data_type_zav;
            type_instruct = data_type_instruct;

            if (i < timer)
                i++;
            else
            {
                if (type_zav == type_instruct)
                {
                    NMD1.zavkas.Dequeue();
                    kol_vo_obrabotan_zav++;
                }
                i = 0;
                time();
            }
        }

        static public void time()
        {
            Random rnd = new Random();
            timer = Convert.ToInt32(rnd.NextDouble() * ((time_obrabotka + pogresh) - (time_obrabotka - pogresh)) + (time_obrabotka - pogresh));
        }


        static public void data_time(int time, int pog)
        {
            time_obrabotka = time;
            pogresh = pog;
        }
    }
}
