using ProjGarage.Vehicles;
using System.Collections;

namespace ProjGarage
{
    //GarageOld also works, but it recreates the array, do we care about performance issue?
    internal class Garage<T> : IGarage<T> where T : class, IVehicle
    {
        private T[] itemArr;
        private int capacity;
        public Garage(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            this.itemArr = new T[this.capacity];
        }
        public bool Add(T item)
        {
            bool bWasFull = true;
            int iIndexUsed = -1;
            for (int i = 0; i < capacity; i++)
            {
                if (itemArr[i] != default(T))
                {
                    if (this.itemArr[i]?.Licenseplate.Value == item.Licenseplate.Value)
                    {
                        //Vehicle already existed in the array, check if we have already added vehicle in this iteration and undo it because it should not have been added, then throw
                        if (iIndexUsed != -1)
                            this.itemArr[iIndexUsed] = default!;

                        throw new DuplicatePlateException(nameof(item));
                    }
                }

                //we have an unused slot in the array and we have not already added it since iIndexUsed is -1
                if (itemArr[i] == default(T) && iIndexUsed == -1)
                {
                    bWasFull = false;
                    this.itemArr[i] = item;
                    iIndexUsed = i;
                }
            }

            if(bWasFull)
                throw new ArgumentOutOfRangeException(nameof(item));

            return true;
        }

        /// <summary>
        /// returns true if items have been removed
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            for(int i = 0; i < capacity; i++)
            {
                if (this.itemArr[i]?.Licenseplate.Value == item.Licenseplate.Value)
                { 
                    this.itemArr[i] = default!;
                    return true;
                }
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0;i<capacity;i++)
            { 
                if(itemArr[i] != default(T))
                    yield return this.itemArr[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
