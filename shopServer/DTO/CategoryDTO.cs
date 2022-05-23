using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int superCategoryId { get; set; }

        public CategoryDTO()
        {

        }

        public CategoryDTO(Category c)
        {
            id = c.id;
            name = c.name;
            superCategoryId = (int)c.superCategoryId;
        }
        public Category FromDTOToTable()
        {
            Category c = new Category();
            c.id = id;
            c.name = name;
            c.superCategoryId = superCategoryId;
            return c;
        }
        public static List<CategoryDTO> CreateDTOList(List<Category> list)
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();
            foreach (var c in list)
            {
                dtoList.Add(new CategoryDTO(c));
            }
            return dtoList;
        }
    }
}
