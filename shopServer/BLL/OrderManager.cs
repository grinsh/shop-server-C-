using DAL;
using DAL.Actions;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderManager
    {
        public static List<OrderDTO> GetOrdersByUserId(int id)
        {
            List<Order> list = OrdersAct.GetOrders();
            List<Order> userOrders = list.Where(o => o.userId == id).ToList();
            List<OrderDTO> userOrdersDTO = OrderDTO.CreateDTOList(userOrders);
            return userOrdersDTO;
        }
    }
}
