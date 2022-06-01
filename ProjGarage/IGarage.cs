namespace ProjGarage
{
    internal interface IGarage<T> : IEnumerable<T>
    {
        //T this[int index] { get; }
        int Length { get; }
        void Add(T vehicle);
        void Remove(T vehicle);
    }
}