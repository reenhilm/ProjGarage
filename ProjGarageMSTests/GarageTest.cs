using ProjGarage;
using ProjGarage.Vehicles;
using System.Collections;

namespace ProjGarageMSTests
{
    [TestClass]
    public class GarageTest
    {
        Garage<IVehicle> initGarage = null!;

        [TestInitialize]
        public void Init() => initGarage = new(10);

        [TestMethod]
        public void Constructor_CapacityIsLessThanZero_DoesNotThrow()
        {
            Garage<IVehicle> garageMinus = new(-10);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Count_InitsZero() => Assert.AreEqual(0, initGarage.Count<IVehicle>());

        [TestMethod]
        public void Count_IncreasesAfterAdd()
        {
            initGarage.Add(new Vehicle(new LicensePlate("ABC123")));
            Assert.AreEqual(1, initGarage.Count<IVehicle>());
        }
        
        [TestMethod]
        public void Count_DecreasesAfterRemove()
        {
            initGarage.Add(new Vehicle(new LicensePlate("ABC111")));
            initGarage.Add(new Vehicle(new LicensePlate("ABC222")));
            initGarage.Add(new Vehicle(new LicensePlate("ABC333")));
            initGarage.Remove(new Vehicle(new LicensePlate("ABC111")));
            Assert.AreEqual(2, initGarage.Count<IVehicle>());
        }

        [TestMethod]
        public void GetEnumerator_FirstFive_AreCorrect()
        {
            IVehicle car1 = new Vehicle(new LicensePlate("ABC111"));
            initGarage.Add(car1);
            IVehicle car2 = new Vehicle(new LicensePlate("ABC222"));
            initGarage.Add(car2);
            IVehicle car3 = new Vehicle(new LicensePlate("ABC333"));
            initGarage.Add(car3);

            initGarage.Remove(car2);

            IEnumerable weak = initGarage.AsWeakEnumerable();
            var sequence = weak.Cast<ProjGarage.Vehicles.Vehicle>().Take(2).ToArray();
            CollectionAssert.AreEqual(sequence,
                new[] { car1, car3 }, new CarComparer());
        }
    }

    public static class Helper
    {
        // Helper extension method
        public static IEnumerable AsWeakEnumerable(this IEnumerable source)
        {
            foreach (object o in source)
                yield return o;
        }
    }

    public class CarComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null || y == null)
                return -1;
            else
            { 
                if (((IVehicle)x).Licenseplate.Value == ((IVehicle)y).Licenseplate.Value)
                    return 0;
                else
                    return -1;
            }
        }
    }
}