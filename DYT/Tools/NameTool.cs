using System.Collections.Generic;
using DYT.Enums;

namespace DYT.Tools
{
    public static class NameTool
    {
        public static string TransformName(string name, NameStyle nameStyle)
        {
            List<string> list = new();
            
            string str = "";
            foreach (char c in name)
            {
                if (c >= 'a' && c <= 'z') str += c;
                else if (c >= 'A' && c <= 'Z')
                {
                    if (str != "") list.Add(str);
                    str = ((char)(c - 'A' + 'a')).ToString();
                }
                else if (c == '_' || c == '-')
                {
                    list.Add(str);
                    str = "";
                }
            }
            list.Add(str);

            string result = "";
            if (nameStyle == NameStyle.LowerCamel)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        result += list[0];
                        continue;
                    }

                    string s = list[i];
                    result += (char)(s[0] - 'a' + 'A') + s.Substring(1, s.Length - 1);
                }
            }
            else if (nameStyle == NameStyle.UpperCamel)
            {
                foreach (string s in list) result += (char)(s[0] - 'a' + 'A') + s.Substring(1, s.Length - 1);
            }
            else if (nameStyle == NameStyle.Snake) result = string.Join("_", list);
            else if (nameStyle == NameStyle.Hyphen) result = string.Join("-", list);
            return result;
        }
    }
}