using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class MessagesAct
    {
        static shopEntities db = new shopEntities();
        public static List<Message> GetMessages()
        {
            return db.Message.ToList();
        }

        public static int AddMessage(Message o)
        {
            try
            {
                db.Message.Add(o);
                db.SaveChanges();
                return o.id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static bool UpdateMessage(Message m)
        {
            try
            {
                Message existingOne = db.Message.FirstOrDefault(m1 => m1.id == m.id);
                existingOne.id = m.id;
                existingOne.from = (int)m.from;
                existingOne.to = (int)m.to;
                existingOne.title = m.title;
                existingOne.body = m.body;
                existingOne.sendDate = (DateTime)m.sendDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteMessage(int id)
        {
            try
            {
                Message o = db.Message.FirstOrDefault(o1 => o1.id == id);
                db.Message.Remove(o);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool DeleteListOfMessages(List<Message> list)
        {
            try
            {
                List<Message> o = db.Message.Where(o1 => list.FirstOrDefault(o2 => o2.id == o1.id) != null).ToList();
                db.Message.RemoveRange(o);
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
