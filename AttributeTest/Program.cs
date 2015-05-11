using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            qoo q = new qoo();
            q.str3 = "152";
            q.CHeckLength<qoo>();
            Console.ReadKey();
            //gg g1 = new gg();
            //g1.rt = ReportType.Succeed;
            //string Msg = g1.GetEnumAttribute(g1.rt);
            //var cc = (qoo)c1.str.GetType().GetCustomAttributes(true)[0];
            //System.Reflection.MemberInfo info = typeof(MyClass);
            //object[] attributes = info.GetCustomAttributes(true);
            //for (int i = 0; i < attributes.Length; i++)
            //{
            //    System.Console.WriteLine(attributes[i]);
            //}
            
        }
    }
}
