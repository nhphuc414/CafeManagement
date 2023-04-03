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
        public bool addProduct(string name, double price, int idCategory, int quantity = 0)
        {

            name = Utils.Utils.NormalizeString(name);
            if (String.IsNullOrEmpty(name))
            {
                throw new Exception("Vui lòng nhập tên Product");
            } 
            if (price <= 0)
            {
                throw new Exception("Vui lòng nhập giá sản phẩm hợp lệ.");
            }
            name = char.ToUpper(name[0]) + name.Substring(1);
            return DAO_Products.Instance.addProduct(name, price, idCategory, quantity);
        }
        public bool updateProduct(int id, string name, double price, int idCategory, int quantity = 0)
        {
            name = Utils.Utils.NormalizeString(name);
            if (String.IsNullOrEmpty(name))
            {
                throw new Exception("Vui lòng nhập tên Product");
            }
            if (price <= 0)
            {
                throw new Exception("Vui lòng nhập giá sản phẩm hợp lệ.");
            }
            return DAO_Products.Instance.updateProduct(id, name, price, idCategory, quantity);
        }

        public bool deleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Vui lòng nhập id hợp lệ.");
            }

            return DAO_Products.Instance.deleteProduct(id);
        }
    }
}
