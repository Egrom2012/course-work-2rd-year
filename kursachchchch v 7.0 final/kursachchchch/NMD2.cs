using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachchchch
{
   static class NMD2
    {
        private static int[] massiv = new int[6] { 1, 2, 3, 4, 5, 8 };

        public static int inst(int data_type)
        {
            switch (data_type)
            {
                case 1:
                    return massiv[0];
                case 2:
                    return massiv[1];
                case 3:
                    return massiv[2];
                case 4:
                    return massiv[3];
                case 5:
                    return massiv[4];
                case 0:
                    return massiv[5];
            }
            return massiv[5];
        }

    }
}
