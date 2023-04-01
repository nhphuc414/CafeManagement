using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Products
    {
        private static BUS_Products instance;

        public static BUS_Products Instance
        {
            get { if (instance == null) instance = new BUS_Products(); return instance; }
            private set
            {
                instance = value;

            }
        }
        public dynamic loadProducts()
        {
            return DAO_Products.Instance.loadProducts();
        }
    }
}
