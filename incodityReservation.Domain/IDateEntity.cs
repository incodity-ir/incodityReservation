namespace incodityReservation.Domain;

public interface IDateEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}
