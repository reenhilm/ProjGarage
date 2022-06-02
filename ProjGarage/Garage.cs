using ProjGarage.Vehicles;
using System.Collections;

namespace ProjGarage
{
    internal class Garage<T> : IGarage<T> where T : IVehicle
    {
        private T[] itemArr;
        public int Length { get; private set; } = 0!;
        private int capacity;

        //public T this[int index] => itemArr[index];

        public Garage(int capacity)
        {
            this.itemArr = new T[capacity];
            this.capacity = capacity;
        }

        public void Add(T item)
        {
            //TODO return success
            if (Length < capacity)
                this.itemArr[Length++] = item;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void Remove(T item)
        {
            //TODO kanske onödigt att gå igenom hela arrayen när vi vet att Licenseplate är unikt och bara ska finnas med 1 gång
            itemArr = itemArr.MergeWith(itemArr.Where(val => val?.Licenseplate != item.Licenseplate)).ToArray();
            Length--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0;i<Length;i++)
                yield return this.itemArr[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
