using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AttributeTest
{

    public class qoo 
    {
        
        public string str { get; set; }

        
        public string str2 { get; set; }

        [LengthCkeck(FixLength=2)]
        public string str3 { get; set; }
    }


    /*
    public class CustomAttribute : Attribute
    {
        private readonly string _other;
        public CustomAttribute(string other)
        {
            _other = other;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_other);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format("Unknown property: {0}", _other)
                );
            }
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);

            // at this stage you have "value" and "otherValue" pointing
            // to the value of the property on which this attribute
            // is applied and the value of the other property respectively
            // => you could do some checks
            if (!object.Equals(value, otherValue))
            {
                // here we are verifying whether the 2 values are equal
                // but you could do any custom validation you like
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
    */
    class class1
    {
        
    }
    //-------------------------------------------------------------------
    namespace qq
    {
    // AttributesTutorial.cs
    // This example shows the use of class and method attributes.
    
        using System;
        using System.Reflection;
        using System.Collections;

        // The IsTested class is a user-defined custom attribute class.
        // It can be applied to any declaration including
        //  - types (struct, class, enum, delegate)
        //  - members (methods, fields, events, properties, indexers)
        // It is used with no arguments.
        public class IsTestedAttribute : Attribute
        {
            public override string ToString()
            {
                return "Is Tested";
            }
        }

        // The AuthorAttribute class is a user-defined attribute class.
        // It can be applied to classes and struct declarations only.
        // It takes one unnamed string argument (the author's name).
        // It has one optional named argument Version, which is of type int.
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
        public class AuthorAttribute : Attribute
        {
            // This constructor specifies the unnamed arguments to the attribute class.
            public AuthorAttribute(string name)
            {
                this.name = name;
                this.version = 0;
            }

            // This property is readonly (it has no set accessor)
            // so it cannot be used as a named argument to this attribute.
            public string Name
            {
                get
                {
                    return name;
                }
            }

            // This property is read-write (it has a set accessor)
            // so it can be used as a named argument when using this
            // class as an attribute class.
            public int Version
            {
                get
                {
                    return version;
                }
                set
                {
                    version = value;
                }
            }

            public override string ToString()
            {
                string value = "Author : " + Name;
                if (version != 0)
                {
                    value += " Version : " + Version.ToString();
                }
                return value;
            }

            private string name;
            private int version;
        }

        // Here you attach the AuthorAttribute user-defined custom attribute to 
        // the Account class. The unnamed string argument is passed to the 
        // AuthorAttribute class's constructor when creating the attributes.
        [Author("Joe Programmer")]
        class Account
        {
            [IsTested]
            public string Qoo { get; set; }
            // Attach the IsTestedAttribute custom attribute to this method.
            [IsTested]
            public void AddOrder(Order orderToAdd)
            {
                orders.Add(orderToAdd);
            }

            private ArrayList orders = new ArrayList();
        }

        // Attach the AuthorAttribute and IsTestedAttribute custom attributes 
        // to this class.
        // Note the use of the 'Version' named argument to the AuthorAttribute.
        [Author("Jane Programmer", Version = 2), IsTested()]
        class Order
        {
            // add stuff here ...
        }

        class MainClass
        {
            private static bool IsMemberTested(MemberInfo member)
            {
                foreach (object attribute in member.GetCustomAttributes(true))
                {
                    if (attribute is IsTestedAttribute)
                    {
                        return true;
                    }
                }
                return false;
            }

            private static void DumpAttributes(MemberInfo member)
            {
                Console.WriteLine("Attributes for : " + member.Name);
                foreach (object attribute in member.GetCustomAttributes(true))
                {
                    Console.WriteLine(attribute);
                }
            }

            public static void Main2()
            {
                Account cc = new Account();
                cc.Qoo = "123";
                // display attributes for Account class
                DumpAttributes(typeof(Account));

                //display list of property members
                

                // display list of tested members
                foreach (MethodInfo method in (typeof(Account)).GetMethods())
                {
                    if (IsMemberTested(method))
                    {
                        Console.WriteLine("Member {0} is tested!", method.Name);
                    }
                    else
                    {
                        Console.WriteLine("Member {0} is NOT tested!", method.Name);
                    }
                }
                Console.WriteLine();

                // display attributes for Order class
                DumpAttributes(typeof(Order));

                // display attributes for methods on the Order class
                foreach (MethodInfo method in (typeof(Order)).GetMethods())
                {
                    if (IsMemberTested(method))
                    {
                        Console.WriteLine("Member {0} is tested!", method.Name);
                    }
                    else
                    {
                        Console.WriteLine("Member {0} is NOT tested!", method.Name);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
