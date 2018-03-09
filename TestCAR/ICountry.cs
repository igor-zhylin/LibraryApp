using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCAR
{
    public interface ISomeInterface
    {
        string SomeProperty { get; set; }

        string this[int index] { get;set; }
        void SomeMethod(int a);
        void SomeMethod(string b);
        event EventHandler SomeEvent;

    }
}
