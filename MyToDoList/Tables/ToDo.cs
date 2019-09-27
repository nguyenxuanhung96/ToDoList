using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyToDoList.Tables
{
    [Table("ToDos")]
    public partial class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        public string ToDoTitle { get; set; }
        public int CategoryID { get; set; }
        public string ToDoContent { get; set; }
        public byte ToDoStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserID { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
    public partial class ToDo
    {
        public static ToDo Create(string title
            , string content
            , int status
            , int categoryId
            , int createBy)
        {
            return new ToDo
            {
                ToDoTitle = title,
                ToDoContent = content,
                ToDoStatus = (byte)status,
                CategoryID = categoryId,
                UserID = createBy,
                IsDeleted = false,
            };
        }
    }
}
