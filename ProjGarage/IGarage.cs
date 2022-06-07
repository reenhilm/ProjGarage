namespace ProjGarage
{
    internal interface IGarage<T> : IEnumerable<T>
    {
        //T this[int index] { get; }
        int Length { get; }
        bool Add(T vehicle);
        bool Remove(T vehicle);
    }
}