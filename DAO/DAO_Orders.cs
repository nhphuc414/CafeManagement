using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Orders
    {
        private static DAO_Orders instance;

        public static DAO_Orders Instance
        {
            get { if (instance == null) instance = new DAO_Orders(); return instance; }
            private set
            {
                instance = value;
            }
        }
    }
}
