namespace incodityReservation.Domain;

public class City:BaseEntity
{
    public City()
    {
        Villas = new List<Villa>();
    }
    public required string Name { get; set; }
    public int ProvinceId { get; set; }

    //navigation properties
    public Province Province { get; set; }
    public ICollection<Villa>? Villas {get; set;}
}
