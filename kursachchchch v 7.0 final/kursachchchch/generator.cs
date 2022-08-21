using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kursachchchch
{
 class generator
    {
     public terminal1 terminal;
     public terminal2 terminal2;
     public terminal3 terminal3;

     static public int timezav1 = 10;//базовое время генерации заявки 1 типа
     static public int timezav2 = 12; //базовое время генерации заявки 2 типа
     static public int timezav3 = 8; //базовое время генерации заявки 3 типа
     static public int timezav4 = 9; //базовое время генерации заявки 4 типа
     static public int timezav5 = 11; //базовое время генерации заявки 5 типа

     static public int pogresh1 = 5;  //базовая погрешность во времени генерации 1 типа заявки
     static public int pogresh2 = 10;  //базовая погрешность во времени генерации 2 типа заявки
     static public int pogresh5 = 15;  //базовая погрешность во времени генерации 5 типа заявки

     private int time_live_1;
     private int time_live_2;
     private int time_live_3;
     private int time_live_4;
     private int time_live_5;

     private Random rnd;


        public void time_zavok(int date_zav1, int date_zav2, int date_zav3, int date_zav4, int date_zav5, int date_pog1, int date_pog2, int date_pog5) // функция для получения настроек времени для генерации заявок
        {                                                // работает в MyForm2 от кнопки "Принять"
            timezav1 = date_zav1;
            timezav2 = date_zav2;
            timezav3 = date_zav3;
            timezav4 = date_zav4;
            timezav5 = date_zav5;
            pogresh1 = date_pog1;
            pogresh2 = date_pog2;
            pogresh5 = date_pog5;
        } 

        public generator()
        {
            rnd = new Random();
            terminal = new terminal1();
            terminal2 = new terminal2();
            terminal3 = new terminal3();

            time_live_1 = Convert.ToInt32(rnd.NextDouble() * ((timezav1 + pogresh1) - (timezav1 - pogresh1)) + (timezav1 - pogresh1));
            time_live_2 = Convert.ToInt32(Poisson(Convert.ToDouble(timezav3)));
            time_live_3 = Convert.ToInt32(Poisson(Convert.ToDouble(timezav4)));
            time_live_4 = Convert.ToInt32(rnd.NextDouble() * ((timezav1 + pogresh1) - (timezav1 - pogresh1)) + (timezav1 - pogresh1));
            time_live_5 = Convert.ToInt32(rnd.NextDouble() * ((timezav5 + pogresh5) - (timezav5 - pogresh5)) + (timezav5 - pogresh5));
        }

        public void osnov_generator()
        {
            if (time_live_1 < 1)
            {
                terminal.prixod_zav(1);
                generator_live_zav(1);
            }
            else time_live_1--;

            if (time_live_2 < 1)
            {
                terminal.prixod_zav(2);
                generator_live_zav(2);
            }
            else time_live_2--;

            if (time_live_3 < 1)
            {
                terminal2.prixod_zav2(3);
                generator_live_zav(3);
            }
            else time_live_3--;

            if (time_live_4 < 1)
            {
                terminal2.prixod_zav2(4);
                generator_live_zav(4);
            }
            else time_live_4--;

            if (time_live_5 < 1)
            {
                terminal3.prixod_zav3(5);
                generator_live_zav(5);
            }
            else time_live_5--;
        }

         private void generator_live_zav(int type_zav)
        {
            Random rnd = new Random();

            switch (type_zav)
            {
                case 1:
                    time_live_1 = Convert.ToInt32(rnd.NextDouble() * ((timezav1 + pogresh1) - (timezav1 - pogresh1)) + (timezav1 - pogresh1));
                    break;
                case 2:
                    time_live_2 = Convert.ToInt32(rnd.NextDouble() * ((timezav2 + pogresh2) - (timezav2 - pogresh2)) + (timezav2 - pogresh2));
                    break;
                case 3:
                    time_live_3 = Convert.ToInt32(Poisson(Convert.ToDouble(timezav3)));
                    break;
                case 4:
                    time_live_4 = Convert.ToInt32(Poisson(Convert.ToDouble(timezav3)));
                    break;
                case 5:
                    time_live_5 = Convert.ToInt32(rnd.NextDouble() * ((timezav5 + pogresh5) - (timezav5 - pogresh5)) + (timezav5 - pogresh5));
                    break;
            }
        }



        private int Poisson(double lambda)
        {
            Random rand = new Random();
            double l = Math.Exp(-lambda);
            double p = 1.0;
            int k = 0;
            while (p > l)
            {
                k++;
                p *= rand.NextDouble();
            };
            return k - 1;
        }
    }
        
}

