using ProjGarage.Vehicles;
using System.Collections;

namespace ProjGarage
{
    internal class DuplicatePlateException : Exception
    {
        public DuplicatePlateException()
        {
        }

        public DuplicatePlateException(string message)
            : base(message)
        {
        }

        public DuplicatePlateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
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

        public bool Add(T item)
        {
            var HasItem = this.itemArr.FirstOrDefault(val => val?.Licenseplate.Value == item.Licenseplate.Value);
            if(HasItem != null)
                throw new DuplicatePlateException(nameof(item));

            if (Length < capacity)
                this.itemArr[Length++] = item;
            else
                throw new ArgumentOutOfRangeException(nameof(item));

            return true;
        }

        /// <summary>
        /// removes true if items have been removed
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            int iBefore = itemArr.Count();
            var newArr = itemArr.Where(val => val?.Licenseplate.Value != item.Licenseplate.Value);
            int iAfter = newArr.Count();
            itemArr = itemArr.MergeWith(newArr).ToArray();
            Length -= (iBefore - iAfter);
            return iAfter != iBefore;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0;i<Length;i++)
                yield return this.itemArr[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
