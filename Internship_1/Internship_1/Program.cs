using System;
using System.Collections.Generic;
using DateTimeList = System.Collections.Generic.List<System.DateTime>;

namespace Internship_1
{
    #region Generics Types And Inheritance
    internal class Node
    {
        protected Node m_next;
        public Node(Node next)
        {
            m_next = next;
        }
    }
    internal sealed class TypedNode<T> : Node
    {
        public T m_data;
        public TypedNode(T data) : this(data, null)
        {
        }
        public TypedNode(T data, Node next) : base(next)
        {
            m_data = data;
        }
        public override String ToString()
        {
            return m_data.ToString() + ((m_next != null) ? m_next.ToString() : String.Empty);
        }
    }
    #endregion

    #region Open and closed types
    // A partially specified open type 
    internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue>
    {
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region Generics Types And Inheritance
            Node head = new TypedNode<Char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("Today is ", head);
            Console.WriteLine(head.ToString());
            Console.WriteLine();
            #endregion

            #region Open and closed types
            Object o = null;
            // Dictionary<,> is an open type having 2 type parameters 
            Type t = typeof(Dictionary<,>);
            // Try to create an instance of this type (fails) 
            o = CreateInstance(t);
            Console.WriteLine();
            // DictionaryStringKey<> is an open type having 1 type parameter 
            t = typeof(DictionaryStringKey<>);
            // Try to create an instance of this type (fails) 
            o = CreateInstance(t);
            Console.WriteLine();
            // DictionaryStringKey<Guid> is a closed type 
            t = typeof(DictionaryStringKey<Guid>);
            // Try to create an instance of this type (succeeds) 
            o = CreateInstance(t);
            // Prove it actually worked 
            Console.WriteLine("Object type=" + o.GetType());
            Console.WriteLine();
            #endregion

            #region Generic Type Identity
            List<DateTime> dt1 = new List<DateTime>();
            DateTimeList dt2 = new DateTimeList();
            Boolean sameType = (typeof(List<DateTime>) == typeof(DateTimeList));
            Console.WriteLine(sameType);
            Console.WriteLine(dt1.GetType() == dt2.GetType());
            Console.WriteLine();
            #endregion

            #region Generic Methods
            Display("Hi, everybody");
            Display(123);
            Display<String>("Hello");
            Console.WriteLine();

            string in1 = "Hello";
            object in2 = "world";
            //Console.WriteLine(GenMeth<string>(ref in1, ref in2));
            Console.WriteLine();
            #endregion

            #region The CLR Has Special Support for Nullable Value Types
            /* Int32? nullableType = null;
            Object ob = nullableType; // no boxing
            Console.WriteLine($"Ob is null : {ob == null} ");
            Console.WriteLine();

            nullableType = 2;
            ob = nullableType; //boxing
            Console.WriteLine($"Ob type is : {ob.GetType()}");
            Console.WriteLine();

            // Unboxing, works correct
            Int32? a = (Int32?)ob;
            Int32 b = (Int32)ob;

            // Unboxing when object equals null
            ob = null;
            a = (Int32?)ob; // a=null;
            //b = (Int32)ob; // NullReferenceException 


            Int32 c = 4;
            Console.WriteLine(c.GetType()); // System.Int32 instead of System.Nullable<Int32>
            Console.WriteLine();

            Int32? n = 5;
            Int32 result = ((IComparable)n).CompareTo(5); // Compiles & runs OK, writes 0, which means that this instance is equal to value(n)
            Console.WriteLine(result);*/
            #endregion
        }

        #region Generic Methods
        public static void Display(string input)
        {
            Console.WriteLine(input);
        }

        public static void Display<T>(T input)
        {
            Display(input.ToString());
        }

        public static T GenMeth<T>(ref T in1, ref T in2)
        {
            T a = in1;
            in2 = in1;

            return a;
        }
        #endregion

        #region Open and closed types
        private static Object CreateInstance(Type t)
        {
            Object o = null;
            try
            {
                o = Activator.CreateInstance(t);
                Console.Write("Created instance of {0}", t.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return o;
        }
        #endregion
    }
}
