using ConsoleApp1.interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class QuotationSystem : IQuatationSystem
    {
        public decimal price { get; set; }
        public bool success { get; set; }
        public string name { get; set; }
        public decimal rate { get; set; }


        public QuotationSystem(string url, string port)
        {

        }
        public QuotationSystem(string url, string port, dynamic request)
        {

        }
        public QuotationSystem(decimal _price, bool _success, string _name, decimal _rate, string url = null, string port = null, dynamic request = null)
        {
            price = _price;
            success = _success;
            name = _name;
            rate = _rate;


        }


        public dynamic GetPrice(dynamic requestData)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = price;
            response.IsSuccess = success;
            response.Name = name;
            response.Tax = price * rate;

            return response;
        }


    }
}
