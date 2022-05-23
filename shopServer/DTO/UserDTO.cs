using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public int houseNumber { get; set; }
        public string phone { get; set; }
        public int status { get; set; }

        public UserDTO()
        {

        }
        public UserDTO(User u)
        {
            id = u.id;
            name = u.name;
            email = u.email;
            password = u.password;
            street = u.street;
            city = u.city;
            houseNumber = (int)u.houseNumber;
            phone = u.phone;
            status = (int)u.status;
        }

        public User FromDTOToTable()
        {
            User u = new User();
            u.id = id;
            u.name = name;
            u.email = email;
            u.password = password;
            u.street = street;
            u.city = city;
            u.houseNumber = houseNumber;
            u.phone = phone;
            u.status = status;
            return u;
        }
        public static List<UserDTO> CreateDTOList(List<User> list)
        {
            List<UserDTO> dtoList = new List<UserDTO>();
            foreach (var u in list)
            {
                dtoList.Add(new UserDTO(u));
            }
            return dtoList;
        }
    }
}
