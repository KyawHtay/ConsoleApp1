using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.interfaces
{
    public interface IQuatationSystem
    {
        decimal price { get; set; }
        bool success { get; set; }
        string name { get; set; }
        dynamic GetPrice(dynamic systemRequest1);
    }
}
