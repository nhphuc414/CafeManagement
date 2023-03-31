using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Categories
    {
        private static DAO_Categories instance;

        public static DAO_Categories Instance
        {
            get { if (instance == null) instance = new DAO_Categories(); return instance; }
            private set
            {
                instance = value;

            }
        }

    }
}
