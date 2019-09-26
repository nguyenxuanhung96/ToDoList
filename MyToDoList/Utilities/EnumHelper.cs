using MyToDoList.Commons;
using MyToDoList.Commons.Attributes;
using MyToDoList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyToDoList.Utilities
{
    public static class EnumHelper
    {
        public static IEnumerable<ToDoStatusValueModel> GetToDoStatusValues()
        {
            return Enum.GetValues(typeof(ToDoStatusValue)).Cast<ToDoStatusValue>()
                .Select(k => new ToDoStatusValueModel
                {
                    statusValue = (int)k,
                    statusName = GetDescription(k),
                });
        }
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
        public static string GetClassHtml(Enum en)
        {
            Type type = en.GetType();

            System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(ClassHtmlAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((ClassHtmlAttribute)attrs[0]).Class;
                }
            }

            return en.ToString();
        }
    }
}
