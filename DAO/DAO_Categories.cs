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
        public dynamic loadCategories()
        {
            using ( CafeManagementEntities db= new CafeManagementEntities())
            {
                return db.Categories.Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description,
                }).ToList();
            }
        }
        public bool addCategory(string name, string description)
        {
            using( CafeManagementEntities db= new CafeManagementEntities())
            {
                // Check if the new category name is already used
                if (db.Categories.Any(c => c.Name.ToUpper() == name.ToUpper()))
                {
                    throw new Exception("The category name is already used");
                }
                db.Categories.Add(new Category 
                { 
                    Name=name,
                    Description=description
                });
                db.SaveChanges();
                return true;
            }    
        }
        public bool updateCategory(int id, string name, string description)
        {
            using (CafeManagementEntities db= new CafeManagementEntities())
            {
                // Check if the category exists in the database
                Category existingCategory = db.Categories.Find(id);
                if (existingCategory==null)
                {
                    throw new Exception("The category does not exist.");
                }
                // Update the category information
                existingCategory.Name = name;
                existingCategory.Description = description;
                db.SaveChanges();
                return true;
            }
        }
        public bool deleteCategory(int id)
        {
            using(CafeManagementEntities db= new CafeManagementEntities())
            {

                // Check if the category exists in the database
                Category existingCategory = db.Categories.Find(id);
                if (existingCategory == null)
                {
                    throw new Exception("The category does not exist.");
                }
                // Check if any product is referencing the category
                bool isReferenced = db.Products.Any(p => p.IdCategory == id);

                if (isReferenced)
                {
                    throw new Exception("Cannot delete the category because there are products referencing it.");
                }
                // Delete the category from the database
                Category category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
        }
    }
}
