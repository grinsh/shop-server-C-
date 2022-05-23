using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class UsersAct
    {
        static shopEntities db = new shopEntities();
        public static List<User> GetUsers()
        {
            return db.User.ToList();
        }

        public static int AddUser(User u)
        {
            try
            {
                db.User.Add(u);
                db.SaveChanges();
                return u.id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static bool UpdateUser(User u)
        {
            try
            {
                User existingOne = db.User.FirstOrDefault(u1 => u1.id == u.id);
                existingOne.id = u.id;
                existingOne.name = u.name;
                existingOne.email = u.email;
                existingOne.password = u.password;
                existingOne.street = u.street;
                existingOne.city = u.city;
                existingOne.houseNumber = (int)u.houseNumber;
                existingOne.phone = u.phone;
                existingOne.status = (int)u.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteUser(int id)
        {
            try
            {
                User u = db.User.FirstOrDefault(u1 => u1.id == id);
                db.User.Remove(u);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool DeleteListOfUsers(List<User> list)
        {
            try
            {
                List<User> u = db.User.Where(u1 => list.FirstOrDefault(u2 => u2.id == u1.id) != null).ToList();
                db.User.RemoveRange(u);
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
