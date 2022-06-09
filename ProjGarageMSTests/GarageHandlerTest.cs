using ProjGarage;

namespace ProjGarageMSTests
{
    [TestClass]
    public class GarageHandlerTests
    {
        GarageHandler initGH = null!;

        [TestInitialize]
        public void Init() => initGH = new(10);

        [TestMethod]
        public void PrintVehiclesList_EmptyGarage_EmptyString()
        {
            string actual = string.Empty;

            initGH.PrintVehiclesList((printString) => { actual = printString; });

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void PrintVehiclesList_FilledGarage_NotEmptyString()
        {
            string actual = string.Empty;
            initGH.ParkVehicle("abc111", (printString1) => { return; });

            initGH.PrintVehiclesList((printString2) => { actual = printString2; });

            Assert.AreEqual("ABC111\r\n", actual);
        }
    }
}