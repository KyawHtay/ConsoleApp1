using ConsoleApp1.interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    public class PriceEngine
    {
        private IQuatationSystem _system1;
        private IQuatationSystem _system2;
        private IQuatationSystem _system3;
        public PriceEngine(IQuatationSystem q1, IQuatationSystem q2, IQuatationSystem q3)
        {
            _system1 = q1;
            _system2 = q2;
            _system3 = q3;
        }
        //pass request with risk data with details of a gadget, return the best price retrieved from 3 external quotation engines
        public decimal GetPrice(PriceRequest request, out decimal tax, out string insurerName, out string errorMessage)
        {
            //initialise return variables
            tax = 0;
            insurerName = "";
            errorMessage = "";

            //validation
            if (request.RiskData == null)
            {
                errorMessage = "Risk Data is missing";
                return -1;
            }

            if (String.IsNullOrEmpty(request.RiskData.FirstName))
            {
                errorMessage = "First name is required";
                return -1;
            }

            if (String.IsNullOrEmpty(request.RiskData.LastName))
            {
                errorMessage = "Surname is required";
                return -1;
            }

            if (request.RiskData.Value == 0)
            {
                errorMessage = "Value is required";

                return -1;
            }


            //now call 3 external system and get the best price
            decimal price = 0;

            dynamic systemRequest1 = new ExpandoObject();
            systemRequest1.FirstName = request.RiskData.FirstName;
            systemRequest1.Surname = request.RiskData.LastName;
            systemRequest1.DOB = request.RiskData.DOB;
            systemRequest1.Make = request.RiskData.Make;
            systemRequest1.Amount = request.RiskData.Value;


            //system 1 requires DOB to be specified
            if (request.RiskData.DOB != null)
            {

                dynamic system1Response = _system1.GetPrice(systemRequest1);
                if (system1Response.IsSuccess)
                {
                    price = system1Response.Price;
                    insurerName = system1Response.Name;
                    tax = system1Response.Tax;
                }
            }

            //system 2 only quotes for some makes
            if (request.RiskData.Make == "examplemake1" || request.RiskData.Make == "examplemake2" ||
                request.RiskData.Make == "examplemake3")
            {


                dynamic system2Response = _system2.GetPrice(systemRequest1);
                if (system2Response.HasPrice && system2Response.Price < price)
                {
                    price = system2Response.Price;
                    insurerName = system2Response.Name;
                    tax = system2Response.Tax;
                }
            }

            //system 3 is always called

            var system3Response = _system3.GetPrice(systemRequest1);
            if (system3Response.IsSuccess && system3Response.Price < price)
            {
                price = system3Response.Price;
                insurerName = system3Response.Name;
                tax = system3Response.Tax;
            }

            if (price == 0)
            {
                price = -1;
            }

            return price;
        }
    }
}
