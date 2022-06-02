namespace ProjGarageMSTests
{
    [TestClass]
    public class GarageTest
    {
        [TestMethod]
        public void SpendMoney_AmountIsLessThanZero_Throws()
        {
            //Arrange

            //Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testar());
        }

        private void testar()
        {
            throw new ArgumentOutOfRangeException("coolt");
        }
    }
}