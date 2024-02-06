namespace incodityReservation.Domain;

public class Province:BaseEntity
{
    public Province()
    {
        cities = new List<City>();
    }
    public required string Name { get; set; }

    //navigation properties
    public ICollection<City>? cities { get; set; }
}
