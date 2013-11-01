using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LBTCPrototype.LBTCAPI;
using LBTCPrototype.ServiceReference1;
using RestSharp;

namespace LBTCPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            LBTSAPI api = new LBTSAPI(null,null,null,null);

            var response = api.Authorize();

            Console.ReadLine();
        }
    }
}
