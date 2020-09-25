using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Setter st = new Setter();
            Console.WriteLine(st.Value1);

            //st.Value1 = 100;
            st.MyDo(123);

            Console.WriteLine(st.Value1);
            Console.ReadLine();
        }
    }
}
