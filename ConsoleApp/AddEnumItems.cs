using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class AddEnumItems
    {
        //Takes a typof enum and adds the enum names to a list
        public static List<string> CreateUpperCase<T>(T e) where T : Type
        {
            List<string> strList = new List<string>();
            foreach (Enum item in Enum.GetValues(e))
            {
                string str = item.ToString();
                //Create a space before all capital letters
                str = string.Concat(str.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

                strList.Add(str);
            }

            return strList;
        }
    }
}