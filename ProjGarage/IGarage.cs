namespace ProjGarage
{
    internal interface IGarage<T> : IEnumerable<T>
    {
        bool Add(T vehicle);
        bool Remove(T vehicle);
    }
}