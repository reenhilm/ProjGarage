//using ProjGarage
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Reflection;

//namespace Main.Tests
//{
//    [TestClass]
//    public class MainTest
//    {
//        [TestInitialize]
//        public void Init()
//        {
//            Manager man = new
//            ProjGarage.Manager.ui = new ProjGarage.MockUI();
//        }

//        [TestMethod]
//        [DataRow("2", "2 2 2 2 2 2 2 2 2 2")]
//        public void Multiply10(string strUserInput, string shouldReturn)
//        {
//            //Arrange
//            ProjGarage.MockUI.SetInput = strUserInput;

//            //Act
//            ProjGarage.Main.Multiply10();
//            string doesReturn = ProjGarage.MockUI.LastOutput;

//            //Assert
//            Assert.AreEqual(doesReturn, shouldReturn);
//        }

//        [TestMethod]
//        [DataRow(" jag   heter  Christian Rönnholm", "Christian")]
//        public void GetThird(string strUserInput, string shouldReturn)
//        {
//            //Arrange
//            ProjGarage.MockUI.SetInput = strUserInput;

//            //Act
//            ProjGarage.Main.GetThird();
//            string doesReturn = ProjGarage.MockUI.LastOutput;

//            //Assert
//            Assert.AreEqual(doesReturn, shouldReturn);
//        }

//        [TestMethod]
//        [DataRow("3", "Enter visitors age:")]
//        [DataRow("50", "Standardpris 120kr")]
//        public void Lookup1Visitor(string strUserInput, string shouldReturn)
//        {
//            //Arrange
//            ProjGarage.MockUI.SetInput = strUserInput;

//            //Act
//            ProjGarage.Main.Lookup1Visitor();
//            string doesReturn = ProjGarage.MockUI.LastOutput;

//            //Assert
//            Assert.AreEqual(doesReturn, shouldReturn);
//        }

//        /// <summary>
//        /// invoking private static method addNewVisitorToTotal on Main class using reflection because we want that method to stay private yet be tested
//        /// </summary>
//        /// <param name="dStartValue"></param>
//        /// <param name="strUserInput"></param> Age of Visitor
//        /// <param name="shouldReturn"></param>
//        [TestMethod]
//        [DataRow(0, "50", 120)]
//        [DataRow(120, "75", 210)]
//        public void TestAddNewVisitorToTotal(double dStartValue, string strUserInput, double shouldReturn)
//        {
//            //Arrange
//            ProjGarage.MockUI.SetInput = strUserInput;
//            ProjGarage.Main objUnderTest = new ();
//            MethodInfo? methodInfo = typeof(ProjGarage.Main).GetMethod("AddNewVisitorToTotal", BindingFlags.NonPublic | BindingFlags.Static);
//            object[] parameters = { dStartValue };

//            //Act
//#pragma warning disable CS8605 // Unboxing a possibly null value.
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//            double doesReturn = (double)methodInfo.Invoke(objUnderTest, parameters);
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
//#pragma warning restore CS8605 // Unboxing a possibly null value.

//            //Assert
//            Assert.AreEqual(doesReturn, shouldReturn);
//        }        

//        [TestMethod]
//        [DataRow(4, "Exercise2.ExceptionPrice")]
//        [DataRow(50, "Standardpris 120kr")]
//        [DataRow(16, "Ungdomspris 80kr")]
//        [DataRow(101, "Exercise2.ExceptionPrice")]
//        [DataRow(65, "Pensionärspris 90kr")]
//        public void VisitorPrice_ToString(int iUserInput, string shouldReturn)
//        {
//            //Arrange
//            Visitor v = new (iUserInput);

//            //Act
//            string? doesReturn = v.Price.ToString();

//            //Note: ExceptionPrice is not meant to be printed
//            //Assert
//            Assert.AreEqual(doesReturn, shouldReturn);
//        }
//    }
//}