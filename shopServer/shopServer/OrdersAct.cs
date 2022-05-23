using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class OrdersAct
    {
        static shopEntities db = new shopEntities();
        public static List<Order> GetOrders()
        {
            return db.Order.ToList();
        }

        public static int AddOrder(Order o)
        {
            try
            {
                db.Order.Add(o);
                db.SaveChanges();
                return o.id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static bool UpdateOrder(Order o)
        {
            try
            {
                Order existingOne = db.Order.FirstOrDefault(o1 => o1.id == o.id);
                existingOne.id = o.id;
                existingOne.orderDate = o.orderDate;
                existingOne.arrivalDate = o.arrivalDate;
                existingOne.userId = o.userId;
                existingOne.phone = o.phone;
                existingOne.address = o.address;
                existingOne.completed = o.completed;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteOrder(int id)
        {
            try
            {
                Order o = db.Order.FirstOrDefault(o1 => o1.id == id);
                db.Order.Remove(o);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool DeleteListOfOrders(List<Order> list)
        {
            try
            {
                List<Order> o = db.Order.Where(o1 => list.FirstOrDefault(o2 => o2.id == o1.id) != null).ToList();
                db.Order.RemoveRange(o);
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
