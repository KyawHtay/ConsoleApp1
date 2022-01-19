using ConsoleApp1;
using ConsoleApp1.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp
{
    [TestClass]
    public class ConsoleAppUniTest
    {
        PriceRequest request = new PriceRequest()
        {
            RiskData = new RiskData() //hardcoded here, but would normally be from user input above
            {
                DOB = DateTime.Parse("1980-01-01"),
                FirstName = "John",
                LastName = "Smith",
                Make = "Cool New Phone",
                Value = 500
            }
        };
        [TestMethod]
        public void GetPrice_Price92_Pass()
        {
            //Arrange

            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual(92M, price);
        }
        [TestMethod]
        public void GetPrice_Tax012_Pass()
        {
            //Arrange

            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual(92M * 0.12M, tax);
        }
        [TestMethod]
        public void GetPrice_insurerZxcvbnm_Pass()
        {
            //Arrange

            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual("zxcvbnm", insurer);
        }

        [TestMethod]
        public void GetPrice_RiskDataismissing_Pass()
        {
            //Arrange
            var request1 = new PriceRequest()
            {
                RiskData = null
            };
            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request1, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual(-1, price);
        }


        [TestMethod]
        public void GetPrice_FirstNameIsEmpty_Pass()
        {
            //Arrange
            PriceRequest request1 = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                }
            };
            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request1, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual(-1, price);
        }

        [TestMethod]
        public void GetPrice_LastNameIsEmpty_Pass()
        {
            //Arrange
            PriceRequest request1 = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "",
                    Make = "Cool New Phone",
                    Value = 500
                }
            };
            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request1, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual(-1, price);
        }

        [TestMethod]
        public void GetPrice_ValueIsZero_Pass()
        {
            //Arrange
            PriceRequest request1 = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "",
                    Make = "Cool New Phone",
                    Value = 0
                }
            };
            decimal tax = 0;
            string insurer = "";
            string error = "";
            IQuatationSystem q1 = new QuotationSystem(123.45M, true, "Test Name", 0.12M);
            IQuatationSystem q2 = new QuotationSystem(234.56M, true, "qewtrywrh", 0.12M);
            IQuatationSystem q3 = new QuotationSystem(92M, true, "zxcvbnm", 0.12M);
            // Act
            var priceEngine = new PriceEngine(q1, q2, q3);
            var price = priceEngine.GetPrice(request1, out tax, out insurer, out error);
            // Assert
            Assert.AreEqual(-1, price);
        }
    }
}
