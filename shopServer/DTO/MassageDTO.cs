using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MessageDTO
    {
        public int id { get; set; }
        public int fromId { get; set; }
        public int toId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime sendDate { get; set; }

        public string fromName { get; set; }
        public string toName { get; set; }


        public MessageDTO()
        {

        }
        public MessageDTO(Message m)
        {
            id = m.id;
            fromId = (int) m.from;
            toId =(int) m.to;
            title = m.title;
            body = m.body;
            sendDate = (DateTime)m.sendDate;
            fromName = m.User.name;
            toName = m.User1.name;
        }
        public Message FromDTOToTable()
        {
            Message m = new Message();
            m.id = id;
            m.from = fromId;
            m.to = toId;
            m.title = title;
            m.body = body;
            m.sendDate = sendDate;
            return m;
        }
        public static List<MessageDTO> CreateDTOList(List<Message> list)
        {
            List<MessageDTO> dtoList = new List<MessageDTO>();
            foreach (var m in list)
            {
                dtoList.Add(new MessageDTO(m));
            }
            return dtoList;
        }
    }
}
