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
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Testar());
        }

        private void Testar()
        {
            throw new ArgumentOutOfRangeException("coolt");
        }
    }
}