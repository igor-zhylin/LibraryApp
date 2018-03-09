using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCAR
{
    public abstract class SomeClass
    {
        public string abstract SomeProperty { get; set; }

        string abstract this[int index] { get; set; }
        void abstract SomeMethod(int a);
        void abstract SomeMethod(string b);
        event abstract EventHandler SomeEvent;
    }
}
