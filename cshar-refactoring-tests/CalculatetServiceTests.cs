using c__refactoring.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace cshar_refactoring_tests
{
    [TestClass]
    public class CalculatetServiceTests
    {

        [TestMethod]
        public void CalculateAmountReturnsCorrectAmountTypeTragedy()
        {
            //Arrange
            var jToken = JObject.FromObject(new { type = "tragedy" });
            var calculateService = new CalculateService();

            //Act
            var result = calculateService.CalculateAmount(jToken, 56);

            //Assert
            Assert.AreEqual(66000, result);
        }

        [TestMethod]
        public void CalculateAmountReturnsWrongAmountTypeTragedy()
        {
            //Arrange
            var jToken = JObject.FromObject(new { type = "tragedy" });
            var calculateService = new CalculateService();

            //Act
            var result = calculateService.CalculateAmount(jToken, 56);

            //Assert
            Assert.AreNotEqual(4325, result);
        }

        [TestMethod]
        public void CalculateAmountReturnsCorrectAmountTypeComedy()
        {
            //Arrange
            var jToken = JObject.FromObject(new { type = "comedy" });
            var calculateService = new CalculateService();

            //Act
            var result = calculateService.CalculateAmount(jToken, 56);

            //Assert
            Assert.AreEqual(74800, result);
        }

        [TestMethod]
        public void CalculateAmountThrowsException()
        {
            //Arrange
            var jToken = JObject.FromObject(new { type = "wrongPlayType" });
            var calculateService = new CalculateService();

            //Act
            var result = Assert.ThrowsException<FormatException>(() => calculateService.CalculateAmount(jToken, 1));

            //Assert
            Assert.AreNotEqual(66000, result);
        }
    }
}