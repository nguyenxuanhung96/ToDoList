using MyToDoList.Commons;
using MyToDoList.Utilities;
using System;

namespace MyToDoList.Models
{
    public class ToDoModel
    {
        public int toDoID { get; set; }
        public string toDoTitle { get; set; }
        public string toDoContent { get; set; }
        public int toDoStatus { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public int categoryID { get; set; }
        public CategoryModel category { get; set; }
        public string toDoStatusText
        {
            get
            {
                return EnumHelper.GetDescription((ToDoStatusValue)toDoStatus);
            }
        }
        public string toDoStatusClassHtml
        {
            get
            {
                return EnumHelper.GetClassHtml((ToDoStatusValue)toDoStatus);
            }
        }
    }

    public class ToDoStatusValueModel
    {
        public int statusValue { get; set; }
        public string statusName { get; set; }
    }
}
