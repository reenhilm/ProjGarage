namespace ProjGarage.Vehicles
{
    public class LicensePlate : ILicensePlate
    {
        public string Value { get; init; }
        public LicensePlate(string licenseplate) => Value = licenseplate.ToUpper();
        public virtual List<string> InvalidReasons()
        {
            if (!IsValid())
                return new List<string>() { "must contain 6 digits" };
            else
                return new List<string>();
        }
        public bool IsValid() => Value.Length == 6;
    }
}
