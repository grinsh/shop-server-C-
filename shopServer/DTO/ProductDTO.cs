using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public byte[] image { get; set; }
        public bool inStock { get; set; }
        public int categoryId { get; set; }

        public ProductDTO()
        {

        }

        public ProductDTO(Product p)
        {
            id = p.id;
            name = p.name;
            description = p.description;
            price = (decimal)p.price;
            image = p.image;
            inStock = (bool)p.inStock;
            categoryId = (int)p.categoryId;
        }

        public Product FromDTOToTable()
        {
            Product p = new Product();
            p.id = id;
            p.name = name;
            p.description = description;
            p.price = price;
            p.image = image;
            p.inStock = inStock;
            p.categoryId = categoryId;
            return p;
        }
        public static List<ProductDTO> CreateDTOList(List<Product> list)
        {
            List<ProductDTO> dtoList = new List<ProductDTO>();
            foreach (var p in list)
            {
                dtoList.Add(new ProductDTO(p));
            }
            return dtoList;
        }
    }
}
