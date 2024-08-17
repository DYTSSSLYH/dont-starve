using System;
using System.Reflection;

namespace DYT.Tools
{
    public static class BeanTool
    {
        public static void CopyFields(object from, object to)
        {
            foreach (FieldInfo fromFieldInfo in from.GetType().GetFields())
            {
                FieldInfo toFieldInfo = to.GetType().GetField(fromFieldInfo.Name);
                if (toFieldInfo == null) continue;
                
                toFieldInfo.SetValue(to, fromFieldInfo.GetValue(from));
            }
        }
        
        public static void CopyFields(object from, Type to)
        {
            foreach (FieldInfo fromFieldInfo in from.GetType().GetFields())
            {
                FieldInfo toFieldInfo = to.GetField(fromFieldInfo.Name);
                if (toFieldInfo == null) continue;
                
                toFieldInfo.SetValue(null, fromFieldInfo.GetValue(from));
            }
        }
    }
}