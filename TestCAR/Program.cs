namespace TestCAR
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Program
    {

        class car
        {
            private const int a = 10;

            private static readonly int b;
            static car()
            {
                b = 10;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
