using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Utils;
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
        public dynamic loadCategories()
        {
            return DAO_Categories.Instance.loadCategories();   
        }
        public bool addCategory(string name, string description=null)
        {
            name = Utils.Utils.NormalizeString(name);
            if (String.IsNullOrEmpty(name)) throw new Exception("You must name the Cates");
            name = char.ToUpper(name[0]) + name.Substring(1);
            return DAO_Categories.Instance.addCategory(name, description);
        }
        public bool updateCategory(int id, string name, string description = null)
        {
            name=Utils.Utils.NormalizeString(name);
            if (String.IsNullOrEmpty(name)) throw new Exception("You must name the Cates");
            name = char.ToUpper(name[0]) + name.Substring(1);
            description =Utils.Utils.NormalizeString(description);
            return DAO_Categories.Instance.updateCategory(id, name, description);
        }
        public bool deleteCategory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Vui lòng nhập id hợp lệ.");
            }
            return DAO_Categories.Instance.deleteCategory(id);
        }
    }
}
