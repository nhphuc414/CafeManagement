using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Categories
    {
        private static BUS_Categories instance;

        public static BUS_Categories Instance
        {
            get { if (instance == null) instance = new BUS_Categories(); return instance; }
            private set
            {
                instance = value;

            }
        }
    }
}
