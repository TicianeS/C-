using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callcenter.DAO
{
    class SingletonObjectContext
    {
        private static readonly SingletonObjectContext instance = new SingletonObjectContext();
        private readonly CallEntities context;

        private SingletonObjectContext()
        {
            context = new CallEntities();
        }

        public static SingletonObjectContext Instance
        {
            get
            {
                return instance;
            }
        }

        public CallEntities Context
        {
            get
            {
                return context;
            }
        }
    }
}
