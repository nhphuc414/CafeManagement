using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Products
    {
        private static DAO_Products instance;

        public static DAO_Products Instance
        {
            get { if (instance == null) instance = new DAO_Products(); return instance; }
            private set
            {
                instance = value;

            }
        }
    }
}
