using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    internal class Setter
    {
        public int Value1 { get; private set; } = 10;

        public void MyDo(int Value1)
        {
            this.Value1 = Value1;
        }


    }

}
