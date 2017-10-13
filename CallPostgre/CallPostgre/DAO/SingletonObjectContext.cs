using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallPostgre.DAO
{
    class SingletonObjectContext
    {
        private static readonly SingletonObjectContext instance = new SingletonObjectContext();

        private readonly CallcenterEntities context;

        private SingletonObjectContext()
        {
            context = new CallcenterEntities();
        }

        public static SingletonObjectContext Instance
        {
            get
            {
                return instance;
            }
        }

        public CallcenterEntities Context
        {
            get
            {
                return context;
            }
        }
    }
}
