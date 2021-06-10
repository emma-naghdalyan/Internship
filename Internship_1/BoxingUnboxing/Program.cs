using System;
using System.Collections;

namespace BoxingUnboxing
{
    struct Point
    {
        public int x, y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 9;
            object ob = a; // boxing
            int j = (int)ob; // unboxing
            //byte b = (byte)ob; // InvalidCastException
            byte b = (byte)(int)ob; // there is not InvalidCastException

            Point p;
            p.x = p.y = 10;
            Object o = p; // Boxes p. o refers to the boxed instance 
            p = (Point)o; // Unboxes o AND copies fields from boxed  inst ance to stack variable

            ArrayList arr = new ArrayList();
            Point point; // Allocate a Point (not in the heap). 
            for (Int32 i = 0; i < 10; i++)
            {
                point.x = point.y = 5; // Initialize the members in the value type. 
                arr.Add(p); // Box the value type and add the reference to the Arraylist. 
            }


            Int32 v = 5; // Create an unboxed value type variable. 
            Object obj = v; // o refers to a boxed Int32 containing 5. 
            v = 123; // Changes the unboxed value to 123 
            Console.WriteLine(v + ", " + (Int32)obj); // Displays "123, 5
        }
    }
}
