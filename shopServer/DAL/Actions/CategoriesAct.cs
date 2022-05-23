using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class CategoriesAct
    {
        static shopEntities db = new shopEntities();
        public static List<Category> GetCategories()
        {
            return db.Category.ToList();
        }

        public static int AddCategory(Category o)
        {
            try
            {
                db.Category.Add(o);
                db.SaveChanges();
                return o.id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static bool UpdateCategory(Category c)
        {
            try
            {
                Category existingOne = db.Category.FirstOrDefault(c1 => c1.id == c.id);
                existingOne.id = c.id;
                existingOne.name = c.name;
                existingOne.superCategoryId = (int)c.superCategoryId;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteCategory(int id)
        {
            try
            {
                Category c = db.Category.FirstOrDefault(c1 => c1.id == id);
                db.Category.Remove(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool DeleteListOfCategorys(List<Category> list)
        {
            try
            {
                List<Category> cList = db.Category.Where(c1 => list.FirstOrDefault(c2 => c2.id == c1.id) != null).ToList();
                db.Category.RemoveRange(cList);
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
