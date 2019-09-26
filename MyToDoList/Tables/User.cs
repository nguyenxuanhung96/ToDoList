using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyToDoList.Tables
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
