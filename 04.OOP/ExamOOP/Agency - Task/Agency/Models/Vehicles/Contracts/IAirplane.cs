namespace Agency.Models.Vehicles.Contracts
{
    public interface IAirplane
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }

        VehicleType Type { get; set; }

        bool HasFreeFood { get; }

    }
}