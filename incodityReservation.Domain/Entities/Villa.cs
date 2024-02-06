namespace incodityReservation.Domain;
/// <summary>
/// ویلا ها
/// </summary>
public class Villa : BaseEntity
{
    public int CityId {get; set;}
    public required string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }=0; // initial value
    public string? Image { get; set; }
    public required  string Address {get; set;}
    
    //navigation properties
    public City City {get; set; }

}
