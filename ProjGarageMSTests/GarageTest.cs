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
        public void Constructor_ItemCount_InitsAsZero() => Assert.AreEqual(0, initGarage.Count<IVehicle>());

        [TestMethod]
        public void ItemCount_IncreasesAfterAdd()
        {
            initGarage.Add(new Vehicle(new LicensePlate("ABC123")));
            Assert.AreEqual(1, initGarage.Count<IVehicle>());
        }
        
        [TestMethod]
        public void ItemCount_DecreasesAfterRemove()
        {
            initGarage.Add(new Vehicle(new LicensePlate("ABC111")));
            initGarage.Add(new Vehicle(new LicensePlate("ABC222")));
            initGarage.Add(new Vehicle(new LicensePlate("ABC333")));
            initGarage.Remove(new Vehicle(new LicensePlate("ABC111")));
            Assert.AreEqual(2, initGarage.Count<IVehicle>());
        }

        [TestMethod]
        public void GetEnumerator_BledningAddRemoves_ExpectedOrderAndAmount()
        {
            IVehicle car1 = new Vehicle(new LicensePlate("ABC111"));
            initGarage.Add(car1);
            IVehicle car2 = new Vehicle(new LicensePlate("ABC222"));
            initGarage.Add(car2);
            IVehicle car3 = new Vehicle(new LicensePlate("ABC333"));
            initGarage.Add(car3);
            //1, 2, 3

            try
            {
                //Should not be added since duplicate
                initGarage.Add(car3);
                //still: 1, 2, 3
            }
            catch
            {
            }

            initGarage.Remove(car1);
            //null, 2, 3

            initGarage.Remove(car1);
            //still: null, 2, 3

            initGarage.Remove(car2);
            //null, null, 3

            IVehicle car4 = new Vehicle(new LicensePlate("ABC444"));
            initGarage.Add(car4);
            IVehicle car5 = new Vehicle(new LicensePlate("ABC555"));
            initGarage.Add(car5);
            IVehicle car6 = new Vehicle(new LicensePlate("ABC666"));
            initGarage.Add(car6);
            IVehicle car7 = new Vehicle(new LicensePlate("ABC777"));
            initGarage.Add(car7);
            IVehicle car8 = new Vehicle(new LicensePlate("ABC888"));
            initGarage.Add(car8);
            //4, 5, 3, 6, 7, 8  (since spots 1, 2 was null those got filled first)

            initGarage.Remove(car7);
            //4, 5, 3, 6, null, 8

            IEnumerable weak = initGarage.AsWeakEnumerable();
            var sequence = weak.Cast<ProjGarage.Vehicles.Vehicle>().Take(10).ToArray();
            CollectionAssert.AreEqual(sequence,
                new[] { car4, car5, car3, car6, car8 }, new CarComparer());
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