using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyToDoList.Tables
{
    [Table("Categories")]
    public partial class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
    public partial class Category
    {
        public static Category Create(string name,
            int createBy)
        {
            return new Category
            {
                CategoryName = name,
                CreatedBy = createBy,
                IsDeleted = false,
            };
        }
    }
}
