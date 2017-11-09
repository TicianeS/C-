using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallPostgre.Util
{
    class Tools
    {
        public static int ConverterParaInt(string txt)
        {
            int num;
            bool conv;

            conv = Int32.TryParse(txt, out num);
            if (conv == false)
            {
                num = 0;
            }
            else
            {
                Int32.TryParse(txt, out num);
            }
            return num;
        }

        public static string VerificarTurno(TimeSpan? hr)
        {
            TimeSpan mad, manha, tarde;
            mad = TimeSpan.Parse("00:00");
            manha = TimeSpan.Parse("10:00");
            tarde = TimeSpan.Parse("16:00");

            if (hr == mad)
            {
                return "MADRUGADA";
            }
            else
            {
                if (hr < manha)
                {
                    return "MANHÃ";
                }
                else
                {
                    if (hr < tarde)
                    {
                        return "TARDE";
                    }
                    else
                    {
                        return "NOITE";
                    }
                }
            }
        }


        /* permite digitar somente números
         
          if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

         */





    }  
}
