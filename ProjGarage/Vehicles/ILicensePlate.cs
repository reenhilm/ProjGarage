namespace ProjGarage.Vehicles
{
    public interface ILicensePlate
    {
        string Value { get; init; }

        List<string> InvalidReasons();
        bool IsValid();
    }
}