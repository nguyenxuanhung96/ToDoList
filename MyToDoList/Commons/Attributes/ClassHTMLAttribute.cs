using System;

namespace MyToDoList.Commons.Attributes
{
    public class ClassHtmlAttribute : Attribute
    {
        public ClassHtmlAttribute()
        {
        }
        public ClassHtmlAttribute(string listClass)
        {
            Class = listClass;
        }

        public string Class { get; private set; }
        protected string ListClassValue
        {
            get
            {
                return Class;
            }
            set
            {
                Class = value;
            }
        }
    }
}
