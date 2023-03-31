using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Orders
    {
        private static BUS_Orders instance;

        public static BUS_Orders Instance
        {
            get { if (instance == null) instance = new BUS_Orders(); return instance; }
            private set
            {
                instance = value;

            }
        }
    }
}
