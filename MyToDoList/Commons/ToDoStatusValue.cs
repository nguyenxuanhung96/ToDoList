using MyToDoList.Commons.Attributes;
using System.ComponentModel;

namespace MyToDoList.Commons
{
    public enum ToDoStatusValue
    {
        [Description("Not start yet")]
        [ClassHtml("bg-info")]
        NotStartYet = 10,
        [Description("Doing")]
        [ClassHtml("bg-primary")]
        Doing = 20,
        [Description("Done")]
        [ClassHtml("bg-success")]
        Done = 30,
    }
}
