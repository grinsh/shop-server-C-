using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public int userId { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public bool completed { get; set; }

        public List<ProductDTO> products { get; set; }

        public OrderDTO()
        {

        }

        public OrderDTO(Order o)
        {
            id = o.id;
            orderDate = (DateTime)o.orderDate;
            userId = (int)o.userId;
            address = o.address;
            phone = o.phone;
            completed = (bool)o.completed;

            products = ProductDTO.CreateDTOList(o.Product.ToList());
        }

        public Order FromDTOToTable()
        {
            Order o = new Order();
            o.id = id;
            o.orderDate = orderDate;
            o.userId = userId;
            o.address = address;
            o.phone = phone;
            o.completed = completed;
            return o;
        }
        public static List<OrderDTO> CreateDTOList(List<Order> list)
        {
            List<OrderDTO> dtoList = new List<OrderDTO>();
            foreach (var o in list)
            {
                dtoList.Add(new OrderDTO(o));
            }
            return dtoList;
        }

    }
}
