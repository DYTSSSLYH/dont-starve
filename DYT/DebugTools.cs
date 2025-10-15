using System;
using System.Collections.Generic;

namespace DYT
{
    public class DebugTools
    {
        public static string tabletoliststring(List<string> obj, Func<string, string> fn)
        {
            if (obj == null) return "[ ]";

            string s = "[ ";
            bool first = true;
            foreach (string v in obj)
            {
                if (!first) s += ", ";
                else first = false;
                
                if (fn != null) s += fn.Invoke(v);
            }
            s += " ]";
            return s;
        }
    }
}