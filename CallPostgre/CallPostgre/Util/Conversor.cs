using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallPostgre.Util
{
    class Conversor
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
    }
}
