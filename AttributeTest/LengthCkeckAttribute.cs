using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true,Inherited=false)]
    public class LengthCkeckAttribute : Attribute
    {
        /// <summary>
        /// 自訂的固定長度
        /// </summary>
        public int FixLength { get; set; }
    }

    public static class Extension
    {
        private static object lockObj = new object();

        public static void CHeckLength<T>(this T obj)
        {
            lock (lockObj)
            {
                PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties.AsEnumerable())
                {
                    LengthCkeckAttribute attr = Attribute.GetCustomAttribute(property, typeof(LengthCkeckAttribute)) as LengthCkeckAttribute;
                    if (attr != null)
                    {
                        object propertyValue = property.GetValue(obj);
                        if (propertyValue is string && !string.IsNullOrEmpty((string)propertyValue))
                        {
                            int valueLength = ((string)propertyValue).Length;
                            if (attr.FixLength != valueLength)
                            {
                                throw new Exception(property.Name + "屬性與設定資料長度不符 => 輸入的資料長度:" + valueLength + " \n不同於屬性設定的長度:" + attr.FixLength);
                            }
                            
                        }
                        else
                        {
                            throw new Exception( property.Name + "屬性:資料型態不為字串或資料為空!!!");
                        }
                    }
                }
            }
        }
    }
}
