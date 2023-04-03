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
        public dynamic loadProducts()
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                return db.Products.Select(p => new
                {
                    p.Id,
                    p.Name,
                    CategoryName=p.Category.Name,
                    p.Price,

                }).ToList();
            }
        }
        public bool addProduct(string name, double price, int idCategory,int quantity=0)
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                
                // Check if the new Product name is already used
                if (db.Products.Any(p=>p.Name==name && p.IdCategory==idCategory))
                {
                    throw new Exception("The new Product name is already used");
                }
                Product product = new Product();
                product.Name = name;
                product.Price = price;
                product.Quantity = quantity;
                product.IdCategory = idCategory;
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
        }
        public bool updateProduct(int id, string name, double price, int idCategory, int quantity)
        {
            using (CafeManagementEntities db = new CafeManagementEntities()) { 
            Product existingProduct = db.Products.Find(id);
            if (existingProduct == null)
            {
                throw new Exception("The Product does not exist.");
            }
                // Update the category information
                existingProduct.Name = name;
                existingProduct.Price = price;
                existingProduct.Quantity = quantity == 0 ? existingProduct.Quantity : quantity;
                existingProduct.IdCategory = idCategory;
            db.SaveChanges();
            return true;
            }
        }
        public bool deleteProduct(int id)
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                // Check if the category exists in the database
                Product existingProduct = db.Products.Find(id);
                if (existingProduct == null)
                {
                    throw new Exception("The Product does not exist.");
                }
                db.Products.Remove(existingProduct);
                db.SaveChanges();
                return true;
            }
        }
    }
}
