using System;

namespace MyToDoList.Models
{
    public class CategoryModel
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string createBy { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
