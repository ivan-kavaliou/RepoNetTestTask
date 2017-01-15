using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary.Tests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod()]
        public void InitModelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateNodeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShowMatrixTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShowTotalJourneyTimeTestForFirstJourney()
        {
            int expectedResult = 10;
            string[] firstJourney = new string[] { "Buenos Aires", "New York", "Liverpool", };
            Model newModel = new Model();
            newModel.InitModel();
            int actualResult = newModel.ShowTotalJourneyTime(firstJourney);

            Assert.AreEqual<int>(expectedResult, actualResult);

        }
        [TestMethod()]
        public void ShowTotalJourneyTimeTestForSecondJourney()
        {
            int expectedResult = 8;
            string[] secondJourney = new string[] { "Buenos Aires", "Casablanca", "Liverpool" };
            Model newModel = new Model();
            newModel.InitModel();
            int actualResult = newModel.ShowTotalJourneyTime(secondJourney);

            Assert.AreEqual<int>(expectedResult, actualResult);

        }
        [TestMethod()]
        public void ShowTotalJourneyTimeTestForThirdJourney()
        {
            int expectedResult = 19;
            string[] thirdJourney = new string[] { "Buenos Aires", "Cape Town", "New York", "Liverpool", "Casablanca" };
            Model newModel = new Model();
            newModel.InitModel();
            int actualResult = newModel.ShowTotalJourneyTime(thirdJourney);

            Assert.AreEqual<int>(expectedResult, actualResult);

        }
        [TestMethod()]
        public void ShowTotalJourneyTimeTestForFourthJourney()
        {
            int expectedResult = -1;
            string[] fourthJourney = new string[] { "Buenos Aires", "Cape Town", "Casablanca" };
            Model newModel = new Model();
            newModel.InitModel();
            int actualResult = newModel.ShowTotalJourneyTime(fourthJourney);

            Assert.AreEqual<int>(expectedResult, actualResult);

        }

        [TestMethod()]
        public void ShowShortJourneyTimeTestForFifthJourney()
        {
            int expectedResult = 8;
            string[] fifthJourney = new string[] { "Buenos Aires", "Liverpool" };
            Model newModel = new Model();
            newModel.InitModel();
            newModel.CalculateNode();
            int actualResult = newModel.ShowShortJourneyTime(fifthJourney);

            Assert.AreEqual<int>(expectedResult, actualResult);

        }

        [TestMethod()]
        public void ShowShortJourneyTimeTestForSixthJourney()
        {
            int expectedResult = 18;
            string[] sixthJourney = new string[] { "New York", "New York" };
            Model newModel = new Model();
            newModel.InitModel();
            newModel.CalculateNode();
            int actualResult = newModel.ShowShortJourneyTime(sixthJourney);

            Assert.AreEqual<int>(expectedResult, actualResult);

        }
    }
}