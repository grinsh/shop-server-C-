using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class ProductsAct
    {
        static shopEntities db = new shopEntities();
        public static List<Product> GetProducts()
        {
            return db.Product.ToList();
        }

        public static int AddProduct(Product p)
        {
            try
            {
                db.Product.Add(p);
                db.SaveChanges();
                return p.id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static bool UpdateProduct(Product p)
        {
            try
            {
                Product existingOne = db.Product.FirstOrDefault(p1 => p1.id == p.id);
                existingOne.id = p.id;
                existingOne.name = p.name;
                existingOne.description = p.description;
                existingOne.price = p.price;
                existingOne.image = p.image;
                existingOne.inStock = p.inStock;
                existingOne.categoryId = p.categoryId;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteProduct(int id)
        {
            try
            {
                Product p = db.Product.FirstOrDefault(p1 => p1.id == id);
                db.Product.Remove(p);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool DeleteListOfProducts(List<Product> list)
        {
            try
            {
                List<Product> pList = db.Product.Where(p1 => list.FirstOrDefault(p2 => p2.id == p1.id) != null).ToList();
                db.Product.RemoveRange(pList);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
