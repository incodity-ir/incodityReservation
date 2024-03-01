using incodityReservation.Domain.Entities;

namespace incodityReservation.Domain;
/// <summary>
/// ویلا ها
/// </summary>
public class Villa : BaseEntity
{
    public virtual int CityId {get; set;}
    public virtual required string Name { get; set; }
    public virtual string? Description { get; set; }
    public virtual double Price { get; set; }=0; // initial value
    public virtual byte[]? ImageBytes { get; set; }
    public virtual required  string Address {get; set;}
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime ExpireDate { get; set; }
    
    //navigation properties
    public virtual City City {get; set; }
    public virtual ICollection<ImageLibrary>? ImageLibraries { get; set; }

}
